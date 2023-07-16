using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LinakisDigitalNews.Context;
using LinakisDigitalNews.Models;
using LinakisDigitalNews.Repositories;
using LinakisDigitalNewsApi;

namespace LinakisDigitalNews.Controllers
{
    public class PageController : Controller
    {
        private readonly IUnitOfWork<LinakisDigitalNewsContext> _unitOfWork;

        public PageController(IUnitOfWork<LinakisDigitalNewsContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Article(string pageTitle)
        {
            var page = _unitOfWork.Pages.GetPageWithArticles(pageTitle);
            if (page != null)            
                return View(page);            
            else            
                return RedirectToRoute(new { controller = "Home", action = "Index" });     
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)            
                _unitOfWork.Dispose();            
            base.Dispose(disposing);
        }
    }
}
