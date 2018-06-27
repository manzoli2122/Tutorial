using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Tutorial.Application;
using Tutorial.Models;
using Tutorial.Persistence;

namespace Tutorial.Controllers
{
    public class CavaloesController : Controller
    {
        //private Context db = new Context();


        //private CavaloDAO db = new ICavaloDAO();

        private ICavaloDAO _db ;
        private ICavaloService _cavaloService;

        public CavaloesController(ICavaloDAO db, ICavaloService cavaloService)
        {
            _db = db;
            _cavaloService = cavaloService;
        }


        


        // GET: Cavaloes
        public ActionResult Index()
        {
            return View(_cavaloService.getDAO().retrieveAll()); 
        }

        // GET: Cavaloes/Details/5
        /*public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cavalo cavalo = db.Cavalos.Find(id);
            if (cavalo == null)
            {
                return HttpNotFound();
            }
            return View(cavalo);
        }
        */


        // GET: Cavaloes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cavaloes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create(Cavalo cavalo)
        public ActionResult  Create(Cavalo cavalo)
        {
            if (ModelState.IsValid)
            {
                cavalo.Ativo = true;


                 _db.Save(cavalo);


                // _cavaloService.create(cavalo);


                return RedirectToAction("Index");


                //_db.Cavalos.Add(cavalo);
                //_db.SaveChanges();
                //return RedirectToAction("Index");
            }

            return View(cavalo);
        }






        /*
        // GET: Cavaloes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cavalo cavalo = db.Cavalos.Find(id);
            if (cavalo == null)
            {
                return HttpNotFound();
            }
            return View(cavalo);
        }

        // POST: Cavaloes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Nascimento,Numero,Ativo")] Cavalo cavalo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cavalo).State = EntityState.Modified;
                db.SaveChanges();
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
            Cavalo cavalo = db.Cavalos.Find(id);
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
            Cavalo cavalo = db.Cavalos.Find(id);
            db.Cavalos.Remove(cavalo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    */
    }
}
