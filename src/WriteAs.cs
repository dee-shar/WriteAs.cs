using System;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WriteAsApi
{
    public class WriteAs
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl = "https://write.as/api";
        public WriteAs()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36");
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        }

        public async Task<string> publishText(string word)
        {
            var content = new StringContent(
                $"w={word}&font=norm&lang=en&rtl=false", Encoding.UTF8);
            var response = await httpClient.PostAsync(apiUrl, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
