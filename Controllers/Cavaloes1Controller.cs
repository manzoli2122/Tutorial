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
using Tutorial.Application;
using Tutorial.Models;
using Tutorial.Persistence;

namespace Tutorial.Controllers
{
    
    public class Cavaloes1Controller : ApiController
    {
        private Context db = new Context();

         
        private ICavaloService _cavaloService;




        public Cavaloes1Controller(  ICavaloService cavaloService)
        {            
            _cavaloService = cavaloService;
        }

         




        // GET: api/Cavaloes1
        public IQueryable<Cavalo> GetCavalos()
        {
            return _cavaloService.getDAO().GetAll();// db.Cavalos;
        }






        // GET: api/Cavaloes1/5
        [ResponseType(typeof(Cavalo))]
        public IHttpActionResult GetCavalo(int id)
        {
            //Cavalo cavalo = db.Cavalos.Find(id);

            Cavalo cavalo = _cavaloService.getDAO().Find(id);

            if (cavalo == null)
            {
                return NotFound();
            }

            return Ok(cavalo);
        }









        // PUT: api/Cavaloes1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCavalo(int id, Cavalo cavalo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cavalo.ID)
            {
                return BadRequest();
            }

            db.Entry(cavalo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CavaloExists(id))
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

        // POST: api/Cavaloes1
        [ResponseType(typeof(Cavalo))]
        public IHttpActionResult PostCavalo(Cavalo cavalo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cavalos.Add(cavalo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cavalo.ID }, cavalo);
        }

        // DELETE: api/Cavaloes1/5
        [ResponseType(typeof(Cavalo))]
        public IHttpActionResult DeleteCavalo(int id)
        {
            Cavalo cavalo = db.Cavalos.Find(id);
            if (cavalo == null)
            {
                return NotFound();
            }

            db.Cavalos.Remove(cavalo);
            db.SaveChanges();

            return Ok(cavalo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CavaloExists(int id)
        {
            return db.Cavalos.Count(e => e.ID == id) > 0;
        }
    }
}