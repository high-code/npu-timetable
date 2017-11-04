using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.DAL.Entities;
using Timetable.DAL.Specifications;
namespace Timetable.DAL.Repositories
{
    public class ClassroomRepository : RepositoryBase<Classroom>, IClassroomRepository
    {
        public ClassroomRepository(IDbFactory dbFactory) : base(dbFactory)
        { }


        public override Classroom GetById(int id)
        {
            return DbContext.Classrooms
                .Include(c => c.Building)
                .FirstOrDefault(c => c.ClassroomId == id);
        }


        public override IEnumerable<Classroom> GetAll()
        {
            return DbContext.Classrooms
                .Include(c => c.Building);
        }


        public IEnumerable<Classroom> List(IPagedSpecification<Classroom> specification)
        {
            var query = RepositoryHelper.MakeIncludesQuery(specification, DbContext.Classrooms);

            return query
                .Where(specification.Criteria)
                .OrderBy(c => c.ClassroomId)
                .Skip((specification.PageNumber - 1) * specification.PageSize)
                .Take(specification.PageSize)
                .ToList();
        }

        




        
    }

   
}
