using PizzaHutAPI.Models.DB_Models;
using PizzaHutAPI.Models.DTO_Models;
using PizzaHutAPI.Repositories.Interfaces;
using PizzaHutAPI.Services.Interfaces;

namespace PizzaHutAPI.Services.Classes
{
    public class PizzaService:IPizzaService
    {
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaService(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public async Task<Pizza> GetPizzaById(int id)
        {
            try
            {
                return await _pizzaRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Pizza>> GetAllPizzas()
        {
            try
            {

                return await _pizzaRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pizza> AddPizza(PizzaDTO pizza)
        {
            try
            {
                Pizza newPizza = new Pizza
                {
                    Name = pizza.Name,
                    Price = pizza.Price,
                    Description = pizza.Description,
                    ImageUrl = pizza.ImageUrl
                };
                return await _pizzaRepository.Add(newPizza);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
        }

        public async Task<Pizza> UpdatePizza(int id, PizzaDTO pizza)
        {
            try
            {
                Pizza newPizza = new Pizza
                {
                    Id = id,
                    Name = pizza.Name,
                    Price = pizza.Price,
                    Description = pizza.Description,
                    ImageUrl = pizza.ImageUrl
                };
                return await _pizzaRepository.Update(newPizza);
            }
            catch(Exception ex) { 
                throw new Exception(ex.Message);
            }
           
        }

        public async Task<Pizza> DeletePizza(int id)
        {
            try
            {
                return await _pizzaRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
