using System.Collections.Generic; 
using Tutorial.Models;
using Tutorial.Persistence;

namespace Tutorial.Application
{ 
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

        public List<Cavalo> GetCavalosAtivos()
        {
            return _db.GetCavalosAtivos();
        }

        public List<Cavalo> GetCavalosInativos()
        {
            return _db.GetCavalosInativos();
        }
         
    }
}