using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.DAL.Entities;

namespace Timetable.DAL.Specifications
{
    public class AcademicGroupSpecification : BaseSpecification<AcademicGroup>
    {
        public AcademicGroupSpecification(string facultyTitle, string specialtyTitle) : base(ag => 
                            (facultyTitle == null || ag.Faculty.FacultyName.ToLower() == facultyTitle.ToLower()) &&
                            (specialtyTitle == null || ag.Specialty.SpecialtyTitle.ToLower() == specialtyTitle.ToLower()))
        {
            AddInclude(ag => ag.Specialty);
            AddInclude(ag => ag.Faculty);
        }


    }
}
