using System.Threading.Tasks;
using BestStudentsResults.ViewModels;

namespace BestStudentsResults.Services
{
    public interface IRatingDbService
    {
        Task<int> AddRating(StudentResultViewModel model);
    }
}