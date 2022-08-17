
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using restaurant.Data;

namespace restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;

        public UserController(IConfiguration configuration,DataContext context)
        {
            _configuration = configuration;
            _context = context;

        }

        public static UserDb user = new UserDb();

        [HttpPost("register")]
        public async Task<ActionResult<List<UserDb>>> RegisterUser(UserDto request, string Name, string Role)
        {
            CreatePasswordHash(request.Password,out byte[] passwordHash, out byte[] passwordSalt);
            user.Name = Name;
            user.Role = Role;
            user.Email = request.Email;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            //_context.RegisterUser(details);
            _context.UserList.Add(user);

            await _context.SaveChangesAsync();
            return Ok(user);

        }


        [HttpPost("login")]
        public async Task<ActionResult<List<string>>> Login(UserDto request)

        {
            var LoginUser = _context.UserList.SingleOrDefault(x => x.Email == request.Email);
            if (LoginUser.Email != request.Email)
            {
                return BadRequest("User not found");
            }
            if(!VerifyPasswordHash(request.Password, LoginUser.PasswordHash, LoginUser.PasswordSalt))
            {
                return BadRequest("Wrong password");
            }

            string token = CreateToken(LoginUser);
            return Ok(LoginUser);

            //var FindUser = _context.GetLoginUser(data);
            //if (FindUser != null)
            //    return Ok(FindUser);
            //else
            //    return Ok("User Not Found");
        }

        private string CreateToken(UserDb user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                 new Claim(ClaimTypes.Role, "Admin")
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(

            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: cred);
            var jwt =new JwtSecurityTokenHandler().WriteToken(token);
           
            return jwt;
        }

        //[HttpDelete("{id}")]

        //public async Task<ActionResult<List<UserDb>>> DeleteUser(int id)
        //{

        //    return Ok(  _context.DeleteUser(id));
        //}

        private void CreatePasswordHash(string password, out byte[] passwordHash , out byte[] passwordSalt)
        {
            using(var hmac=new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var coumputedHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return coumputedHash.SequenceEqual(passwordHash);

            }
        }

    }
}
