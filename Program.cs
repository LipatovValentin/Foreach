using System;

namespace Foreach
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new Iterator<int>(1, 2, 3, 4, 5);
            foreach (var element in array)
            {
                Console.WriteLine(element);
            }
            Console.ReadKey();
        }
    }

    public class Iterator<T>
    {
        private T[] _items;
        private int _position = -1;
        public T Current
        {
            get
            {
                try
                {
                    return this._items[this._position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                } 
            }
        }
        public Iterator(params T[] values)
        {
            this._items = values;
        }
        public bool MoveNext()
        {
            this._position = this._position + 1;
            if (this._position >= this._items.Length)
            {
                this._position = -1;
                return false;
            }
            else
            {
                return true;
            }
        }
        public Iterator<T> GetEnumerator()
        {
            return this;
        }
    }
}
