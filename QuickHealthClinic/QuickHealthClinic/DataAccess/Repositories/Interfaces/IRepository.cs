﻿using System.Linq.Expressions;

namespace QuickLifeCoachingClinic.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null);
        Task<T?> GetAsync(int id);
        Task<T?> GetAsync(
        Expression<Func<T, bool>>? filter = null,
        string? includeProperties = null);
        Task AddAsync(T entity);
        void Modify(T entity);
        void Remove(T entity);

        void SetModified(T entity);
    }
}
