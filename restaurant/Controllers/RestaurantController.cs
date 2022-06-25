using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restaurant.Data;

namespace restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly DataContext _context;

        public RestaurantController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
         
        public async Task<ActionResult<List<RestoList>>> GetRestoList()
        {
            return Ok(await _context.Listresto.ToListAsync());
        }

      [HttpPost]
        public async Task<ActionResult<List<RestoList>>> CreateRestoList(RestoList details)
        {
             _context.Listresto.Add(details);
            await _context.SaveChangesAsync();

            return Ok(await _context.Listresto.ToListAsync());

        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<RestoList>>> UpdateRestoList(RestoList details, int id)
        {
            var dbresto= await _context.Listresto.FindAsync(details.Id);
            if (dbresto == null)
                return BadRequest("not found");

            dbresto.Name = details.Name;
            dbresto.Email = details.Email;
            dbresto.Address = details.Address;

            await _context.SaveChangesAsync();

            return Ok(await _context.Listresto.ToListAsync());

        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<List<RestoList>>> DeleteRestoList(int id)
        {
            var dbresto = await _context.Listresto.FindAsync(id);
            if (dbresto == null)
                return BadRequest("not found");

            _context.Listresto.Remove(dbresto);
            await _context.SaveChangesAsync();

            return Ok(await _context.Listresto.ToListAsync());
        }

     

       

        [HttpGet("{id}")]

        public async Task<ActionResult<RestoList>> EditRestoList(int id)
        {
            var dbresto = await _context.Listresto.FindAsync(id);

            /* return Ok(await _context.Listresto.ToListAsync());*/

            return (dbresto);
        }






    }
}
