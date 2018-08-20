using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BestStudentsResults.Data.Entity
{
    public class StudentResult
    {
        [Key]
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }
        public int Rating { get; set; }

    }
}
