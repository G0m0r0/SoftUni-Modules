using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IChronometer
{
    public class Chronometer : IChronometer
    {
        public Stopwatch sw { get; set; }

        public Chronometer()
        {
            sw = new Stopwatch();
            laps = new List<string>();
        }

        public string GetTime =>string.Format(
            $"{Math.Round(sw.Elapsed.TotalMinutes)}:" +
            $"{Math.Round(sw.Elapsed.TotalSeconds)}:" +
            $"{Math.Round(sw.Elapsed.TotalMilliseconds)}","00:00:0000");

        List<string> IChronometer.Laps => this.laps;
        public List<string> laps;

        public string Lap()
        {
            laps.Add(string.Format(
            $"{Math.Round(sw.Elapsed.TotalMinutes)}:" +
            $"{Math.Round(sw.Elapsed.TotalSeconds)}:" +
            $"{Math.Round(sw.Elapsed.TotalMilliseconds)}", "00:00:0000"));

            return string.Format(
            $"{Math.Round(sw.Elapsed.TotalMinutes)}:" +
            $"{Math.Round(sw.Elapsed.TotalSeconds)}:" +
            $"{Math.Round(sw.Elapsed.TotalMilliseconds)}", "00:00:0000");
        }

        public void Reset()
        {
            sw.Reset();
            laps.Clear();
            Thread.Sleep(3000);
           // await Task.Delay(3000);
        }

        public void Start()
        {
            sw.Start();
            Thread.Sleep(3000);
        }

        public void Stop()
        {
            sw.Stop();
            Thread.Sleep(3000);
        }
    }
}
