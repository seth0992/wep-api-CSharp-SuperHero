using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wep_api_CSharp_SuperHero.Controllers.Entities;
using wep_api_CSharp_SuperHero.Data;

namespace wep_api_CSharp_SuperHero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        //public async Task<IActionResult> GetAllHeroes() {
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();

            //            return Ok(heroes);
            return heroes;
        }


        [HttpGet]
        [Route("{id}")]
        //public async Task<IActionResult> GetAllHeroes() {
        public async Task<ActionResult<SuperHero>> GetHeroe(int id)
        {
            var heroe = await _context.SuperHeroes.FindAsync(id);
            if (heroe is null) {
                return NotFound("Hero not found");
                //return BadRequest("Hero not found");
            }

            //            return Ok(heroes);
            return Ok(heroe);
        }


        [HttpPost]
        //public async Task<IActionResult> GetAllHeroes() {
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
          
            //            return Ok(heroes);
            return Ok(await GetAllHeroes());
        }

        [HttpPut]
        //public async Task<IActionResult> GetAllHeroes() {
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero hero)
        {
            var dbHeroe = await _context.SuperHeroes.FindAsync(hero.Id);
            if (dbHeroe is null)
            {
                return NotFound("Hero not found");
                //return BadRequest("Hero not found");
            }

            dbHeroe.Name = hero.Name;
            dbHeroe.FirstName = hero.FirstName;
            dbHeroe.LastName = hero.LastName;
            dbHeroe.Place = hero.Place;

            await _context.SaveChangesAsync();

            //            return Ok(heroes);
            return Ok(await GetAllHeroes());
        }

        [HttpDelete]
        //public async Task<IActionResult> GetAllHeroes() {
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var dbHeroe = await _context.SuperHeroes.FindAsync(id);
            if (dbHeroe is null)
            {
                return NotFound("Hero not found");
                //return BadRequest("Hero not found");
            }

            _context.SuperHeroes.Remove(dbHeroe);          
            await _context.SaveChangesAsync();

            //            return Ok(heroes);
            return Ok(await GetAllHeroes());
        }
    }
}
