using EkomsStore.Domain.Entities;
using EkomsStore.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkomsStore.Infrastructure.IRepositories
{
    public interface IAuthRepository
    {
        public Task<Users> ValidateUser(LoginRequest login);
        public Task<UserSecurity> GetUserSecurityById(int Id);

    }
}
