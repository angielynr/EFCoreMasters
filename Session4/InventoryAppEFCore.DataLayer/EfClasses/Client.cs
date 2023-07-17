namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

    }
}
