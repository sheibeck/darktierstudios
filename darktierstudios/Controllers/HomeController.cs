using darktierstudios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace darktierstudios.Controllers
{
    public class HomeController : Controller
    {
        DarktierStudiosDbContext db = new DarktierStudiosDbContext();

        public ActionResult Index()
        {
            var model = db.Project.OrderByDescending(p => p.ProjectDate).Take(3).ToList();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

    }
}