using Microsoft.AspNetCore.Mvc;
using NET7_WebAPI_EntityFramework.Models;


namespace NET7_WebAPI_EntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> superHeroes = new List<SuperHero>
            {
                new SuperHero
                {
                    Id = 1,
                    Name = "Spider-Man",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "New York City"
                },
                new SuperHero
                {
                    Id = 2,
                    Name = "Wonder Woman",
                    FirstName = "Diana",
                    LastName = "Prince",
                    Place = "Themyscira"
                },
                new SuperHero
                {
                    Id = 3,
                    Name = "Iron Man",
                    FirstName = "Tony",
                    LastName = "Stark",
                    Place = "Malibu"
                },
                new SuperHero
                {
                    Id = 4,
                    Name = "Hulk",
                    FirstName = "Bruce",
                    LastName = "Banner",
                    Place = "New york"
                },
                new SuperHero
                {
                    Id = 5,
                    Name = "Black Widow",
                    FirstName = "Natasha",
                    LastName = "Romanoff",
                    Place = "Russia"
                }
            };
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes() // Corrected the method name.
        {
            return Ok(superHeroes); 
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetSingleHero(int id) // Corrected the method name.
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if(hero == null)
            {
                return NotFound("Sorry, but this hero doesn't exist");
            }
            return Ok(hero);
        }
    }
}
