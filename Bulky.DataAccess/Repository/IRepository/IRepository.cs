using System.Linq.Expressions;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        // Retrieves all entities based on the optional filter and include properties
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperty = null);

        // Retrieves a single entity based on the filter, optional include properties, and tracking behavior
        T Get(Expression<Func<T, bool>> filter, string? includeProperty = null, bool tracked = false);

        // Adds a new entity to the repository
        void Add(T entity);

        // Removes a specific entity from the repository
        void Remove(T entity);

        // Removes a range of entities from the repository
        void RemoveRange(IEnumerable<T> entities);
    }
}
