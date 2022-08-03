
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
        private  IUserData _context;

        public UserController(IUserData context)
        {
            _context = context;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<List<UserDb>>> RegisterUser(UserDb details)
        {
            _context.RegisterUser(details);

            //return Ok(await _context.UserList.ToListAsync());
            return Ok("User Registered");

        }


        [HttpPost]

        public  IActionResult GetLoginUser(UserDb data)
        {
            var FindUser = _context.GetLoginUser(data);
            if (FindUser != null)
                return Ok(FindUser);
            else
                return Ok("User Not Found");
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<UserDb>>> DeleteUser(int id)
        {
    
            return Ok(  _context.DeleteUser(id));
        }

    }
}
