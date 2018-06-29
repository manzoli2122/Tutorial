 using System.Collections.Generic;
using System.Linq; 
using Tutorial.Models;

namespace Tutorial.Persistence
{
    public class CavaloDAO : GenericDAO<Cavalo> , ICavaloDAO
    {
        public override bool EntityExists(int id)
        {
            return ConjuntoDeDados().Count(e => e.ID == id) >  0 ;
        }

        public List<Cavalo> GetCavalosAtivos()
        {
            return ConjuntoDeDados().Where(a => a.Ativo == true).OrderBy(a => a.Numero).ToList();
        }
         
        public List<Cavalo> GetCavalosInativos()
        {
            return ConjuntoDeDados().Where(a => a.Ativo == false).OrderBy(a => a.Numero).ToList();
        } 
    }
}