using System;

namespace Timer
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Timer();
            using (timer.Start())
            {
                for (var n = 0; n < 1000000; n++)
                {
                    var j = n + 1;
                }
            }
            Console.WriteLine(timer.ElapsedMilliseconds);

            using (timer.Continue())
            {
                for (var n = 0; n < 1000000; n++)
                {
                    var j = n + 1;
                }
            }
            Console.WriteLine(timer.ElapsedMilliseconds);
        }
    }
}
