using LinakisDigitalNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinakisDigitalNews.Repositories
{
    public interface IPageRepository : IGenericRepository<Page>
    {
        Page GetPageWithArticles(string pageTitle);
        Guid? GetPageIdByTitle(string pageTitle);
        IEnumerable<string> GetAllPageTitles();
    }
}
