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
        void ValidarCriacao(TEntity entity); 
        void ValidarAtualizacao(TEntity entity);   
        void ValidarExclusao(TEntity entity);   
        void Salvar(TEntity entity); 
        TEntity BuscarPeloId(int id); 
        void Atualizar(TEntity entity);  
        void Apagar(TEntity entity);  
        IGenericDAO<TEntity> getDAO();  
        void Autorizar();  
        long BuscarQuantidade();  
        List<TEntity> Buscar(int[] interval);
        List<TEntity> Buscar( );
        IQueryable<TEntity> ConjuntoDeDados();
    }
} 