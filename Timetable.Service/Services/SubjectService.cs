using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Entities;
using Timetable.DAL.Infrastructure;
using Timetable.DAL.Repositories.Interfaces;
using Timetable.Service.Interfaces;
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

        public IEnumerable<SubjectDTO> GetByChair(string chair)
        {
            var subjects = subjectRepository.GetSubjectsByChair(chair);

            return mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectDTO>>(subjects);
        }

        public IEnumerable<SubjectDTO> GetByChairId(int chairId)
        {
            var subjects = subjectRepository.GetSubjectsByChairId(chairId);

            return mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectDTO>>(subjects);
        }

        public IEnumerable<SubjectDTO> GetByTeacherId(int teacherId)
        {
            var teachers = subjectRepository.GetSubjectsByTeacherId(teacherId);


            return mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectDTO>>(teachers);
        }

        public IEnumerable<SubjectDTO> GetByTitle(string title)
        {
            var teachers = subjectRepository.GetSubjectsByTitle(title);

            return mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectDTO>>(teachers);
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
