using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace SimpleLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string url = args[0];
                var totalRequests = 100;
                int.TryParse(args[1], out totalRequests);

                var sw = new Stopwatch();
                var client = new WebClient();

                long totalTime = 0;
                int requestCount = 0;

                //warm up website
                Console.WriteLine($"Warming up {url}");
                ReadUrl(client, url);
                Console.WriteLine($"End of warming up {url}");
                Console.WriteLine("--------------------------------------");
                //end of warm up

                for (int i = 0; i < totalRequests; i++)
                {
                    sw.Reset();
                    sw.Start();

                    requestCount += 1;
                    ReadUrl(client, url);

                    sw.Stop();
                    totalTime += sw.ElapsedMilliseconds;
                }

                float avg = totalTime / requestCount;
                Console.WriteLine($"Total Time: {totalTime}");
                Console.WriteLine($"Total requests: {requestCount}");
                Console.WriteLine($"Average request time (ms): {avg}");
            }
            catch (Exception)
            {
                Console.WriteLine("Please use following arguments: 1) URL to the page that you would like to request, 2) Number of requests you would like to perform");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void ReadUrl(WebClient client, string url)
        {
            var stream = client.OpenRead(url);
            if (stream != null)
            {
                var reader = new StreamReader(stream);
                var content = reader.ReadToEnd();
                reader.Dispose();
            }
        }
    }
}
