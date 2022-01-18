
namespace PieShopHRM.App.Services
{
    public class TokenProvider
    {
        public string XsrfToken { get; set; } // = "XSRF-TOKEN";
        public string Cookie { get; set; }
    }

    public class InitialApplicationState
    {
        public string XsrfToken { get; set; }
        public string Cookie { get; set; }

    }
}