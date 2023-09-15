using Core.Entities.Abstract;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SuporteFront;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_GAMA.Controllers
{

    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private ILoginService _loginService;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }


        [HttpPost("cidadao")]
        public async Task<IActionResult> LoginCidadao(LoginCidadaoViewModel login)
        {
            var user = await _loginService.AuthenticateCidadao(login.Cpf, login.Password);
            if(user is not null)
            {
                var token = GenerateTokenCidadao(login);
                return Ok(token);
            }
            
            return BadRequest();
        }

        [HttpPost("servidor")]
        public async Task<IActionResult> LoginServidor(LoginServidorViewModel login)
        {
            var user = await _loginService.AuthenticateServidor(login.Matricula, login.Password);
            if(user is not null)
            {
                var token = GenerateTokenServidor(login);
                return Ok(token);
            }
            
            return BadRequest();
        }

        public string GenerateTokenCidadao(LoginCidadaoViewModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Cpf),
                new Claim(ClaimTypes.Role, "cidadao")
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public string GenerateTokenServidor(LoginServidorViewModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Matricula),
                new Claim(ClaimTypes.Role,"servidor")
            };

            var token = new JwtSecurityToken(_config["JWT:Issuer"],
              _config["JWT:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(60),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}

