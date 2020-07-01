using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SearchfightManager
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            var queryParams = "?args=";

            foreach (var argument in args)
            {
                queryParams = queryParams + argument;
            }

            for (int i = 0; i < args.Length; i++)
            {
                if (i == 0)
                {
                    queryParams = "?args=" + args[i];
                }
                else
                {
                    queryParams = queryParams + "&args=" + args[i];
                }
            }
            HttpResponseMessage response = await client.GetAsync(@"https://localhost:44331/searchfight" + queryParams);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
    }
}
