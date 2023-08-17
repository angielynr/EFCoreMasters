using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Tests
{
    public static class CategoryTrackerTestData
    {

        public static IEnumerable<Category> CategoryData()
        {
            return new List<Category>
            {
                new Category {
                        Name = "Category1",
                        Description ="Category1"

                },
                new Category {
                        Name = "Category2",
                        Description ="Category2"

                },
            };
        }
    }
}
