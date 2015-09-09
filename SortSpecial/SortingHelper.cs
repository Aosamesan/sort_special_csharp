using SortSpecial.SortingAlgorithms;
using SortingDataType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SortSpecial
{
    class SortingHelper
    {
        public static void TestCase<T>(IList<int> testCases, int? length = null) where T : IComparable
        {
            Type algo;
            Sortable<T> sortAlgorithm;
            foreach (int size in testCases)
            {
                CloneableList<T> originArray = GenerateRandomArray<T>(size, length);
                foreach (Type genericAlgo in GetSortingAlgorithms<T>())
                {
                    algo = genericAlgo.MakeGenericType(typeof(T));
                    sortAlgorithm = Activator.CreateInstance(algo) as Sortable<T>;
                    var cloneArray = originArray.Clone() as CloneableList<T>;
                    Console.WriteLine($" - {sortAlgorithm.SortName}");
                    PrintArray(cloneArray);
                    sortAlgorithm.Sort(cloneArray);
                    PrintArray(cloneArray);
                    Console.WriteLine();
                }
            }
        }

        public static CloneableList<T> GenerateRandomArray<T>(params int?[] param) where T : IComparable
        {
            Type type = typeof(T);
            int size = param[0].HasValue ? param[0].Value : 10;
            int? length = param[1];

            if (type.GetInterface("IComparable") == null)
                return null;

            if (type == typeof(int))
            {
                return GenerateRandomIntegerArray(size) as CloneableList<T>;
            }
            else if (type == typeof(string))
            {
                return GenerateRandomStringArray(size, length) as CloneableList<T>;
            }
            else
            {
                return null;
            }
        }

        private static CloneableList<int> GenerateRandomIntegerArray(int size)
        {
            CloneableList<int> arr = new CloneableList<int>();
            Random r = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < size; i++)
                arr.Add(r.Next(size));

            return arr;
        }

        private static CloneableList<string> GenerateRandomStringArray(int size, int? length)
        {
            CloneableList<string> arr = new CloneableList<string>();
            Random r = new Random(DateTime.Now.Millisecond);
            length = length.HasValue ? length.Value : 5;

            for (int i = 0; i < size; i++)
            {
                string tmp = "";
                for (int j = 0; j < length; j++)
                {
                    tmp += Convert.ToChar(r.Next() % 26 + 'A');
                }
                arr.Add(tmp);
            }

            return arr;
        }

        public static void PrintArray<T>(CloneableList<T> arr) where T : IComparable
        {
            foreach (T i in arr)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine(IsSorted<T>(arr) ? "Sorted" : "Unsorted");
        }

        public static bool IsSorted<T>(CloneableList<T> arr) where T : IComparable
        {
            for (int i = 0; i < arr.Count - 1; i++)
            {
                if (SortingAlgorithms.Sortable<T>.CompareItems(arr[i], arr[i + 1]))
                    return false;
            }
            return true;
        }

        public static Type[] GetSortingAlgorithms<T>() where T : IComparable
        {
            Console.WriteLine(typeof(T).Name);
            foreach(Type t in Assembly.GetExecutingAssembly().GetTypes())
            {
                foreach(var f in t.GetInterfaces())
                Console.WriteLine(f.Name);
            }

            return Assembly.GetExecutingAssembly().GetTypes().Where(type =>
                String.Equals(type.Namespace, "SortSpecial.SortingAlgorithms")
                && type.IsSubclassOf(typeof(Sortable<T>))
                && !type.IsAbstract).ToArray();
        }
    }
}
