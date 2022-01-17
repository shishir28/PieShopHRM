using PieShopHRM.Shared;

namespace PieShopHRM.Api.Repositories
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAllCountries();
        Country GetCountryById(int countryId);
    }
}
