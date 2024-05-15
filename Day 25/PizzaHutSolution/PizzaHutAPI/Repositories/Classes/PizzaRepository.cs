
using Microsoft.EntityFrameworkCore;
using PizzaHutAPI.Contexts;
using PizzaHutAPI.Models.DB_Models;
using PizzaHutAPI.Repositories.Interfaces;

namespace PizzaHutAPI.Repositories.Classes
{
    public class PizzaRepository: BaseRepository<int, Pizza>, IPizzaRepository
    {
        public PizzaRepository(PizzaHutDbContext context) : base(context)
        {
        }

       public override async Task<Pizza> GetById(int id)
        {
            var pizza = await _context.Pizzas
                .Include(p => p.Stock)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pizza == null)
            {
                throw new InvalidOperationException($"{id} not found.");
            }
            return pizza;
        }

        public override async Task<IEnumerable<Pizza>> GetAll()
        {
            var pizzas = await _context.Pizzas
                .Include(p => p.Stock)
                .ToListAsync();

            return pizzas;
        }
    }
}
