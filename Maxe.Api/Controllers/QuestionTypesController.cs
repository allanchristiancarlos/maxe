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
    public class QuestionTypesController : BaseApiController
    {
        // GET: api/QuestionTypes
        public IQueryable<QuestionType> GetQuestionTypes()
        {
            return db.QuestionTypes;
        }

        // GET: api/QuestionTypes/5
        [ResponseType(typeof(QuestionType))]
        public async Task<IHttpActionResult> GetQuestionType(int id)
        {
            QuestionType questionType = await db.QuestionTypes.FindAsync(id);
            if (questionType == null)
            {
                return NotFound();
            }

            return Ok(questionType);
        }

        // PUT: api/QuestionTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutQuestionType(int id, QuestionType questionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionType.QuestionTypeId)
            {
                return BadRequest();
            }

            db.Entry(questionType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionTypeExists(id))
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

        // POST: api/QuestionTypes
        [ResponseType(typeof(QuestionType))]
        public async Task<IHttpActionResult> PostQuestionType(QuestionType questionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QuestionTypes.Add(questionType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("QuestionTypesApi", new { id = questionType.QuestionTypeId }, questionType);
        }

        // DELETE: api/QuestionTypes/5
        [ResponseType(typeof(QuestionType))]
        public async Task<IHttpActionResult> DeleteQuestionType(int id)
        {
            QuestionType questionType = await db.QuestionTypes.FindAsync(id);
            if (questionType == null)
            {
                return NotFound();
            }

            db.QuestionTypes.Remove(questionType);
            await db.SaveChangesAsync();

            return Ok(questionType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionTypeExists(int id)
        {
            return db.QuestionTypes.Count(e => e.QuestionTypeId == id) > 0;
        }
    }
}