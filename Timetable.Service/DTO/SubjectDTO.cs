using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Service.DTO
{
    public class SubjectDTO
    {
        public int SubjectId { get; set; }

        public string SubjectTitle { get; set; }

        public int SubjectTypeId { get; set; }

        public string SubjectTypeName { get; set; }

        public int ChairId { get; set; }

        public string ChairTitle { get; set; }

        public int TeacherId { get; set; }

        public string TeacherName { get; set; }

    }
}
