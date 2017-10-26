using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories;

namespace Timetable.DAL.Repositories.Interfaces
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        IEnumerable<Subject> GetSubjectsByTitle(string title);
        IEnumerable<Subject> GetSubjectsByChair(string chair);
        IEnumerable<Subject> GetSubjectsByChairId(int chairId);
        IEnumerable<Subject> GetSubjectsByTeacherId(int teacherId);
    }
}
