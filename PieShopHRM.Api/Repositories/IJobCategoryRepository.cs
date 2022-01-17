using PieShopHRM.Shared;

namespace PieShopHRM.Api.Repositories
{
    public interface IJobCategoryRepository
    {
        IEnumerable<JobCategory> GetAllJobCategories();
        JobCategory GetJobCategoryById(int jobCategoryId);
    }
}
