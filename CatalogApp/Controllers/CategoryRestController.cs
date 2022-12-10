using CatalogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogApp.Controllers;

[ApiController]
[Route("/api/categories")]
public class CategoryRestController : ControllerBase {

    private CatalogDbContext CatalogRepository;

    public CategoryRestController(CatalogDbContext catalogRepository) {
        this.CatalogRepository = catalogRepository;
    }

    [HttpGet]
    public IEnumerable<Category> Get() {
        return CatalogRepository.Categories;
    }

    [HttpGet("{Id}")]
    public Category? GetById(int Id) {
        return CatalogRepository.Categories.FirstOrDefault(c => c.Id == Id);
    }

    [HttpGet("{Id}/products")]
    public IEnumerable<Product>? Products(int Id) {
        Category? category = CatalogRepository.Categories.Include(c => c.Products).FirstOrDefault(c => c.Id == Id);
        return category?.Products;
    }

    [HttpPost]
    public Category Save([FromBody] Category category) {
        CatalogRepository.Categories.Add(category);
        CatalogRepository.SaveChanges();
        return category;
    }

    [HttpPut("{Id}")]
    public Category Update(int Id, [FromBody] Category category) {
        category.Id = Id;
        CatalogRepository.Categories.Update(category);
        CatalogRepository.SaveChanges();
        return category;
    }

    [HttpDelete("{Id}")]
    public bool Delete(int Id) {
        Category? category = CatalogRepository.Categories.FirstOrDefault(c => c.Id == Id);

        if(category == null)
            return false;

        CatalogRepository.Categories.Remove(category);
        CatalogRepository.SaveChanges();
        return true;
    }
}