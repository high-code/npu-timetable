using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Service.DTO
{
    public class ClassroomDTO
    {
        public int ClassroomId { get; set; }

        public string ClassroomTitle { get; set; }

        public int BuildingId { get; set; }

        public string BuildingTitle { get; set; }
    }
}
