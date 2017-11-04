using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.Service.Interfaces;
using Timetable.DAL.Specifications;
using Timetable.Service.Infrastructure;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.Service.DTO;
using AutoMapper;
namespace Timetable.Service.Services
{
    public class ChairService : IChairService
    {
        private readonly IChairRepository chairRepository;
        private readonly IFacultyRepository facultyRepository;
        private readonly ITeacherRepository teacherRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ChairService(IChairRepository chairRepo, IFacultyRepository facultyRepo, IUnitOfWork unitOfWork,
            ITeacherRepository teacherRepository, IMapper mapper)
        {
            this.chairRepository = chairRepo;
            this.facultyRepository = facultyRepo;
            this.teacherRepository = teacherRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public int Count
        {
            get { return Count; }
        }


        public ChairDTO Get(int id)
        {
            var chair = chairRepository.GetById(id);
            return mapper.Map<Chair, ChairDTO>(chair);
        }


        public PagedResult<Chair, ChairDTO> Filter(string facultyTitle, int page, int pageSize)
        {
            var chairSpec = new ChairPagedSpecification(facultyTitle, page, pageSize);

            

            var pagedChairs = new PagedResult<Chair, ChairDTO>(chairSpec, chairRepository, mapper);

            return pagedChairs;
        }

        public IEnumerable<ChairDTO> Filter(string facultyTitle)
        {
            var chairSpec = new ChairSpecification(facultyTitle);



            var chairs = chairRepository.GetMany(chairSpec);

            return mapper.Map<IEnumerable<Chair>, IEnumerable<ChairDTO>>(chairs);
        }

        public PagedResult<Teacher, TeacherDTO> GetChairTeachers(int id, int page, int pageSize)
        {
            var chairSpec = new TeacherPagedSpecification(id, page, pageSize);

            var pagedTeachers = new PagedResult<Teacher, TeacherDTO>(chairSpec,teacherRepository, mapper);

            return pagedTeachers;
        }

        public IEnumerable<ChairDTO> GetAll()
        {
            var chairs = chairRepository.GetAll();
            return mapper.Map<IEnumerable<Chair>, IEnumerable<ChairDTO>>(chairs);
        }

        public void Create(ChairDTO chair)
        {
            throw new NotImplementedException();
        }

        public void Update(ChairDTO chair)
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
