// See https://aka.ms/new-console-template for more information
using EFCoreAssignment;
using EFCoreAssignment.Entities;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

var connection = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=EFCoreMasters;Integrated Security=True";
var optionsBuilder =
    new DbContextOptionsBuilder
           <AppDbContext>();
optionsBuilder.UseSqlServer(connection);

var options = optionsBuilder.Options;

var dbContext = new AppDbContext(options);

Filtering(dbContext);
SingleOrDefault(dbContext);
LoadingRelatedData_Manual(dbContext);
LoadingRelatedData_ExplicitLoading(dbContext);
LoadingRelatedData_EagerLoading(dbContext);

InsertProduct(dbContext);
InsertProductWithNewShop(dbContext);
UpdateProduct(dbContext);
DeleteProduct(dbContext);
DeleteProductByKey(dbContext);

static void InsertProduct(AppDbContext dbContext)
{
    var product = new Product
    {
        Name = "McFlurry Oreo",
        ShopId = 3
    };

    dbContext.Products.Add(product);
    dbContext.SaveChanges();
}

static void InsertProductWithNewShop(AppDbContext dbContext)
{
    var shop = new Shop
    {
        Name = "Coco"
    };

    var product = new Product
    {
        Name = "Ice Water",
        Shop = shop
    };

    dbContext.Shops.Add(shop);
    dbContext.Products.Add(product);
    dbContext.SaveChanges();
}

static void UpdateProduct(AppDbContext dbContext)
{
    var productId = 3;

    var product = dbContext.Products.SingleOrDefault(p => p.Id == productId);
    if (product != null)
    {
        product.Name = "Dog Food";
        product.ShopId = 3;
    }

    dbContext.SaveChanges();
}

static void DeleteProduct(AppDbContext dbContext)
{
    var product = new Product
    {
        Id = 8,
        Name = "Lechon",
        ShopId = 2
    };

    dbContext.Products.Remove(product);
    dbContext.SaveChanges();
}

static void DeleteProductByKey(AppDbContext dbContext)
{
    var productId = 14;

    var product = dbContext.Products.SingleOrDefault(x => x.Id == productId);
    if (product != null)
    {
        dbContext.Products.Remove(product);
        dbContext.SaveChanges();
    }
}

static void Filtering(AppDbContext dbContext)
{
    var products = dbContext.Products
        .Where(a => a.Name == "Chicken")
        .ToList();

    foreach (var product in products)
    {
        Console.WriteLine($"Product: {product.Name}");
    }
}

static void SingleOrDefault(AppDbContext dbContext)
{
    var product = dbContext.Products
        .SingleOrDefault(p => p.Id == 1);

    if (product != null)
    {
        Console.WriteLine($"Product: {product.Name}");
    }
}

static void LoadingRelatedData_Manual(AppDbContext dbContext)
{
    var product = dbContext.Products.FirstOrDefault();

    if (product != null)
    {
        product.Shop = dbContext.Shops
            .Single(s => s.Id == product.ShopId);

        Console.WriteLine($"Product: {product.Name}, Shop: {product.Shop.Name}");
    }
}

static void LoadingRelatedData_ExplicitLoading(AppDbContext dbContext)
{
    var product = dbContext.Products.FirstOrDefault();

    if (product != null)
    {
        dbContext.Entry(product)
            .Reference(p => p.Shop)
            .Load();

        dbContext.Entry(product)
            .Collection(p => p.Reviews)
            .Load();

        foreach (var review in product.Reviews)
        {
            Console.WriteLine($"Product: {product.Name}, Shop: {product.Shop.Name}");
            Console.WriteLine($"Review: {review.Comment}");
        }
    }
}

static void LoadingRelatedData_EagerLoading(AppDbContext dbContext)
{
    var product = dbContext.Products.Include(p => p.Shop)
                    .Include(p => p.Reviews)
                    .FirstOrDefault();

    if (product != null)
    {
        foreach (var review in product.Reviews)
        {
            Console.WriteLine($"Product: {product.Name}, Shop: {product.Shop.Name}");
            Console.WriteLine($"Review: {review.Comment}");
        }
    }
}

Console.WriteLine("EF Core is the best");
