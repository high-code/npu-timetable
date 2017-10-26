using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.Service.Infrastructure;
using Timetable.DAL.Entities;
using Timetable.Service.DTO;

namespace Timetable.Service.Interfaces
{
    public interface ISubjectTypeService : IService<SubjectTypeDTO>
    {
        SubjectTypeDTO Get(string name);
    }
}
