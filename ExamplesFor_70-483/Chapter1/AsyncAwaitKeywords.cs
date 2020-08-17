using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExamplesFor_70_483_Chapter1
{
    public static class AsyncAwaitKeywords
    {
        public static void Launch()
        {
            string result = DownloadContent().Result;
            Console.WriteLine(result);
        }
        public static async Task<string> DownloadContent()
        {
            using (HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync("http://www.microsoft.com");
                return result;
            }
        }
    }
}