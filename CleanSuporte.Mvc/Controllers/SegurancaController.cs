
using CleanSuporte.Infra.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanSuporte.Mvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegurancaController : ControllerBase
    {
        private IConfiguration _config;
        public SegurancaController(IConfiguration Configuration)
        {
            _config = Configuration;
        }

        
        [HttpPost]
        public IActionResult Login(
            [FromBody] Usuario loginDetalhes, [FromServices] UserManager<ApplicationUser> userManager, [FromServices] SignInManager<ApplicationUser> signInManager)
        {
            try
            {
                var userIdentity = userManager.FindByNameAsync(loginDetalhes.UserName).Result;

                if (userIdentity != null)
                {
                    // Efetua o login com base no usuário e sua senha
                    var resultadoLogin = signInManager
                        .PasswordSignInAsync(loginDetalhes.UserName, loginDetalhes.PasswordHash, false, false)
                        .Result;

                    if (resultadoLogin.Succeeded)
                    {
                        var tokenString = GerarTokenJWT();
                        return Ok(new { token = tokenString });
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
                return Unauthorized();
            }catch(Exception)
            {
                return Unauthorized();
            }
        }

        private string GerarTokenJWT()
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(3);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: issuer, audience: audience, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
               
    }
}
