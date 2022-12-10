namespace CatalogApp.Services;

public class DbInit {

    private CatalogDbContext CatalogRepository;

    public DbInit(CatalogDbContext CatalogRepository) {
        this.CatalogRepository = CatalogRepository;
    }

    public void init() {
        Console.WriteLine("Db Initialisation...");
        this.CatalogRepository.Categories.Add(new Models.Category{Name = "Computers"});
        this.CatalogRepository.Categories.Add(new Models.Category{Name = "Printers"});
        this.CatalogRepository.Categories.Add(new Models.Category{Name = "Graphics"});
        this.CatalogRepository.Categories.Add(new Models.Category{Name = "Phones"});
        this.CatalogRepository.SaveChanges();
    }
}