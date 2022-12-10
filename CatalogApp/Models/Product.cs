using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogApp.Models;

[Table("products")]
public class Product {
    [Key]
    public int Id {get; set;}
    public string? Name {get; set;}
    public double Price {get; set;}
    public int CategoryId {get; set;}
    [ForeignKey("CategoryId")]
    public virtual Category Category {get; set;} = null!;

    public Product() {}

    public Product(int id, string name, double price, int CategoryId) {
        this.Id = id;
        this.Name = name;
        this.Price = price;
        this.CategoryId = CategoryId;
    }
}