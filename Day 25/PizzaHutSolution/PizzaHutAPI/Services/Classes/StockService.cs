using PizzaHutAPI.Models.DB_Models;
using PizzaHutAPI.Models.DTO_Models;
using PizzaHutAPI.Repositories.Interfaces;
using PizzaHutAPI.Services.Interfaces;

namespace PizzaHutAPI.Services.Classes
{
    public class StockService:IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<Stock> AddStock(StockDTO stock)
        {
            try
            {
                var newStock = new Stock
                {
                    PizzaId = stock.PizzaId,
                    Quantity = stock.Quantity
                };
                return await _stockRepository.Add(newStock);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<Stock> DeleteStock(int id)
        {
            try
            {
                return await _stockRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Stock>> GetAllStocks()
        {
            try
            {
                return await _stockRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Stock> GetStockById(int id)
        {
            try
            {
                return await _stockRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Stock> UpdateStock(int id, StockDTO stock)
        {
            try
            {
                var newStock = new Stock
                {
                    PizzaId = stock.PizzaId,
                    Quantity = stock.Quantity,
                };
                return await _stockRepository.Update(newStock);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
