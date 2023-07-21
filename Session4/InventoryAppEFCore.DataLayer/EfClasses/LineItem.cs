using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class LineItem
    {
        [Key]
        public int LineItemId { get; set; }
        public short NumOfProducts { get; set; }
        public decimal ProductPrice { get; set; }

        //relationships
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public Order Order { get; set; } // 1:Many relationship with Order
        public int ProductId { get; set; }
        public Product SelectedProduct { get; set; }
    }
}
