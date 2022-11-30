using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DAL.Repositories.Interfaces
{
    public interface IMovieRepository<T> where T : class
    {
        void Create(T entity);
        T GetById(int id);
        IEnumerable<T> GetByGanre(int ganre);
        IEnumerable<T> GetAll();

        IEnumerable<T> GetByUserId(int userId);



    }
}
