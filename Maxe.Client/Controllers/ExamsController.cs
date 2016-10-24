using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Maxe.DAL.Models;
using System.Threading.Tasks;

namespace Maxe.Client.Controllers
{
    public class ExamsController : Controller
    {
        // GET: Exams/Take/1
        public async Task<ActionResult> Take(int id)
        {
            var db = new MaxeDbContext();
            var exam = await db.Exams.FindAsync(id);

            if (exam == null)
            {
                HttpNotFound();
            }

            ViewBag.Title = exam.Title;
            ViewBag.Exam = exam;

            return View();
        }
    }
}