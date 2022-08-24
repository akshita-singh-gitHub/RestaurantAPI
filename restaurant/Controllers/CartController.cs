using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restaurant.Data;

namespace restaurant.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICartData _context;

        public CartController(ICartData context)
        {
            _context = context;
        }

        [HttpGet("{UserId}")]
        public IActionResult GetUserCartItems(int UserId)
        {

            return Ok(_context.GetUserCartItems(UserId));
        }



        [HttpPut("[action]/{UserId}")]
        public IActionResult EmptyCartList(int UserId)
        {
            List<CartDb> cart = new List<CartDb>();
             cart= _context.GetUserCartItems(UserId);
            if (cart == null)
                return BadRequest("not found");
           
            return Ok(_context.EmptyCartList(cart));


        }

        [HttpPut("[action]")]
        public IActionResult ModifyCartItems(CartDb Cart)
        {


            return Ok(_context.ModifyCartItems(Cart));

        }



        [HttpPut("[action]")]
        public async Task<ActionResult<List<CartDb>>> AddCartItem(int userId, string customerName, int foodId)
        {


            

            return Ok(_context.AddCartItem(userId, customerName, foodId));

        }


    }
}
