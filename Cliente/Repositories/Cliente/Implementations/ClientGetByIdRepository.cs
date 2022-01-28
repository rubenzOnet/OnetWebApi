using Dapper;
using Onet.Cliente.Entities;
using Onet.Cliente.Repositories.Cliente.Interfaces;
using Onet.Core;
using System.Linq;
using System.Threading.Tasks;

namespace Onet.Cliente.Repositories.Cliente.Implementations
{
    public class ClientGetByIdRepository: BaseRepository, IClientGetByIdRepository
    {

        public ClientGetByIdRepository(DbSession session) : base(session)
        {
        }

        public async Task<ClienteEntities> GetClientByIdAsync(int Id)
        {
            string SqlQuery = @"SELECT Id,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone 
                                FROM Cliente
                                WHERE Id = @Id";

            return (await _session.Connection.QueryAsync<ClienteEntities>(SqlQuery, new { Id = Id }, _session.Transaction)).FirstOrDefault();

        }

    }
}
