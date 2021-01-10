using Laborator4_exersat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laborator4_exersat.Controllers
{
    public class ArticlesController : Controller
    {
        private ArticleDBContext db =new ArticleDBContext();
        // GET: Article
        public ActionResult Index()
        {
            var articles = db.Articles.Include("Category");
            return View();
        }
    }
}