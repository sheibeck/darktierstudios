using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using darktierstudios.Models;

namespace darktierstudios.Controllers
{
    public class GamesController : Controller
    {
        private DarktierStudiosDbContext db = new DarktierStudiosDbContext();

        // GET: Game        
        public ActionResult List()
        {           
            return View(db.Project.OrderByDescending(p => p.ProjectDate).ToList());
        }

        // GET: Games/Details/5
        public ActionResult Details(string slug)
        {
            if (slug == null || slug == "list")
            {
                return RedirectToAction("list", "games");
            }
            Project project = db.Project.Where( p => p.Slug == slug).FirstOrDefault();
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        
    }
}
