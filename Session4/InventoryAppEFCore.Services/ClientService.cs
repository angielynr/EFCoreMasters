using InventoryAppEFCore.DataLayer;
using InventoryAppEFCore.DataLayer.EfClasses;
using Microsoft.EntityFrameworkCore;

namespace InventoryAppEFCore.Services
{
    public class ClientService : IClientService
    {
        private readonly InventoryAppEfCoreContext _inventoryAppEfCoreContext;

        public ClientService(InventoryAppEfCoreContext inventoryAppEfCoreContext)
        {
            _inventoryAppEfCoreContext = inventoryAppEfCoreContext;
        }

        public async Task<List<Client>> GetAllClients()
        {
            var products = await _inventoryAppEfCoreContext.Clients.ToListAsync();

            return products;
        }
    }

    public interface IClientService
    {
        Task<List<Client>> GetAllClients();
    }
}
