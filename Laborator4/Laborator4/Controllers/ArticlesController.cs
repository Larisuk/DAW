using System;
using Laborator4.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Remoting.Messaging;

namespace Laborator4.Controllers
{
    public class ArticlesController : Controller
    {
        private ArticleDBContext db = new ArticleDBContext();
        // GET: Articles
       
        public ActionResult Index()
        {
            var articles = db.Articles.Include("Category");
            ViewBag.Articles = articles;
            return View();
        }
    
        public ActionResult Show(int id)
        {
            Article article = db.Articles.Find(id);
            ViewBag.Article = article;
            ViewBag.Category = article.Category;
            return View("Show");
        }
        public ActionResult New()
        {
            var categories=from cat in db.Categories select cat;
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public ActionResult New(Article article)
        {
            try
            {
                db.Articles.Add(article);
                db.SaveChanges();
                ViewBag.Article = article;
                return View("Show");
             
            }
            catch(Exception e)
            {
                return View();
            }
         
        }

        public ActionResult Edit(int id)
        {
            Article article = db.Articles.Find(id);
            ViewBag.Article = article;
            ViewBag.Category = article.Category;
            var categories = from cat in db.Categories select cat;
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPut]
        public ActionResult Edit(int id,Article requestArticle)
        {
            try
            {
                Article article = db.Articles.Find(id);
                if(TryUpdateModel(article))
                {
                    article.Title = requestArticle.Title;
                    article.Content = requestArticle.Content;
                    article.Date = requestArticle.Date;
                    article.CategoryId = requestArticle.CategoryId;
                    db.SaveChanges();
                    return RedirectToAction("Show");
                }

            }catch(Exception e)
            {
                return View();
            }
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var article= db.Articles.Find(id);
            if(TryUpdateModel(article))
                {
                    db.Articles.Remove(article);
                //db.Categories.Remove(article);
                    db.SaveChanges();
                }
            return RedirectToAction("Index");
        }
     
    }
}