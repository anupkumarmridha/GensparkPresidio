using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingModelLibery
{
    

    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }

        public User(string username, string email)
        {
            Id = 0;
            Username = username;
            Email = email;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"User ID: {Id}");
            sb.AppendLine($"Username: {Username}");
            sb.AppendLine($"Email: {Email}");

            return sb.ToString();
        }
        public void SetId(int id)
        {
            Id = id;
        }
    }
}
