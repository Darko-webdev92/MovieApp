using MovieApp.DAL.Repositories.Interfaces;
using MovieApp.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DAL.Repositories.Implementations
{
    public class UserEntityRepository : IUserRepository<UserDto>
    {
        private readonly AppDbContext _context;

        public UserEntityRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(UserDto user)
        {

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<UserDto> GetAll()
        {
           return _context.Users;
        }
    }
}
