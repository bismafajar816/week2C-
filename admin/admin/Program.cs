using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using admin;
using System.IO;

namespace admin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<employees> workers = new List<employees>();
            List<employees> buses = new List<employees>();


            string path = "D:\\oop\\week2\\enteries.txt";
            string path1 = "D:\\oop\\week2\\employees.txt";
            string path2 = "D:\\oop\\week2\\busData.txt";
            List<Credentials> users = new List<Credentials>();
            int choice;

            do
            {
                LoadEmployees(workers, path1);
                LoadBusData(buses, path2);
                readData(path, users);
                Console.Clear();
                main_header();
                choice = menu();
                Console.Clear();
                if (choice == 1)
                {
                    main_header();
                    Console.WriteLine("Write name: ");
                    string name = Console.ReadLine();
                    Console.Write("Write password: ");
                    string password = Console.ReadLine();
                    Console.Write("Write role: ");
                    string role = Console.ReadLine();

                    signUp(path, name, password, role);
                }
                else if (choice == 2)
                {
                    main_header();
                    Console.WriteLine("Write name: ");
                    string name = Console.ReadLine();
                    Console.Write("Write password: ");
                    string password = Console.ReadLine();
                    if (signin(name, password, users) == "Admin" || signin(name, password, users) == "admin")
                    {
                        Console.Clear();
                        AdminHeader();
                        Console.ReadKey();
                        int adminchoice = AdminMenu();
                        while (adminchoice != 0)
                        {
                            if (adminchoice == 1)
                            {
                                Console.Clear();
                                int number;
                                string numbers;
                                AdminHeader();
                                Console.WriteLine("Enter the number of employees: ");
                                numbers = (Console.ReadLine());
                                number = Intvalidation(numbers);
                                for (int x = 0; x < number; x++)
                                {
                                    addEmployees(workers, path1);


                                }

                                adminchoice = AdminMenu();
                            }
                            else if (adminchoice == 2)
                            {
                                Console.Clear();
                                int number1;
                                string numbers1;
                                AdminHeader();
                                Console.WriteLine("Enter the number of employees: ");
                                numbers1 = (Console.ReadLine());
                                number1 = Intvalidation(numbers1);
                                for (int x = 0; x < number1; x++)
                                {
                                    DeleteEmployee(workers, path1);


                                }

                                adminchoice = AdminMenu();
                            }
                            else if (adminchoice == 3)
                            {
                                Console.Clear();
                                AdminHeader();
                                Updateemployees(workers, path1);
                                adminchoice = AdminMenu();
                            }
                            else if (adminchoice == 4)
                            {
                                Console.Clear();
                                AdminHeader();
                                SearchEmployee(workers);
                                adminchoice = AdminMenu();

                            }
                            else if (adminchoice == 5)
                            {
                                Console.Clear();
                                AdminHeader();
                                ViewEmployee(workers);
                                adminchoice = AdminMenu();

                            }
                            else if (adminchoice == 6)
                            {

                                Console.Clear();
                                AdminHeader();
                                AddBus(buses, path2);
                                adminchoice = AdminMenu();
                            }
                            else if (adminchoice == 7)
                            {
                                Console.Clear();
                                AdminHeader();
                                UpdateBus(buses, path2);
                                adminchoice = AdminMenu();

                            }
                            else if (adminchoice == 8)
                            {
                                Console.Clear();
                                AdminHeader();
                                SearchBus(buses);
                                adminchoice = AdminMenu();
                            }
                            else if (adminchoice == 9)
                            {
                                Console.Clear();
                                AdminHeader();
                                DeleteBus(buses, path2);
                                adminchoice = AdminMenu();
                            }
                            else if (adminchoice == 10)
                            {
                                Console.Clear();
                                AdminHeader();
                                ViewBus(buses);
                                adminchoice = AdminMenu();
                            }
                            Console.ReadKey();


                        }
                        choice = menu();
                    }





                }

            }
          
            while (choice < 3);
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
        static void readData(string path, List<Credentials> users)
        {


            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    Credentials info = new Credentials();

                    info.name = dataParse(line, 1);
                    info.password = dataParse(line, 2);
                    info.role = dataParse(line, 3);
                    users.Add(info);

                }
                file.Close();
            }
            else
            {
                Console.WriteLine("File does not exists");
            }

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
        static void signUp(string path, string name, string password, string role)
        {

            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(name + "," + password + "," + role);
            file.Flush();
            file.Close();
        }
        static string signin(string name, string passsword, List<Credentials> users)
        {
            bool flag = false;
            for (int x = 0; x < users.Count; x++)
            {
                if (name == users[x].name && passsword == users[x].password)
                {
                    Console.WriteLine("valid user");
                    flag = true;
                    return (users[x].role);


                }
            }
            if (flag == false)
            {



                Console.WriteLine("Invalid user");
            }
            return "";


        }

        static void main_header()
        {

            Console.WriteLine("      >>        >=>              >=======>                                              >=>       >=>              >=>                              ");
            Console.WriteLine("     >>=>       >=>              >=>                      >=>                           >> >=>   >>=>              >=>                              ");
            Console.WriteLine("    >> >=>      >=>              >=>          >=> >=>            >=> >=>  >> >==>       >=> >=> > >=>    >=>     >=>>==>    >=>     >> >==>  >===>  ");
            Console.WriteLine("   >=>  >=>     >=> >====>       >=====>    >=>   >=>     >=>  >=>   >=>   >=>          >=>  >=>  >=>  >=>  >=>    >=>    >=>  >=>   >=>    >=>     ");
            Console.WriteLine("  >=====>>=>    >=>              >=>       >=>    >=>     >=> >=>    >=>   >=>          >=>   >>  >=> >=>    >=>   >=>   >=>    >=>  >=>      >==>  ");
            Console.WriteLine(" >=>      >=>   >=>              >=>        >=>   >=>     >=>  >=>   >=>   >=>          >=>       >=>  >=>  >=>    >=>    >=>  >=>   >=>        >=> ");
            Console.WriteLine(">=>        >=> >==>              >=>         >==>>>==>    >=>   >==>>>==> >==>          >=>       >=>    >=>        >=>     >=>     >==>    >=> >=> ");
            Console.WriteLine("                                                       >==>                                                                                         ");
            Console.WriteLine("");
            Console.WriteLine("");

        }
        static void AdminHeader()
        {

            Console.WriteLine("   _   _   _   _   _   _   _     _   _   _   _     _   _   _   _   _  ");
            Console.WriteLine("  / \\ / \\ / \\ / \\ / \\ / \\ / \\   / \\ / \\ / \\ / \\   / \\ / \\ / \\ / \\ / \\ ");
            Console.WriteLine(" ( W | e | l | c | o | m | e ) ( D | e | a | r ) ( A | d | m | i | n )");
            Console.WriteLine("  \\_/ \\_/ \\_/ \\_/ \\_/ \\_/ \\_/   \\_/ \\_/ \\_/ \\_/   \\_/ \\_/ \\_/ \\_/ \\_/ ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");



        }
        static int AdminMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(" You can do these tasks .");
            Console.WriteLine(" -----------------------------------------");
            Console.WriteLine(" 1.  add employee.");
            Console.WriteLine(" 2.  delete employee.");
            Console.WriteLine(" 3.  update employee.");
            Console.WriteLine(" 4.  search employee.");
            Console.WriteLine(" 5.  view all employees .");
            Console.WriteLine(" 6.  add bus with timing and route .");
            Console.WriteLine(" 7.  update bus");
            Console.WriteLine(" 8.  search bus");
            Console.WriteLine(" 9.  delete bus .");
            Console.WriteLine(" 10. view all buses .");
            Console.WriteLine(" 0.  exit.");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Your choice: ");
            string opt = (Console.ReadLine());
            int option = Intvalidation(opt);
            return option;

        }
        static int Intvalidation(string number)
        {
            if (int.TryParse(number, out int result))
            {
                return result;
            }
            string num = "er";
            int res = 0;
            while (!int.TryParse(num.ToString(), out res))
            {
                Console.WriteLine("Enter integer number: ");
                num = Console.ReadLine();
            }
            return res;
        }
        static employees addEmployees(List<employees> workers, string path1)
        {


            employees obj = new employees();
            Console.WriteLine("Enter employee name: ");
            obj.Emp_name = Console.ReadLine();
            Console.WriteLine("Enter employee type: ");
            obj.Emp_type = Console.ReadLine();
            workers.Add(obj);
            StoreEmployees(workers, path1);
            return obj;

        }
        static void StoreEmployees(List<employees> workers, string path1)
        {

            StreamWriter file = new StreamWriter(path1);
            for (int x = 0; x < workers.Count(); x++)
            {
                file.WriteLine(workers[x].Emp_name + "," + workers[x].Emp_type);
            }
            file.Flush();
            file.Close();
        }
        static void LoadEmployees(List<employees> workers, string path1)
        {
            if (File.Exists(path1))
            {
                StreamReader file = new StreamReader(path1);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    employees info = new employees();

                    info.Emp_name = dataParse(line, 1);
                    info.Emp_type = dataParse(line, 2);

                    workers.Add(info);

                }
                file.Close();
            }
            else
            {
                Console.WriteLine("File does not exists");
            }
        }
        static void DeleteEmployee(List<employees> workers, string path1)
        {
            int index = 0;
            Console.WriteLine("Enter the name of employee to delete: ");
            string name = Console.ReadLine();
            for (int i = 0; i < workers.Count; i++) // this loop will give the index to delete
            {

                if (name == workers[i].Emp_name)
                {
                    index = i;

                }
            }
            workers.RemoveAt(index);
            StoreEmployees(workers, path1);
        }
        static void Updateemployees(List<employees> workers, string path1)
        {
            int index = 0;
            Console.WriteLine("Enter the name of employee to change: ");
            string name = Console.ReadLine();
            for (int i = 0; i < workers.Count; i++) // this loop will give the index to delete
            {

                if (name == workers[i].Emp_name)
                {
                    index = i;

                }
            }
            Console.WriteLine("Enter updated name: ");
            string upName = Console.ReadLine();
            workers[index].Emp_name = upName;
            StoreEmployees(workers, path1);


        }
        static void SearchEmployee(List<employees> workers)
        {
            Console.WriteLine("Enter the name of employee to search: ");
            string name = Console.ReadLine();
            for (int i = 0; i < workers.Count; i++) // this loop will give the index to delete
            {

                if (name == workers[i].Emp_name)
                {
                    Console.Write("this workers is : ");
                    Console.WriteLine(workers[i].Emp_type);

                }
            }


        }
        static void ViewEmployee(List<employees> workers)
        {
            Console.WriteLine("Name \t" + "\t\t Type");
            for (int x = 0; x < workers.Count; x++)
            {
                Console.WriteLine(workers[x].Emp_name + "\t\t\t" + workers[x].Emp_type);
            }

        }
        static void AddBus(List<employees> buses, string path2)
        {
            employees obj = new employees();
            Console.WriteLine("Enter the Serial number of bus: ");
            obj.busSerial = Console.ReadLine();
            Console.WriteLine("Enter the timing of the bus: ");
            obj.busTiming = Console.ReadLine();
            Console.WriteLine("Enter the route of the bus : ");
            obj.busRoute = Console.ReadLine();
            Console.WriteLine("Enter the date of departure :  ");
            obj.date = Console.ReadLine();
            buses.Add(obj);
            StoreBus(buses, path2);


        }
        static void StoreBus(List<employees> buses, string path2)
        {
            StreamWriter file = new StreamWriter(path2);
            for (int x = 0; x < buses.Count(); x++)
            {
                file.WriteLine(buses[x].busSerial + "," + buses[x].busTiming + "," + buses[x].busRoute + "," + buses[x].date);
            }
            file.Flush();
            file.Close();

        }
        static void LoadBusData(List<employees> buses, string path2)
        {
            if (File.Exists(path2))
            {
                StreamReader file = new StreamReader(path2);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    employees info = new employees();

                    info.busSerial = dataParse(line, 1);
                    info.busTiming = dataParse(line, 2);
                    info.busRoute = dataParse(line, 3);
                    info.date = dataParse(line, 4);


                    buses.Add(info);

                }
                file.Close();
            }
            else
            {
                Console.WriteLine("File does not exists");
            }

        }
        static void UpdateBus(List<employees> buses, string path2)
        {

            string route;
            Console.WriteLine("Enter the serial number of the bus you want to change the route: ");
            string number = Console.ReadLine();
            for (int x = 0; x < buses.Count(); x++)
            {
                if (number == buses[x].busSerial)
                {
                    Console.WriteLine("Enter the updated route : ");
                    route = Console.ReadLine();
                    buses[x].busRoute = route;
                }
            }
            StoreBus(buses, path2);
        }
        static void DeleteBus(List<employees> buses, string path2)
        {

            Console.WriteLine("Enter the serial of bus to delete: ");
            string number = Console.ReadLine();
            for (int x = 0; x < buses.Count(); x++)
            {
                if (number == buses[x].busSerial)
                {
                    buses.RemoveAt(x);
                }
            }
            StoreBus(buses, path2);
        }
        static void SearchBus(List<employees> buses)
        {
            Console.WriteLine("Enter the route to search: ");
            string route = Console.ReadLine();
            for (int x = 0; x < buses.Count(); x++)
            {
                if (route == buses[x].busRoute)
                {
                    Console.WriteLine("Timing of route :{0} ", buses[x].busTiming);
                    Console.WriteLine("Serial of bus :{0} ", buses[x].busSerial);
                    Console.WriteLine("Date of departure of route :{0} ", buses[x].date);

                }
            }
        }
        static void ViewBus(List<employees> buses)
        {
            Console.WriteLine("Serial \t\t Timing \t Date \t\t Route");
            for (int x = 0; x < buses.Count(); x++)
            {
                Console.WriteLine(buses[x].busSerial + "\t\t" + buses[x].busTiming + "\t\t" + buses[x].date + " \t\t " + buses[x].busRoute);
            }
        }







    }
}
