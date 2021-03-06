﻿using System;
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
    public class ExamsController : BaseApiController
    {
        // GET: api/Exams
        public IQueryable<Exam> GetExams()
        {
            db.Exams.Include(
                e => e.Sections.Select(
                    s => s.Questions.Select(
                        q => q.OptionGroups.Select(
                            og => og.OptionChoices
                        )
                    )
                )
            );


            db.Exams.Include(
                e => e.Sections.Select(
                    s => s.Questions.Select(
                        q => q.QuestionOptions.Select(
                                oc => oc.OptionChoice
                            )
                    )
                )
            );

            return db.Exams
                .Include(
                    e => e.Sections.Select( 
                        s => s.Questions.Select(
                            q => q.QuestionType
                        )
                    )
                )
           ;
        }

        // GET: api/Exams/5
        [ResponseType(typeof(Exam))]
        public async Task<IHttpActionResult> GetExam(int id)
        {
            Exam exam = await db.Exams.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }

            return Ok(exam);
        }

        // PUT: api/Exams/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutExam(int id, Exam exam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exam.ExamId)
            {
                return BadRequest();
            }

            db.Entry(exam).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamExists(id))
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

        // POST: api/Exams
        [ResponseType(typeof(Exam))]
        public async Task<IHttpActionResult> PostExam(Exam exam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Exams.Add(exam);
            await db.SaveChangesAsync();

            return CreatedAtRoute("ExamsApi", new { id = exam.ExamId }, exam);
        }

        // DELETE: api/Exams/5
        [ResponseType(typeof(Exam))]
        public async Task<IHttpActionResult> DeleteExam(int id)
        {
            Exam exam = await db.Exams.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }

            db.Exams.Remove(exam);
            await db.SaveChangesAsync();

            return Ok(exam);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExamExists(int id)
        {
            return db.Exams.Count(e => e.ExamId == id) > 0;
        }
    }
}