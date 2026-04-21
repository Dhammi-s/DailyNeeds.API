using Microsoft.AspNetCore.Http;
using ServicePro.Core.Interfaces.Databaseinterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Services.CommonService.Databasemiddleware
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ITenantService tenantService)
        {
            var host = context.Request.Host.Host;

            var agency = await tenantService.GetAgencyAsync(host);

            if (agency == null)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid domain");
                return;
            }

            string conn;

            if (!string.IsNullOrEmpty(agency.ConnectionString))
            {
                conn = agency.ConnectionString;
            }
            else
            {
                conn = $"Server={agency.DbServer};Database={agency.DbName};User Id={agency.DbUser};Password={agency.DbPassword};TrustServerCertificate=True;";
            }

            context.Items["Conn"] = conn;
            context.Items["AID"] = agency.AgencyId;

            await _next(context);
        }
    }
}
