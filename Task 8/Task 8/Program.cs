using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task_8
{
    public class Program
    {
        public static IEnumerable<string[]> ReadCsv1(string fileName)
        {
            using (var stream = new StreamReader(fileName))
            {
                string line;

                while ((line = stream.ReadLine()) != null)
                {
                    yield return line.Split(',')
                        .Select(str => str == "NA" ? null : str)
                        .ToArray();
                }

                stream.Close();
                yield break;
            }
        }
        
        /*public static IEnumerable<T> ReadCsv2<T>(string fileName)
        {
            var file = ReadCsv1(fileName);

            var fields = file.First();

            var lines = file.Skip(1);

            foreach (var line in lines)
            {
                
            }
        }*/

        static void Main(string[] args)
        {
            foreach (var str in ReadCsv1("airquality.csv"))
            {
                foreach (var element in str)
                {
                    Console.Write(element + ", ");
                }

                Console.WriteLine();
            }
        }
    }
}
