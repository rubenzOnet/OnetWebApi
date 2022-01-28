using AutoMapper;
using Onet.Cliente.Entities;
using Onet.Cliente.Repositories.Cliente.Interfaces;
using Onet.Cliente.Requests;
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
    public class ClieteCreateServices: ServiceExceptionLogger, IClieteCreateServices
    {

        private readonly IClieteCreateRepository _clieteCreateRepository;
        private readonly IClientGetByIdService _clientGetByIdService;
        private readonly IMapper _mapper;

        public ClieteCreateServices(IClieteCreateRepository clieteCreateRepository,
                                    IClientGetByIdService clientGetByIdService,
                                    IMapper mapper)
        {
            _clieteCreateRepository = clieteCreateRepository;
            _clientGetByIdService = clientGetByIdService;
            _mapper = mapper;
        }

        public async Task<Response> ClientCreateAsync(ClienteRequest clienteRequest )
        {
            try
            {
                ClienteEntities resultCliente = MapCliente(clienteRequest);

                ulong result = await _clieteCreateRepository.ClientCreateAsync(resultCliente);

                var resultData = await _clientGetByIdService.GetClientByIdAsync((int)result);
                
                if(!resultData.IsValid)
                    return string.Empty.ToResponse(false, HttpStatusCode.BadRequest, Messages.Client.NotExists);


                return resultData.ToResponse(true, HttpStatusCode.OK, Messages.Client.Create);
            }
            catch (Exception ex)
            {
                LogException(ex, Messages.Client.EX);
                throw new Exception(Messages.Client.EX);

            }
        }


        private ClienteEntities MapCliente(ClienteRequest clienteRequest)
        {
            ClienteEntities result = _mapper.Map<ClienteEntities>(clienteRequest);

            return result;
        }
    }
}
