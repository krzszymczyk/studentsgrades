using System;
using System.Collections.Generic;
using System.Text;
using BestStudentsResults.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BestStudentsResults.IntegrationTests.Xunit.Fixtures
{
    public class DbFixture:IDisposable
    {
        public StudentResultsDbContext DbContext { get; }

        public DbFixture()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer( "Server=(localdb)\\mssqllocaldb;Database=BestStudentsResult;Trusted_Connection=True;MultipleActiveResultSets=true");
            DbContext = new StudentResultsDbContext(builder.Options);
        }
        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
