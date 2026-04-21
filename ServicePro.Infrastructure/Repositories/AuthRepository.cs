using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using ServicePro.Core.Entities;
using ServicePro.Core.Interfaces;
using System.Data;

namespace ServicePro.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IHttpContextAccessor _http;

        public AuthRepository(IHttpContextAccessor http)
        {
            _http = http;
        }

        private SqlConnection GetConnection()
        {
            var connStr = _http.HttpContext?.Items["Conn"]?.ToString();

            if (string.IsNullOrEmpty(connStr))
                throw new Exception("❌ Connection not found from TenantMiddleware");

            return new SqlConnection(connStr);
        }

        public async Task RegisterUserAsync(User user)
        {
            using SqlConnection db = GetConnection();

            using SqlCommand cmd = new SqlCommand("sp_RegisterUser", db);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
            cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
            cmd.Parameters.AddWithValue("@Role", user.Role);

            await db.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            using SqlConnection db = GetConnection();

            using SqlCommand cmd = new SqlCommand("sp_LoginUser", db);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", email);

            await db.OpenAsync();

            using var reader = await cmd.ExecuteReaderAsync();

            if (!reader.Read()) return null;

            return new User
            {
                Id = Guid.Parse(reader["Id"].ToString()),
                Name = reader["Name"].ToString(),
                Email = reader["Email"].ToString(),
                PasswordHash = reader["PasswordHash"].ToString(),
                Role = reader["Role"].ToString(),
                PhoneNumber = reader["PhoneNumber"].ToString()
            };
        }


    }
}
