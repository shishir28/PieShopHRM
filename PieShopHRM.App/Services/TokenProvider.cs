
namespace PieShopHRM.App.Services
{
    public class TokenProvider
    {
        public string XsrfToken { get; set; } // = "XSRF-TOKEN";
        public string AccessToken { get; set; }
    }

    public class InitialApplicationState
    {
        public string XsrfToken { get; set; }
        public string AccessToken { get; set; }

    }
}