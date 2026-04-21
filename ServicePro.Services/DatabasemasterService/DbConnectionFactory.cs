using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using ServicePro.Core.Interfaces.Databaseinterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Services.DatabasemasterService
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IHttpContextAccessor _http;

        public DbConnectionFactory(IHttpContextAccessor http)
        {
            _http = http;
        }

        public SqlConnection CreateConnection()
        {
            var connStr = _http.HttpContext?.Items["Conn"]?.ToString();

            if (string.IsNullOrEmpty(connStr))
                throw new Exception(" Connection not found from TenantMiddleware");

            return new SqlConnection(connStr);
        }
    }
}