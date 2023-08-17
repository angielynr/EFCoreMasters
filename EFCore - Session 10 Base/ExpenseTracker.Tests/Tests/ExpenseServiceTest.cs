using ExpenseTracker.Data;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Infrastructure.Services;
using ExpenseTracker.Tests.Helper;
using FluentAssertions;

namespace ExpenseTracker.Tests.Tests
{
    public class ExpenseServiceTest
    {

        private readonly string _className;
        public ExpenseServiceTest()
        {
            _className = GetType().Name;
        }

        [Fact]
        public void GetAllExpenses_ShouldReturnAllExpenses()
        {
            //Arrange
            var dbContextOptions = DBContextOptionsGenerator.CreateUniqueClassOptions<ExpenseTrackerDBContext>(_className);
            using var context = new ExpenseTrackerDBContext(dbContextOptions);
            context.InitializeDBWithData();

            var expenseService = new ExpenseService(context);

            //Act
            var expenses = expenseService.GetAll();

            //Assert
            expenses.Should().NotBeNull();
            expenses.Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public void GetAllOrderedByAmount_ExpensesShouldBeInAscendingOrder()
        {
            var dbContextOptions = DBContextOptionsGenerator.CreateUniqueClassOptions<ExpenseTrackerDBContext>(_className);
            using var context = new ExpenseTrackerDBContext(dbContextOptions);
            context.InitializeDBWithData();

            var expenseService = new ExpenseService(context);

            // Act
            var expenses = expenseService.GetAllOrderedByAmount();

            // Assert
            expenses.Should().BeInAscendingOrder(e => e.ItemAmount);
        }

        [Fact]
        public void GetSingleExpense_ShouldReturnRequested()
        {
            // Arrange
            var dbContextOptions = DBContextOptionsGenerator.CreateUniqueClassOptions<ExpenseTrackerDBContext>(_className);
            using var context = new ExpenseTrackerDBContext(dbContextOptions);
            context.InitializeDBWithData();

            var expenseService = new ExpenseService(context);

            // Act
            var expenseId = 1;
            var expense = expenseService.GetSingle(expenseId);

            // Assert
            expense.Should().NotBeNull();
            expense.ExpenseId.Should().Be(expenseId);
        }

        [Fact]
        public void AddExpense_ShouldSuccessfullyAddExpense()
        {
            // Arrange
            var dbContextOptions = DBContextOptionsGenerator.CreateUniqueClassOptions<ExpenseTrackerDBContext>(_className);
            using var context = new ExpenseTrackerDBContext(dbContextOptions);
            context.InitializeDBWithData();

            var expenseService = new ExpenseService(context);

            var newExpense = new Expense
            {
                Item = "Item3",
                DatePurchased = DateTime.Now,
                ItemAmount = 100,
                Category = new Category
                {
                    Name = "Category3",
                    Description = "Category3"
                }
            };

            // Act
            expenseService.Add(newExpense);
            var addedExpense = expenseService.GetSingle(newExpense.ExpenseId);

            // Assert
            addedExpense.Should().NotBeNull();
            addedExpense.ExpenseId.Should().Be(newExpense.ExpenseId);
        }

        [Fact]
        public void DeleteExpense_ShouldSuccessfullyDeleteExpense()
        {
            // Arrange
            var dbContextOptions = DBContextOptionsGenerator.CreateUniqueClassOptions<ExpenseTrackerDBContext>(_className);
            using var context = new ExpenseTrackerDBContext(dbContextOptions);
            context.InitializeDBWithData();

            var expenseService = new ExpenseService(context);

            var expenseToDelete = new Expense
            {
                ExpenseId = 2,
            };


            // Act
            expenseService.Delete(expenseToDelete);
            var deletedExpense = expenseService.GetSingle(expenseToDelete.ExpenseId);

            // Assert
            deletedExpense.Should().BeNull();
        }
    }
}
