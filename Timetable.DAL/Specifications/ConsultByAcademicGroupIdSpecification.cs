using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.DAL.Entities;
namespace Timetable.DAL.Specifications
{
    public class ConsultByAcademicGroupIdSpecification : BaseSpecification<Consult>
    {
        public ConsultByAcademicGroupIdSpecification(int academicGroupId) : base(c => c.AcademicGroupId == academicGroupId)
        {
            AddInclude(e => e.AcademicGroup);
            AddInclude(e => e.Classroom);
            AddInclude(e => e.Faculty);
            AddInclude(e => e.Subject);
        }
    }
}
