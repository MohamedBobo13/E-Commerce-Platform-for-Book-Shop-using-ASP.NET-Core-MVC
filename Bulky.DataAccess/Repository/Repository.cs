using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bulky.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>(); // Initialize DbSet for the generic type T
        }

        public void Add(T entity)
        {
            dbSet.Add(entity); // Add a new entity to the DbSet
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity); // Remove a specific entity from the DbSet
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperty = null, bool tracked = false)
        {
            IQueryable<T> query;

            // Determine whether to track the entity
            if (tracked)
            {
                query = dbSet;
            }
            else
            {
                query = dbSet.AsNoTracking();
            }

            query = query.Where(filter); // Apply the filter

            // Include related properties if specified
            if (!string.IsNullOrEmpty(includeProperty))
            {
                foreach (var property in includeProperty.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }

            return query.FirstOrDefault(); // Return the first matching entity or null
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter, string? includeProperty = null)
        {
            IQueryable<T> query = dbSet;

            // Apply filter if provided
            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Include related properties if specified
            if (!string.IsNullOrEmpty(includeProperty))
            {
                foreach (var property in includeProperty.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }

            return query.ToList(); // Return the list of matching entities
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities); // Remove a range of entities from the DbSet
        }
    }
}
