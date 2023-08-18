using QuickHealthClinic.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace QuickHealthClinic.DataAccess.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        public Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }
    }
}
