using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ReWrite.API.DAL.AuthDAL.Interfaces;
using ReWrite.API.DTOs;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ReWrite.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthDAL _authDAL;
        IConfiguration _conf;
        public AuthController(IAuthDAL authDAL, IConfiguration conf)
        {
            _authDAL = authDAL;
            _conf = conf;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]LoginDTO dto)
        {
            if (await _authDAL.UserExist(dto.Username))
            {
                ModelState.AddModelError("not valid", "User already exist!");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = await _authDAL.Register(new DAL.Entities.User() { Username=dto.Username},dto.Password);
            return StatusCode(201);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginDTO dto)
        {
            var user = await _authDAL.Login(dto.Username, dto.Password);
            if (user == null)
            {
                return BadRequest();
            }
            else
            {
                var desc = new SecurityTokenDescriptor()
                {
                    Expires = DateTime.Now.AddDays(1),
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                        new Claim(ClaimTypes.Name, user.Username)
                    }),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_conf.GetSection("Tokens:AppSettings:Token").Value)), SecurityAlgorithms.HmacSha512Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(desc);
                var tokenR = tokenHandler.WriteToken(token);
                return Ok(tokenR);
            }
        }
    }
}
