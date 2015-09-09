using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace SortSpecial
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeString = Console.ReadLine();
            Type type = null;
            List<int> testCases;
            int? length = null;

            switch (typeString.ToUpper())
            {
                case "INT":
                case "INTEGER":
                    type = typeof(int);
                    break;
                case "STRING":
                case "STR":
                    type = typeof(string);
                    
                    break;
                default:
                    return;
            }
            string s;
            testCases = new List<int>();
            while ((s = Console.ReadLine()) != "-1")
            {
                try
                {
                    var item = Convert.ToInt32(s);
                    testCases.Add(item);
                }
                catch(FormatException e)
                {
                    PrintStackTrace(e);
                }
            }

            typeof(SortingHelper).GetMethod("TestCase").MakeGenericMethod(type).Invoke(null, new object[] { testCases, length });
        }

        [Conditional("DEBUG")]
        private static void PrintStackTrace(Exception e)
            => Console.Error.WriteLine(e.StackTrace);
    }
}
