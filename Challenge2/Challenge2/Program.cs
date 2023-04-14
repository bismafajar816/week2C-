using System;
using System.IO;

namespace Challenge2
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = "D:\\oop\\week2\\users.txt";
            int option;
            string name = "";
            string password = "";

            Users[] u = new Users[10];
            int count = 0;
            readData(path, count, u);
            Console.ReadKey();

            do
            {

                Console.Clear();
                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    u[count] = SignUp();
                    count++;
                    StoreData(path, u, count);
                    option = menu();
                }
                if (option == 2)
                {
                    SignIn(name, password, u,count);


                    option = menu();
                }
            }
            while (option >= 3);
            Console.ReadKey();

        }
        static int menu()
        {
            Console.WriteLine("1. Sign up");
            Console.WriteLine("2. Sign In");
            Console.WriteLine("3. Exit");
            int option;
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static Users SignUp()
        {
            Console.Clear();
            Users u1 = new Users();
            Console.WriteLine("Write name: ");
            u1.name = Console.ReadLine();
            Console.Write("Write password: ");
            u1.password = Console.ReadLine();
            return u1;
        }
        static void SignIn(string name, string password, Users[] u, int count)
        {
            Console.WriteLine("Write name: ");
            name = Console.ReadLine();
            Console.Write("Write password: ");
            password = Console.ReadLine();
            bool ans = Check(u, count, name, password);
            if (ans == true)
            {
                Console.WriteLine("Valid user");

            }
            else
            {
                Console.WriteLine("Invalid user");
            }

        }
        static bool Check(Users[] u, int count, string name, string password)
        {
            bool flag = false;
            for (int x = 0; x < 10; x++)
            {

                if (name == u[x].name && password == u[x].password)
                {
                    flag = true;
                    return flag;
                }

            }
          
            flag = false;
          
            return flag;

        }
        static void StoreData(string path, Users[] u, int count)
        {

            StreamWriter file = new StreamWriter(path, true);
            for (int x = 0; x < count; x++)
            {
                file.WriteLine(u[x].name + "," + u[x].password);

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
        static void readData(string path, int count, Users[] u)
        {
            int x = 0;

            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    Users u1 = new Users();
                    u[x] = u1;
                    u[x].name = dataParse(line, 1);
                  
                    u[x].password = dataParse(line, 2);
                    x++;
                    if (x > 10)
                    {
                        break;

                    }


                }
                file.Close();
            }
            else
            {
                Console.WriteLine("File does not exists");
            }

        }




    }
}
