using AutoMapper;
using InventoryAppEFCore.API.DTO;
using InventoryAppEFCore.DataLayer.EfClasses;

namespace InventoryAppEFCore.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Client, ClientDto>();
        }

    }
}
