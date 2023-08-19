using Microsoft.AspNetCore.Mvc;
using NET7_WebAPI_EntityFramework.Services;

namespace NET7_WebAPI_EntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
          return await _superHeroService.GetAllHeroes();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var result = await _superHeroService.GetSingleHero(id);
            if (result is null)
                return NotFound("Hero not found");
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero([FromBody]SuperHero hero) 
        {
            var result = await _superHeroService.AddHero(hero);
            if (result is null)
                return NotFound("Hero not found");
            return Ok(hero);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id,SuperHero request) 
        {
          var result = await _superHeroService.UpdateHero(id, request);
            if (result is null)
                return NotFound("Hero not found");
            return Ok(result);

        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
          var result = await _superHeroService.DeleteHero(id);
            if (result is null)
                return NotFound("Hero not found");
            return Ok(result);
        }
    }
}
