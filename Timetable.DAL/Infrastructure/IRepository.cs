using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Timetable.DAL.Specifications;

namespace Timetable.DAL.Infrastructure
{
    public interface IRepository<T> where T : class
    {

        int Count(Expression<Func<T, bool>> where);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(Expression<Func<T, bool>> where);

        T GetById(int id);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetMany(ISpecification<T> specification);

        

    }
}
