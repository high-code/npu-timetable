﻿using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories;

namespace Timetable.DAL.Repositories.Interfaces
{
    public interface IClassroomRepository : IRepository<Classroom>
    {

        Classroom GetClassroomByTitle(string title);
        IEnumerable<Classroom> GetClassroomsByBuilding(string building);
        IEnumerable<Classroom> GetClassroomsByBuildingId(int buildingId);
        
       
    }
}