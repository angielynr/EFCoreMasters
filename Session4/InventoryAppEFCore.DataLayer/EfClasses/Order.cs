using System.ComponentModel.DataAnnotations;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public DateTime DateOrderedUtc { get; set; }

        //relationships
        public ICollection<LineItem> LineItems { get; set; }

        public OrderStatus Status { get; set; }

        public int ClientId { get; set; }
    }
}
