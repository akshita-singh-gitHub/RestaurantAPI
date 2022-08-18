
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
            return Ok(_context.OrderList.ToList());
        }

        [HttpPost("[action]")]
        public IActionResult PlaceOrder(OrderDto details)
        {
            List<FoodDetail> OrderDetail = new List<FoodDetail>();


            var OrderArr = details.Order.Split(',');
            MenuFunc menuFunc = new MenuFunc(_context);

            OrderDetail = menuFunc.GetFoodDetail(OrderArr);
            for (int i = 0; i < OrderArr.Length; i++)
            {
                Orders order = new Orders();

                DateTime datetime = DateTime.Now;
                order.Datetime = datetime;
                order.CustomerName = details.CustomerName;
                order.Restaurant = OrderDetail[i].Restaurant;
                order.Order = OrderDetail[i].Name;
                order.Price = OrderDetail[i].Price;
                order.Status = "pending";
                order.Address = details.Address;
                _context.OrderList.Add(order);

                _context.SaveChanges();
            }


           
            return Ok("Ok");

        }

        //[HttpGet("[action]/{restaurant}")]
        //public IActionResult GetOrderByResto(string restaurant)
        //{
        //    var resto = _context.OrderList.Where(x => x.Restaurant == restaurant).ToList();
            
        //    return Ok(resto);
        //}


        //[HttpGet("[action]/{restaurant}")]
        //public IActionResult GetOrderByStatus(string restaurant)
        //{
        //    var resto = _context.OrderList.Where(x => x.Restaurant == restaurant && x.Status=="pending").ToList();

        //    return Ok(resto);
        //}


        [HttpGet("{id}")]

        public async Task<ActionResult<Orders>> getOrderById(int id)
        {
            var dbresto = await _context.OrderList.FindAsync(id);

            /* return Ok(await _context.Listresto.ToListAsync());*/

            return dbresto;
        }


    }
}
