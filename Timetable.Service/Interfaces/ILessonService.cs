using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.Service.Infrastructure;
using Timetable.Service.DTO;

namespace Timetable.Service.Interfaces
{
    public interface ILessonService : IService<LessonDetailsDTO>
    {
        IEnumerable<LessonDetailsDTO> GetByFacultyTitle(string faculty);
        IEnumerable<LessonDetailsDTO> GetByFacultyId(int facultyId);
        IEnumerable<LessonDetailsDTO> GetByAcademicGroupName(string academicGroup);
        IEnumerable<LessonDetailsDTO> GetByAcademicGroupId(int academicGroupId);
        IEnumerable<LessonDetailsDTO> GetByClassroomTitle(string classroom);
        IEnumerable<LessonDetailsDTO> GetByClassroomId(int classroomId);
        IEnumerable<LessonDetailsDTO> GetBySubjectTitle(string subject);
        IEnumerable<LessonDetailsDTO> GetBySubjectId(int subjectId);
        IEnumerable<LessonDetailsDTO> GetByTeacherId(int teacherId);

        IEnumerable<LessonDetailsDTO> Filter(string facultyTitle, string subjectName,string subjectTypeName,
            int? weekday,int? lessonOrder, bool? isEnumerator, string classroomTitle, string academicGroupName, int page, int pageSize);


    }
}
