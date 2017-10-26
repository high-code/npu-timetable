using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.Service.Infrastructure;
using Timetable.Service.DTO;
namespace Timetable.Service.Interfaces
{
    public interface IAcademicGroupService : IService<AcademicGroupDTO>
    {
     
        IEnumerable<AcademicGroupDTO> GetByFaculty(string facultyName);
        IEnumerable<AcademicGroupDTO> GetByFacultyId(int facultyId);
        IEnumerable<AcademicGroupDTO> GetBySpecialty(string specialtyName);
        IEnumerable<AcademicGroupDTO> GetBySpecialtyId(int specialtyId);
        IEnumerable<AcademicGroupDTO> Filter(string facultyTitle, string specialtyTitle);
        AcademicGroupDTO Get(string groupName);
        
    }
}
