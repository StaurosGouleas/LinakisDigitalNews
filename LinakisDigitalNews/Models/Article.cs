using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinakisDigitalNews.Models
{
    public class Article
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string SourceName { get; set; }        
        public DateTime? PublicationDate { get; set; }
        public string Url { get; set; }
        public Guid? PageId { get; set; }
    }
}