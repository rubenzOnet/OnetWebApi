using Onet.Cliente.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onet.Cliente.Repositories.Cliente.Interfaces
{
    public interface IClieteCreateRepository
    {
        Task<ulong> ClientCreateAsync(ClienteEntities clienteEntities);
    }
}
