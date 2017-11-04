using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.DAL.Entities;
namespace Timetable.DAL.Specifications
{
    public class ClassroomSpecification : BaseSpecification<Classroom>
    {
        public ClassroomSpecification(string buildingTitle) :
            base(c => buildingTitle == null || c.Building.BuildingTitle.ToLower() == buildingTitle.ToLower())
        {
            AddInclude(c => c.Building);
        }

        public ClassroomSpecification(int? buildingId) :
            base(c => buildingId.HasValue || c.BuildingId == buildingId)
        {
            AddInclude(c => c.Building);
        }
    }
}
