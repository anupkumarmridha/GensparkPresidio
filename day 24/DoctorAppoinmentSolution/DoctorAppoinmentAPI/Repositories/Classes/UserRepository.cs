using DoctorAppoinmentAPI.Contexts;
using DoctorAppoinmentAPI.Models;
using DoctorAppoinmentAPI.Repositories.Interfaces;

namespace DoctorAppoinmentAPI.Repositories.Classes
{
    public class UserRepository: BaseRepository<int, User>, IUserRepository
    {
        public UserRepository(DoctorAppoinmentDbContext context) : base(context)
        {
    
        }
    }
}
