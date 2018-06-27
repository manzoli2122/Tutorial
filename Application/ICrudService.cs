using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Persistence;

namespace Tutorial.Application
{
    public interface ICrudService<TEntity>
    {
         

        void validateCreate(TEntity entity); // throws CrudException;


        void validateUpdate(TEntity entity); // throws CrudException;


        void validateDelete(TEntity entity); // throws CrudException;

        
        void create(TEntity entity);


        TEntity retrieve(long id);

         
        void update(TEntity entity);

         
        void delete(TEntity entity);

          
        IGenericDAO<TEntity> getDAO();

         
        void authorize();

         
        long count();

        
         
        List<TEntity> list(int[] interval);


        //List<T> filter(Filter<?> filter, String filterParam, int ... interval);


        //T fetchLazy(T entity);


        //long countFiltered(Filter<?> filterType, String filter);

         

    }
}
