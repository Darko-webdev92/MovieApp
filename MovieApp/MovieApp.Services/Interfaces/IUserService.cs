using MovieApp.DomainModels;
using MovieApp.InterfaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Interfaces
{
    public interface IUserService
    {
        void Register(Register model);
        IEnumerable<User> GetAllUsers();
        string GenerateJwtToken(UserDto model);
        User Authenticate(Login model);
    }
}
