using EkomsStore.Application.IServices;
using EkomsStore.Application.Services;
using EkomsStore.Domain.Models.Request;
using EkomsStore.Domain.Models.Response;
using EkomsStore.Infrastructure.IRepositories;
using EkomsStore.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace EkomsStore.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<AuthController> logger;
        private IAuthService authService;
        private JwtService jwtService;
        public AuthController(IConfiguration _configuration,ILogger<AuthController> _ilogger, JwtService _jwtService)
        {
            configuration = _configuration;
            logger = _ilogger;
            jwtService = _jwtService;
        }

        private void InitDependency()
        {
            var repo = new AuthRepository(configuration);
            authService = new AuthService(repo);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login([FromBody] LoginRequest login)
        {
            try
            {
                InitDependency();

                var user = await authService.AuthLogin(login);
                if (user == null)
                    return Unauthorized(new AuthLoginResponse { ErrorMessage = "Invalid Username or Password" });

                var signingCredentials = jwtService.GetSigningCredentials();
                var claims = jwtService.GetClaims(user);
                var tokenOptions = jwtService.GenerateTokenOptions(signingCredentials, claims);
                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new AuthLoginResponse { isAuthSuccessful = true , Token = token});

            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database." + ex.Message);
            }
        }
    }
}
