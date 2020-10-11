using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IChronometer
{
    class StartUp
    {
        static async Task Main()
        {
            IChronometer chronometer = new Chronometer();

            while (true)
            {
                var input = Console.ReadLine();

                switch (input)
                {
                    case "start":
                        var startTask=Task.Run(()=> chronometer.Start());
                        //chronometer.Start();
                        break;
                    case "stop":
                       var stopTask=Task.Run(()=> chronometer.Stop());
                        break;
                    case "lap":
                        var lapTask = Task.Run(() => chronometer.Lap());
                        Console.WriteLine(lapTask.Result);
                        break;
                    case "laps":
                        var taskLaps=Task.Run(()=> chronometer.Laps);
                        List<string> listOfTimes = taskLaps.Result;

                        PrintLaps(listOfTimes);
                        break;
                    case "time":
                     var taskGetTime=Task.Run(()=> chronometer.GetTime);
                        Console.WriteLine(taskGetTime.Result);
                        break;
                    case "reset":
                       var taskReset= Task.Run(()=> chronometer.Reset());
                        break;
                    case "exit":
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Invalid operation!");
                        break;
                }


            }
        }

        private static void PrintLaps(List<string> listOfTimes)
        {
            if (listOfTimes.Count == 0)
            {
                Console.WriteLine("Laps: no laps");
            }
            else
            {
                Console.WriteLine("Laps:");
                for (int i = 0; i < listOfTimes.Count; i++)
                {
                    Console.WriteLine($"{i}. {listOfTimes[i]}");
                }
            }
        }
    }
}
