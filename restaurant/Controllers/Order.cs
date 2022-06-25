
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

        public Order(DataContext context)
        {
            _context = context;
        }

        [HttpGet]     

        public async Task<ActionResult<List<Orders>>> GetOrderList()
        {
            return Ok(await _context.OrderList.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Orders>>> CreateOrderList(Orders details)
        {
            _context.OrderList.Add(details);
            await _context.SaveChangesAsync();

            return Ok(await _context.OrderList.ToListAsync());

        }


    }
}
