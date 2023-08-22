using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Infrastructure.Services;
using ExpenseTracker.Tests.Fixture;
using FluentAssertions;

namespace ExpenseTracker.Tests.Tests
{
    public class CategoryServiceTest : IClassFixture<CategoryFixture>
    {
        private readonly CategoryFixture _categoryFixture;

        public CategoryServiceTest(CategoryFixture categoryFixture)
        {
            _categoryFixture = categoryFixture;
        }

        [Fact]
        public void GetAllCategories_ShouldReturnAllCategories()
        {
            // Arrange
            var dbContextOptions = _categoryFixture.CreateContext();

            var categoryService = new CategoryService(dbContextOptions);

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
            var dbContextOptions = _categoryFixture.CreateContext();

            var categoryService = new CategoryService(dbContextOptions);

            int categoryIdToFetch = 1;

            var expectedResult = dbContextOptions.Categories.FirstOrDefault(a => a.CategoryId == categoryIdToFetch);

            // Act
            var category = categoryService.GetSingle(categoryIdToFetch);

            // Assert
            category.Should().Be(expectedResult);
        }

        [Fact]
        public void AddCategory_ShouldSuccessfullyAddCategory()
        {
            // Arrange
            var dbContextOptions = _categoryFixture.CreateContext();

            var categoryService = new CategoryService(dbContextOptions);

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
            var dbContextOptions = _categoryFixture.CreateContext();

            var categoryService = new CategoryService(dbContextOptions);

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
