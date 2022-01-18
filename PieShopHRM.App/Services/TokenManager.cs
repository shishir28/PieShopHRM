
using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace PieShopHRM.App.Services
{
    public class TokenManager
    {

        private readonly TokenProvider _tokenProvider;
        private readonly IHttpClientFactory _httpClientFactory;

        public TokenManager(TokenProvider tokenProvider, IHttpClientFactory httpClientFactory)
        {
            _tokenProvider = tokenProvider ?? throw new ArgumentNullException(nameof(tokenProvider));
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<string> RetrieveAccessTokenAsync()
        {
            if (_tokenProvider.ExpiresAt.AddSeconds(-60).ToUniversalTime() > DateTimeOffset.UtcNow)
                return _tokenProvider.AccessToken;

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetDiscoveryDocumentAsync("https://localhost:5000");
            var refreshResponse = await client.RequestRefreshTokenAsync(new RefreshTokenRequest
            {
                Address = response.TokenEndpoint,
                ClientId = "PieShopHRM",
                ClientSecret = "49C1A7E1-0C79-4A89-A3D6-A37998FB86B0",
                RefreshToken = _tokenProvider.RefreshToken
            });

            _tokenProvider.AccessToken = refreshResponse.AccessToken;
            _tokenProvider.RefreshToken = refreshResponse.RefreshToken;
            _tokenProvider.ExpiresAt = DateTime.UtcNow.AddSeconds(refreshResponse.ExpiresIn);

            return _tokenProvider.AccessToken;
        }

    }


}