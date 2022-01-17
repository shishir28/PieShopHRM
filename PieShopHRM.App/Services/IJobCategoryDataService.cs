using PieShopHRM.Shared;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PieShopHRM.App.Services
{
    public interface IJobCategoryDataService
    {
        Task<IEnumerable<JobCategory>> GetAllJobCategories();
        Task<JobCategory> GetJobCategoryById(int jobCategoryId);
    }
}
