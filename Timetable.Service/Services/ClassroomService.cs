using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.Service.Interfaces;
using Timetable.Service.Infrastructure;
using Timetable.DAL.Specifications;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.Service.DTO;
using AutoMapper;

namespace Timetable.Service.Services
{
    public class ClassroomService  : IClassroomService
    {

        IClassroomRepository classroomRepository;
        IUnitOfWork unitOfWork;
        IMapper mapper;

        public ClassroomService(IClassroomRepository classroomRepo, IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.classroomRepository = classroomRepo;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public int Count
        {
            get { return Count; }
        }

        public ClassroomDTO Get(int id)
        {
            var classroom = classroomRepository.GetById(id);
            return mapper.Map<Classroom,ClassroomDTO>(classroom);
        }

        public PagedResult<Classroom, ClassroomDTO> Filter(string buildingTitle, int page, int pageSize)
        {
            var classroomSpec = new ClassroomPagedSpecification(buildingTitle, page, pageSize);

            


            var classroomsPaged = new PagedResult<Classroom, ClassroomDTO>(classroomSpec, classroomRepository,
                mapper);


            return classroomsPaged;

        }


        public IEnumerable<ClassroomDTO> Filter(string buildingTitle)
        {
            var classroomSpec = new ClassroomSpecification(buildingTitle);

            

            var classrooms = classroomRepository.GetMany(classroomSpec);

            return mapper.Map<IEnumerable<Classroom>, IEnumerable<ClassroomDTO>>(classrooms);
        }

        public IEnumerable<ClassroomDTO> GetAll()
        {
            var classrooms = classroomRepository.GetAll();

            return mapper.Map <IEnumerable<Classroom>, IEnumerable<ClassroomDTO>>(classrooms);
        }

        public void Create(ClassroomDTO classroom)
        {
            throw new NotImplementedException();
        }

        public void Update(ClassroomDTO classroom)
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
