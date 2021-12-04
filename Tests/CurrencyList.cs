using System.Collections.Generic;

namespace Tests
{
    class MyList<T>
    {
        private List<T> innerList = new List<T>();

        public T this[int index]
        {
            get
            {
                return innerList[index];
            }
            set
            {
                innerList[index] = value;
            }
        }

        public void Add(T value)
        {
            innerList.Add(value);
        }
    }
}
