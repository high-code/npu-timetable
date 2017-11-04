using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.Service.Infrastructure;
using Timetable.Service.DTO;

namespace Timetable.Service.Interfaces
{
    public interface IExamsService : IService<ExamDTO>
    {
        IEnumerable<ExamDTO> Filter(DateTime? date, string facultyTitle, string subjectName,
            string classroomTitle, string academicGroupName);
    }
}
