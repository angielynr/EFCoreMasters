using ExpenseTracker.API.DTOs;
using ExpenseTracker.Domain.Entities;
using System.Runtime.CompilerServices;

namespace ExpenseTracker.API.Extensions
{
    public static class DTOConverters
    {
        public static Category DTOToCategory(this CategoryDTO category)
        {
            return new Category
            {
                Name = category.Name,
                Description = category.Description
            };
        }

        public static Expense DTOToExpense(this ExpenseDTO expense)
        {
            return new Expense
            {
                CategoryId = expense.CategoryId,
                Item = expense.Item,
                DatePurchased = expense.DatePurchased,
                ItemAmount = expense.ItemAmount
            };
        }
    }
}
