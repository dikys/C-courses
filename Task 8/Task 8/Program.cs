using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

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
        
        public static IEnumerable<T> ReadCsv2<T>(string fileName)
        {
            var lines = ReadCsv1(fileName);
            var fieldNames = lines.First();

            lines = lines.Skip(1);

            //foreach (var line in lines)
            //{
            //    yield return new IEnumerable<T>();
            //}

            yield break;
        }

        static void Main(string[] args)
        {
            /*foreach (var str in ReadCsv1("airquality.csv"))
            {
                foreach (var element in str)
                {
                    Console.Write(element + ", ");
                }

                Console.WriteLine();
            }*/

            //var a = new { Id = 3, Speed = 3 };
            //dynamic a = new 

            foreach(var property in a.GetType().GetProperties())
            {
                Console.WriteLine("{0} = {1}", property.Name, property.GetValue(a));
            }

            Console.WriteLine(a.GetType());
        }
    }
}
