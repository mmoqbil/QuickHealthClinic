using Microsoft.EntityFrameworkCore;
using QuickHealthClinic.DataAccess.DbContexts;
using QuickHealthClinic.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace QuickHealthClinic.DataAccess.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly QuickHealthClinicContext Context;
        protected DbSet<T> DbSet;
        protected Repository(QuickHealthClinicContext context)
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


    }
}
