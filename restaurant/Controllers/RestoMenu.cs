using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restaurant.Data;

namespace restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestoMenu : ControllerBase
    {
        private IMenuData _context;

        public RestoMenu(IMenuData context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<FoodDetail>>> GetMenuList()
        {
            return Ok(_context.GetMenuList());
        }

     


        [HttpGet("{id}")]

        public async Task<ActionResult<FoodDetail>> getFoodById(int id)
        {
            return Ok(_context.getFoodById(id));
        }






        [HttpGet("[action]/{restaurant}")]
        public IActionResult GetRestoByName(string restaurant)
        {

            return Ok(_context.GetRestoByName(restaurant));
        } 

        
        [HttpPost("[action]")]
        public IActionResult GetFoodDetail(string[] CartArray)
        {


            return Ok(_context.GetFoodDetail(CartArray));
        }

        [HttpGet("[action]/{Tag}")]
        public IActionResult GetFoodByTag(string Tag)
        {
            return Ok(_context.GetFoodByTag(Tag));

        }
        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<List<FoodDetail>>> UpdateFoodItem(FoodDetail details, int id)
        {


            return Ok(_context.UpdateFoodItem(details, id));


        }

        [HttpPut("[action]")]
        public IActionResult SetFoodAvailability(int  id)
        {
           var Food= _context.getFoodById(id);

            _context.SetFoodAvailability(Food);
            return Ok();

        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<List<FoodDetail>>> DeleteRestoList(int id)
        {
            var Food = _context.getFoodById(id);
            if (Food == null)
                return BadRequest("not found");
            else
            {
                _context.DeleteFoodItem(Food);
                return Ok(Food);
            }

        }

        [HttpPost("[action]")]
        public async Task<ActionResult<List<FoodDetail>>> AddFoodItem(FoodDetail details)
        {
            return Ok(_context.AddFoodItem(details));

        }


    }
}
