using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Domain.Entities
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public DateTime DatePurchased{ get; set; }
        public string Item { get; set; }
        public decimal ItemAmount { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get;set; }
    }
}
