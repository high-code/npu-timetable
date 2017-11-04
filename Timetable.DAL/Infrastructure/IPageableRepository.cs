using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.DAL.Specifications;

namespace Timetable.DAL.Infrastructure
{
    public interface IPageableRepository<T> : IRepository<T> where T : class
    {
        IEnumerable<T> List(IPagedSpecification<T> specification);
    }
}
