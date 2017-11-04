using System;
using System.Collections.Generic;
using Timetable.DAL.Specifications;
using Timetable.DAL.Infrastructure;
using AutoMapper;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Service.Infrastructure
{
    public class PagedResult<EntityType, DTOtype> where EntityType : class where DTOtype : class
    {

        public int PageNumber { get; }
        
        public int PageSize { get; }

        public int PageCount { get;  }

        public int TotalRecordsCount { get;  }

        public virtual IEnumerable<DTOtype> Result { get; }


        public PagedResult(IPagedSpecification<EntityType> specification, IPageableRepository<EntityType> pageableRepo,IMapper mapper ) 
        {
            
            var result = pageableRepo.List(specification);

            PageNumber = specification.PageNumber;

            PageSize = specification.PageSize;

            TotalRecordsCount = pageableRepo.Count(specification.Criteria);

            PageCount = (int)(TotalRecordsCount / (double)PageSize);

            Result = mapper.Map<IEnumerable<EntityType>, IEnumerable<DTOtype>>(result);

        }
         



    }
}
