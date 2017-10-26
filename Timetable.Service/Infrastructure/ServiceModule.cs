using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.DAL.Infrastructure;
using Ninject.Modules;
using Timetable.DAL.Repositories;
using Timetable.DAL.Repositories.Interfaces;
namespace Timetable.Service.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(connectionString);
            Bind<IAcademicGroupRepository>().To<AcademicGroupRepository>().WithConstructorArgument(connectionString);
            Bind<IBuildingRepository>().To<BuildingRepository>().WithConstructorArgument(connectionString); 
            Bind<IFacultyRepository>().To<FacultyRepository>().WithConstructorArgument(connectionString);
            Bind<IChairRepository>().To<ChairRepository>().WithConstructorArgument(connectionString);
            Bind<IClassroomRepository>().To<ClassroomRepository>().WithConstructorArgument(connectionString);
            Bind<IConsultRepository>().To<ConsultsRepository>().WithConstructorArgument(connectionString);
            Bind<IExamRepository>().To<ExamsRepository>().WithConstructorArgument(connectionString);
            Bind<ILessonRepository>().To<LessonsRepository>().WithConstructorArgument(connectionString);
            Bind<ISpecialtyRepository>().To<SpecialtyRepository>().WithConstructorArgument(connectionString);
            Bind<IStudentRepository>().To<StudentRepository>().WithConstructorArgument(connectionString);
            Bind<ISubjectRepository>().To<SubjectRepository>().WithConstructorArgument(connectionString);
            Bind<ISubjectTypeRepository>().To<SubjectTypeRepository>().WithConstructorArgument(connectionString);
            Bind<ISupervisorRepository>().To<SupervisorRepository>().WithConstructorArgument(connectionString);
            Bind<ITeacherRepository>().To<TeacherRepository>().WithConstructorArgument(connectionString);
            Bind<IDbFactory>().To<DbFactory>().WithConstructorArgument(connectionString);
        }
    
    }
}
