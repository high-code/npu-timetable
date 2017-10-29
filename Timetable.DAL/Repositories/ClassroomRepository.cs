using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.DAL.Entities;

namespace Timetable.DAL.Repositories
{
    public class ClassroomRepository : RepositoryBase<Classroom>, IClassroomRepository
    {
        public ClassroomRepository(IDbFactory dbFactory) : base(dbFactory)
        { }


        public override Classroom GetById(int id)
        {
            return DbContext.Classrooms
                .Include(c => c.Building)
                .FirstOrDefault(c => c.ClassroomId == id);
        }


        public override IEnumerable<Classroom> GetAll()
        {
            return DbContext.Classrooms
                .Include(c => c.Building);
        }

        public IEnumerable<Classroom> GetMany(Expression<Func<Classroom, bool>> where, int page, int pageSize)
        {
            return DbContext.Classrooms
                .Include(c => c.Building)
                .Where(where)
                .OrderBy(c => c.ClassroomId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        public Classroom GetClassroomByTitle(string title)
        {
            return DbContext.Classrooms
                .Include(c => c.Building)
                .FirstOrDefault(c => c.ClassroomTitle.ToLower() == title.ToLower());
        }

        public IEnumerable<Classroom> GetClassroomsByBuilding(string building)
        {
            return DbContext.Classrooms
                .Include(c => c.Building)
                .Where(c => c.Building.BuildingTitle.ToLower() == building.ToLower());
        }

        public IEnumerable<Classroom> GetClassroomsByBuildingId(int buildingId)
        {
            return DbContext.Classrooms
                .Include(c => c.Building)
                .Where(c => c.BuildingId == buildingId);
        }

    }

   
}
