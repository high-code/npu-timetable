using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.DAL.Entities;

namespace Timetable.DAL.Specifications
{
    public class AcademicGroupPagedSpecification : PagedBaseSpecification<AcademicGroup>
    {
        public AcademicGroupPagedSpecification(string facultyTitle, string specialtyTitle, int page, int pageSize) :
                base(ag => ( facultyTitle == null || ag.Faculty.FacultyName.ToLower() == facultyTitle.ToLower()) &&
                           ( specialtyTitle == null || ag.Specialty.SpecialtyTitle.ToLower() == specialtyTitle.ToLower())
                           , page, pageSize)
        {
            AddInclude(ag => ag.Specialty);
            AddInclude(ag => ag.Faculty);
            
        }
        
    }
}
