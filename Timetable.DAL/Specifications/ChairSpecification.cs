using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.DAL.Entities;


namespace Timetable.DAL.Specifications
{
    public class ChairSpecification : BaseSpecification<Chair>
    {
        public ChairSpecification(string facultyTitle) : base(c =>
         facultyTitle == null ||c.Faculty.FacultyName.ToLower() == facultyTitle.ToLower())
        {
            AddInclude(c => c.Faculty);
        }

        public ChairSpecification(int? facultyId) : base(c =>
        facultyId.HasValue || c.FacultyId == facultyId)
        {
            AddInclude(c => c.Faculty);
        }
    }
}
