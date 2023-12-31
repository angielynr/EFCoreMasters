﻿using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Tests
{
    public static class ExpenseTrackerTestData
    {

        public static IEnumerable<Expense> ExpenseData()
        {
            return new List<Expense>
            {
                new Expense {
                    Item = "Item1",
                    DatePurchased = DateTime.Now,
                    ItemAmount = 100,
                    Category = new Category
                    {
                        Name = "Category1",
                        Description ="Category1"
                    }
                },
                new Expense
                {
                    Item = "Item1",
                    DatePurchased = DateTime.Now,
                    ItemAmount = 100,
                    Category = new Category
                    {
                        Name = "Category2",
                        Description = "Category2"
                    }
                }
            };
        }
    }
}
