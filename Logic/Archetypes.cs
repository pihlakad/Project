using System;
using System.Collections;
using System.Collections.Generic;

namespace Logic
{
    public class Archetypes<T>: Archetype, IList<T>
    {
        private List<T> list = new List<T>();
        public IEnumerator<T> GetEnumerator() {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public void Add(T item) {
            list.Add(item);
        }

        public void Clear() {
            list.Clear();
        }

        public bool Contains(T item) {
            return list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex) {
            list.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item) {
            return list.Remove(item);
        }

        public int Count { get; }
        public bool IsReadOnly { get; }
        public int IndexOf(T item) {
            return list.IndexOf(item);
        }

        public void Insert(int index, T item) {
            list.Insert(index, item);
        }

        public void RemoveAt(int index) {
            list.RemoveAt(index);
        }

        public T this[int index] {
            get { return list[index]; }
            set { list[index] = value; }
        }
        public T Find(Predicate<T> match)
        {
            return list.Find(match);
        }

    }
}
