using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.DAL.Entities;

namespace Timetable.DAL.Specifications
{
    public class ChairPagedSpecification : PagedBaseSpecification<Chair>
    {
        public ChairPagedSpecification(string facultyTitle, int page, int pageSize) : base( c =>
         ( facultyTitle == null || c.Faculty.FacultyName.ToLower() == facultyTitle.ToLower()),
            page, pageSize)
        {
            AddInclude(c => c.Faculty);
        }

        public ChairPagedSpecification(int? facultyId, int page, int pageSize) : base( c => 
         (facultyId.HasValue || c.FacultyId == facultyId),  page, pageSize)
        {
            AddInclude(c => c.Faculty);
        }
        
    }
}
