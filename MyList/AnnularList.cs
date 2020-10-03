using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
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
        public string Remove(T Data)
        {
            Item<T> current = head;
            Item<T> previous = null;
            if (Empty) return "List is empty";
            do
            {
                if (current.data.Equals(Data))
                {
                    if (previous != null) // If not first
                    {
                        previous.next = current.next;
                        if (current == tail) tail = previous;
                    }
                    else
                    {
                        if (count == 1) // If we delete first item and list count is 1
                        {
                            head = tail = null;
                        }
                        else
                        {
                            head = current.next;
                            tail.next = current.next;
                        }
                    }
                    count--;
                    return "Item '" + Data + "' removed";
                }
                previous = current;
                current = current.next;
            } while (current != head);
            return "Item '" + Data + "' not in list";
        }
        public string Clear()
        {
            head = null;
            tail = null;
            count = 0;
            return "Cleared";
        }
        public string Contains(T Data)
        {
            Item<T> current = head;
            if (current == null) return "List is empty";
            do
            {
                if (current.data.Equals(Data))
                    return "Item '"+ Data + "' found";
                current = current.next;
            }
            while (current != head);
            return "Item '" + Data + "' not found";
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
