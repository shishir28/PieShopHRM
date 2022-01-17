using PieShopHRM.Shared;

namespace PieShopHRM.Api.Repositories
{
    public class JobCategoryRepository : IJobCategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public JobCategoryRepository(AppDbContext appDbContext) =>
            _appDbContext = appDbContext;

        public IEnumerable<JobCategory> GetAllJobCategories() =>
             _appDbContext.JobCategories;

        public JobCategory GetJobCategoryById(int jobCategoryId) =>
             _appDbContext.JobCategories.FirstOrDefault(c => c.JobCategoryId == jobCategoryId);

    }
}
