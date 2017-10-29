using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Timetable.WebApi.Models
{
    public class SearchLessonModel
    {
        public string FacultyTitle { get; set; }
        public string ClassroomTitle { get; set; }
        public string AcademicGroupName { get; set; }
        public string SubjectName { get; set; }
        public string SubjectTypeName { get; set; }
        public int? Weekday { get; set; }
        public int? LessonOrder { get; set; }
        public bool? IsEnumerator { get; set; }
        
        
    }
}