namespace PizzaHutAPI.Models.DTO_Models
{
    public class LoginReturnDTO
    {
        public int CustomerId { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; set; }
    }
}
