using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Tutorial.Persistence
{
    public interface InterfaceDAO<TEntity>
    {

        Task<int> Save(TEntity entity);


        Task<int> Delete(TEntity entity);


        Task<int> Update(TEntity entity);


        IQueryable<TEntity> GetAll();

        //DbSet<TEntity> ConjutoDeDados();
    }
}