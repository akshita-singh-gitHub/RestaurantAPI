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
        private readonly DataContext _context;

        public CartController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{Id}")]
        public IActionResult GetUserCartItems(int Id)
        {
           
            var Cart = _context.CartList.Where(x => x.Id == Id  );
            if (Cart != null )
            {

                return Ok(Cart);
            }
            else
                return Ok("null");
        }

  

        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<List<CartDb>>> EmptyCartList( int id)
        {
            var cart = await _context.CartList.FindAsync(id);
            if (cart == null)
                return BadRequest("not found");
            

            cart.CartItems = null;

            await _context.SaveChangesAsync();

            return Ok(cart.CartItems);

        }

        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<List<CartDb>>> ModifyCartItems(int id, string item)
        {
            string str2;
            var cart = await _context.CartList.FindAsync(id);
            if (cart == null|| cart.CartItems==null)
                return BadRequest("not found");
            
            int pos1= cart.CartItems.IndexOf(item);

            if (pos1 == 0)           
                str2 = cart.CartItems.Remove(pos1, item.Length + 1);
            
            else 
              str2 = cart.CartItems.Remove(pos1-1,item.Length+1);

            cart.CartItems = str2;

            await _context.SaveChangesAsync();

            return Ok(cart.CartItems);
            
        }  
        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<List<CartDb>>> SaveOrder( string item, int id)
        {
            var order = await _context.CartList.FindAsync(id);
            if (order == null)
                return BadRequest("not found");
            if (order.OrderHistory == null)
                order.OrderHistory = item;
            else
                order.OrderHistory = order.OrderHistory.Insert(0, item + ",");

            await _context.SaveChangesAsync();

            return Ok(order.OrderHistory);

        }   
        
        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<List<CartDb>>> AddCartItem(int id, string item)
        {
            var cart = await _context.CartList.FindAsync(id);
            if (cart == null)
                return BadRequest("not found");
            if (cart.CartItems == null)
                cart.CartItems = item;
            else
            cart.CartItems=cart.CartItems.Insert(0, item+",");

            await _context.SaveChangesAsync();

            return Ok(cart.CartItems);

        }


        [HttpDelete("{id}")]

        public async Task<ActionResult<List<CartDb>>> DeleteUserCart(int id)
        {
            var user = await _context.CartList.FindAsync(id);
            if (user == null)
                return BadRequest("not found");

            _context.CartList.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(await _context.CartList.ToListAsync());
        }








        [HttpPost]
        public async Task<ActionResult<List<CartDb>>> CreateUserCart(CartDb details)
        {
            _context.CartList.Add(details);
            await _context.SaveChangesAsync();
            var cart = await _context.CartList.FindAsync(details.Id);

            cart.CartItems = null;
            await _context.SaveChangesAsync();

            return Ok(await _context.CartList.ToListAsync());
           

        }
    }
}
