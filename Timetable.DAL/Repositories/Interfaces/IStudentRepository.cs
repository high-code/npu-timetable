using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;

namespace Timetable.DAL.Repositories.Interfaces
{
    public interface IStudentRepository : IRepository<Student>, IUserRepository<Student>
    {
        IEnumerable<Student> GetStudentsByAcademicGroupName(string academicGroup);
        IEnumerable<Student> GetStudentsByAcademicGroupId(int id);
    }
}
