using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace weather.Helpers
{
    public static class RestConnector
    {
        public static async Task<string> GetObjectAsync(string conn)
        {
            var response = string.Empty;
            try
            {
                var client = new HttpClient();
                var httpResponse = await client.GetAsync(conn);
                response = await httpResponse.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return response;
        }
    }
}
