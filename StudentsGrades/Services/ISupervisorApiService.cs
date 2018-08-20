using System;
using System.Threading.Tasks;

namespace StudentsGrades.Services
{
    public interface ISupervisorApiService
    {
        Task SendRating(Guid studentId, int rating);
    }
}
