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

        [HttpGet("{Id}")]
        public IActionResult GetUserCartItems(int Id)
        {

            return Ok(_context.GetUserCartItems(Id));
        }

         

        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<List<CartDb>>> EmptyCartList( int id)
        {
            var cart = _context.GetUserCartItems(id);
            if (cart == null)
                return BadRequest("not found");

            return  Ok(_context.EmptyCartList(cart));
           

        }

        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<List<CartDb>>> ModifyCartItems(int id, string item)
        {
          
            var cart = _context.GetUserCartItems(id);
            if (cart == null|| cart.CartItems==null)
                return BadRequest("not found");

            return Ok(_context.ModifyCartItems(cart,item));

        }  

        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<List<CartDb>>> SaveOrder( string item, int id)
        {
            var order = _context.GetUserCartItems(id);
            if (order == null)
                return BadRequest("not found");


            return Ok(_context.SaveOrder(order, item));

        }   
        
        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<List<CartDb>>> AddCartItem(int id, string item)
        {
             var cart = _context.GetUserCartItems(id);
            if (cart == null)
                return BadRequest("not found");

            return Ok(_context.AddCartItem(cart, item));

        }


        [HttpDelete("{id}")]

        public async Task<ActionResult<List<CartDb>>> DeleteUserCart(int id)
        {
            var user = _context.GetUserCartItems(id);
            if (user == null)
                return BadRequest("not found");



            return Ok(_context.DeleteUserCart(user));
        }



        [HttpPost]
        public async Task<ActionResult<List<CartDb>>> CreateUserCart(CartDb details)
        {
           
            return Ok(_context.CreateUserCart(details));


        }
    }
}
