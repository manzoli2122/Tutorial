using System.Collections.Generic;
using System.Linq;
using System.Web;  
using Microsoft.AspNet.Identity.Owin; 
using System.Data.Entity; 

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

        public long BuscarQuantidade()
        {
            return ContextManager.Set<TEntity>().LongCount();
        }
          
        public List<TEntity> Buscar()
        {
            return ContextManager.Set<TEntity>().ToList();
        }

        public List<TEntity> Buscar(int[] interval)
        {
            return ContextManager.Set<TEntity>().Skip(interval[0]).Take(interval[1] - interval[0]).ToList();
        }
         
        public IQueryable<TEntity> ConjuntoDeDados()
        {
            return ContextManager.Set<TEntity>();
        }
           
        public TEntity BuscarPeloId(int id)
        {
            return ContextManager.Set<TEntity>().Find(id);
        }

        public virtual int Salvar(TEntity entity)
        {
            ContextManager.Set<TEntity>().Add(entity); 
            return ContextManager.SaveChanges(); 
        }
         
        public virtual int Atualizar(TEntity entity)
        {
            ContextManager.Entry(entity).State = EntityState.Modified; 
            return ContextManager.SaveChanges(); 
        }
          
        public int Apagar(TEntity entity)
        { 
            ContextManager.Set<TEntity>().Remove(entity);
            return ContextManager.SaveChanges(); 
        }
         
        public void Dispose()
        {
            ContextManager.Dispose(); 
        }

        public abstract bool EntityExists(int id);
    }
}