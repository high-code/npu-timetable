using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;


namespace Timetable.DAL.Repositories.Interfaces
{
    public interface IUserRepository<T> : IPageableRepository<T> where T: User
    {
        T GetUserByUsername(string username);

        T GetUserByName(string firstName, string fathersName, string lastName);



    }
}
