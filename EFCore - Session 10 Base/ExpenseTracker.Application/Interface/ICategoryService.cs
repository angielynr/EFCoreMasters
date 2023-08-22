using ExpenseTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Interface
{
    public interface ICategoryService
    {
        Category Add(Category category);
        void Delete(Category category);
        List<Category> GetAll();
        Category GetSingle(int id);
    }
}
