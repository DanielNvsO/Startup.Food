using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace Startup.Food.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("RequestToken")]
        public IActionResult RequestToken([FromBody] JObject Usuario)
        {

            if (Usuario["Usuario"].ToString() == "admin" && Usuario["Senha"].ToString() == "admin")
            {
                var claims = new[]{
                     new Claim(ClaimTypes.Name, Usuario["Usuario"].ToString())
                };

                //recebe uma instancia da classe SymmetricSecurityKey 
                //armazenando a chave de criptografia usada na criação do token
                var key = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));

                //recebe um objeto do tipo SigninCredentials contendo a chave de 
                //criptografia e o algoritmo de segurança empregados na geração 
                // de assinaturas digitais para tokens
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                     issuer: "macoratti.net",
                     audience: "macoratti.net",
                     claims: claims,
                     expires:  DateTime.Now.AddMinutes(30),
                     signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            return BadRequest("Credenciais inválidas...");
        }



    }
}
