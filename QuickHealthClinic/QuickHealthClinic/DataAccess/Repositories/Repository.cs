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


            return await query.AsNoTracking().ToListAsync();
        }
}
