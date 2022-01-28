using Dapper;
using Onet.Cliente.Entities;
using Onet.Cliente.Repositories.Cliente.Interfaces;
using Onet.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Onet.Cliente.Repositories.Cliente.Implementations
{
    public class ClienteGetAllRepository: BaseRepository, IClienteGetAllRepository
    {
        public ClienteGetAllRepository(DbSession session) : base(session)
        {
        }

        public async Task<IEnumerable<ClienteEntities>> GetAllClientsAsync()
        {
            string SqlQuery = @"SELECT Id,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone FROM Cliente";

            return (await _session.Connection.QueryAsync<ClienteEntities>(SqlQuery, null, _session.Transaction)).ToList();

        }

    }
}
