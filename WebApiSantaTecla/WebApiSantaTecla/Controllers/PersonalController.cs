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
using WebApiSantaTecla.Models;

namespace WebApiSantaTecla.Controllers
{
    public class PersonalController : ApiController
    {
        private PersonalDbContext db = new PersonalDbContext();

        // GET: api/Personal
        public IQueryable<Personal> GetPersonal()
        {
            return db.Personal;
        }

        // GET: api/Personal/5
        [ResponseType(typeof(Personal))]
        public async Task<IHttpActionResult> GetPersonal(int id)
        {
            Personal personal = await db.Personal.FindAsync(id);
            if (personal == null)
            {
                return NotFound();
            }

            return Ok(personal);
        }

        // PUT: api/Personal/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPersonal(int id, Personal personal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personal.Id)
            {
                return BadRequest();
            }

            db.Entry(personal).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalExists(id))
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

        // POST: api/Personal
        [ResponseType(typeof(Personal))]
        public async Task<IHttpActionResult> PostPersonal(Personal personal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Personal.Add(personal);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = personal.Id }, personal);
        }

        // DELETE: api/Personal/5
        [ResponseType(typeof(Personal))]
        public async Task<IHttpActionResult> DeletePersonal(int id)
        {
            Personal personal = await db.Personal.FindAsync(id);
            if (personal == null)
            {
                return NotFound();
            }

            db.Personal.Remove(personal);
            await db.SaveChangesAsync();

            return Ok(personal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonalExists(int id)
        {
            return db.Personal.Count(e => e.Id == id) > 0;
        }
    }
}