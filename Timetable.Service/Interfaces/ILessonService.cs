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

        PagedResult<Lesson, LessonDetailsDTO> Filter(string facultyTitle, string subjectName, string subjectTypeName,
            int? weekday, int? lessonOrder, bool? isEnumerator, string classroomTitle, string academicGroupName, int page, int pageSize);

        IEnumerable<LessonDetailsDTO> Filter(string facultyTitle, string subjectName,string subjectTypeName,
            int? weekday,int? lessonOrder, bool? isEnumerator, string classroomTitle, string academicGroupName);

        

    }
}
