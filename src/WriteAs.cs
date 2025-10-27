using System.Net.Http;
using System.Net.Http.Headers;

namespace WriteAsApi
{
    public class WriteAs
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl = "https://write.as/api/";
        public WriteAs()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Write.as v1.7.0; Android");
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            httpClient.DefaultRequestHeaders.AcceptEncoding.ParseAdd("gzip");
            httpClient.DefaultRequestHeaders.ConnectionClose = false;
        }

        public async Task<string> PublishText(string word)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("w", word),
                new KeyValuePair<string, string>("font", "norm"),
                new KeyValuePair<string, string>("lang", "en"),
                new KeyValuePair<string, string>("rtl", "false")
            });
            var response = await httpClient.PostAsync(apiUrl, content);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
