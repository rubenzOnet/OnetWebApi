using AutoMapper;
using Onet.Cliente.DTO;
using Onet.Cliente.Entities;
using Onet.Cliente.Repositories.Cliente.Interfaces;
using Onet.Cliente.Services.Cliente.Constants;
using Onet.Cliente.Services.Cliente.Interfaces;
using Onet.Core;
using Onet.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Onet.Cliente.Services.Cliente.Implementations
{
    public class ClientGetByIdService: ServiceExceptionLogger, IClientGetByIdService
    {
        private readonly IClientGetByIdRepository _clientGetByIdRepository;
        private readonly IMapper _mapper;


        public ClientGetByIdService(IClientGetByIdRepository clientGetByIdRepository,
                                    IMapper mapper)
        {
            _clientGetByIdRepository = clientGetByIdRepository;
            _mapper = mapper;
        }

        public async Task<Response> GetClientByIdAsync(int Id)
        {
            try
            {
                ClienteEntities clientResult = await _clientGetByIdRepository.GetClientByIdAsync(Id);

                if(clientResult == null)
                    return string.Empty.ToResponse(false, HttpStatusCode.OK, Messages.Client.NotExists);


                var result = _mapper.Map<ClientDto>(clientResult);

                return result.ToResponse(true, HttpStatusCode.OK, Messages.Client.OK);
            }
            catch (Exception ex)
            {
                LogException(ex, Messages.Client.EX);
                throw new Exception(Messages.Client.EX);

            }
        }
    }
}
