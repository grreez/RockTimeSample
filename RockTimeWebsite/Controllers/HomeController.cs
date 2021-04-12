using DataLayer.Concrete;
using DataLayer.Entities;
using Domain;
using RockTimeWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RockTimeWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (TempData["EditorMessage"] != null)
            {
                ViewBag.EditorMessage = TempData["EditorMessage"];
                ViewBag.MessageType = TempData["MessageType"];
            }
            using (IRepository<Article> repository = new ArticleRepository())
            {
                ArticleViewModel model = new ArticleViewModel
                {
                    Article = repository.Default
                };
                return View(model);
            }
        }
    }
}
