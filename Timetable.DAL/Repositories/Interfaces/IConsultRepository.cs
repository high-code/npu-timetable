using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.DAL.Repositories;
using Timetable.DAL.Infrastructure;


namespace Timetable.DAL.Repositories.Interfaces
{
    public interface IConsultRepository : IRepository<Consult>
    {
        IEnumerable<Consult> GetConsultsByFaculty(string faculty);
        IEnumerable<Consult> GetConsultsByFacultyId(int id);
        IEnumerable<Consult> GetConsultsBySubject(string subject);
        IEnumerable<Consult> GetConsultsBySubjectId(int id);
        IEnumerable<Consult> GetConsultsByClassroom(string classroom);
        IEnumerable<Consult> GetConsultsByClassroomId(int classroomId);
        IEnumerable<Consult> GetConsultsByAcademicGroup(string academicGroup);
        IEnumerable<Consult> GetConsultsByAcademicGroupId(int academicGroupId);
        IEnumerable<Consult> GetConsultsByDate(DateTime date);
    }
}
