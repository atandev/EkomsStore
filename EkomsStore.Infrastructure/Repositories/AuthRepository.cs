using EkomsStore.Domain.DataAccess;
using EkomsStore.Domain.Entities;
using EkomsStore.Domain.Models.Request;
using EkomsStore.Infrastructure.IRepositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkomsStore.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration configuration;

        public AuthRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public async Task<Users> ValidateUser(LoginRequest login)
        {
            try
            {
                using(EkomsStoreDbContext context = new EkomsStoreDbContext(configuration))
                {
                    var result = context.Users.Where(x => x.Username == login.Username && x.UserType == login.UserType).FirstOrDefault();
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<UserSecurity> GetUserSecurityById(int Id)
        {
            try
            {
                using (EkomsStoreDbContext context = new EkomsStoreDbContext(configuration))
                {
                    var result = context.UserSecurity.Where(x => x.Id == Id).FirstOrDefault();
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
