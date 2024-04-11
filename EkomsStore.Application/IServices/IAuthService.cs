using EkomsStore.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkomsStore.Application.IServices
{
    public interface IAuthService
    {
        public Task<AuthUserResponse> AuthLogin(LoginRequest user);
    }
}
