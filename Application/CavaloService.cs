using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tutorial.Models;
using Tutorial.Persistence;

namespace Tutorial.Application
{

    // [Authorize]
    public class CavaloService : CrudService<Cavalo> , ICavaloService
    {



        private ICavaloDAO _db;


        public CavaloService(ICavaloDAO db)
        {
            _db = db;
        }



        public override IGenericDAO<Cavalo> getDAO()
        {
            return _db;
        }




        public bool Cadastrar(Cavalo cavalo)
        {

            _db.Save(cavalo);
                        
            return true;
        }


        public IQueryable<Cavalo> GetCavalos()
        {
            //return null;
            return _db.GetAll();
        }



        public Cavalo GetCavalo(int id)
        {
            Cavalo cavalo = _db.Find(id);
            return cavalo; 
        }

        
    }
}