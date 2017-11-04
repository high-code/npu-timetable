using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.DAL.Entities;

namespace Timetable.DAL.Specifications
{
    public class ConsultSpecification : BaseSpecification<Consult>
    {
        public ConsultSpecification(DateTime? date, string facultyTitle, string subjectTitle,
            string classroomTitle, string academicGroupName) : base
                (c => (date.HasValue || c.Date == date) &&
                      (facultyTitle == null || c.Faculty.FacultyName.ToLower() == facultyTitle.ToLower()) &&
                      ( subjectTitle == null|| c.Subject.SubjectTitle.ToLower() == subjectTitle.ToLower()) &&
                      ( classroomTitle == null || c.Classroom.ClassroomTitle.ToLower() == classroomTitle.ToLower()) &&
                      ( academicGroupName == null || c.AcademicGroup.GroupName.ToLower() == academicGroupName.ToLower()))
                {
            AddInclude(e => e.AcademicGroup);
            AddInclude(e => e.Classroom);
            AddInclude(e => e.Faculty);
            AddInclude(e => e.Subject);
        }
    }
}
