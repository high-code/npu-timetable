using System;
using System.Collections.Generic;
using System.Linq;
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

        public Faculty GetFacultyByName(string facultyName)
        {
            return this.DbContext.Faculties.Where(f => f.FacultyName == facultyName).FirstOrDefault();
        }
    }

   
}
