using System;
using System.Collections.Generic;
using System.Text;
using StudentsGrades.Services;

namespace StudentsGrades.IntegrationTests.Xunit.Fixtures
{
    public class SupervisorApiServiceFixture :IDisposable
    {

        public SupervisorApiService ServiceUnderTest { get;  }

        public SupervisorApiServiceFixture()
        {
            ServiceUnderTest = new SupervisorApiService();
        }

        public void Dispose()
        {
            ServiceUnderTest.Dispose();
        }
    }
}
