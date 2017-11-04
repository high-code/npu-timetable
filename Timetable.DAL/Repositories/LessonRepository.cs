using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.DAL.Specifications;
using System.Linq.Expressions;

namespace Timetable.DAL.Repositories
{
    public class LessonsRepository : RepositoryBase<Lesson>, ILessonRepository
    {
        public LessonsRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }

        
        public override Lesson GetById(int id)
        {
            
            return DbContext.Lessons
                .Include(l => l.AcademicGroup)
                .Include(l => l.Classroom)
                .Include(l => l.Faculty)
                .Include(l => l.Subject)
                .FirstOrDefault(l => l.Id == id);
        }


        public IEnumerable<Lesson> List(IPagedSpecification<Lesson> specification)
        {
            var query = RepositoryHelper.MakeIncludesQuery(specification, DbContext.Lessons);

            return query
                .Where(specification.Criteria)
                .OrderBy(l => l.Id)
                .Skip(specification.Skip)
                .Take(specification.Take)
                .ToList();
        }

    }

    
}
