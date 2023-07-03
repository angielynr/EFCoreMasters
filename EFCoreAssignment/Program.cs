// See https://aka.ms/new-console-template for more information
using EFCoreAssignment;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

var connection = ""; // TODO : Add your connection string here
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

static void Filtering(AppDbContext dbContext)
{
    // TODO : Filter by Product Name    
}

static void SingleOrDefault(AppDbContext dbContext)
{
    // TODO : Select using SingleOrDefault by Product Id    
}

static void LoadingRelatedData_Manual(AppDbContext dbContext)
{
    // TODO : Load Product with related shop data manually
}

static void LoadingRelatedData_ExplicitLoading(AppDbContext dbContext)
{
    // TODO : Load Product with related shop data explicitly
}

static void LoadingRelatedData_EagerLoading(AppDbContext dbContext)
{
    // TODO : Load Product with related Shop data eagerly    
}


Console.WriteLine("EF Core is the best");
