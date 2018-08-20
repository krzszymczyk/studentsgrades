using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestStudentsResults.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace BestStudentsResults.Data.Context
{
    public class StudentResultsDbContext:DbContext
        
    {
        public StudentResultsDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<StudentResult> StudentsResults { get; set; }
    }
}
