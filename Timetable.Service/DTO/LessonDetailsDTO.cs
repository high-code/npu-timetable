﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Service.DTO
{
    public class LessonDetailsDTO
    {
        public int Id { get; set; }

        public int FacultyId { get; set; }

        public string FacultyName { get; set; }

        public int SubjectId { get; set; }

        public string SubjectName { get; set; }

        public int SubjectTypeId { get; set; }

        public string SubjectTypeName { get; set; }

        public int? LessonOrder { get; set; }

        public int AcademicGroupId { get; set; }

        public string AcademicGroupName { get; set; }

        public int? Weekday { get; set; }

        public int ClassroomId { get; set; }

        public string  ClassroomTitle { get; set; }

        public int BuildingId { get; set; }

        public string BuildingTitle { get; set; }

        public bool? IsEnumerator { get; set; }

        public int ExpectedAmountOfStudents { get; set; }

        public string TeacherNotification { get; set; }
    }
}
