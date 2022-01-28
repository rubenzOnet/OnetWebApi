using Onet.Cliente.Requests;
using Onet.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onet.Cliente.Services.Cliente.Interfaces
{
    public interface IClieteCreateServices
    {
        Task<Response> ClientCreateAsync(ClienteRequest clienteRequest);
    }
}
