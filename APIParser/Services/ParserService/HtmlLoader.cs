using APIParser.ConfigurationManager;
using System.Net;

namespace APIParser.Services.ParserService
{
    public static class HtmlLoader
    {
        private static SocketsHttpHandler socketHandler = new SocketsHttpHandler { PooledConnectionLifetime = TimeSpan.FromMinutes(2) };
        private static HttpClient _httpClient = new HttpClient(socketHandler);
        public static async Task<string> GetSourceByPageId(string url, int id)
        {
            var currentUrl = url.Replace("{CurrentId}", id.ToString());
            var response = await _httpClient.GetAsync(currentUrl);
            string source = string.Empty;

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }
    }
}
