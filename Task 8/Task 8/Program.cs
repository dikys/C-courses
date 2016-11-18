using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Dynamic;

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
                    yield return line.Replace("\"", "")
                        .Split(',')
                        .Select(str => str == "NA" ? null : str)
                        .ToArray();
                }

                stream.Close();
            }
        }
        
        public static IEnumerable<T> ReadCsv2<T>(string fileName)
        {
            var lines = ReadCsv1(fileName);
            var fieldNames = lines.First();

            lines = lines.Skip(1);
            
            yield break;
        }

        public static IEnumerable<Dictionary<string, object>> ReadCsv3(string fileName)
        {
            var lines = ReadCsv1(fileName);
            var fieldNames = lines.First();

            lines = lines.Skip(1);

            foreach (var line in lines)
            {
                var result = new Dictionary<string, object>();
                
                for (var i = 0; i < line.Length; i++)
                    result.Add(fieldNames[i], line[i]);

                yield return result;
            }
        }

        public static IEnumerable<dynamic> ReadCsv4(string fileName)
        {
            foreach (var element in ReadCsv3(fileName))
            {
                dynamic result = new ExpandoObject();
                var dictionary = (IDictionary<string, object>) result;

                foreach (var propery in element)
                {
                    dictionary[propery.Key] = propery.Value;
                }

                yield return result;
            }
        }

        static void Main(string[] args)
        {
            //foreach (var str in ReadCsv1("airquality.csv"))
            //{
            //    foreach (var element in str)
            //    {
            //        Console.Write(element + ", ");
            //    }

            //    Console.WriteLine();
            //}

            //Program.ReadCsv4("airquality.csv").Where(z => z.Ozone > 10).Select(z => z.Wind).ToList().ForEach(z => Console.WriteLine(z.Name));

            //Program.ReadCsv4("airquality.csv").ToList().ForEach(z => Console.WriteLine(z.Ozone));

            Console.WriteLine();
        }
    }
}
