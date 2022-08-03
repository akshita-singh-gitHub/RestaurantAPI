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
        private readonly DataContext _context;

        public RestoMenu(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<FoodDetail>>> GetMenuList()
        {
            return Ok(await _context.RestoMenu.ToListAsync());
        }

     


        [HttpGet("{id}")]

        public async Task<ActionResult<FoodDetail>> getFoodById(int id)
        {
            var dbresto = await _context.RestoMenu.FindAsync(id);

            /* return Ok(await _context.Listresto.ToListAsync());*/

            return dbresto;
        }






        [HttpGet("[action]/{restaurant}")]
        public IActionResult GetRestoByName(string restaurant)
        {
            
            var resto = _context.RestoMenu.Where(x => x.Restaurant==restaurant).ToList();
            return Ok(resto);
        } 
        
        [HttpPost("[action]")]
        public IActionResult GetFoodDetail(string[] CartArray)
        {
           
           List <FoodDetail> UserCart = new List<FoodDetail>();
            for (int i=0; i<CartArray.Length;i++)
            {
               var  item = _context.RestoMenu.Where(x => x.Name == CartArray[i]).FirstOrDefault();

                UserCart.Add(item);


            }
            return Ok(UserCart);
        }

        [HttpGet("[action]/{Tag}")]
        public IActionResult GetFoodByTag(string Tag)
        {

            var item = _context.RestoMenu.Where(x => x.Tag == Tag).ToList();
            return Ok(item);
        }




    }
}
