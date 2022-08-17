
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restaurant.Data;

namespace restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Order: ControllerBase
    {

        private readonly DataContext _context;
        //private readonly RestoMenu menu;
        

        public Order(DataContext context )
        {
            _context = context;
            //this.menu = menu;
        }


        [HttpGet]     

        public async Task<ActionResult<List<Orders>>> GetOrderList()
        {
            return Ok( _context.OrderList.ToList());
        }

        [HttpPost("[action]")]
        public IActionResult PlaceOrder(OrderDto details)
        {
            Orders  order = new Orders();
            var OrderArr = details.Order.Split(',');
            RestoMenu restoMenu = new RestoMenu();
            //RestoMenu.GetFoodDetail(OrderArr);
            //return  RedirectToAction("GetFoodDetail(details.Order)", "RestoMenu");


            //return Ok(menu.GetFoodDetail(OrderArr));


            //DateTime datetime = DateTime.Now;
            //order.Datetime = datetime;
            //order.CustomerName = details.CustomerName;
            //order.Restaurant = details.Restaurant;
            ////order.Order = details.Order;
            //order.Status = "pending";
            //order.Address = details.Address;
            //_context.OrderList.Add(order);

            //_context.SaveChanges();


            //return Ok(_context.OrderList.ToList());
            return Ok(order);

        }


        [HttpGet("{id}")]

        public async Task<ActionResult<Orders>> getOrderById(int id)
        {
            var dbresto = await _context.OrderList.FindAsync(id);

            /* return Ok(await _context.Listresto.ToListAsync());*/

            return dbresto;
        }


    }
}
