using ExpenseTracker.Data;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Infrastructure.Services;
using ExpenseTracker.Tests.Helper;
using FluentAssertions;

namespace ExpenseTracker.Tests.Tests
{
    public class CategoryServiceTest
    {
        //TODO
        //Fill in the steps for every test
        //1. Create a unique dbcontextoption 
        //2. Setup a new database with fresh data for every test
        //3. Test respective method in the CategoryService.cs 
        //4. Do atleast 1 assertion using fluent assertions

        //GOAL: This test should run in parallel with ExpenseServiceTest

        private readonly string _className;
        public CategoryServiceTest()
        {
            _className = GetType().Name;
        }

        [Fact]
        public void GetAllCategories_ShouldReturnAllCategories()
        {
            // Arrange
            var dbContextOptions = DBContextOptionsGenerator.CreateUniqueClassOptions<ExpenseTrackerDBContext>(_className);
            using var context = new ExpenseTrackerDBContext(dbContextOptions);
            context.InitializeDBWithData();

            var categoryService = new CategoryService(context);

            // Act
            var categories = categoryService.GetAll();

            // Assert
            categories.Should().NotBeNull();
            categories.Should().NotBeEmpty();
        }


        [Fact]
        public void GetSingleCategory_ShouldReturnRequested()
        {
            // Arrange
            var dbContextOptions = DBContextOptionsGenerator.CreateUniqueClassOptions<ExpenseTrackerDBContext>(_className);
            using var context = new ExpenseTrackerDBContext(dbContextOptions);
            context.InitializeDBWithData();

            var categoryService = new CategoryService(context);

            var categoryIdToFetch = 1; // Replace with the actual CategoryId of an existing category

            // Act
            var category = categoryService.GetSingle(categoryIdToFetch);

            // Assert
            category.Should().NotBeNull();
            category.CategoryId.Should().Be(categoryIdToFetch);
        }

        [Fact]
        public void AddCategory_ShouldSuccessfullyAddCategory()
        {
            // Arrange
            var dbContextOptions = DBContextOptionsGenerator.CreateUniqueClassOptions<ExpenseTrackerDBContext>(_className);
            using var context = new ExpenseTrackerDBContext(dbContextOptions);
            context.InitializeDBWithData();

            var categoryService = new CategoryService(context);

            var newCategory = new Category
            {
                Name = "Category2",
                Description = "Category2"
            };

            // Act
            categoryService.Add(newCategory);
            var addedCategory = categoryService.GetSingle(newCategory.CategoryId);

            // Assert
            addedCategory.Should().NotBeNull();
            addedCategory.Name.Should().Be(newCategory.Name);
        }

        [Fact]
        public void DeleteCategory_ShouldSuccessfullyDeleteCategory()
        {
            // Arrange
            var dbContextOptions = DBContextOptionsGenerator.CreateUniqueClassOptions<ExpenseTrackerDBContext>(_className);
            using var context = new ExpenseTrackerDBContext(dbContextOptions);
            context.InitializeDBWithData();

            var categoryService = new CategoryService(context);

            var categoryIdToDelete = 1;

            // Act
            var categoryToDelete = categoryService.GetSingle(categoryIdToDelete);
            categoryService.Delete(categoryToDelete);
            var deletedCategory = categoryService.GetSingle(categoryIdToDelete);

            // Assert
            deletedCategory.Should().BeNull();
        }
    }
}
