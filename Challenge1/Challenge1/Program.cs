using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge1.BL;
using System.IO;

namespace Challenge1
{
    class Program
    {
        static void Main(string[] args)
        {
          
            Products[] p = new Products[10];
            int count = 0;
            string path = "D:\\oop\\week2\\products.txt";
            ReadData(p, path);


            char option;
            do
            {
                option = menu();
                if (option == '1')
                {
                    p[count] = AddProducts();
                    count++;
                    Console.WriteLine("Product added");
                    Storedata(p, count, path);
                }
                else if (option == '2')
                {
                    ViewProducts(p, count);
                }
                else if (option == '3')
                {

                    float prices = Worth(p, count);
                    Console.WriteLine("Total worth: {0} ", prices);
                    Console.ReadKey();

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
            Console.WriteLine("1. add products");
            Console.WriteLine("2. view products");
            Console.WriteLine("3. view total worth");
            Console.WriteLine("4. exit");
            choice = char.Parse(Console.ReadLine());
            return choice;
        }
        static Products AddProducts()
        {
            Console.Clear();
            Products s1 = new Products();

            Console.WriteLine("Enter ID (number): ");
            s1.ID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter name : ");
            s1.name = Console.ReadLine();
            Console.WriteLine("Enter price: ");
            s1.price = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter category name :");
            s1.category = (Console.ReadLine());
            Console.WriteLine("Enter Brandname : ");
            s1.brandName = Console.ReadLine();
            Console.WriteLine("Enter country ");
            s1.country = Console.ReadLine();
           
            return s1;

        }
        static void ViewProducts(Products[] p , int count)
        {
            for(int x = 0; x < count; x++)
            {
                Console.WriteLine("ID: {0} Name: {1} Price: {2} Category: {3} Brandname: {4} Country: {5} " ,p[x].ID , p[x].name, p[x].price,p[x].category, p[x].brandName, p[x].country );
            }
            Console.ReadKey();
        }
        static float Worth(Products[] p , int count)
        {
            float sum = 0.0F;
            for(int x = 0; x < count; x++)
            {
                sum = sum + p[x].price;
            }
            return sum;
        }
        static void Storedata(Products[] p , int count , string path)
        {
            StreamWriter file = new StreamWriter(path, true);
            for(int x = 0; x < count; x++)
            {
                file.WriteLine(p[x].ID + "," + p[x].name + "," + p[x].price+ "," + p[x].category + "," + p[x].brandName + "," + p[x].country);
            }
            file.Flush();
            file.Close();

        }
        static string dataParse(string line, int field)
        {
            string item = "";
            int commacount = 1;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ',')
                {
                    commacount++;
                }
                else if (commacount == field)
                {
                    item = item + line[i];
                }
            }
            return item;
        }
        static void ReadData(Products[] p,string path)
        {
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    p[x].ID = int.Parse(dataParse(line, 1));
                    p[x].name = dataParse(line, 2);
                    p[x].price = float.Parse(dataParse(line, 3));
                    p[x].category = dataParse(line, 4);
                    p[x].brandName = dataParse(line, 5);
                    p[x].country = dataParse(line, 6);
                    x++;
                    if(x > 10)
                    {
                        break;
                    }

                }
                file.Close();
            }
        }

    }
}
