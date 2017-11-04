using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.DAL.Entities;

namespace Timetable.DAL.Specifications
{
    public class LessonSpecification : BaseSpecification<Lesson>
    {

        public LessonSpecification(string facultyTitle, string subjectName, string subjectTypeName,
           int? weekday, int? lessonOrder, bool? isEnumerator, string classroomTitle, string academicGroupName)
            : base(l => (facultyTitle == null || l.Faculty.FacultyName.ToLower() == facultyTitle.ToLower()) &&
                        (subjectName == null || l.Subject.SubjectTitle.ToLower() == subjectName.ToLower()) &&
                        (subjectTypeName == null || l.Subject.SubjectType.SubjectTypeTitle.ToLower() == subjectTypeName.ToLower()) &&
                        (weekday.HasValue || l.Weekday == weekday) &&
                        (lessonOrder.HasValue || l.LessonOrder == lessonOrder) &&
                        (isEnumerator == null || l.IsEnumerator == isEnumerator) &&
                        (classroomTitle == null|| l.Classroom.ClassroomTitle.ToLower() == classroomTitle.ToLower()) &&
                        (academicGroupName == null || l.AcademicGroup.GroupName.ToLower() == academicGroupName.ToLower()))
        {
            AddInclude(l => l.AcademicGroup);
            AddInclude(l => l.Classroom);
            AddInclude(l => l.Faculty);
            AddInclude(l => l.Subject);
            AddInclude("Classroom.Building");
            AddInclude("Subject.SubjectType");
        }



    }
}
