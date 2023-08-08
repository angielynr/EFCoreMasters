using InventoryAppEFCore.DataLayer;
using InventoryAppEFCore.DataLayer.EfClasses;
using Microsoft.EntityFrameworkCore;

namespace InventoryAppEFCore.Services
{
    public class ClientService : IClientService
    {
        private readonly InventoryAppEfCoreContext _inventoryAppEfCoreContext;
        /*        public const string UdfAverageVotes = nameof(UdfMethods.AverageVotes);
        */
        public ClientService(InventoryAppEfCoreContext inventoryAppEfCoreContext)
        {
            _inventoryAppEfCoreContext = inventoryAppEfCoreContext;
        }

        public async Task<List<Client>> GetAllClients()
        {
            var clients = await _inventoryAppEfCoreContext.Clients.ToListAsync();

            return clients;
        }

        public async Task<Client> AddClient(Client client)
        {
            var newClient = _inventoryAppEfCoreContext.Clients.Add(client);
            await _inventoryAppEfCoreContext.SaveChangesAsync();
            return client;
        }
    }
}

public interface IClientService
{
    Task<List<Client>> GetAllClients();
    Task<Client> AddClient(Client client);
}

