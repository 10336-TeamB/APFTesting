using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APFTestingHookIn
{
    class DoubleLinkedList<T> : IEnumerable<T>
    {
        public class Iterator
        {
            public T Value { get; set; }
            public Iterator Previous { get; set; }
            public Iterator Next { get; set; }
        }

        public Iterator Begin { get; set; }
        public Iterator End { get; set; }
        public int Count
        {
            get
            {
                int retVal = 0;
                Iterator it = Begin;
                while (it != null)
                {
                    ++retVal;
                    it = it.Next;
                }
                return retVal;
            }
        }

        public DoubleLinkedList()
        {
            Clear();
        }

        private void addFirstValue(T value)
        {
            Begin = new Iterator();
            Begin.Value = value;
            End = Begin;
        }

        public void Clear() {
            Begin = null;
            End = null;
        }

        public void InsertBack(T value)
        {
            if (Begin == null)
            {
                addFirstValue(value);
            }
            else
            {
                End.Next = new Iterator();
                End = End.Next;
                End.Value = value;
            }
            
        }

        public void InsertFront(T value)
        {
            if (Begin == null)
            {
                addFirstValue(value);
            }
            else
            {
                Begin.Previous = new Iterator();
                Begin = Begin.Previous;
                Begin.Value = value;
            }
        }

        public void InsertBefore(T value, Iterator it)
        {
            if (it == null)
            {
                throw new IndexOutOfRangeException("Iterator cannot be null");
            }

            Iterator affectedIterator = it.Previous;
            if (affectedIterator == null)
            {
                it.Previous = new Iterator();
                it.Previous.Value = value;
                Begin = it.Previous;
            }
            else
            {
                Iterator newIterator = new Iterator();
                newIterator.Value = value;
                newIterator.Previous = affectedIterator;
                newIterator.Next = it;

                affectedIterator.Next = newIterator;
                it.Previous = newIterator;
            }
        }

        public void InsertAfter(T value, Iterator it)
        {
            if (it == null)
            {
                throw new IndexOutOfRangeException("Iterator cannot be null");
            }

            Iterator affectedIterator = it.Next;
            if (affectedIterator == null)
            {
                it.Next = new Iterator();
                it.Next.Value = value;
                End = it.Next;
            }
            else
            {
                Iterator newIterator = new Iterator();
                newIterator.Value = value;
                newIterator.Next = affectedIterator;
                newIterator.Previous = it;

                affectedIterator.Previous = newIterator;
                it.Next = newIterator;
            }
        }

        public void PopFront()
        {
            if (Begin == End)
            {
                Clear();
            } 
            else 
            {
                Begin = Begin.Next;
                Begin.Previous = null;
            }
        }

        public void PopBack()
        {
            if (Begin == End)
            {
                Clear();
            }
            else
            {
                Begin = Begin.Next;
                Begin.Previous = null;
            }
        }

        public void Delete(Iterator it)
        {
            if (it.Next == null && it.Previous == null)
            {
                Clear();
            }
            else
            {
                Iterator next = it.Next, previous = it.Previous;
                
                if (next != null)
                {
                    next.Previous = previous;
                }

                if (previous != null)
                {
                    previous.Next = next;
                }
            }
        }

        public T this[int index] {
            get
            {
                if (index < 0)
                {
                    throw new IndexOutOfRangeException("Index is out of bound");
                }
                
                Iterator retVal = Begin;
                while (index-- >= 0)
                {
                    retVal = retVal.Next;
                    if (retVal == null)
                    {
                        throw new IndexOutOfRangeException("Index is out of bound");
                    }
                }

                return retVal.Value;
            }
            
            set
            {
                if (index < 0)
                {
                    throw new IndexOutOfRangeException("Index is out of bound");
                }

                Iterator it = Begin;
                while (index-- >= 0)
                {
                    it = it.Next;
                    if (it == null)
                    {
                        throw new IndexOutOfRangeException("Index is out of bound");
                    }
                }

                it.Value = value;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Iterator it = Begin;
            while (it != null)
            {
                yield return it.Value;
                it = it.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
