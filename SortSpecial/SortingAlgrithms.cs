using SortingDataType;
using System;

namespace SortingAlgorithms
{
    internal abstract class Sortable<T> where T : IComparable
    {
        public long Count { get; private set; }
        public string SortName { get; }
        public abstract void Sort(CloneableList<T> list);

        /// <summary>
        /// CompareTo를 간단히 item1 > item2
        /// </summary>
        /// <param name="item1">IComparable Object</param>
        /// <param name="item2">IComparable Object</param>
        /// <returns>item1 > item2</returns>
        public static bool CompareItems(T item1, T item2)
            => item1.CompareTo(item2) > 0;

        protected Sortable()
        {
            ResetCount();
        }

        protected Sortable(string sortName) : this()
        {
            SortName = sortName;
        }

        public void ResetCount()
        {
            Count = 0;
        }
    }

    internal class BubbleSort<T> : Sortable<T> where T : IComparable
    {
        public BubbleSort() : base("Bubble Sort") { }

        public override void Sort(CloneableList<T> list)
        {
            ResetCount();
            for(int i = list.Count - 1; i > 0; i--)
            {
                for(int j = 0; j < i; j++)
                {
                    if(CompareItems(list[j], list[j+1]))
                    {
                        var tmp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = tmp;
                    }
                }
            }
        }
    }

    internal class SelectionSort<T> : Sortable<T> where T : IComparable
    {
        public SelectionSort() : base("Selection Sort") { }

        public override void Sort(CloneableList<T> list)
        {
            ResetCount();
            int minIndex = 0;

            for(int i = 0; i < list.Count - 1; i++)
            {
                minIndex = i + 1;
                for(int j = minIndex; j < list.Count; j++)
                {
                    if (CompareItems(list[minIndex], list[j]))
                        minIndex = j;
                }

                if(CompareItems(list[i], list[minIndex]))
                {
                    T tmp = list[i];
                    list[i] = list[minIndex];
                    list[minIndex] = tmp;
                }
            }
        }
    }
}
