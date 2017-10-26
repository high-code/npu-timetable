using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timetable.DAL.Entities
{
    public class Lesson
    {
        public int Id { get; set; }

        public int? FacultyId { get; set; }

        public Faculty Faculty { get; set; }

        public int SubjectId { get; set; }

        public Subject Subject { get; set; }

        [Range(0,7)]
        public int LessonOrder { get; set; }

        public AcademicGroup AcademicGroup { get; set; }

        public int? AcademicGroupId { get; set; }

        [Range(0,6)]
        public int Weekday { get; set; }

        public int? ClassroomId { get; set; }

        public Classroom Classroom { get; set; }

        public bool IsEnumerator { get; set; }

        public int ExpectedAmountOfStudents { get; set; }

        public string TeacherNotification { get; set; }

    }
}
