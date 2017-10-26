using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories;

namespace Timetable.DAL.Repositories.Interfaces
{
    public interface ILessonRepository : IRepository<Lesson>
    {

        IEnumerable<Lesson> GetLessonsForFaculty(string faculty);
        IEnumerable<Lesson> GetLessonsByFacultyId(int facultyId);
        IEnumerable<Lesson> GetLessonsByAcademicGroup(string academicGroup);
        IEnumerable<Lesson> GetLessonsByAcademicGroupId(int academicGroupId);
        IEnumerable<Lesson> GetLessonsByClassroom(string classroom);
        IEnumerable<Lesson> GetLessonsByClassroomId(int classroomId);
        IEnumerable<Lesson> GetLessonsByTeacherId(int teacherId);
        IEnumerable<Lesson> GetLessonsBySubject(string subject);
        IEnumerable<Lesson> GetLessonsBySubjectId(int subjectId);

    }
}
