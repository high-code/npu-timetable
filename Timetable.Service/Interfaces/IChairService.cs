using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.Service.Infrastructure;
using Timetable.Service.DTO;

namespace Timetable.Service.Interfaces
{
    public interface IChairService : IService<ChairDTO>
    {

        PagedResult<Chair, ChairDTO> Filter(string facultyTitle, int page, int pageSize);
        IEnumerable<ChairDTO> Filter(string facultyTitle);
        PagedResult<Teacher, TeacherDTO> GetChairTeachers(int id, int page, int pageSize);

    }
}
