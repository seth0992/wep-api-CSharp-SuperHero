using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wep_api_CSharp_SuperHero.Controllers.Entities;

namespace wep_api_CSharp_SuperHero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        [HttpGet]
        //public async Task<IActionResult> GetAllHeroes() {
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var heroes = new List<SuperHero> {
                new SuperHero{
                    Id = 1,
                    Name = "SpiderMan",
                    FirstName = "Perter",
                    LastName = "Parker",
                    Place = "New York City"
                }
            };

            //            return Ok(heroes);
            return heroes;
        }
    }
}
