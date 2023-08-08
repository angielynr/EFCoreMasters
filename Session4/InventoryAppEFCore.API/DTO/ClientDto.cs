namespace InventoryAppEFCore.API.DTO
{
    public class ClientDto
    {
        public int ClientId { get; set; }

        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedOn { get; private set; }

        public string NameAndCreatedOn { get; private set; }

        public int ComputedBirthYear { get; set; }

    }
}
