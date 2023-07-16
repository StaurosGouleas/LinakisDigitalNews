using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsAPI.Models;

namespace LinakisDigitalNewsApi
{
    public interface INewsApiRequest
    {
        IEnumerable<Article> GetArticles(string pageTitle);
    }
}
