
namespace PieShopHRM.App.Services
{
    public class TokenProvider
    {
        public string XsrfToken { get; set; } // = "XSRF-TOKEN";
    }

    public class InitialApplicationState
    {
        public string XsrfToken { get; set; }
    }
}