using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using System.Configuration;

namespace LinakisDigitalNewsApi
{
    public class NewsApiRequest: INewsApiRequest
    {
        private readonly string _apiKey = ConfigurationManager.AppSettings["apiKey"];
        public IEnumerable<Article> GetArticles(string pageTitle)
        {
            var articles = new List<Article>();            
            var newsApiClient = new NewsApiClient(_apiKey);
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = pageTitle,
                PageSize=5
            });
            if (articlesResponse.Status == Statuses.Ok)
            {
                foreach (var article in articlesResponse.Articles)
                {
                    articles.Add(article);                    
                }
            }
            return articles;       
        }
    }
}
