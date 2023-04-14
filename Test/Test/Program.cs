using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        static char menu()
        {
           
                char choice;
                Console.WriteLine("1. Add students.");
                Console.WriteLine("2. View students");
                Console.WriteLine("3. Top 3 students");
                Console.WriteLine("4. Exit");
                choice = char.Parse(Console.ReadLine());
                return choice;

           
        }
        static Students Add()
        {
            Console.Clear();
            Students s1 = new Students();
        }
    }
}
