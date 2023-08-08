using AutoMapper;
using InventoryAppEFCore.API.DTO;
using InventoryAppEFCore.DataLayer.EfClasses;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAppEFCore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IClientService _clientService;

        public ClientController(IMapper mapper, IClientService clientService)
        {
            _mapper = mapper;
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllClients()
        {
            var clients = await _clientService.GetAllClients();
            var clientDto = _mapper.Map<List<ClientDto>>(clients);

            return Ok(clientDto);
        }

        [HttpPost]
        public async Task<ActionResult<ClientDto>> CreateClient([FromBody] AddClientDto addClientDto)
        {

            try
            {
                var newClient = _mapper.Map<Client>(addClientDto);
                var createdClient = await _clientService.AddClient(newClient);
                var createdClientDto = _mapper.Map<ClientDto>(createdClient);
                return Ok(createdClientDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating client.");
            }
        }
    }
}
