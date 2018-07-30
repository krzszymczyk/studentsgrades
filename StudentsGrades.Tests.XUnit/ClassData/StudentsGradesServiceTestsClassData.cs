using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using StudentsGrades.Models;

namespace StudentsGrades.Tests.XUnit.ClassData
{
    public class StudentsGradesServiceTestsClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        private readonly List<Object[]> data = new List<object[]>
        {
            new object[]
            {
                new List<Grade>
                {
                    new Grade{Value = 2.75M,Weight = 1},
                    new Grade{Value = 1.75M,Weight = 1},
                    new Grade{Value = 2.75M,Weight = 1},
                },
                2.4167M
            },
            new object[]
            {
                new List<Grade>
                {
                    new Grade{Value = 2.75M,Weight = 1},
                    new Grade{Value = 1.75M,Weight = 1},
                    new Grade{Value = 1.75M,Weight = 1},
                },
                2.0833M
            }
        };

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
       
    }
}
