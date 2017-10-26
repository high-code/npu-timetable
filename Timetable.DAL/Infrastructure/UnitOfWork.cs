using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.DAL.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private TimetableContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public TimetableContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }


        public void Commit()
        {
            dbContext.Commit();
        }

    }
}
