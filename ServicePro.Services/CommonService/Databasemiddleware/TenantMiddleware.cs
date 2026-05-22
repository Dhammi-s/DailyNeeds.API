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
                context.Response.ContentType = "text/html";

                await context.Response.WriteAsync("<!DOCTYPE html><html><head><title>Invalid Domain</title><style>body{margin:0;padding:0;background:#f2f2f2;font-family:Arial}.box{width:400px;margin:100px auto;background:#fff;border:1px solid #ccc;padding:30px;text-align:center}h1{color:#c00}p{color:#555}a{color:#0066cc;text-decoration:none}</style></head><body><div class='box'><h1>Invalid Domain</h1><p>You do not have access to this domain.</p><p>Contact support: <a href='mailto:jassadhammi@gmail.com'>jassadhammi@gmail.com</a></p></div></body></html>");

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
