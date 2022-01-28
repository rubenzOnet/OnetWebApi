using Microsoft.AspNetCore.Mvc;
using Onet.Cliente.Services.Cliente.Interfaces;
using Onet.Core;
using Onet.Core.Response;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Onet.Api.Controllers.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientGetAllController : ControllerBase
    {
        private readonly IClienteGetAllServices _clienteGetAllServices;

        public ClientGetAllController(IClienteGetAllServices clienteGetAllServices)
        {
            _clienteGetAllServices = clienteGetAllServices;
        }

        [HttpGet]
        public async Task<ActionResult<IResponse>> Create([FromServices] IUnitOfWork unitOfWork)
        {
            try
            {
                unitOfWork.BeginTransaction();
                Response response = await _clienteGetAllServices.GetClientAllAsync();
                unitOfWork.Commit();

                if (response.Type != HttpStatusCode.OK)

                {
                    return StatusCode((int)response.Type, response);
                }
                else
                {
                    return Ok(response);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToResponseException("Operation couldn't complete."));
            }
        }

        
    }
}
