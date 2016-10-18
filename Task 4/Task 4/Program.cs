using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {
        public static int Com(List<int> list)
        {
            return list.Select(x => x * x).First(x => x > 6);
        }

        static void Main(string[] args)
        {
            StorageId storage = new StorageId();
            storage.CreateObject<int>();
            storage.CreateObject<int>();
            storage.CreateObject<int>();
            storage.CreateObject<double>();
            storage.CreateObject<double>();

            storage.PrintAllGroupsObjects();
            
        }
    }
}
