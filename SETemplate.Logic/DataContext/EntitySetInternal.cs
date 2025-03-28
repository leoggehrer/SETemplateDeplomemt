//@BaseCode
namespace SETemplate.Logic.DataContext
{
    partial class EntitySet<TEntity>
    {
        #region methods
        /// <summary>
        /// Creates a new instance of the entity.
        /// </summary>
        /// <returns>A new instance of the entity.</returns>
        internal virtual TEntity CreateInternal()
        {
            return new TEntity();
        }

        /// <summary>
        /// Returns the count of entities in the set.
        /// </summary>
        /// <returns>The count of entities.</returns>
        internal virtual int CountInternal()
        {
            return DbSet.Count();
        }

        /// <summary>
        /// Returns the count of entities in the set asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the count of entities.</returns>
        internal virtual Task<int> CountInternalAsync()
        {
            return DbSet.CountAsync();
        }

        /// <summary>
        /// Gets the queryable set of entities.
        /// </summary>
        /// <returns>An <see cref="IQueryable{TEntity}"/> that can be used to query the set of entities.</returns>
        internal virtual IQueryable<TEntity> AsQuerySetInternal() => DbSet.AsQueryable();

        /// <summary>
        /// Adds the specified entity to the set.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity.</returns>
        internal virtual TEntity AddInternal(TEntity entity)
        {
            BeforeAdding(entity);
            return DbSet.Add(entity).Entity;
        }

        /// <summary>
        /// Asynchronously adds the specified entity to the set.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the added entity.</returns>
        internal virtual async Task<TEntity> AddInternalAsync(TEntity entity)
        {
            BeforeAdding(entity);
            var result = await DbSet.AddAsync(entity).ConfigureAwait(false);

            return result.Entity;
        }

        /// <summary>
        /// Updates the specified entity in the set.
        /// </summary>
        /// <param name="id">The identifier of the entity to update.</param>
        /// <param name="entity">The entity with updated values.</param>
        /// <returns>The updated entity, or null if the entity was not found.</returns>
        internal virtual TEntity? UpdateInternal(int id, TEntity entity)
        {
            BeforeUpdating(entity);

            var existingEntity = DbSet.Find(id);
            if (existingEntity != null)
            {
                CopyProperties(existingEntity, entity);
            }
            return existingEntity;
        }

        /// <summary>
        /// Asynchronously updates the specified entity in the set.
        /// </summary>
        /// <param name="id">The identifier of the entity to update.</param>
        /// <param name="entity">The entity with updated values.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the updated entity, or null if the entity was not found.</returns>
        internal virtual async Task<TEntity?> UpdateInternalAsync(int id, TEntity entity)
        {
            BeforeUpdating(entity);

            var existingEntity = await DbSet.FindAsync(id).ConfigureAwait(false);
            if (existingEntity != null)
            {
                CopyProperties(existingEntity, entity);
            }
            return existingEntity;
        }

        /// <summary>
        /// Removes the entity with the specified identifier from the set.
        /// </summary>
        /// <param name="id">The identifier of the entity to remove.</param>
        /// <returns>The removed entity, or null if the entity was not found.</returns>
        internal virtual TEntity? RemoveInternal(int id)
        {
            var entity = DbSet.Find(id);

            if (entity != null)
            {
                BeforeRemoving(entity);
                DbSet.Remove(entity);
            }
            return entity;
        }
        #endregion methods
    }
}
