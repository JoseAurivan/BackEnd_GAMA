using Core.Entities.Abstract;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SuporteFront;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace API_GAMA.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private ILoginService _loginService;

        public LoginController(IConfiguration config, ILoginService loginService)
        {
            _config = config;
            _loginService = loginService;
        }


        [HttpPost("cidadao")]
        public async Task<IActionResult> LoginCidadao(LoginCidadaoViewModel login)
        {
            try
            {
                var user = await _loginService.AuthenticateCidadao(login.Cpf, login.Password);
                if (user is not null)
                {
                    var token = GenerateTokenCidadao(login);
                    return Ok(token);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("servidor")]
        public async Task<IActionResult> LoginServidor(LoginServidorViewModel login)
        {
            var user = await _loginService.AuthenticateServidor(login.Matricula, login.Password);
            if (user is not null)
            {
                var token = GenerateTokenServidor(login);
                return Ok(token);
            }

            return BadRequest();
        }

        [HttpGet("adm")]
        public IActionResult LoginAdm()
        {
            var token = GenerateTokenADM();
            if (!string.IsNullOrEmpty(token))
                return Ok(token);
            return BadRequest();
        }

        
        [HttpPost("auth")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetNameFromToken(TokenViewModel token)
        {
            var identity = new ClaimsIdentity();

            if (!string.IsNullOrEmpty(token.token))
            {
                var claims = new JwtSecurityTokenHandler().ReadJwtToken(token.token);
                foreach (var claim in claims.Claims)
                {
                    identity.AddClaim(claim);
                }
                var name = identity.Claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault();
                return Ok(name.Value);
            }
            return Unauthorized();
            
        }

        public string GenerateTokenCidadao(LoginCidadaoViewModel user)
        {
            var secret = _config.GetValue<string>("JWT:Secret");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Cpf),
                new Claim(ClaimTypes.Role, "cidadao")
            };
            var issuer = _config.GetValue<string>("JWT:ValidAudience");
            var audience = _config.GetValue<string>("JWT:ValidIssuer");

            var token = new JwtSecurityToken(issuer,
              audience,
              claims,
              expires: DateTime.Now.AddMinutes(45),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public string GenerateTokenServidor(LoginServidorViewModel user)
        {
            var secret = _config.GetValue<string>("JWT:Secret");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Matricula),
                new Claim(ClaimTypes.Role,"servidor")
            };
            var issuer = _config.GetValue<string>("JWT:ValidAudience");
            var audience = _config.GetValue<string>("JWT:ValidIssuer");

            var token = new JwtSecurityToken(issuer,
              audience,
              claims,
              expires: DateTime.Now.AddMinutes(60),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public string GenerateTokenADM()
        {
            var secret = _config.GetValue<string>("JWT:Secret");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,"ADM"),
                new Claim(ClaimTypes.Role,"Administrador")
            };
            var issuer = _config.GetValue<string>("JWT:ValidAudience");
            var audience = _config.GetValue<string>("JWT:ValidIssuer");

            var token = new JwtSecurityToken(issuer,
              audience,
              claims,
              expires: DateTime.Now.AddMinutes(20),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}

