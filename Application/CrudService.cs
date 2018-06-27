using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tutorial.Persistence;

namespace Tutorial.Application
{
    public abstract class CrudService<TEntity> : ICrudService<TEntity> where TEntity : class
    {


        public abstract IGenericDAO<TEntity> getDAO();


         

        public void authorize()
        {
             
        }


        protected TEntity validate(TEntity newEntity, TEntity oldEntity)
        { 
            return newEntity;
        }




        public long count()
        {
            return getDAO().retrieveCount(); 
        }



        public void create(TEntity entity)
        {
            entity = validate(entity, null);
             
            getDAO().Save(entity); 

        }



        public void delete(TEntity entity)
        { 
            if (entity != null)
            { 
                getDAO().Delete(entity); 
            }
        }

        

        public List<TEntity> list(int[] interval)
        {
            List<TEntity> entities = getDAO().retrieveSome(interval); 
            return entities;
        }



        public TEntity retrieve(long id)
        {
            TEntity entity = getDAO().retrieveById(id); 
            return entity;
        }



        public void update(TEntity entity)
        {
            entity = validate(entity, null );
             
            getDAO().Save(entity);

        }




        public void validateCreate(TEntity entity)
        {
             
        }



        public void validateDelete(TEntity entity)
        {
             
        }



        public void validateUpdate(TEntity entity)
        {
             
        }
    }
}