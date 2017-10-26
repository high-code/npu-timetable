using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Service.DTO
{
    public class ConsultDTO
    {
        public int Id { get; set; }

        public int FacultyId { get; set; }

        public string FacultyName { get; set; }

        public int SubjectId { get; set; }

        public string SubjectName { get; set; }

        public DateTime Date { get; set; }

        public int ClassroomId { get; set; }

        public string ClassroomTitle { get; set; }

        public int AcademicGroupId { get; set; }

        public string AcademicGroupName { get; set; }
    }
}
