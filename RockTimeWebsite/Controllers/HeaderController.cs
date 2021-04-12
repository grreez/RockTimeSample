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
    public class HeaderController : Controller
    {
        public PartialViewResult Index(string catchall)
        {
            using(IRepository<Article> repository = new ArticleRepository())
            {
                ViewBag.SelectedPage = catchall;
                return PartialView(repository.All.ToList().Where(a => a.ArticleLevel == 1).ToList());
            }
        }

    }
}
