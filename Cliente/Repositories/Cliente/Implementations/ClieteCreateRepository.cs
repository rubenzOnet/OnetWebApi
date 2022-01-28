using Dapper;
using Onet.Cliente.Entities;
using Onet.Cliente.Repositories.Cliente.Interfaces;
using Onet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onet.Cliente.Repositories.Cliente.Implementations
{
    public class ClieteCreateRepository: BaseRepository, IClieteCreateRepository
    {
        public ClieteCreateRepository(DbSession session) : base(session)
        {
        }

        public async Task<ulong> ClientCreateAsync(ClienteEntities clienteEntities)
        {
            string SqlQuery = @"INSERT INTO [dbo].[Cliente]
                               ([CompanyName]
                               ,[ContactName]
                               ,[ContactTitle]
                               ,[Address]
                               ,[City]
                               ,[Region]
                               ,[PostalCode]
                               ,[Country]
                               ,[Phone])
                         VALUES
                               (@CompanyName
                               ,@ContactName
                               ,@ContactTitle
                               ,@Address
                               ,@City
                               ,@Region
                               ,@PostalCode
                               ,@Country
                               ,@Phone);

                         SELECT SCOPE_IDENTITY();";

            var result = await _session.Connection.ExecuteScalarAsync<ulong>(SqlQuery, clienteEntities, _session.Transaction);

            return result;

        }

    }
}
