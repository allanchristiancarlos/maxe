using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Maxe.DAL.Models;
using System.Threading.Tasks;

namespace Maxe.Client.Controllers
{
    public class EntriesController : Controller
    {
        private MaxeDbContext db = new MaxeDbContext();

        // GET: /Entries
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Entries/View/{id}
        public async Task<ActionResult> View(int id)
        {
            var entry = await db.Entries.FindAsync(id);

            if (entry == null)
            {
                return HttpNotFound();
            }

            ViewBag.Title = "ID: " + entry.EntryId + " Entry";
            ViewBag.Entry = entry;

            return View();
        }
    }
}