using AutoMapper;
using Onet.Cliente.DTO;
using Onet.Cliente.Entities;
using Onet.Cliente.Requests;

namespace Cliente
{
    public class MappingProfileConfig : Profile
    {
        public MappingProfileConfig()
        {
            CreateMap<ClienteEntities, ClientDto>();
            CreateMap<ClienteRequest, ClienteEntities>();
        }
    }
}
