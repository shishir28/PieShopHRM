using PieShopHRM.Shared;

namespace PieShopHRM.Api.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CountryRepository(AppDbContext appDbContext) => _appDbContext = appDbContext;

        public IEnumerable<Country> GetAllCountries() => _appDbContext.Countries;

        public Country GetCountryById(int countryId) => _appDbContext.Countries.FirstOrDefault(c => c.CountryId == countryId);

    }
}
