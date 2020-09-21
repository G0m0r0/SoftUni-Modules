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
                var task = Task.Run(async () =>
                  {
                      var input = Console.ReadLine();

                      switch (input)
                      {
                          case "start":
                              chronometer.Start();
                              break;
                          case "stop": chronometer.Stop(); break;
                          case "lap": Console.WriteLine(chronometer.Lap()); break;
                          case "laps":
                              List<string> listOfTimes = chronometer.Laps;

                              if (listOfTimes.Count == 0)
                              {
                                  Console.WriteLine("Laps: no laps");
                                  return;
                              }

                              Console.WriteLine("Laps:");
                              for (int i = 0; i < listOfTimes.Count; i++)
                              {
                                  Console.WriteLine($"{i}. {listOfTimes[i]}");
                              }

                              break;
                          case "time": Console.WriteLine(chronometer.GetTime); break;
                          case "reset": chronometer.Reset(); break;
                          case "exit": Environment.Exit(1); break;
                          default:
                              Console.WriteLine("Invalid operation!");
                              break;
                      }
                  });                
           }
        }
    }
}
