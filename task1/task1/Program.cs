using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        class Students
        {
            public string name;
            public int roll_number;
            public float cgpa;
        }
        static void Main(string[] args)
        {
            /*            Task1
                        Console.ReadKey();*/
            /*  Task2*/
            /*   Students s1 = new Students();
               s1.name = "Bisma";
               s1.roll_number = 66;
               s1.cgpa = 3.6F;
               Console.WriteLine("Name: {0} Roll-No: {1} CGPA: {2}", s1.name, s1.roll_number, s1.cgpa);
               Console.ReadKey();*/
            /* Task3*/
            /* Students s1 = new Students();
             s1.name = "Bisma";
             s1.roll_number = 66;
             s1.cgpa = 3.6F;
             Console.WriteLine("Name: {0} Roll-No: {1} CGPA: {2}", s1.name, s1.roll_number, s1.cgpa);

             Students s2 = new Students();
             s2.name = "Fajar";
             s2.roll_number = 65;
             s2.cgpa = 3.5F;
             Console.WriteLine("Name: {0} Roll-No: {1} CGPA: {2}", s2.name, s2.roll_number, s2.cgpa);
             Console.ReadKey();*/
            /* 
             Task4*/
            Students s1 = new Students();
            Console.WriteLine("Enter name: ");
            s1.name = Console.ReadLine();
            Console.WriteLine("Enter roll number : ");
            s1.roll_number = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter cgpa: ");
            s1.cgpa = float.Parse(Console.ReadLine());
            Console.ReadKey();



        }
    }
}
