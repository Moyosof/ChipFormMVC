using System.Linq.Expressions;

namespace ChipsForm.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Add a new instance of an entity to DB
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task Add(T entity);

        Task AddRange(IList<T> entity);

        /// <summary>
        /// Get all objects from DB
        /// </summary>
        /// <returns></returns>
        IQueryable<T> ReadAllQuery();

        Task<IEnumerable<T>> ReadAll();

        /// <summary>
        /// Asynchronous method to get element by ID
        /// </summary>
        /// <param name="EntityId"></param>
        /// <returns></returns>
        Task<T> ReadSingle(Guid EntityId);

        /// <summary>
        /// Update an Entity
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        void Update(T Entity);

        void UpdateRange(IList<T> entities);

        /// <summary>
        /// Delete an object from DB
        /// </summary>
        /// <param name="EntityId"></param>
        /// <returns></returns>
        Task Delete(Guid EntityId);
        /// <summary>
        /// Delete an object from DB
        /// </summary>
        /// <param name="Entity"></param>
        void DeleteEntity(T Entity);

        void DeleteRange(IList<T> entity);

        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
    }
}
