using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnularList
{
    public class Item<T>
    {
        public Item(T Data)
        {
            data = Data;
        }
        public T data;
        public Item<T> next;
    }
}
