using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tutorial.Models;

namespace Tutorial.Persistence
{
    public class CavaloDAO : GenericDAO<Cavalo> , ICavaloDAO
    {

        public List<Cavalo> GetCavalosAtivos()
        {
            return ConjutoDeDados().Where(a => a.Ativo == true).OrderBy(a => a.Numero).ToList();
        }

        public List<Cavalo> GetCavalosInativos()
        {
            return ConjutoDeDados().Where(a => a.Ativo == false).OrderBy(a => a.Numero).ToList();
        }


    }
}