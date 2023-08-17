using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Infrastructure.Services;
using ExpenseTracker.Tests.Fixture;
using FluentAssertions;

namespace ExpenseTracker.Tests.Tests
{
    public class ExpenseServiceTest : IClassFixture<ExpenseFixture>
    {
        private readonly ExpenseFixture _expense;

        public ExpenseServiceTest(ExpenseFixture expense)
        {
            _expense = expense;
        }

        [Fact]
        public void GetAllExpenses_ShouldReturnAllExpenses()
        {
            //Arrange
            var dbContextOptions = _expense.CreateContext();

            var expenseService = new ExpenseService(dbContextOptions);

            //Act
            var expenses = expenseService.GetAll();

            //Assert
            expenses.Should().NotBeNull();
            expenses.Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public void GetAllOrderedByAmount_ExpensesShouldBeInAscendingOrder()
        {
            var dbContextOptions = _expense.CreateContext();

            var expenseService = new ExpenseService(dbContextOptions);

            // Act
            var expenses = expenseService.GetAllOrderedByAmount();

            // Assert
            expenses.Should().BeInAscendingOrder(e => e.ItemAmount);
        }

        [Fact]
        public void GetSingleExpense_ShouldReturnRequested()
        {
            // Arrange
            var dbContextOptions = _expense.CreateContext();

            var expenseService = new ExpenseService(dbContextOptions);

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
            var dbContextOptions = _expense.CreateContext();

            var expenseService = new ExpenseService(dbContextOptions);

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
            var dbContextOptions = _expense.CreateContext();

            var expenseService = new ExpenseService(dbContextOptions);

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
