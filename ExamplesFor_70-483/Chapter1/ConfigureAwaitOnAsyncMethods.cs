using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExamplesFor_70_483_Chapter1
{
    public static class ConfigureAwaitOnAsyncMethods
    {
        public static void Launch()
        {
            string result = DownloadContentWithResponseToUI().Result;
            DownloadContentWithoutResponse();
        }

        //This example throws an exception if you run it at WPF app, the Output.Content line is not executed on the UI thread because of the ConfigureAwait(false). 
        //If you do something else, such as writing the content to file, you don’t need to set the SynchronizationContext to be set(see Listing 1-21).
        public static async Task<string> DownloadContentWithResponseToUI()
        {
            string content = string.Empty;
            try
            {
                HttpClient httpClient = new HttpClient();
                content = await httpClient.GetStringAsync("http://www.microsoft.com").ConfigureAwait(false);
                
                Console.WriteLine(content);

                //Use this line in WPF
                //Output.Content = content;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return content;
        }

        //When creating async methods, it’s important to choose a return type of Task or Task<T>. Avoid the void return type. 
        //A void returning async method is effectively a fire-and-forget method.You can never inspect the return type, exceptions, etc...
        //You should also avoid returning void from an async method except when it’s an event handler.
        public static async void DownloadContentWithoutResponse()
        {
            HttpClient httpClient = new HttpClient();
            string content = await httpClient.GetStringAsync("http://www.microsoft.com").ConfigureAwait(false);

            using (FileStream sourceStream = new FileStream("temp.html", FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync: true))
            {
                byte[] encodedText = Encoding.Unicode.GetBytes(content);
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length).ConfigureAwait(false);
            };
        }
    }
}