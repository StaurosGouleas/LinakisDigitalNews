using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinakisDigitalNews.Repositories
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext, new()
    {
        IPageRepository Pages { get; }
        IArticleRepository Articles { get; }
        void Save();

    }
}
