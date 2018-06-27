using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tutorial.Models;
using Tutorial.Persistence;

namespace Tutorial.Application
{
    public class CavaloService : ICavaloService
    {



        private ICavaloDAO _db;


        public CavaloService(ICavaloDAO db)
        {
            _db = db;
        }


        public bool Cadastrar(Cavalo cavalo)
        {

            _db.Save(cavalo);
                        
            return true;
        }


        public IQueryable<Cavalo> GetCavalos()
        { 
            return _db.GetAll();
        }



    }
}