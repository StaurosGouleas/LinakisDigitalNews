using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LinakisDigitalNews.Repositories
{
    public class GenericRepository<TContext, TModel>: IGenericRepository<TModel>, IDisposable where TModel : class where TContext : DbContext
    {
        protected readonly TContext _context;
        protected DbSet<TModel> _table;

        public GenericRepository(TContext context)
        {
            _context = context;
            _table = _context.Set<TModel>();
        }
        public void Create(TModel model)
        {
            if (model != null)
                _table.Add(model);
        }

        public void Delete(Guid id)
        {
            TModel existing = GetById(id);
            if (existing != null)
                _table.Remove(existing);
        }        

        public void Edit(TModel model)
        {
            if (model != null)
            {
                _table.Attach(model);
                _context.Entry(model).State = EntityState.Modified;
            }
        }

        public IEnumerable<TModel> GetAll()
        {
           return  _table;
        }

        public TModel GetById(Guid id)
        {
            return _table.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }
    }
}