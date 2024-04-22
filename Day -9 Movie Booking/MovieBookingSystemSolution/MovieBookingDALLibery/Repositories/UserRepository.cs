using MovieBookingDALLibery.Interfaces;
using MovieBookingModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingDALLibery.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public User GetUserByUsername(string username)
        {
            return _data.Values.FirstOrDefault(user => user.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }
    }
}
