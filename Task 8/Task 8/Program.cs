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
                while (true)
                {
                    var strings = stream.ReadLine();

                    if (strings == null)
                    {
                        stream.Close();
                        yield break;
                    }
                    
                    yield return strings.Split(',')
                        .Select(str => str == "NA" ? null : str)
                        .ToArray();
                }
            }
        }

        #region Сюда не смотреть
        /*public static IEnumerable<T> ReadCsv2<T>(string fileName)
        {
            var file = ReadCsv1(fileName);

            var fields = file.First();

            var lines = file.Skip(1);

            foreach (var line in lines)
            {
                
            }
        }*/
        #endregion

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
