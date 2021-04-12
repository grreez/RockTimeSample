using DataLayer.Concrete;
using DataLayer.Entities;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RockTimeWebsite.Controllers
{
    public class ArticleController : Controller
    {
        public PartialViewResult Index(int? pageId)
        {
            using (IRepository<Article> repository = new ArticleRepository())
            {
                if (pageId != null)
                    return PartialView(repository.Find(Convert.ToInt16(pageId)));
                else
                    return PartialView(new Article {
                        ArticleTitle="No article has been found",
                        ArticleHeader = "No article has been found!",
                        ArticleLevel = 2,
                        ArticleContent = "",
                        ParentArticleId = 0
                    });
            }
        }
        [HttpGet]
        public ViewResult Edit(int articleId, int parentArticleId)
        {
            if(articleId!=0)
            {
                using (IRepository<Article> repository = new ArticleRepository())
                {
                    var article = repository.Find(articleId);
                    ViewBag.EditorTitle = article.ArticleTitle; 
                    return View(article); 
                }
            }
            else
            {
                ViewBag.EditorTitle = "Add New Article"; 
                return View(new Article {
                    ParentArticleId = parentArticleId,
                    ArticleLevel = 2
                });
            }    
        }
        [HttpPost]
        public ActionResult Edit(Article article)
        {
            bool isSaved = false;
            if (ModelState.IsValid)
            {
                using (IRepository<Article> repository = new ArticleRepository())
                {
                    repository.InsertOrUpdate(article);
                    isSaved = repository.Save();
                }
            }
            if (isSaved)
            {
                TempData["EditorMessage"] =  "Article " + article.ArticleTitle + " Was Successfully Updated!";
                TempData["MessageType"] = 1;
            }   
            else
            {
                TempData["EditorMessage"] = "Problem saving data!";
                TempData["MessageType"] = 0;
            }
            return RedirectToAction("Index", "Home", null); 
        }
        public ActionResult Delete(int articleId)
        {
            bool isDeleted = false;
            using (IRepository<Article> repository = new ArticleRepository())
            {
                var article = repository.Find(articleId);
                repository.Delete(article);
                isDeleted = repository.Save();
            }
            if(isDeleted)
            {
                TempData["EditorMessage"] = "Article Was Removed From The Database!";
                TempData["MessageType"] = 1;
            }
            else
            {
                TempData["EditorMessage"] = "Can't Delete Data!";
                TempData["MessageType"] = 0;
            }
            return RedirectToAction("Index", "Home", null);
        }

    }
}
