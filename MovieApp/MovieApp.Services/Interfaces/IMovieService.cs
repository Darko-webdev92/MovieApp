using MovieApp.InterfaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Interfaces
{
    public interface IMovieService
    {
        void Create(Movie movie, int userId);
        Movie GetById(int id);
        List<Movie> GetByGenre(int genre);
        List<Movie> GetAll();   
        List<Movie> GetByUserId(int userId);

    }
}
