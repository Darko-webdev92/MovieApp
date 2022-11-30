using MovieApp.DAL.Repositories.Interfaces;
using MovieApp.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DAL.Repositories.Implementations
{
    public class UserStaticDbRepository : IUserRepository<UserDto>
    {
        public void Add(UserDto user)
        {
            user.Id = StaticDB.UserId++;
            StaticDB.Users.Add(user);
        }

        public IEnumerable<UserDto> GetAll()
        {
            return StaticDB.Users;
        }
    }
}
