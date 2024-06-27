using APIParser.ConfigurationManager;
using System.Net;

namespace APIParser.Services.ParserService
{
    internal class HtmlLoader
    {
        readonly HttpClient client;

        public HtmlLoader(IParserSettings settings)
        {
            client = new HttpClient();
        }
        public async Task<string> GetSourceByPageId(string url, int id)
        {
            var currentUrl = url.Replace("{CurrentId}", id.ToString());
            var response = await client.GetAsync(currentUrl);
            string source = null;

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }
    }
}
