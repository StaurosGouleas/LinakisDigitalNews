using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LinakisDigitalNews.Repositories
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IDisposable where TContext : DbContext, new()
    {
        private readonly TContext _context;

        private bool _disposed;

        public IPageRepository Pages { get; }
        public IArticleRepository Articles { get; }

        public UnitOfWork(TContext context, IPageRepository pages, IArticleRepository links)
        {
            _context = context;
            Pages = pages;
            Articles = links;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();
            _disposed = true;
        }
    }
}