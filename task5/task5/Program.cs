using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task5.BL;

namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Students[] s = new Students[10];
            int count = 0;
            char option;
            do
            {
                option = menu();
                if (option == '1')
                {
                    s[count] = addStudent();
                    count++;
                }
                else if (option == '2')
                {
                    ViewStudents(s, count);
                }
                else if (option == '3')
                {
                    TopStudents(s, count);

                }
                else if (option == '4')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                }
            }
            while (option != 4);
                Console.WriteLine("Press enter to exit");
                Console.ReadKey();
               
            
           
        }
        static char menu()
        {
            Console.Clear();
            char choice;
            Console.WriteLine("1. add students");
            Console.WriteLine("2. view students");
            Console.WriteLine("3. top students");
            Console.WriteLine("4. exit");
            choice = char.Parse(Console.ReadLine());
            return choice;
        }
        static Students addStudent()
        {
            Console.Clear();
            Students s1 = new Students();
            Console.WriteLine("Enter name: ");
            s1.name = Console.ReadLine();
            Console.WriteLine("Enter roll number : ");
            s1.roll_number = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter cgpa: ");
            s1.cgpa = float.Parse(Console.ReadLine());
            Console.WriteLine("Is Hostelide Y for yes N for no :");
            s1.is_hostelide = char.Parse(Console.ReadLine());
            Console.WriteLine("Enter department: ");
            s1.department = Console.ReadLine();
            Console.ReadKey();
            return s1;

        }
        static void ViewStudents(Students [] s1 , int count)
        {

            for(int x = 0; x < count; x++)
            {
                Console.WriteLine("Name: {0} Roll number: {1} CGPA: {2} Is Hostelide: {3} Departmen: {4} ", s1[x].name, s1[x].roll_number, s1[x].cgpa, s1[x].is_hostelide, s1[x].department);
            }
            Console.WriteLine("Press any key to continue ");
            Console.ReadKey();
          
        }
        static void TopStudents(Students[] s, int count)
        {
            Console.Clear();
            if(count == 0)
            {
                Console.WriteLine("No Record Present");
            }
            else if(count == 1)
            {
                ViewStudents(s, 1);
            }
            else if(count == 2)
            {
                for(int x = 0; x < 2; x++)
                {
                    int index = Largest(s, x, count);
                    Students temp = s[index];
                    s[index] = s[x];
                    s[x] = temp;
                        
                }
                ViewStudents(s, 2);
            }
            else
            {
                for(int x = 0; x < 3; x++)
                {
                    int index = Largest(s, x, count);
                    Students temp = s[index];
                    s[index] = s[x];
                    s[x] = temp;
                }
                ViewStudents(s, 3);
            }


        }
        static int Largest(Students[] s, int start, int end)
        {
            int index = start;
            float large = s[start].cgpa;
            for(int x = start; x < end; x++)
            {
                if(large< s[x].cgpa)
                {
                    large = s[x].cgpa;
                    index = x;
                }
            }
            return index;

        }


    }
}
