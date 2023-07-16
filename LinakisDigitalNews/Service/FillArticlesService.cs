using Autofac;
using LinakisDigitalNews.Context;
using LinakisDigitalNews.Models;
using LinakisDigitalNews.Repositories;
using LinakisDigitalNewsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinakisDigitalNews.Service
{
    public class FillArticlesService: IFillArticlesService
    {
        private readonly IUnitOfWork<LinakisDigitalNewsContext> _unitOfWork;
        private readonly INewsApiRequest _newsApiRequest;
        public FillArticlesService(IUnitOfWork<LinakisDigitalNewsContext> unitOfWork, INewsApiRequest newsApiRequest)
        {
            _unitOfWork = unitOfWork;
            _newsApiRequest = newsApiRequest;
        }
        public void FillArticlesFromRequest()
        {
            var pageTitles = _unitOfWork.Pages.GetAllPageTitles().ToList();
            foreach (var pageTitle in pageTitles)
            {
                var articlesResponse = _newsApiRequest.GetArticles(pageTitle);
                var articles = articlesResponse.Select(x => new Article()
                {
                    Id = Guid.NewGuid(),
                    Title = x.Title,
                    PublicationDate = x.PublishedAt,
                    Url = x.Url,
                    SourceName = x.Source.Name,

                });

                foreach (var article in articles)
                {
                    article.PageId = _unitOfWork.Pages.GetPageIdByTitle(pageTitle);
                    _unitOfWork.Articles.Create(article);
                }
            }
            _unitOfWork.Save();

        }
    }
}