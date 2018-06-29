using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Tutorial.Persistence
{
    public interface IGenericDAO<TEntity>
    {

        long retrieveCount();
         
         
        List<TEntity> retrieveAll();


        IQueryable<TEntity> GetAll();

        
        List<TEntity> retrieveSome(int[] interval);
         

        TEntity retrieveById(long id);


        TEntity Find(int id);


        int Save(TEntity entity);

        
        int Delete(TEntity entity);


        int Update(TEntity entity);


        //DbSet<TEntity> ConjutoDeDados();




        // long retrieveFilteredCount(Filter<?> filter, String value);

        //List<T> retrieveWithFilter(Filter<?> filter, String value);

        // List<T> retrieveSomeWithFilter(Filter<?> filter, String value, int[] interval);
    }
}