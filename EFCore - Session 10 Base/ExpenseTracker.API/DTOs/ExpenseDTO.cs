using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.API.DTOs
{
    public class ExpenseDTO
    {
        public DateTime DatePurchased { get; set; }
        public string Item { get; set; }
        public decimal ItemAmount { get; set; }
        public int CategoryId { get; set; }
    }
}
