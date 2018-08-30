using System;
using System.Threading.Tasks;

namespace StudentsGrades.Services
{
    public interface ISupervisorApiService : IDisposable
    {
        Task<bool> SendRating(Guid studentId, int rating);
    }
}
