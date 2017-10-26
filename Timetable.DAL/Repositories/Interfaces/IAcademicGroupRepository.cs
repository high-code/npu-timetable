using System;
using System.Collections.Generic;
using Timetable.DAL.Entities;
using Timetable.DAL.Repositories;
using Timetable.DAL.Infrastructure;

namespace Timetable.DAL.Repositories.Interfaces
{

    public interface IAcademicGroupRepository : IRepository<AcademicGroup>
    {
        AcademicGroup GetAcademicGroupByName(string name);
        IEnumerable<AcademicGroup> GetAcademicGroupBySpecialtyId(int specId);
        IEnumerable<AcademicGroup> GetAcademicGroupBySpecialtyTitle(string title);
        IEnumerable<AcademicGroup> GetAcademicGroupsByFacultyId(int facultyId);
        IEnumerable<AcademicGroup> GetAcademicGroupsByFacultyName(string name);

    }
}
