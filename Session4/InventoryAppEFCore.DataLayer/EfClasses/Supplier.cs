using System.ComponentModel.DataAnnotations;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public ExcludeClass ExcludedClass { get; set; }

        //Relationships
        public ICollection<Product> ProductsLink { get; set; }
    }
}
