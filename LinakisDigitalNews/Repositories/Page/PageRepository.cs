using LinakisDigitalNews.Context;
using LinakisDigitalNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinakisDigitalNews.Repositories
{
    public class PageRepository: GenericRepository<LinakisDigitalNewsContext,Page>, IPageRepository
    {
        public PageRepository(LinakisDigitalNewsContext context): base(context)
        {
        }

        public Page GetPageWithArticles(string pageTitle)
        {
            return _table.Include("Articles").FirstOrDefault(x => x.Title == pageTitle);
        }

        public Guid? GetPageIdByTitle(string pageTitle)
        {
            return _table.FirstOrDefault(x => x.Title == pageTitle)?.Id;
        }

        public IEnumerable<string> GetAllPageTitles()
        {
            return _table.Select(x => x.Title);
        }
    }
}