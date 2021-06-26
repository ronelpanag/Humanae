using Humanae.Contracts.Repositories;
using Humanae.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Humanae.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext Context = new ApplicationDbContext();

        /// <summary>
        /// Método para agregar una entidad
        /// </summary>
        /// <param name="entity">Entidad agreagda</param>
        public async Task AddAsync(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            await Context.SaveChangesAsync();
        }

        /// <summary>
        /// Método para agregar una lista de entidades
        /// </summary>
        /// <param name="entities">lista de entidades agreagdas</param>
        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
            await Context.SaveChangesAsync();
        }

        /// <summary>
        /// Obtener  entidad con predicado
        /// </summary>
        /// <param name="predicate">filtros para la búsqueda</param>
        /// <returns>Devuelve el primere registro la entidad.</returns>
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity> FirstOrDefaultAsync()
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync();
        }

        /// <summary>
        /// Método para actualizar una entidad
        /// </summary>
        /// <param name="entity">Entidad actualizada</param>
        public async Task UpdateAsync(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().UpdateRange(entities);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().AnyAsync(predicate);
        }

        public DbSet<TEntity> Entity()
        {
            return Context.Set<TEntity>();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsync();
        }
    }
}
