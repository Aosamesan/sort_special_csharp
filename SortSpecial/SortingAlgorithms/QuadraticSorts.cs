using SortingDataType;
using System;

namespace SortSpecial.SortingAlgorithms
{

    internal class BubbleSort<T> : Sortable<T> where T : IComparable
    {
        public override void Sort(CloneableList<T> list)
        {
            ResetCount();
            for (int i = list.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (CompareItems(list[j], list[j + 1]))
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
        public override void Sort(CloneableList<T> list)
        {
            ResetCount();
            int minIndex = 0;

            for (int i = 0; i < list.Count - 1; i++)
            {
                minIndex = i + 1;
                for (int j = minIndex; j < list.Count; j++)
                {
                    if (CompareItems(list[minIndex], list[j]))
                        minIndex = j;
                }

                if (CompareItems(list[i], list[minIndex]))
                {
                    T tmp = list[i];
                    list[i] = list[minIndex];
                    list[minIndex] = tmp;
                }
            }
        }
    }

    internal class InsertionSort<T> : Sortable<T> where T : IComparable
    {
        public override void Sort(CloneableList<T> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                int j = i + 1;
                T tmp = list[j];
                while (--j >= 0 && CompareItems(list[j], tmp))
                    list[j + 1] = list[j];

                list[j + 1] = tmp;
            }
        }
    }
}
