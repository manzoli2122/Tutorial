 
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq; 
 
namespace Tutorial.Persistence
{
    public interface IGenericDAO<TEntity>
    { 
        long BuscarQuantidade(); 
        List<TEntity> Buscar();
        List<TEntity> Buscar(int[] interval);
        TEntity BuscarPeloId(int id);
        IQueryable<TEntity> ConjuntoDeDados();   
        int Salvar(TEntity entity); 
        int Apagar(TEntity entity); 
        int Atualizar(TEntity entity); 
    }
}