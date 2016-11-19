using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Dynamic;
using System.Globalization;
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
            var fieldNames = new string[]
            {
                "Name",
                "Ozone",
                "Solar.R",
                "Wind",
                "Temp",
                "Month",
                "Day"
            };
            var fieldTypes = new Type[]
            {
                typeof(string),
                typeof(int?),
                typeof(int?),
                typeof(double),
                typeof(int),
                typeof(int),
                typeof(int)
            };
            
            var allFieldsT = typeof(T).GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            var fieldsInfo = new FieldInfo[fieldNames.Length];

            for (var i = 0; i < fieldsInfo.Length; i++)
            {
                FieldInfo fieldInfo = allFieldsT.First(z => z.Name == fieldNames[i]);

                if (fieldInfo == null)
                {
                    throw new ArgumentException("Type T have not field with Name = " + fieldNames[i]);
                }

                if (fieldInfo.FieldType != fieldTypes[i])
                {
                    throw new ArgumentException("Type T have not field with Name = " + fieldNames[i] + " and Type = " + fieldTypes[i]);
                }

                fieldsInfo[i] = fieldInfo;
            }

            var lines = ReadCsv3(fileName).Skip(1);

            foreach (var line in lines)
            {
                T result = (T)Activator.CreateInstance(typeof(T));

                for (var i = 0; i < fieldsInfo.Length; i++)
                {
                    fieldsInfo[i].SetValue(result, line[fieldNames[i]]);
                }

                yield return result;
            }

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
                
                result.Add(fieldNames[0], line[0]);
                result.Add(fieldNames[1], line[1] == null ? (int?)null : Int32.Parse(line[1]));
                result.Add(fieldNames[2], line[2] == null ? (int?)null : Int32.Parse(line[2]));
                result.Add(fieldNames[3], Double.Parse(line[3], CultureInfo.InvariantCulture));
                result.Add(fieldNames[4], Int32.Parse(line[4]));
                result.Add(fieldNames[5], Int32.Parse(line[5]));
                result.Add(fieldNames[6], Int32.Parse(line[6]));

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

            //var a = Program.ReadCsv4("airquality.csv").ElementAt(4);
            //Console.WriteLine(a);
        }
    }
}
