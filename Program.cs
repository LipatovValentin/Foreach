using System;

namespace Foreach
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new SimpleClass<int>(new[] { 1, 2, 3, 4, 5});
            foreach (var element in array)
            {
                Console.WriteLine(element);
            }
            Console.ReadKey();
        }
    }

    public class SimpleClass<T>
    {
        private T[] _array;
        private int _position = -1;
        public T Current
        {
            get
            {
                try
                {
                    return this._array[this._position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                } 
            }
        }
        public SimpleClass (params T[] values)
        {
            this._array = values;
        }
        public bool MoveNext()
        {
            this._position = this._position + 1;
            if (this._position >= this._array.Length)
            {
                this._position = -1;
                return false;
            }
            else
            {
                return true;
            }
        }
        public SimpleClass<T> GetEnumerator()
        {
            return this;
        }
    }
}
