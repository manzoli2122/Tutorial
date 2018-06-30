using System.Net;
using System.Web.Mvc;
using Tutorial.Application;
using Tutorial.Models; 

namespace Tutorial.Controllers
{
    public class CavaloesController : Controller
    { 

        private ICavaloService _cavaloService;

        public CavaloesController( ICavaloService cavaloService )
        { 
            _cavaloService = cavaloService;
        } 



        // GET: Cavaloes
        public ActionResult Index()
        {
            return View( _cavaloService.Buscar() ); 
        }


        // GET: Cavaloes
        public ActionResult Datatable()
        {
            return View(_cavaloService.Buscar());
        }

        // GET: Cavaloes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cavalo cavalo = _cavaloService.BuscarPeloId((int)id);
            if (cavalo == null)
            {
                return HttpNotFound();
            }
            return View(cavalo);
        }
         
        // GET: Cavaloes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cavaloes/Create 
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public ActionResult  Create(Cavalo cavalo)
        {
            if (ModelState.IsValid)
            { 
                _cavaloService.Salvar(cavalo); 
                return RedirectToAction("Index"); 
            } 
            return View(cavalo);
        } 
        
        // GET: Cavaloes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cavalo cavalo = _cavaloService.BuscarPeloId((int)id);
            if (cavalo == null)
            {
                return HttpNotFound();
            }
            return View(cavalo);
        } 
        
        // POST: Cavaloes/Edit/5 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Cavalo cavalo)
        {
            if (ModelState.IsValid)
            {
                _cavaloService.Atualizar(cavalo);
                return RedirectToAction("Index"); 
            }
            return View(cavalo);
        } 

        // GET: Cavaloes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cavalo cavalo = _cavaloService.BuscarPeloId((int)id);
            if (cavalo == null)
            {
                return HttpNotFound();
            }
            return View(cavalo);
        } 
        
        // POST: Cavaloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cavalo cavalo = _cavaloService.BuscarPeloId(id);
            _cavaloService.Apagar(cavalo); 
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               // _cavaloService.Dispose();
            }
            base.Dispose(disposing);
        } 
    }
}
