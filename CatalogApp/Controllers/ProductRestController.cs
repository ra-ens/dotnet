using CatalogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogApp.Controllers;

[ApiController]
[Route("/api/products")]
public class ProductRestController : ControllerBase {

    private CatalogDbContext CatalogRepository;

    public ProductRestController(CatalogDbContext catalogRepository) {
        this.CatalogRepository = catalogRepository;
    }

    [HttpGet]
    public IEnumerable<Product> Get() {
        return CatalogRepository.Products.Include(p => p.Category);
    }

    [HttpGet("{Id}")]
    public Product? GetById(int Id) {
        return CatalogRepository.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == Id);
    }

    [HttpGet("search/{keyword}")]
    public IEnumerable<Product> Search(string keyword) {
        return CatalogRepository.Products.Include(p => p.Category).Where(p => p.Name!.Contains(keyword));
    }

    [HttpPost]
    public Product Save([FromBody] Product product) {
        CatalogRepository.Products.Add(product);
        CatalogRepository.SaveChanges();
        return product;
    }

    [HttpPut("{Id}")]
    public Product Update(int Id, [FromBody] Product product) {
        product.Id = Id;
        CatalogRepository.Products.Update(product);
        CatalogRepository.SaveChanges();
        return product;
    }

    [HttpDelete("{Id}")]
    public bool Delete(int Id) {
        Product? product = CatalogRepository.Products.FirstOrDefault(p => p.Id == Id);

        if(product == null)
            return false;

        CatalogRepository.Products.Remove(product);
        CatalogRepository.SaveChanges();
        return true;
    }
}