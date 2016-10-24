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
using System.Web;
using System.Net.Http.Formatting;
using Maxe.Api.Models;

namespace Maxe.Api.Controllers
{
    public class ExamSectionsController : ApiController
    {
        private MaxeDbContext db = new MaxeDbContext();

        // GET: api/ExamSections
        public IQueryable<ExamSection> GetExamSections()
        {
            return db.ExamSections.Include("Questions");
        }

        // GET: api/ExamSections/5
        [ResponseType(typeof(ExamSection))]
        public async Task<IHttpActionResult> GetExamSection(int id)
        {
            ExamSection examSection = await db.ExamSections.FindAsync(id);
            if (examSection == null)
            {
                return NotFound();
            }

            return Ok(examSection);
        }

        // PUT: api/ExamSections/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutExamSection(int id, ExamSection examSection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != examSection.ExamSectionId)
            {
                return BadRequest();
            }

            db.Entry(examSection).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamSectionExists(id))
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

        // POST: api/ExamSections
        [ResponseType(typeof(ExamSection))]
        public async Task<IHttpActionResult> PostExamSection(ExamSection examSection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ExamSections.Add(examSection);
            await db.SaveChangesAsync();

            return CreatedAtRoute("ExamSectionsApi", new { id = examSection.ExamSectionId }, examSection);
        }

        // DELETE: api/ExamSections/5
        [ResponseType(typeof(ExamSection))]
        public async Task<IHttpActionResult> DeleteExamSection(int id)
        {
            ExamSection examSection = await db.ExamSections.FindAsync(id);
            if (examSection == null)
            {
                return NotFound();
            }

            db.ExamSections.Remove(examSection);
            await db.SaveChangesAsync();

            return Ok(examSection);
        }


        public async Task<IHttpActionResult> Validate(int id, List<Answer> answers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ExamSection examSection = await db.ExamSections.FindAsync(id);


            if (examSection == null)
            {
                return NotFound();
            }

            /**
             * This is QUICK WAY OF VALIDATION BUT NOT RECOMMENDED
             * */

            // Validate input
            foreach (var question in examSection.Questions)
            {
                // Check for required questions
                if (question.Required)
                {
                    // Find the QuestionId in the answers
                    var answer = answers.Where(c => c.QuestionId == question.QuestionId).FirstOrDefault();
                    var hasError = (answer == null);
                    var errorKey = question.QuestionId.ToString();

                    // If the question has an answer then check the answer values
                    if (hasError == false)
                    {
                        if (!string.IsNullOrEmpty(answer.StringValue)
                            || answer.NumberValue.HasValue
                            || (answer.AnswerItems?.Count ?? 0) > 0)
                        {
                            // no action
                        }
                        else
                        {
                            hasError = true;
                        }
                    }

                    // Add error to model state if any
                    if (hasError)
                    {
                        ModelState.AddModelError(errorKey, "This question is required.");
                    }

                    // For question with choices
                    if (!hasError && question.QuestionType.Name == "multiple_choice")
                    {
                        var exists = question.QuestionOptions.Where(c => c.OptionChoiceId == answer.NumberValue).FirstOrDefault();

                        if (exists == null)
                        {
                            ModelState.AddModelError(errorKey, String.Format("{0} does not exists in the choices.", answer.NumberValue));
                        }
                    } else if (!hasError && question.QuestionType.Name == "checklist") {

                        // Prevent user from submitting option ids that are not in the choices
                        // in the question
                        var options = question.QuestionOptions.ToArray();
                        
                        foreach (var answerItem in answer.AnswerItems)
                        {
                            var foundItem = options.Where(w => w.OptionChoiceId == answerItem.NumberValue).FirstOrDefault();

                            if (foundItem == null)
                            {
                                ModelState.AddModelError(errorKey, String.Format("{0} does not exists in the choices.", answerItem.NumberValue));
                            }
                        }
                    }
                }
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(new { valid = true });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExamSectionExists(int id)
        {
            return db.ExamSections.Count(e => e.ExamSectionId == id) > 0;
        }
    }
}