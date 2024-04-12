using EkomsStore.Application.IServices;
using EkomsStore.Application.Utilities;
using EkomsStore.Domain.Models.Request;
using EkomsStore.Infrastructure.IRepositories;
using EkomsStore.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkomsStore.Application.Services
{
    public class AuthService : IAuthService
    {
        private IAuthRepository authRepo;
        public AuthService(IAuthRepository _authRepo) 
        {
            authRepo = _authRepo;
        }

        public async Task<AuthUserResponse> AuthLogin(LoginRequest login)
        {
            AuthUserResponse result = new AuthUserResponse();

            var user = await authRepo.ValidateUser(login);

            if (user == null) { return result; }

            var userSecurity = await authRepo.GetUserSecurityById(user!.Id);

            if (userSecurity == null) { return result; }

            var passord = PasswordSecurityHelper.CalculateHash($"{login.Password}{login.Username}", userSecurity.password_salt);

            bool passwordValidated = PasswordSecurityHelper.CheckPassword(userSecurity.password,password);

            if (passwordValidated)
            {
                result = new AuthUserResponse()
                {
                    Id = user.Id,
                    Firstname = user.FirstName,
                    Lastname = user.LastName,
                    Username = user.Username,
                    EmailAddress = user.EmailAddress,
                    Role = ":"
                };
            }

            return result;
            
        }
    }
}
