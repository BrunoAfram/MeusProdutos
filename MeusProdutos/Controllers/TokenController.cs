using MeusProdutos.DataBase;
using MeusProdutos.Model;
using MeusProdutos.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MeusProdutos.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        public readonly AppDataBase _context;

        public TokenController(IConfiguration configuration, AppDataBase context)
        {
            _configuration = configuration;
            _context = context;
        }
        //[HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            if (usuario != null && usuario.Email != null && usuario.Senha != null)
            {
                Usuario _usuario = await GetUser(usuario.Email, usuario.Senha);
                if (_usuario != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id",_usuario.Id.ToString()),
                        new Claim("Email", _usuario.Email),
                        new Claim("Senha", _usuario.Senha)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Credenciais Inválidas");
                }
            }
            else
            {
                return BadRequest("");
            }
        }


        private async Task<Usuario> GetUser (string email, string senha)
        {
            Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
            string encryptedPassword = usuario.Senha;
            string decryptedPassword = EncryptService.Decrypt(encryptedPassword);
            if (decryptedPassword != senha) return null;
            return usuario;
        }

    }
}
