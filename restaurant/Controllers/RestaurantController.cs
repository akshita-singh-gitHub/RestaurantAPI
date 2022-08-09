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
        private  IRestoListData _context;

        public RestaurantController(IRestoListData context)
        {
            _context = context;
        }
        [HttpGet]
         
        public async Task<ActionResult<List<RestoList>>> GetRestoList()
        {
            return Ok(_context.GetRestoList());
        }

      [HttpPost]
        public async Task<ActionResult<List<RestoList>>> CreateRestoList(RestoList details)
        {


            return Ok( _context.CreateRestoList(details));

        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<RestoList>>> UpdateRestoList(RestoList details, int id)
        {
        

            return Ok(  _context.UpdateRestoList( details,  id));


        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<List<RestoList>>> DeleteRestoList(int id)
        {
            var dbresto =  _context.GetRestoById( id);
            if (dbresto == null)
                return BadRequest("not found");
            else
            {
                _context.DeleteRestoList(dbresto);
                return Ok(dbresto);
            }
            

            
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<RestoList>> GetRestoById(int id)
        {
            return Ok(_context.GetRestoById(id));
        }

        //[HttpPut("[action]")]
        //public IActionResult SetRestoAvailability(int id)
        //{
        //    var resto = _context.GetRestoById(id);

        //    _context.SetAvailability(resto);
        //    return Ok();

        //}




    }
}
