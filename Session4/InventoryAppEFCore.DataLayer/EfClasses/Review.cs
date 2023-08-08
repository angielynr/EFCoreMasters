using System.ComponentModel.DataAnnotations;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class Review
    {
        private int _productId;

        [Key]
        public int ReviewId { get; set; }
        public string VoterName { get; set; }

        public string Comment { get; set; }
        public int NumStars { get; set; }

        public int ClientId { get; set; }


        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }
    }
}