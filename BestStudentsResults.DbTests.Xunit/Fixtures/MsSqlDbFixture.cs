using System;
using System.Collections.Generic;
using System.Text;
using BestStudentsResults.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BestStudentsResults.DbTests.Xunit.Fixtures
{
    public class MsSqlDbFixture:IDisposable
    {
        public StudentResultsDbContext DbContext { get; }

        public MsSqlDbFixture()
        {
            var options = new DbContextOptionsBuilder().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Tests;Trusted_Connection=True;MultipleActiveResultSets=true").Options;
            DbContext = new StudentResultsDbContext(options);

            DbContext.Database.EnsureCreated();
        }
        public void Dispose()
        {
            DbContext.Database.EnsureDeleted();
        }
    }
}
