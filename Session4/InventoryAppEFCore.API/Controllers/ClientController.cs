using AutoMapper;
using InventoryAppEFCore.API.DTO;
using InventoryAppEFCore.Services;
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
    }
}
