using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Maxe.DAL.Models;

namespace Maxe.Api.Controllers
{
    public class ExamineesController : BaseApiController
    {
        // GET: api/Examinees
        public IQueryable<Examinee> GetExaminees()
        {
            return db.Examinees;
        }

        // GET: api/Examinees/5
        [ResponseType(typeof(Examinee))]
        public async Task<IHttpActionResult> GetExaminee(int id)
        {
            Examinee examinee = await db.Examinees.FindAsync(id);
            if (examinee == null)
            {
                return NotFound();
            }

            return Ok(examinee);
        }

        // PUT: api/Examinees/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutExaminee(int id, Examinee examinee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != examinee.ExamineeId)
            {
                return BadRequest();
            }

            db.Entry(examinee).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamineeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Examinees
        [ResponseType(typeof(Examinee))]
        public async Task<IHttpActionResult> PostExaminee(Examinee examinee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Examinees.Add(examinee);
            await db.SaveChangesAsync();

            return CreatedAtRoute("ExamineesApi", new { id = examinee.ExamineeId }, examinee);
        }

        // DELETE: api/Examinees/5
        [ResponseType(typeof(Examinee))]
        public async Task<IHttpActionResult> DeleteExaminee(int id)
        {
            Examinee examinee = await db.Examinees.FindAsync(id);
            if (examinee == null)
            {
                return NotFound();
            }

            db.Examinees.Remove(examinee);
            await db.SaveChangesAsync();

            return Ok(examinee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExamineeExists(int id)
        {
            return db.Examinees.Count(e => e.ExamineeId == id) > 0;
        }
    }
}