using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StudentsGrades.Tests.MsTest.PresentationPurposeOnly
{
    [TestClass]
    public class DataTestMethodTests
    {
        [DataTestMethod]
        [DataRow(1,2)]
        [DataRow(3,4)]
        [DataRow(5,6)]
        public void DataRowExample(int a, int b)
        {
            Assert.AreEqual(a,b);
        }
    }
}
