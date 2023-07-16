using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinakisDigitalNews.Repositories
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        IEnumerable<TModel> GetAll();
        TModel GetById(Guid id);
        void Create(TModel model);
        void Edit(TModel model);
        void Delete(Guid id);
        void Save();
    }
}
