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
    public class ExamsRepository : RepositoryBase<Exam>, IExamRepository
    {
        public ExamsRepository(IDbFactory dbFactory) : base(dbFactory)
        { }


        public override Exam GetById(int id)
        {
            return DbContext.Exams
                .Include(e => e.AcademicGroup)
                .Include(e => e.Classroom)
                .Include(e => e.Faculty)
                .Include(e => e.Subject)
                .FirstOrDefault(e => e.Id == id);
        }


        public IEnumerable<Exam> List(IPagedSpecification<Exam> specification)
        {
            var query = RepositoryHelper.MakeIncludesQuery(specification, DbContext.Exams);

            return query
                .Where(specification.Criteria)
                .OrderBy(e => e.Id)
                .Skip(specification.Skip)
                .Take(specification.Take)
                .ToList();
        }

        


        
    }
}
