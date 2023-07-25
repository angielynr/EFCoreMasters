using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class PriceOffer
    {
        [Key]
        public int PriceOfferId { get; set; }

        public decimal NewPrice { get; set; }

        [NotMapped]
        public string PromotinalText { get; set; }

        //relationship---
        public int ProductId { get; set; }
    }
}
