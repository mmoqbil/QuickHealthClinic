using Microsoft.EntityFrameworkCore;
using QuickLifeCoachingClinic.DataAccess.DbContexts;
using QuickLifeCoachingClinic.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace QuickLifeCoachingClinic.DataAccess.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly QuickLifeCoachingClinicContext Context;
        protected DbSet<T> DbSet;
        protected Repository(QuickLifeCoachingClinicContext context)
        {
            Context = context;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        string? includeProperties = null)
        {
            IQueryable<T> query = DbSet;

            if (filter is not null) query = query.Where(filter);

            if (!string.IsNullOrWhiteSpace(includeProperties))
                query = includeProperties
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Aggregate(query, (current, includeProperty) =>
                        current.Include(includeProperty));

            if (orderBy is not null) query = orderBy(query);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<T?> GetAsync(
        Expression<Func<T, bool>>? filter = null,
        string? includeProperties = null)
        {
            IQueryable<T> query = DbSet;

            if (filter is not null) query = query.Where(filter);

            if (!string.IsNullOrWhiteSpace(includeProperties))
                query = includeProperties
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Aggregate(query, (current, includeProperty) =>
                        current.Include(includeProperty));

            return await query.FirstOrDefaultAsync();
        }

        public async Task AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
        }

        public void Modify(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
