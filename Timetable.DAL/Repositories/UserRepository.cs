using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Entities;
using Timetable.DAL.Repositories.Interfaces;

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

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where, int page, int pageSize)
        {
            return DbContext.Set<T>()
                .Where(where)
                .OrderBy(t => t.UserId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public T GetUserByName(string firstName, string fathersName, string lastName)
        {

            return DbContext.Set<T>().FirstOrDefault(t => t.FirstName.ToLower() == firstName.ToLower()
                && t.FathersName.ToLower() == fathersName.ToLower() && t.LastName.ToLower() == lastName.ToLower());
        }
    }

    
}
