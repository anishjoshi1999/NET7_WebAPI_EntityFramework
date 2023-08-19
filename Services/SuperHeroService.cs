using Microsoft.EntityFrameworkCore;
using NET7_WebAPI_EntityFramework.Data;

namespace NET7_WebAPI_EntityFramework.Services
{
    public class SuperHeroService : ISuperHeroService
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
        private readonly DataContext _context;

        public SuperHeroService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<SuperHero>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return superHeroes;
        }

        public async Task<List<SuperHero>> DeleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
                return null;
            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();
            return superHeroes;
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return heroes;
        }

        public async Task<SuperHero> GetSingleHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
            {
                return null;
            }
            return hero;
        }

        public async Task<List<SuperHero>> UpdateHero(int id, SuperHero request)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
            {
                return null;
            }
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;

            await _context.SaveChangesAsync();
            return superHeroes;
   
        }
    }
}
