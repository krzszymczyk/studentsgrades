using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StudentsGrades.Tests.XUnit.PresentationPurposesOnly
{
    public class TheoryInlineDataTests
    {
        [Theory]
        [InlineData(1,2)]
        [InlineData(3,4)]
        [InlineData(5,6)]
        public void InlineDataTest(int a,int b)
        {
            Assert.NotEqual(a,b);
        }
    }
}
