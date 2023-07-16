using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinakisDigitalNews.Models
{
    public class Page
    {        
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}