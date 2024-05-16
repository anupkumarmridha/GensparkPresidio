using PizzaHutAPI.Models.DB_Models;
using PizzaHutAPI.Models.DTO_Models;

namespace PizzaHutAPI.Services.Interfaces
{
    public interface IPizzaService
    {
        Task<IEnumerable<Pizza>> GetAllPizzas();
        Task<Pizza> GetPizzaById(int id);
        Task<Pizza> GetPizzaByName(string name);
        Task<Pizza> AddPizza(PizzaDTO pizza);
        Task<Pizza> UpdatePizza(int id, PizzaDTO pizza);
        Task<Pizza> DeletePizza(int id);
    }
}
