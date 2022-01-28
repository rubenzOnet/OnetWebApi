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
    public class ClienteGetAllServices: ServiceExceptionLogger, IClienteGetAllServices
    {
        private readonly IClienteGetAllRepository _clienteGetAllRepository;

        public ClienteGetAllServices(IClienteGetAllRepository clienteGetAllRepository)
        {
            _clienteGetAllRepository = clienteGetAllRepository;
        }

        public async Task<Response> GetClientAllAsync()
        {
            try
            {
                IEnumerable<ClienteEntities> clientResult = await _clienteGetAllRepository.GetAllClientsAsync();

                return clientResult.ToResponse(true, HttpStatusCode.OK, Messages.Client.OK);
            }
            catch (Exception ex)
            {
                LogException(ex, Messages.Client.EX);
                throw new Exception(Messages.Client.EX);

            }
        }
    }
}
