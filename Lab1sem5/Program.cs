using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyList;

namespace Lab1sem5
{
    class Program
    {
        static void Main()
        {
            AnnularList<string> ts = new AnnularList<string>();
            Console.WriteLine("Add new items to Annular List\n");
            ts.Add("Gosha");
            ts.Add("Alex");
            ts.Add("Vova");
            ts.Add("Katia");
            Console.WriteLine("\nOur List:");
            foreach (var item in ts)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nList count: " + ts.Count());
            ts.Contains("Vova");
            ts.Remove("Vova");
            ts.Contains("Vova");
            ts.Remove("Vova");
            Console.WriteLine("\nList after remove");
            foreach (var item in ts)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n" + "Is list is empty? " + ts.Empty);
            ts.Clear();
            Console.WriteLine("List count: " + ts.Count());
            Console.ReadLine();
        }
    }
}
