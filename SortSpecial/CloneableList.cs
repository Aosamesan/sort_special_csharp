using System;
using System.Collections.Generic;

namespace SortingDataType
{
    public class CloneableList<T> : List<T>, ICloneable
    {
        public object Clone()
        {
            CloneableList<T> list = new CloneableList<T>();
            foreach (var value in this)
                list.Add(value);
            return list;
        }
    }
}
