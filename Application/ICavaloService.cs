using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Models;

namespace Tutorial.Application
{
    public interface ICavaloService
    {


        bool Cadastrar(Cavalo cavalo);

        IQueryable<Cavalo> GetCavalos();
    }
}
