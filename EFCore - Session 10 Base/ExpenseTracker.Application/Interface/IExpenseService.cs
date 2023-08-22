using ExpenseTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Interface
{
    public interface IExpenseService
    {
        List<Expense> GetAll();
        List<Expense> GetAllOrderedByAmount();
        Expense GetSingle(int id);
        Expense Add(Expense expense);
        void Delete(Expense expense);   
    }
}
