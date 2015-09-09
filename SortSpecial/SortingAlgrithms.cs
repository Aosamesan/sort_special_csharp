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
}
