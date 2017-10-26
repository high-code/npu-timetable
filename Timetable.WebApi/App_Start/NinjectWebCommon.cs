[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Timetable.WebApi.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Timetable.WebApi.App_Start.NinjectWebCommon), "Stop")]

namespace Timetable.WebApi.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Timetable.Service.Infrastructure;
    using Timetable.Service.Interfaces;
    using Timetable.Service.Services;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Load(
                new ServiceModule("DefaultConnection"),
                new AutoMapperModule());

            kernel.Bind<IAcademicGroupService>().To<AcademicGroupService>();
            kernel.Bind<IBuildingService>().To<BuildingService>();
            kernel.Bind<IChairService>().To<ChairService>();
            kernel.Bind<IClassroomService>().To<ClassroomService>();
            kernel.Bind<IConsultsService>().To<ConsultsService>();
            kernel.Bind<IExamsService>().To<ExamsService>();
            kernel.Bind<IFacultyService>().To<FacultyService>();
            kernel.Bind<ILessonService>().To<LessonService>();
            kernel.Bind<ISpecialtyService>().To<SpecialtyService>();
            kernel.Bind<IStudentService>().To<StudentService>();
            kernel.Bind<ISubjectService>().To<SubjectService>();
            kernel.Bind<ISubjectTypeService>().To<SubjectTypeService>();
            kernel.Bind<ISupervisorService>().To<SupervisorService>();
            kernel.Bind<ITeacherService>().To<TeacherService>();
        }        
    }
}
