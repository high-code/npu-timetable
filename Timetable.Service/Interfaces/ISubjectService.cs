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
        PagedResult<Subject, SubjectDTO> Filter(string subjectType, string chairTitle, int? teacherId, int page, int pageSize);

    }
}
