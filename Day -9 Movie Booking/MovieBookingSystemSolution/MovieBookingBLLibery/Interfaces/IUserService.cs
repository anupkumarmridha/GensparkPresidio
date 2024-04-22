using MovieBookingDALLibery.Interfaces;
using MovieBookingModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBookingBLLibery.Interfaces
{
    public interface IUserService:IRepository<User>
    {
        User GetUserByUsername(string username);
    }
}
