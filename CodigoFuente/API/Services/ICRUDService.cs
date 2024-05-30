﻿using  API.DataSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API.Services
{
    public interface ICRUDService<T>
    {
        IEnumerable<T> GetAll();

        Task<T> GetByID(int id);

        Task Add(T genericClass);

        Task Delete(int id);

        Task Update(T genericClass);

        Task<IEnumerable<T>> GetByParam(Expression<Func<T, bool>> where);


    }
}