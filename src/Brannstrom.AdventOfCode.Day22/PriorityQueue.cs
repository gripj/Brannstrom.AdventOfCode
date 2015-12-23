using System;
using System.Collections.Generic;

namespace Brannstrom.AdventOfCode.Day22
{
    public class PriorityQueue<T>
    {
        private const int DefaultCapacity = 4;
        private static readonly T[] EmptyArray = new T[0];
        private readonly IComparer<T> _comparer;
        private T[] _items;

        public PriorityQueue(int capacity = 0, IComparer<T> comparer = null)
        {
            _items = capacity == 0 ? EmptyArray : new T[capacity];
            _comparer = comparer ?? Comparer<T>.Default;
        }

        public int Capacity => _items.Length;
        public int Count { get; private set; }

        public void Add(T item)
        {
            if (Count == Capacity)
                Expand();

            _items[Count] = item;
            BubbleUp(Count);
            Count++;
        }

        public T ExtractMax()
        {
            var min = _items[0];
            Count--;
            if (Count > 0)
                MoveLastToRoot();

            _items[Count] = default(T);
            return min;
        }

        private void MoveLastToRoot()
        {
            _items[0] = _items[Count];
            BubbleDown(0);
        }

        private void Expand()
        {
            var newCapacity = Math.Max(Count * 2, DefaultCapacity);
            Resize(newCapacity);
        }

        private void Resize(int newCapacity)
        {
            Array.Resize(ref _items, newCapacity);
        }

        private void BubbleUp(int index)
        {
            while (index != 0)
            {
                var parentIndex = (index - 1) / 2;

                if (ItemIsSmallerThanParent(index, parentIndex))
                    break;

                Swap(ref _items[index], ref _items[parentIndex]);
                index = parentIndex;
            }
        }

        private bool ItemIsSmallerThanParent(int itemIndex, int parentIndex)
        {
            return _comparer.Compare(_items[itemIndex], _items[parentIndex]) <= 0;
        }
        
        private void BubbleDown(int index)
        {
            while (true)
            {
                var left = index * 2 + 1;
                if (left >= Count)
                    break;

                var right = left + 1;
                var largestChildIndex = left;

                if (right < Count && _comparer.Compare(_items[right], _items[left]) > 0)
                    largestChildIndex = right;

                if (ItemIsLargerThanChildren(index, largestChildIndex))
                    break;

                Swap(ref _items[index], ref _items[largestChildIndex]);
                index = largestChildIndex;
            }
        }

        private bool ItemIsLargerThanChildren(int index, int largestChildIndex)
        {
            return _comparer.Compare(_items[index], _items[largestChildIndex]) >= 0;
        }

        private static void Swap<TVal>(ref TVal left, ref TVal right)
        {
            var temp = left;
            left = right;
            right = temp;
        }
    }
}
