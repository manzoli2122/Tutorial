using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net; 
using System.Web.Http;
using System.Web.Http.Description;
using Tutorial.Application;
using Tutorial.Models;

namespace Tutorial.Controllers
{
    
    public class CavaloesApiController : ApiController
    {
      
        private ICavaloService _cavaloService;
         
        public CavaloesApiController(  ICavaloService cavaloService)
        {            
            _cavaloService = cavaloService;
        }
         
        // GET: api/CavaloesApi
        public IQueryable<Cavalo> GetCavalos()
        {
            return _cavaloService.ConjuntoDeDados(); 
        }
         
        // GET: api/CavaloesApi/5
        [ResponseType(typeof(Cavalo))]
        public IHttpActionResult GetCavalo(int id)
        { 
            Cavalo cavalo = _cavaloService.BuscarPeloId(id); 
            if (cavalo == null)
            {
                return NotFound();
            } 
            return Ok(cavalo);
        }

        // PUT: api/CavaloesApi/5
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
            try
            {
                _cavaloService.Atualizar(cavalo); 
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
            _cavaloService.Salvar(cavalo);
            return CreatedAtRoute("DefaultApi", new { id = cavalo.ID }, cavalo);
        }

        // DELETE: api/Cavaloes1/5
        [ResponseType(typeof(Cavalo))]
        public IHttpActionResult DeleteCavalo(int id)
        {
            Cavalo cavalo = _cavaloService.BuscarPeloId(id);
            if (cavalo == null)
            {
                return NotFound();
            }
            _cavaloService.Apagar(cavalo);
            return Ok(cavalo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CavaloExists(int id)
        {
            return _cavaloService.EntityExists(id) ;
        }
    }
}