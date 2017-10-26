using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories.Interfaces;
namespace Timetable.DAL.Repositories
{
    public class SubjectRepository : RepositoryBase<Subject>, ISubjectRepository
    {
        public SubjectRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }

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
