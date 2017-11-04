using Timetable.DAL.Entities;
using System.Linq.Expressions;
using System.Linq;
namespace Timetable.DAL.Specifications
{
    public class TeacherPagedSpecification : PagedBaseSpecification<Teacher>
    {
        public TeacherPagedSpecification(string chairTitle, int page, int pageSize) 
            : base(t => t.Chairs.Any(c => c.ChairTitle.ToLower() == chairTitle.ToLower()), page, pageSize)
        {
            
        }

        public TeacherPagedSpecification(int? chairId, int page, int pageSize)
            : base(t => t.Chairs.Any(c => c.ChairId == chairId), page, pageSize)
        {
            
        }
    }
}
