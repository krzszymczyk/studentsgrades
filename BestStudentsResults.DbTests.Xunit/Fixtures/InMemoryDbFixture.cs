using System;
using System.Collections.Generic;
using System.Text;
using BestStudentsResults.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BestStudentsResults.DbTests.Xunit.Fixtures
{
    public class InMemoryDbFixture:IDisposable
    {
        public InMemoryDbFixture()
        {
            var options = new DbContextOptionsBuilder().UseInMemoryDatabase("InMemory").Options;
            DbContext = new StudentResultsDbContext(options);

            DbContext.Database.EnsureCreated();
        }

        public StudentResultsDbContext DbContext { get; }
        public void Dispose()
        {
            DbContext.Database.EnsureDeleted();
        }
    }
}
