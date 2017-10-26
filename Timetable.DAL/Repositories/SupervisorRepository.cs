using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories.Interfaces;

namespace Timetable.DAL.Repositories
{
    public class SupervisorRepository : UserRepository<Supervisor>, ISupervisorRepository
    {
        public SupervisorRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }

        public IEnumerable<Supervisor> GetSupervisorsByFaculty(string faculty)
        {
            return DbContext.Supervisors.Where(s => s.Faculty.FacultyName.ToLower() == faculty.ToLower());
        }

        public IEnumerable<Supervisor> GetSupervisorsByFacultyId(int facultyId)
        {
            return DbContext.Supervisors.Where(s => s.FacultyId == facultyId);
        }
        
    }


}
