 using System.Collections.Generic; 
using Tutorial.Models;

namespace Tutorial.Application
{
    public interface ICavaloService : ICrudService<Cavalo>
    { 
        List<Cavalo> GetCavalosAtivos();
        List<Cavalo> GetCavalosInativos(); 
    }
}
