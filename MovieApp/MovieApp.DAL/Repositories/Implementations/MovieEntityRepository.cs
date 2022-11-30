using MovieApp.DAL.Repositories.Interfaces;
using MovieApp.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DAL.Repositories.Implementations
{
    public class MovieEntityRepository : IMovieRepository<MovieDto>
    {
        private readonly AppDbContext _context;
        public MovieEntityRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Create(MovieDto entity)
        {
            _context.Movies.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<MovieDto> GetAll()
        {
            return _context.Movies;
        }


        public IEnumerable<MovieDto> GetByGanre(int genre)
        {
            return _context.Movies.Where(movie => movie.Genre == genre);

        }

        public MovieDto GetById(int id)
        {
            return _context.Movies.FirstOrDefault(x => x.Id == id);

        }

        public IEnumerable<MovieDto> GetByUserId(int userId)
        {
            return GetAll().Where(x => x.UserId == userId).ToList();

        }
    }
}
