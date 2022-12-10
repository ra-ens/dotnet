using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CatalogApp.Models;

[Table("categories")]
public class Category {
    [Key]
    public int Id {get; set;}
    public string? Name {get; set;}
    [JsonIgnore]
    public virtual ICollection<Product> Products {get; set;} = null!;

    public Category() {}

    public Category(int id, string name) {
        this.Id = id;
        this.Name = name;
    }
}