using Microsoft.AspNetCore.Mvc;
using Onet.Cliente.Requests;
using Onet.Cliente.Services.Cliente.Interfaces;
using Onet.Core;
using Onet.Core.Response;
using System;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Onet.Api.Controllers.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientCreateController : ControllerBase
    {

        private readonly IClieteCreateServices _clieteCreateServices;

        public ClientCreateController(IClieteCreateServices clieteCreateServices)
        {
            _clieteCreateServices = clieteCreateServices;
        }

        [HttpPost]
        public async Task<ActionResult<IResponse>> Create([FromServices] IUnitOfWork unitOfWork, ClienteRequest clienteRequest)
        {
            try
            {
                unitOfWork.BeginTransaction();
                Response response = await _clieteCreateServices.ClientCreateAsync(clienteRequest);
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
