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
    public class EntriesController : BaseApiController
    {

        // GET: api/Entries
        public IQueryable<Entry> GetEntries()
        {
            return db.Entries
                .Include(e => e.Answers.Select(a => a.AnswerItems))
                .Include(e => e.Exam);
        }

        // GET: api/Entries/5
        [ResponseType(typeof(Entry))]
        public async Task<IHttpActionResult> GetEntry(int id)
        {
            Entry entry = await db.Entries.FindAsync(id);
            if (entry == null)
            {
                return NotFound();
            }

            return Ok(entry);
        }

        // PUT: api/Entries/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEntry(int id, Entry entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entry.EntryId)
            {
                return BadRequest();
            }

            db.Entry(entry).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntryExists(id))
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

        // POST: api/Entries
        [ResponseType(typeof(Entry))]
        public async Task<IHttpActionResult> PostEntry(Entry entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entries.Add(entry);
            await db.SaveChangesAsync();

            return CreatedAtRoute("EntriesApi", new { id = entry.EntryId }, entry);
        }

        // DELETE: api/Entries/5
        [ResponseType(typeof(Entry))]
        public async Task<IHttpActionResult> DeleteEntry(int id)
        {
            Entry entry = await db.Entries.FindAsync(id);
            if (entry == null)
            {
                return NotFound();
            }

            db.Entries.Remove(entry);
            await db.SaveChangesAsync();

            return Ok(entry);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntryExists(int id)
        {
            return db.Entries.Count(e => e.EntryId == id) > 0;
        }
    }
}