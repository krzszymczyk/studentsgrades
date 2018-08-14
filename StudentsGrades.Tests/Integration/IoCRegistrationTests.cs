using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Autofac;
using Autofac.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StudentsGrades.Tests.MsTest.Integration
{
    [TestClass]
    public class IoCRegistrationTests
    {
        #region configuration

        private IContainer container;

        public IoCRegistrationTests()
        {
            var builder = new ContainerBuilder();


            var studentsGradesAssembly = Assembly.Load("StudentsGrades");

            builder.RegisterAssemblyTypes(studentsGradesAssembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            container = builder.Build();

        }

        #endregion

        [TestMethod]
        public void ContainterResolveAllTypeShouldBeRegistered()
        {
            var studentsGradesAssembly = Assembly.Load("StudentsGrades");
            var typesToResolve = studentsGradesAssembly
                .GetTypes()
                .Where(t => t.Name.EndsWith("Service") && t.IsInterface);

            var typesObjects = new List<object>();

            foreach (var typeToResolve in typesToResolve)
            {
                typesObjects.Add(typeToResolve);
            }

            Assert.AreEqual(typesToResolve.Count(), typesObjects.Count);

        }
    }
}
