using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.DAL.Repositories;
using Timetable.DAL.Infrastructure;
using Timetable.Service.Interfaces;
using Timetable.Service.Infrastructure;
using Timetable.Service.DTO;
using Timetable.DAL.Specifications;
using AutoMapper;

namespace Timetable.Service.Services
{
   public class BuildingService : IBuildingService
   {
       private readonly IBuildingRepository buildingRepository;
       private readonly IClassroomRepository classroomRepository;
       private readonly IUnitOfWork unitOfWork;
       private readonly IMapper mapper;

       public BuildingService(IBuildingRepository buildingRepo, IUnitOfWork unitOfWork, IClassroomRepository classroomRepository,
           IMapper mapper)
       {
           this.buildingRepository = buildingRepo;
           this.classroomRepository = classroomRepository;
           this.unitOfWork = unitOfWork;
           this.mapper = mapper;
       }


        public IEnumerable<BuildingDTO> GetAll()
       {
           var buildings = buildingRepository.GetAll();

           return mapper.Map<IEnumerable<Building>, List<BuildingDTO>>(buildings);
       }

       public BuildingDTO Get(int id)
       {
           var building = buildingRepository.GetById(id);

           return mapper.Map<Building, BuildingDTO>(building);
       }

       public PagedResult<Classroom,ClassroomDTO> GetBuildingClassrooms(int id, int page, int pageSize)
        {
            var specification = new ClassroomPagedSpecification(id, page, pageSize);

            var pagedClassrooms = new PagedResult<Classroom, ClassroomDTO>(specification, classroomRepository, mapper);

            return pagedClassrooms;
        }

       public void Create(BuildingDTO building)
       {
           throw new NotImplementedException();   
       }

       public void Update(BuildingDTO building)
       {
           throw new NotImplementedException();
       }

       public void Delete(int id)
       {
           throw new NotImplementedException();
       }

       public void Save()
       {
           unitOfWork.Commit();
       }
   }

    
}
