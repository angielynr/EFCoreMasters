using ExpenseTracker.Application.Interface;
using ExpenseTracker.Data;
using ExpenseTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Infrastructure.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly ExpenseTrackerDBContext _context;

        public ExpenseService(ExpenseTrackerDBContext context)
        {
            _context = context;
        }
        public Expense Add(Expense expense)
        {
            _context.Expenses.Add(expense);
            _context.SaveChanges();

            return expense;
        }

        public void Delete(Expense expense)
        {
            _context.Expenses.Remove(expense);
            _context.SaveChanges();
        }

        public List<Expense> GetAll()
        {
            return _context.Expenses.ToList();
        }

        public List<Expense> GetAllOrderedByAmount()
        {
            return _context.Expenses.OrderBy(x => x.ItemAmount).ToList();
        }

        public Expense GetSingle(int id)
        {
            return _context.Expenses.FirstOrDefault(x => x.ExpenseId == id);
        }
    }
}
