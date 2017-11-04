using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.DAL.Entities;

namespace Timetable.DAL.Specifications
{
    public class SubjectPagedSpecification : PagedBaseSpecification<Subject>
    {
        public SubjectPagedSpecification(string subjectType, string chairTitle, int? teacherId, int page, int pageSize)
            : base(s => (subjectType == null || s.SubjectType.SubjectTypeTitle.ToLower() == subjectType.ToLower()) &&
                        (chairTitle == null|| s.Chair.ChairTitle.ToLower() == chairTitle.ToLower()) &&
                        (teacherId.HasValue || s.TeacherId == teacherId),
                         page, pageSize)
        {
            AddInclude(s => s.Chair);
            AddInclude(s => s.SubjectType);
            AddInclude(s => s.Teacher);
        }
    }
}
