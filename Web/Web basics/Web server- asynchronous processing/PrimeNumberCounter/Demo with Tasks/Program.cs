using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace Demo_with_Tasks
{
    class Program
    {
        static async Task Main()
        {
            //Task schedular
            //download
            //write file
            //send email
            //create
            //send over the internet


            Stopwatch sw = Stopwatch.StartNew();
            HttpClient httpClient = new HttpClient();
            List<Task> tasksList = new List<Task>();

            for (int i = 1; i <= 100; i++)
            {
                 var task =Task.Run(async ()=>
                {
                    var url = $"http://vicove.com/vic-{i}";
                    var httpsResponse = await httpClient.GetAsync(url);
                    var vic = await httpsResponse.Content.ReadAsStringAsync();
                    Console.WriteLine(vic.Length);
                });
                tasksList.Add(task);
            }

            Task.WaitAll(tasksList.ToArray());

            Console.WriteLine(sw.Elapsed);
            Console.ReadLine();
        }
    }
}
