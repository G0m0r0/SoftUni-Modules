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
        public Stopwatch Stopwatch { get; set; }
        public TimeSpan Milliseconds { get; set; }
        public TimeSpan Seconds { get; set; }
        public TimeSpan Minutes { get; set; }

        public Chronometer()
        {
            Stopwatch = new Stopwatch();
        }

        public string GetTime => string.Format($"{Minutes.TotalMinutes}:{Seconds.TotalSeconds}:{Milliseconds.TotalMilliseconds}","00:00:0000");

        public List<string> Laps => Laps;

        public string Lap()
        {
            Laps.Add(string.Format(
                $"{Minutes.TotalMinutes}:{Seconds.TotalSeconds}:{Milliseconds.TotalMilliseconds}"
                , "00:00:0000"));

            return string.Format($"{Minutes.TotalMinutes}:{Seconds.TotalSeconds}:{Milliseconds.TotalMilliseconds}","00:00:0000");
        }

        public void Reset()
        {
            Stopwatch.Restart();
        }

        public void Start()
        {

        }

        private void MyMethod3()
        {
            throw new NotImplementedException();
        }

        private void MyMethod2()
        {
            throw new NotImplementedException();
        }

        private void MyMethod1()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            Stopwatch.Stop();        
        }
    }
}
