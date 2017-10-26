using System;
using System.Collections.Generic;


namespace Timetable.DAL.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        TimetableContext dbContext;

        public TimetableContext Init()
        {
            return dbContext ?? (dbContext = new TimetableContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
