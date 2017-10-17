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
    public class ProjectController : Controller
    {
        private DarktierStudiosDbContext db = new DarktierStudiosDbContext();

        // GET: Project/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Project.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        
    }
}
