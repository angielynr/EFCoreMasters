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
    public class CategoryService : ICategoryService
    {
        private readonly ExpenseTrackerDBContext _context;

        public CategoryService(ExpenseTrackerDBContext context)
        {
            _context = context;
        }
        public Category Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetSingle(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.CategoryId == id);
        }

    }
}
