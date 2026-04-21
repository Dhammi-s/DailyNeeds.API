using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using ServicePro.Core.Entities;
using ServicePro.Core.Interfaces;
using ServicePro.Core.Interfaces.Databaseinterface;
using System.Data;

namespace ServicePro.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IDbConnectionFactory _dbFactory;

        public AuthRepository(IDbConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }


        public async Task RegisterUserAsync(User user)
        {
            using SqlConnection db = _dbFactory.CreateConnection();
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
            using SqlConnection db = _dbFactory.CreateConnection();
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
