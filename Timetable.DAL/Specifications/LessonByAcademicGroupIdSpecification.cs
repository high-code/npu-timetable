using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.DAL.Entities;
namespace Timetable.DAL.Specifications
{
    public class LessonByAcademicGroupIdSpecification : BaseSpecification<Lesson>
    {
        public LessonByAcademicGroupIdSpecification(int academicGroupId) : base(l => l.AcademicGroupId == academicGroupId)
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
