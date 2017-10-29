using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories.Interfaces;
namespace Timetable.DAL.Repositories
{
    public class FacultyRepository : RepositoryBase<Faculty>, IFacultyRepository
    {
        public FacultyRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }


        public IEnumerable<Faculty> GetMany(Expression<Func<Faculty, bool>> where, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Faculty GetFacultyByName(string facultyName)
        {
            return this.DbContext.Faculties.Where(f => f.FacultyName == facultyName).FirstOrDefault();
        }
    }

   
}
