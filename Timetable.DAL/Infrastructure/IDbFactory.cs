using System;
using Timetable.DAL;
namespace Timetable.DAL.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        TimetableContext Init();
    }
}
