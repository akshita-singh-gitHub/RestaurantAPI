
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restaurant.Data;

namespace restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<List<UserDb>>> RegisterUser(UserDb details)
        {
            _context.UserList.Add(details);
            await _context.SaveChangesAsync();

            //return Ok(await _context.UserList.ToListAsync());
            return Ok("User Registered");

        }


        [HttpPost]

        public IActionResult GetLoginUser(UserDb data)
        {
            var FindUser = _context.UserList.SingleOrDefault(x => x.Email == data.Email && x.Password == data.Password);
            if (FindUser != null)
                return Ok(FindUser);
            else
                return Ok("User Not Found");
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<UserDb>>> DeleteUser(int id)
        {
            var user = await _context.UserList.FindAsync(id);
            if (user == null)
                return BadRequest("not found");

            _context.UserList.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(await _context.UserList.ToListAsync());
        }

    }
}
