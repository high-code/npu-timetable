using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Timetable.DAL.Repositories
{
    public class SubjectRepository : RepositoryBase<Subject>, ISubjectRepository
    {
        public SubjectRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }

        public override Subject GetById(int id)
        {
            return DbContext.Subjects
                .Include(s => s.Chair)
                .Include(s => s.SubjectType)
                .Include(s => s.Teacher)
                .FirstOrDefault(s => s.SubjectId == id);
        }

        public IEnumerable<Subject> GetMany(Expression<Func<Subject, bool>> where, int page, int pageSize)
        {
            return DbContext.Subjects
                .Include(s => s.Chair)
                .Include(s => s.SubjectType)
                .Include(s => s.Teacher)
                .Where(where)
                .OrderBy(s => s.SubjectId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
        public IEnumerable<Subject> GetSubjectsByTitle(string title)
        {
            return DbContext.Subjects.Where(s => s.SubjectTitle.ToLower() == title.ToLower());
        }

        public IEnumerable<Subject> GetSubjectsByChair(string chair)
        {
            return DbContext.Subjects.Where(s => s.Chair.ChairTitle.ToLower() == chair.ToLower());

        }

        public IEnumerable<Subject> GetSubjectsByChairId(int chairId)
        {
            return DbContext.Subjects.Where(s => s.ChairId == chairId);
        }

        public IEnumerable<Subject> GetSubjectsByTeacherId(int teacherId)
        {
            return DbContext.Subjects.Where(s => s.TeacherId == teacherId);
        }
    }

    
}
