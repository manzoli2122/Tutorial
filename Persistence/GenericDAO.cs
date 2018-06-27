using System;

using System.Collections.Generic;
using System.Linq;
using System.Web; 
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Host.SystemWeb;
using System.Web.Mvc;
using Tutorial.Persistence;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Tutorial.Persistence
{
    public abstract class GenericDAO<TEntity> : IGenericDAO<TEntity> where TEntity : class
    {


        private Context _context;
        protected Context ContextManager
        {
            get
            {
                return _context ?? HttpContext.Current.GetOwinContext().Get<Context>();
            }

        }




        public long retrieveCount()
        {
            return ContextManager.Set<TEntity>().LongCount();
        }



        public List<TEntity> retrieveAll()
        {
            return ContextManager.Set<TEntity>().ToList();
        }



        public IQueryable<TEntity> GetAll()
        {
            return ContextManager.Set<TEntity>();
        }



        public List<TEntity> retrieveSome(int[] interval)
        {
            return ContextManager.Set<TEntity>().Skip( interval[0]).Take(interval[1] - interval[0]).ToList();
        }



        public TEntity retrieveById(long id)
        {
            return ContextManager.Set<TEntity>().Find(id);
        }



        public TEntity Find(int id)
        {
            return ContextManager.Set<TEntity>().Find(id);
        }

         

        public virtual Task<int> Save(TEntity entity)
        {
            ContextManager.Set<TEntity>().Add(entity); 
            return ContextManager.SaveChangesAsync(); 
        }

          

        public virtual Task<int> Update(TEntity entity)
        {
            ContextManager.Entry(entity).State = EntityState.Modified; 
            return ContextManager.SaveChangesAsync(); 
        }
         
          

        public Task<int> Delete(TEntity entity)
        { 
            ContextManager.Set<TEntity>().Remove(entity);
            return ContextManager.SaveChangesAsync(); 
        }

         


        /*

        public DbSet<TEntity> ConjutoDeDados()
        {
            return ContextManager.Set<TEntity>();

        }

        */



        public void Dispose()
        {
            ContextManager.Dispose();

        }

          

    }
}