using Onet.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onet.Cliente.Services.Cliente.Interfaces
{
    public interface IClienteGetAllServices
    {
        Task<Response> GetClientAllAsync();
    }
}
