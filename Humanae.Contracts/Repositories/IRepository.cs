using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Humanae.Contracts.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Obtener primero
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>Retorna primer registro que cumpla con la condicion expresada</returns>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Obtener  entidad 
        /// </summary>
        /// <returns>Devuelve la lista de registros de la entidad.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Método para agregar una entidad
        /// </summary>
        /// <param name="entity">Entidad agreagda</param>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// Método para actualizar una entidad
        /// </summary>
        /// <param name="entity">Entidad actualizada</param>
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
        DbSet<TEntity> Entity();
    }
}
