using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories.Interfaces;
using System.Data.Entity;
namespace Timetable.DAL.Repositories
{
    public class ChairRepository : RepositoryBase<Chair>, IChairRepository
    {

        public ChairRepository(IDbFactory dbFactory) : base(dbFactory)
        { }


        public override Chair GetById(int id)
        {
            return DbContext.Chairs
                .Include(c => c.Faculty)
                .FirstOrDefault(c => c.ChairId == id);
        }

        

        public override IEnumerable<Chair> GetAll()
        {
            
            return DbContext.Chairs
                .Include(c => c.Faculty);
        }
        
        public IEnumerable<Chair> GetMany(Expression<Func<Chair, bool>> where, int page, int pageSize)
        {
            return DbContext.Chairs
                .Include(c => c.Faculty)
                .Where(where)
                .OrderBy(c => c.ChairId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        public Chair GetChairByTitle(string title)
        {
            return DbContext.Chairs
                    .Include(c => c.Faculty)
                    .FirstOrDefault(c => c.ChairTitle.ToLower() == title.ToLower());
        }

        public IEnumerable<Chair> GetChairsByFacultyName(string faculty)
        {
            return DbContext.Chairs
                .Include(c => c.Faculty)
                .Where(c => c.Faculty.FacultyName.ToLower() == faculty.ToLower());
        }


        public IEnumerable<Chair> GetChairsByFacultyId(int facultyId)
        {
            return DbContext.Chairs
                .Include(c => c.Faculty)
                .Where(c => c.FacultyId == facultyId);
        }

    }

    

}
