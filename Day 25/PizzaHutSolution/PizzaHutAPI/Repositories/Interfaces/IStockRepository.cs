using PizzaHutAPI.Models.DB_Models;

namespace PizzaHutAPI.Repositories.Interfaces
{
    public interface IStockRepository:IRepository<int, Stock>
    {
    }
}
