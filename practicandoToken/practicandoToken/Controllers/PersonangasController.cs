using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using practicandoToken.Models;

namespace practicandoToken.Controllers
{
    public class PersonangasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Personangas
        [Authorize]
        public IQueryable<Personanga> GetPersonangas()
        {
            return db.Personangas;
        }

        // GET: api/Personangas/5
        [Authorize]
        [ResponseType(typeof(Personanga))]
        public IHttpActionResult GetPersonanga(int id)
        {
            Personanga personanga = db.Personangas.Find(id);
            if (personanga == null)
            {
                return NotFound();
            }

            return Ok(personanga);
        }

        // PUT: api/Personangas/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonanga(int id, Personanga personanga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personanga.PersonId)
            {
                return BadRequest();
            }

            db.Entry(personanga).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonangaExists(id))
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

        // POST: api/Personangas
        [Authorize]
        [ResponseType(typeof(Personanga))]
        public IHttpActionResult PostPersonanga(Personanga personanga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Personangas.Add(personanga);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personanga.PersonId }, personanga);
        }

        // DELETE: api/Personangas/5
        [Authorize]
        [ResponseType(typeof(Personanga))]
        public IHttpActionResult DeletePersonanga(int id)
        {
            Personanga personanga = db.Personangas.Find(id);
            if (personanga == null)
            {
                return NotFound();
            }

            db.Personangas.Remove(personanga);
            db.SaveChanges();

            return Ok(personanga);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonangaExists(int id)
        {
            return db.Personangas.Count(e => e.PersonId == id) > 0;
        }
    }
}