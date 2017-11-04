using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.Service.Interfaces;
using Timetable.DAL.Specifications;
using Timetable.Service.Infrastructure;
using Timetable.Service.DTO;
using AutoMapper;

namespace Timetable.Service.Services
{
    public class SubjectService : ISubjectService
    {
        ISubjectRepository subjectRepository;
        IUnitOfWork unitOfWork;
        IMapper mapper;

        public SubjectService(ISubjectRepository subjectRepo, IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.subjectRepository = subjectRepo;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public int Count
        {
            get { return Count; }
        }


        public SubjectDTO Get(int id)
        {
            var subject = subjectRepository.GetById(id);

            return mapper.Map<Subject, SubjectDTO>(subject);
        }

        public PagedResult<Subject, SubjectDTO> Filter(string subjectType, string chairTitle, int? teacherId, int page, int pageSize)
        {
            var subjectSpec = new SubjectPagedSpecification(subjectType, chairTitle, teacherId, page, pageSize);

            var pagedSubjects = new PagedResult<Subject, SubjectDTO>(subjectSpec, subjectRepository, mapper);

            return pagedSubjects;
        }

        public IEnumerable<SubjectDTO> GetAll()
        {
            var teachers = subjectRepository.GetAll();

            return mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectDTO>>(teachers);
        }

        public void Create(SubjectDTO subject)
        {
            throw new NotImplementedException();
        }

        public void Update(SubjectDTO subject)
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
