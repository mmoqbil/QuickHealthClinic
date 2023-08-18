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
        public Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }
    }
}
