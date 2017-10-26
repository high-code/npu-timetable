using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;

namespace Timetable.Service.DTO
{
    public class AcademicGroupDTO
    {
       
            public int AcademicGroupId { get; set; }

            public string GroupName { get; set; }
       
            public int Course { get; set; }

            public int StudentsAmount { get; set; }

            public int SpecialtyId { get; set; }

            public int FacultyId { get; set; }

            public DateTime CreationDate { get; set; }

    }
}
