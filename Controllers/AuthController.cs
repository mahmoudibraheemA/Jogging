using MagicVilla.Data;
using MagicVilla.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace MagicVilla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static Users user = new Users();
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<Users>> Register(UsersDTO request)
        {
            createPaawwordHash(request.Pasword, out byte[] passwordhash, out byte[] passwordsalt);
            user.Name = request.Name;
            user.PasswordHash = passwordhash;
            user.PasswordSalt = passwordsalt;
            joggingStore.usersList.Add(user);
            return Ok(user);
        }
        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UsersDTO request)
        {
            var users = joggingStore.usersList.FirstOrDefault(u => u.Name == request.Name);
            if(users == null)
            {
                return BadRequest("User Not Found");
            }
            
            if(!VerifyPasswordHash(request.Pasword, users.PasswordHash, users.PasswordSalt))
            {
                return BadRequest("Password Isn't Correct");
            }
            string Token = CreateToken(users);
            return Ok(Token);
        }
        private string CreateToken(Users user)
        {
            List<Claim> Claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var ced = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims:Claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials:ced);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
                
            return jwt;
        }
        private void createPaawwordHash(string Password, out byte[] passwordhash, out byte[] passwordsalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordsalt = hmac.Key;
                passwordhash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
            }
        }

        private bool VerifyPasswordHash(string Password, byte[] passwordhash, byte[] passwordsalt)
        {
            using(var hmac =new HMACSHA512(passwordsalt))
            {
                var computehash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
                return computehash.SequenceEqual(passwordhash);
            }
        }
    }
}
