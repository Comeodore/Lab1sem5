using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnularList
{
    public class AnnularList<T>:IEnumerable<T>
    {
        public Item<T> head;
        public Item<T> tail;
        int count;
        public int Count { get { return count; } }

        public bool Empty { get { return count == 0; } }

        public void Add(T Data)
        {
            Item<T> newitem = new Item<T>(Data);

            if (head == null) // If list is empty
            {
                head = newitem;
                tail = newitem;
                tail.next = head;
            }
            else
            {
                newitem.next = head; // Put new item between head and tail
                tail.next = newitem;
                tail = newitem;
            }
            count++;
        }
        public void Remove(T Data)
        {
            Item<T> current = head;
            Item<T> previous = null;
            if (Empty)
            {
                Console.WriteLine("List is empty");
            }
            else
            {
                do
                {
                    if (current.data.Equals(Data))
                    {
                        if (previous != null) // Not the first item
                        {
                            previous.next = current.next;
                        }
                        if (current == tail) tail = previous; // If element is tail
                    }
                    else // If remove first element
                    {
                        if (count == 1) head = tail = null;
                        else
                        {
                            head = current.next;
                            tail.next = current.next;
                        }
                        count--;
                        Console.WriteLine("Element was removed");
                        break;
                    }
                    previous = current;
                    current = current.next;
                } while (current != head);
            }
        }
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        public bool Contains(T Data)
        {
            Item<T> current = head;
            if (current == null) return false;
            do
            {
                if (current.data.Equals(Data))
                    return true;
                current = current.next;
            }
            while (current != head);
            return false;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Item<T> current = head;
            do
            {
                if (current != null)
                {
                    yield return current.data;
                    current = current.next;
                }
            }
            while (current != head);
        }
    }
}
