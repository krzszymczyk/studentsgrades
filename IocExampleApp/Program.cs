using System;
using System.Reflection;
using Autofac;
using StudentsGrades.Services;

namespace IocExampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            var studentsGradesAssembly = Assembly.Load("StudentsGrades");
            builder.RegisterAssemblyTypes(studentsGradesAssembly)
                .Where(s => s.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
            //builder.RegisterType<StudentGradesAverageService>().As<IStudentGradesAverageService>();

            var container = builder.Build();

            var studentsFinagRatingService = container.Resolve <IStudentsFinalRatingService>();

        }
    }
}
