using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using LinakisDigitalNews.Models;
using System.Threading.Tasks;
using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;
using LinakisDigitalNewsApi;

namespace LinakisDigitalNews.Context
{
    public class LinakisDigitalNewsDbInitializer : DropCreateDatabaseAlways<LinakisDigitalNewsContext>
    {
        protected override void Seed(LinakisDigitalNewsContext context)
        {
            Page technology = new Page()
            {
                Id = Guid.NewGuid(),
                Title = "Technology"
            };
            Page business = new Page()
            {
                Id = Guid.NewGuid(),
                Title = "Business"
            };

            Page entertainment = new Page()
            {
                Id = Guid.NewGuid(),
                Title = "Entertainment"
            };

            Page miscellaneous = new Page()
            {
                Id = Guid.NewGuid(),
                Title = "Miscellaneous"
            };

            context.Pages.AddOrUpdate(technology, business, entertainment, miscellaneous);           
            context.SaveChanges();
        }
    }
}