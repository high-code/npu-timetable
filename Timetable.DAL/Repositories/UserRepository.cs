using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Entities;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.DAL.Specifications;
namespace Timetable.DAL.Repositories
{
    public abstract class UserRepository<T> : RepositoryBase<T>, IUserRepository<T> where T : User
    {
        public UserRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }

         
        public virtual T GetUserByUsername(string username)
        {
            return DbContext.Set<T>().FirstOrDefault(t => t.UserName == username);
        }
         

        public T GetUserByName(string firstName, string fathersName, string lastName)
        {

            return DbContext.Set<T>().FirstOrDefault(t => t.FirstName.ToLower() == firstName.ToLower()
                && t.FathersName.ToLower() == fathersName.ToLower() && t.LastName.ToLower() == lastName.ToLower());
        }

        public virtual IEnumerable<T> List(IPagedSpecification<T> specification)
        {
            var query = RepositoryHelper.MakeIncludesQuery(specification, DbContext.Set<T>());

            return query
                .Where(specification.Criteria)
                .OrderBy(t => t.UserId)
                .Skip((specification.PageNumber - 1) * specification.PageSize)
                .Take(specification.PageSize)
                .ToList();
        }

    }

    
}
