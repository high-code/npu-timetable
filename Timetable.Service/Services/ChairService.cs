using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.Service.Interfaces;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.Service.DTO;
using AutoMapper;
namespace Timetable.Service.Services
{
    public class ChairService : IChairService
    {
        private readonly IChairRepository chairRepository;
        private readonly IFacultyRepository facultyRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ChairService(IChairRepository chairRepo, IFacultyRepository facultyRepo, IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.chairRepository = chairRepo;
            this.facultyRepository = facultyRepo;
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

        public ChairDTO Get(string title)
        {
            var chair = chairRepository.GetChairByTitle(title);

            return mapper.Map<Chair, ChairDTO>(chair);
        }

        public IEnumerable<ChairDTO> GetAll()
        {
            var chairs = chairRepository.GetAll();
            return mapper.Map<IEnumerable<Chair>, IEnumerable<ChairDTO>>(chairs);
        }

        public IEnumerable<ChairDTO> GetByFacultyName(string faculty)
        {
            var chairs = chairRepository.GetChairsByFacultyName(faculty);
            return mapper.Map<IEnumerable<Chair>, IEnumerable<ChairDTO>>(chairs);
        }

        public IEnumerable<ChairDTO> GetByFacultyId(int facultyId)
        {
            var chairs = chairRepository.GetChairsByFacultyId(facultyId);
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
