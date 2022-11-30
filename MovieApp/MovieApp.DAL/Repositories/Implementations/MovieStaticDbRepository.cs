using MovieApp.DAL.Repositories.Interfaces;
using MovieApp.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DAL.Repositories.Implementations
{
    public class MovieStaticDbRepository : IMovieRepository<MovieDto>
    {
        public void Create(MovieDto entity)
        {
            entity.Id = StaticDB.MovieId++; 
           StaticDB.Movies.Add(entity);
        }

        public IEnumerable<MovieDto> GetAll()
        {
            return StaticDB.Movies;
        }

        public IEnumerable<MovieDto> GetByGanre(int genre)
        {
           return StaticDB.Movies.Where(movie => movie.Genre == genre);
        }

        public MovieDto GetById(int id)
        {
            return StaticDB.Movies.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<MovieDto> GetByUserId(int userId)
        {
            return GetAll().Where(x => x.UserId == userId).ToList();
        }
    }
}
