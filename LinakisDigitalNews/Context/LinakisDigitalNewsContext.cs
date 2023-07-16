using LinakisDigitalNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LinakisDigitalNews.Context
{
    public class LinakisDigitalNewsContext: DbContext
    {
        public LinakisDigitalNewsContext() : base("Connection")
        {
            Database.SetInitializer(new LinakisDigitalNewsDbInitializer());
        }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}