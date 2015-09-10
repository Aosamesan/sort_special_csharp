using System;
using SortingDataType;
using System.Reflection;
using System.Collections.Generic;

namespace SortSpecial.SortingAlgorithms
{
    internal class MergeSort<T> : Sortable<T> where T : IComparable
    {
        public override void Sort(CloneableList<T> list)
        {
            Sort(list, 0, list.Count - 1);
        }

        private void Sort(CloneableList<T> list, int left, int right)
        {
            if (left >= right)
                return;

            int mid = (left + right) / 2;

            Sort(list, left, mid);
            Sort(list, mid + 1, right);

            int leftHold = left;
            int rightHold = right;
            right = mid + 1;
            Queue<T> tempQueue = new Queue<T>();

            while(left <= mid && right <= rightHold)
            {
                if(CompareItems(list[left],list[right]))
                {
                    tempQueue.Enqueue(list[right++]);
                }
                else
                {
                    tempQueue.Enqueue(list[left++]);
                }
            }

            while (left <= mid)
                tempQueue.Enqueue(list[left++]);
            while (right <= rightHold)
                tempQueue.Enqueue(list[right++]);

            for (int i = leftHold; i <= rightHold; i++)
                list[i] = tempQueue.Dequeue();
        }
    }
}
