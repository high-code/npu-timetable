using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.DAL.Specifications
{
    public class PagedBaseSpecification<T> : BaseSpecification<T>, IPagedSpecification<T> where T : class
    {
        public PagedBaseSpecification(Expression<Func<T, bool>> criteria,int page,
            int pageSize) : base(criteria)
        {
            PageSize = pageSize;
            PageNumber = page;
            Take = () => pageSize;
            Skip = () => (page - 1) * pageSize;

        }

        public int PageSize { get; }
        public int PageNumber { get; }
        public Expression<Func<int>> Take { get; }
        public Expression<Func<int>> Skip { get; }


    }
}
