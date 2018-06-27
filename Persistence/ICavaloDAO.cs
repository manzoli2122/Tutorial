using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Models;

namespace Tutorial.Persistence
{
    public interface ICavaloDAO : IGenericDAO<Cavalo>
    {


        List<Cavalo> GetCavalosAtivos();

         
        List<Cavalo> GetCavalosInativos();


    }
}
