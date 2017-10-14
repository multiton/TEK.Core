using System;
using System.Net.Http;

namespace TEK.Core.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Start the web-api host and press Enter to send request");
            Console.ReadLine();

            do
            {
                Console.Clear();
                Load();                
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        static async void Load()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var task = await httpClient.GetAsync(
                        "http://localhost:51404/api/asynch/1000000",
                        HttpCompletionOption.ResponseHeadersRead);

					using (var consoleOut = Console.OpenStandardOutput())
                    {
                        using (var result = await task.Content.ReadAsStreamAsync())
                        {
							await result.CopyToAsync(consoleOut);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}