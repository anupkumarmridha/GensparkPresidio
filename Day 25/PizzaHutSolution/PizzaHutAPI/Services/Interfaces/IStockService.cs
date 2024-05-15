using PizzaHutAPI.Models.DB_Models;
using PizzaHutAPI.Models.DTO_Models;

namespace PizzaHutAPI.Services.Interfaces
{
    public interface IStockService
    {
        Task<IEnumerable<Stock>> GetAllStocks();
        Task<Stock> GetStockById(int id);
        Task<Stock> AddStock(StockDTO stock);
        Task<Stock> UpdateStock(int id, StockDTO stock);
        Task<Stock> DeleteStock(int id);
    }
}
