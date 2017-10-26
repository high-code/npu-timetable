using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;


namespace Timetable.DAL
{
    public class StoreSeedData : DropCreateDatabaseIfModelChanges<TimetableContext>
    {

        /// <summary>
        /// Seed a database with initial data
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(TimetableContext context)
        {
            
        }
    }
}
