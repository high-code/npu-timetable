using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.Service.Infrastructure;
using Timetable.Service.DTO;

namespace Timetable.Service.Interfaces
{
    public interface ISubjectService : IService<SubjectDTO>
    {
        IEnumerable<SubjectDTO> GetByChair(string chair);
        IEnumerable<SubjectDTO> GetByChairId(int chairId);
        IEnumerable<SubjectDTO> GetByTitle(string title);
        IEnumerable<SubjectDTO> GetByTeacherId(int teacherId);
    }
}
