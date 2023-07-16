using LinakisDigitalNews.Context;
using LinakisDigitalNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinakisDigitalNews.Repositories
{
    public class ArticleRepository: GenericRepository<LinakisDigitalNewsContext,Article>, IArticleRepository
    {
        public ArticleRepository(LinakisDigitalNewsContext context): base(context)
        {
        }
    }
}