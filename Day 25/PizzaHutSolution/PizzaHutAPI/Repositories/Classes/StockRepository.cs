using PizzaHutAPI.Contexts;
using PizzaHutAPI.Models.DB_Models;
using PizzaHutAPI.Repositories.Interfaces;

namespace PizzaHutAPI.Repositories.Classes
{
    public class StockRepository:BaseRepository<int, Stock>, IStockRepository
    {
        public StockRepository(PizzaHutDbContext context) : base(context)
        {
        }
    }
}
