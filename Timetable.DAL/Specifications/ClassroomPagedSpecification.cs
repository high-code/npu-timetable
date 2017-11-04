using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.DAL.Entities;

namespace Timetable.DAL.Specifications
{
    public class ClassroomPagedSpecification : PagedBaseSpecification<Classroom>
    {
        public ClassroomPagedSpecification(string buildingTitle,int page, int pageSize) 
            : base(c => buildingTitle == null || c.Building.BuildingTitle.ToLower() == buildingTitle.ToLower(),
                  page, pageSize)
        {
            AddInclude(c => c.Building);
        }

        public ClassroomPagedSpecification(int? buildingId, int page, int pageSize)
            : base(c => (buildingId.HasValue || c.BuildingId == buildingId),
                  page, pageSize)
        {
            AddInclude(c => c.Building);
        }
    }
}
