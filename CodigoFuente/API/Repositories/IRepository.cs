﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace rsAPIElevador.Repositories
{
    public interface IRepository<T> :IDisposable where T : class
    {
        IQueryable<T> AllAsNoTracking();

        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expr);

        Task<T> Find(Guid id);
        
        Task<T> Find(int id);

        Task Add(T entity);

        Task AddWithImage(T entity);

        Task Delete(Guid Id);

        Task Delete(int Id);

        Task Update(T entity);

        Task<IEnumerable<TResult>> GetAllDTO<TResult>(Expression<Func<T, bool>>? criterio, Expression<Func<T, TResult>>? selector, bool? orderbydescendin, int? page, int? limit, params Expression<Func<T, Object>>[]? order) where TResult : class;

        public int Count(Expression<Func<T, bool>> criterio);

    }
}