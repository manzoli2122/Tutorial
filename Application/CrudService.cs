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
          
        public void Autorizar() {  }
         
        protected TEntity Validar(TEntity newEntity, TEntity oldEntity)
        { 
            return newEntity;
        }
         
        public long BuscarQuantidade()
        {
            return getDAO().BuscarQuantidade(); 
        }
         
        public void Salvar(TEntity entity)
        {
            entity = Validar(entity, null); 
            getDAO().Salvar(entity);  
        }
         
        public void Apagar(TEntity entity)
        { 
            if (entity != null)
            { 
                getDAO().Apagar(entity); 
            }
        }
         
        public List<TEntity> Buscar(int[] interval)
        {
            List<TEntity> entities = getDAO().Buscar(interval); 
            return entities;
        }

        public List<TEntity> Buscar( )
        {
            List<TEntity> entities = getDAO().Buscar( );
            return entities;
        }

        public IQueryable<TEntity> ConjuntoDeDados()
        {
            return getDAO().ConjuntoDeDados();
        }

        public TEntity BuscarPeloId(int id)
        {
            TEntity entity = getDAO().BuscarPeloId(id); 
            return entity;
        }
         
        public void Atualizar(TEntity entity)
        {
            entity = Validar(entity, null ); 
            getDAO().Atualizar(entity); 
        }
         
        public void ValidarCriacao(TEntity entity){  }
         
        public void ValidarExclusao(TEntity entity){ }
         
        public void ValidarAtualizacao(TEntity entity){ }

        public bool EntityExists(int id)
        {
            return getDAO().EntityExists(id);
        }
    }
}