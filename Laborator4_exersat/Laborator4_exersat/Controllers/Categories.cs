using Laborator4_exersat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laborator4_exersat.Controllers
{
    public class Categories : Controller
    {
        private ArticleDBContext db = new ArticleDBContext();
        // GET: Category
        public ActionResult Index()
        {
            var categories = from cat in db.Categories
                             orderby cat.CategoryName
                             select cat;
            ViewBag.Categories = categories;
            return View();
        }
        public ActionResult Show(int id)
        {
            Category cat = db.Categories.Find(id);
            ViewBag.Category = cat;
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Category cat = db.Categories.Find(id);
      
                if(TryUpdateModel(cat))
                {
                    db.Categories.Remove(cat);
                    db.SaveChanges();
                }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Categories = db.Categories.Find(id);
            return View();
        }
        [HttpPut]
        public ActionResult Edit(int id,Category RequestCategory)
        {
            try
            {
                Category cat = db.Categories.Find(id);
                if(TryUpdateModel(cat))
                {
                    cat.CategoryName = RequestCategory.CategoryName;
                    db.SaveChanges();
                    return Redirect("Categories/Show/" + cat.CategoryId);
                }

            }catch(Exception e)
            {
                return View();
            }
            return View();
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Category cat)
        {
            try
            {
                db.Categories.Add(cat);
                db.SaveChanges();
                ViewBag.Category = cat;
                return Redirect("Categories/Show/" + cat.CategoryId);

            }
            catch(Exception e)
            {
                return View();
            }
        }
    }
}