using System;
using System.Diagnostics;

namespace Timer
{
    public class Timer : IDisposable
    {
        private Stopwatch stopwatch;

        public long ElapsedMilliseconds
        {
            get { return this.stopwatch.ElapsedTicks; }
        }

        public Timer()
        {
            stopwatch = new Stopwatch();
        }

        public void Dispose()
        {
            this.stopwatch.Stop();
        }

        public Timer Start()
        {
            this.stopwatch.Reset();
            this.stopwatch.Start();

            return this;
        }

        public Timer Continue()
        {
            this.stopwatch.Start();

            return this;
        }
    }
}
