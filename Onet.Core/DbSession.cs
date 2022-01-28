using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;


namespace Onet.Core
{
    public class DbSession : IDisposable
    {


        private Guid _id;
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        private IConfiguration _configuration;
        public DbSession(IConfiguration configuration)
        {
            _id = Guid.NewGuid();
            _configuration = configuration;
            var conString = _configuration.GetSection("ConnectionStrings:myConString").Value;
            Connection = new SqlConnection(conString);
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();


    }
}
