using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.Service.Interfaces;
using Timetable.DAL.Entities;
using Timetable.Service.DTO;
using AutoMapper;
namespace Timetable.Service.Services
{
    public class SubjectTypeService : ISubjectTypeService
    {
        private readonly ISubjectTypeRepository subjectTypeRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SubjectTypeService(ISubjectTypeRepository subjectTypeRepo,IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.subjectTypeRepository = subjectTypeRepo;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public int Count
        {
            get { return Count; }
        }

        public SubjectTypeDTO Get(int id)
        {
            var subjectType = subjectTypeRepository.GetById(id);

            return mapper.Map<SubjectType, SubjectTypeDTO>(subjectType);
        }

        

        public IEnumerable<SubjectTypeDTO> GetAll()
        {
            var subjectTypes = subjectTypeRepository.GetAll();

            return mapper.Map<IEnumerable<SubjectType>, IEnumerable<SubjectTypeDTO>>(subjectTypes);
        }

        public void Create(SubjectTypeDTO subjectType)
        {
            throw new NotImplementedException();
        }

        public void Update(SubjectTypeDTO subjectType)
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
