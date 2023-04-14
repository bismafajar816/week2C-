using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using game.BL;
using EZInput;

namespace Task02
{
    class Program
    {
        static char[,] Maze = new char[36, 72];

        static char i = (char)2;
        static char k = (char)19;
        static char[,] hero = new char[3, 4] {
    { ' ', i, ' ',  ' ' },
    { '<', '#', '-',  '>' },
    { ' ', k, ' ' , ' ' }};
        static char[,] HeroLeft = new char[3, 4] {
    { ' ', i, ' ',  ' ' },
    { '<', '-', '#',  '>' },
    { ' ', k, ' ' , ' ' }};
        static char h = (char)127;
        static char m = (char)193;
        static char[,] Enemy = new char[3, 5] {
                                             { ' ',  ' ', h, h, ' ' },
                                             { '<',  '-', m, m, '>' },
                                             { ' ',  ' ', '!', '!', ' ' }
                                             };




        static int HeroX = 3;
        static int HeroY = 22;
        static int Herohealth = 100;
        static string Direction = "right";


        static int[] HerobulletX = new int[100];
        static int[] HerobulletY = new int[100];
        static char[] HerobulletDirection = new char[100];
        static int HerobulletCount = 0;

        static int enemyX = 20;
        static int enemyY = 10;
        static string enemydirection = "down";
        static int Enemyhealth = 50;

        static int score = 0; // score

        static int check = 0; // flags for game
        static bool game = true;

        static void Main(string[] args)
        {
            player heroCO = new player();
            heroCO.HeroX = 3;
            heroCO.HeroY = 18;
            LoadMaze(Maze);
            PrintMaze(Maze);
            printHero(hero, heroCO, Maze);
            while(true)
            {
                MotionOfHero(Maze, hero, HeroLeft, heroCO, ref Direction, HerobulletX, HerobulletY, HerobulletDirection, ref HerobulletCount, ref check, ref game, ref score, ref Enemyhealth, ref Herohealth);
                Thread.Sleep(50);            
            }    
          
            Console.ReadKey();
            /*   while (true)
               {


              
            /* }*/
            /*  Header();
              int opt = Menu();
              while (opt < 3)
              {
                  Console.Clear();
                  if (opt == 1)
                  {
                      LoadMaze(Maze);

                      PrintMaze(Maze);
                      PrintEnemy(Enemy, ref enemyX, ref enemyY);
                      printHero(hero, ref HeroX, ref HeroY);

                      while (game)
                      {

                          printHeroHealth(ref Herohealth, ref game, ref Enemyhealth, ref score);
                          EnemyMotion(Maze, Enemy, ref enemyX, ref enemyY, ref Enemyhealth, ref enemydirection);
                          gameover(ref Herohealth, ref game);
                          gameoverCollsion(ref HeroX, ref HeroY, ref Herohealth, ref enemyX, ref enemyY, ref Enemyhealth);

                          movebullet(Maze, HerobulletX, HerobulletY, HerobulletDirection, ref HerobulletCount);
                          collision(ref Herohealth, ref enemyX, ref enemyY, HerobulletX, HerobulletY, HerobulletDirection, ref HerobulletCount, ref Enemyhealth, ref score);
                          Thread.Sleep(50);
                      }

                  }
                  if (opt == 2)
                  {
                      Console.Clear();
                      Header();
                      int choice = Option2();
                      while (choice < 3)
                      {
                          if (choice == 1)
                          {
                              Console.Clear();
                              Header();
                              keys();
                              choice = Option2();
                          }
                          if (choice == 2)
                          {
                              Console.Clear();
                              Header();
                              instructions();
                              choice = Option2();
                          }
                          if (choice > 2 || choice == 0)
                          {
                              Console.Clear();
                              Header();
                              *//* choice = Option2();*//*
                          }

                      }
                      opt = Menu();

                  }

              }


              Console.ReadKey();*/
        }
        static void Header()
        {
            Console.WriteLine("     /$$      /$$                                      /$$$$$$  ");
            Console.WriteLine("   | $$$    /$$$                                     /$$__  $$                  ");
            Console.WriteLine("   | $$$$  /$$$$  /$$$$$$  /$$$$$$$$  /$$$$$$       | $$  \\__/  /$$$$$$  /$$$$$$  /$$$$$$$$  /$$$$$$  ");
            Console.WriteLine("   | $$ $$/$$ $$ |____  $$|____ /$$/ /$$__  $$      | $$       /$$__  $$|____  $$|____ /$$/ /$$__  $$ ");
            Console.WriteLine("   | $$  $$$| $$  /$$$$$$$   /$$$$/ | $$$$$$$$      | $$      | $$  \\__/ /$$$$$$$   /$$$$/ | $$$$$$$$ ");
            Console.WriteLine("   | $$\\  $ | $$ /$$__  $$  /$$__/  | $$_____/      | $$    $$| $$      /$$__  $$  /$$__/  | $$_____/ ");
            Console.WriteLine("   | $$ \\/  | $$|  $$$$$$$ /$$$$$$$$|  $$$$$$$      |  $$$$$$/| $$     |  $$$$$$$ /$$$$$$$$|  $$$$$$$ ");
            Console.WriteLine("   |__/     |__/ \\_______/|________/ \\_______/       \\______/ |__/      \\_______/|________/ \\_______/ ");
        }
        static int Menu()
        {
            int option;
            Console.WriteLine("\n\n\n\nMenu");
            Console.WriteLine("___________________________________");
            Console.WriteLine("1. Start");
            Console.WriteLine("2. Option");
            Console.WriteLine("3. Exit");
            Console.WriteLine("\nYour Choice: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static int Option2()
        {
            int choice;
            Console.WriteLine("\n\n\n_________________________________");
            Console.WriteLine("1. Keys");
            Console.WriteLine("2. Instructions");
            Console.WriteLine("3. Exit");
            Console.WriteLine("\nYour Choice: ");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
        static void keys()
        {
            Console.WriteLine("Keys\t\t\t\t Functions");
            Console.WriteLine("Up arrow\t\t\t Move character upward");
            Console.WriteLine("Down arrow\t\t\t Move character downward");
            Console.WriteLine("Left arrow\t\t\t Move character leftward");
            Console.WriteLine("Right arrow\t\t\t Move character rightward");
            Console.WriteLine("Space Bar\t\t\t  Hero Bullets");
            Console.WriteLine();
            Console.WriteLine();
        }

        static void instructions()
        {
            Console.WriteLine("You can press arrow keys for movement and space key for shooting");
            Console.WriteLine("Your score will increase by eating food pallets.");
            Console.WriteLine("Your health will decrease by colliding with enemy or by fire of enemy.");
            Console.WriteLine("Food pallets will give you shield to bullets of enemy.");
            Console.WriteLine("It is a game of seconds try to keep away from bullets and enemies");
            Console.WriteLine("If wall or enemy are exactly next to you then health will decrease continuously.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        static void PrintMaze(char[,] Maze)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int i = 0; i < 35; i++)
            {
                for (int j = 0; j < 70; j++)
                {
                    Console.Write(Maze[i, j]);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Black;
        }
        static void moveheroDown(char[,] Maze, char[,] hero, char[,] HeroLeft, player heroCo, ref string Direction, ref int score)
        {
            char next = Maze[heroCo.HeroY + 3, heroCo.HeroX];
            char next1 = Maze[heroCo.HeroY + 3, heroCo.HeroX + 1];
            char next2 = Maze[heroCo.HeroY + 3, heroCo.HeroX + 2];
            char next3 = Maze[heroCo.HeroY + 3, heroCo.HeroX + 3];
            if (next == ' ' && next1 == ' ' && next2 == ' ' && next3 == ' ')
            {
                eraseHero(heroCo);
                heroCo.HeroY++;
                if (Direction == "right")
                {
                    printHero(hero, heroCo,Maze);
                }
                else
                {
                    printHeroLeft(HeroLeft, heroCo);
                }
            }

            else if (next == '.' || next1 == '.' || next2 == '.' || next3 == '.')
            {
                score = score + 1;
                eraseHero(heroCo);
                heroCo.HeroY++;
                if (Direction == "right")
                {
                    printHero(hero, heroCo, Maze);
                }
                else
                {
                    printHeroLeft(HeroLeft, heroCo);
                }
            }
        }

        /*  static void moveheroUp(char[,] Maze, char[,] hero, char[,] HeroLeft, ref int HeroX, ref int HeroY, ref string Direction, ref int score)
          {
              char next = Maze[HeroY - 1, HeroX];
              char next1 = Maze[HeroY - 1, HeroX + 1];
              char next2 = Maze[HeroY - 1, HeroX + 2];
              char next3 = Maze[HeroY - 1, HeroX + 3];
              if (next == ' ' && next1 == ' ' && next2 == ' ' && next3 == ' ')
              {
                  eraseHero(ref HeroX, ref HeroY);
                  HeroY--;
                  if (Direction == "right")
                  {
                      printHero(hero, ref HeroX, ref HeroY);
                  }
                  else
                  {
                      printHeroLeft(HeroLeft, ref HeroX, ref HeroY);
                  }
              }

              if (next == '.' || next1 == '.' || next2 == '.' || next3 == '.')
              {
                  score = score + 1;

                  eraseHero(ref HeroX, ref HeroY);
                  HeroY--;
                  if (Direction == "right")
                  {
                      printHero(hero, ref HeroX, ref HeroY);
                  }
                  else
                  {
                      printHeroLeft(HeroLeft, ref HeroX, ref HeroY);
                  }
              }

          }
  */
        /* static void moveheroLeft(char[,] Maze, char[,] hero, char[,] HeroLeft, ref int HeroX, ref int HeroY, ref string Direction, ref int score)
         {
             Direction = "left";
             char next = Maze[HeroY, HeroX - 1];
             char next1 = Maze[HeroY + 1, HeroX - 1];
             char next2 = Maze[HeroY + 2, HeroX - 1];
             if (next == ' ' && next1 == ' ' && next2 == ' ')
             {
                 eraseHero(ref HeroX, ref HeroY);
                 HeroX--;
                 printHeroLeft(HeroLeft, ref HeroX, ref HeroY);
             }
             if (next == '.' || next1 == '.' || next2 == '.')
             {
                 score = score + 1;
                 eraseHero(ref HeroX, ref HeroY);
                 HeroX--;
                 printHeroLeft(HeroLeft, ref HeroX, ref HeroY);
             }
         }*/

        /* static void moveheroRight(char[,] Maze, char[,] hero, char[,] heroLeft, ref int HeroX, ref int HeroY, ref string Direction, ref int score)
         {
             Direction = "right";
             char next = Maze[HeroY, HeroX + 4];
             char next1 = Maze[HeroY + 1, HeroX + 4];
             char next2 = Maze[HeroY + 2, HeroX + 4];
             if (next == ' ' && next1 == ' ' && next2 == ' ')
             {
                 eraseHero(ref HeroX, ref HeroY);
                 HeroX++;
                 printHero(hero, ref HeroX, ref HeroY);
             }
             if (next == '.' || next1 == '.' || next2 == '.')
             {
                 score = score + 1;
                 eraseHero(ref HeroX, ref HeroY);
                 HeroX++;
                 printHero(hero, ref HeroX, ref HeroY);
             }


         }
 */
        static void MotionOfHero(char[,] Maze, char[,] hero, char[,] HeroLeft, player heroCo, ref string Direction, int[] HerobulletX, int[] HerobulletY, char[] HerobulletDirection, ref int HerobulletCount, ref int check, ref bool game, ref int score, ref int Enemyhealth, ref int Herohealth)
        {
            /*  if (Keyboard.IsKeyPressed(Key.LeftArrow))
              {
                  moveheroLeft(Maze, hero, HeroLeft, ref HeroX, ref HeroY, ref Direction, ref score);
              }

              if (Keyboard.IsKeyPressed(Key.RightArrow))
              {
                  moveheroRight(Maze, hero, HeroLeft, ref HeroX, ref HeroY, ref Direction, ref score);
              }
              if (Keyboard.IsKeyPressed(Key.UpArrow))
              {

                  moveheroUp(Maze, hero, HeroLeft, ref HeroX, ref HeroY, ref Direction, ref score);

              }*/
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                moveheroDown(Maze, hero, HeroLeft, heroCo, ref Direction, ref score);
            }
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                createBullet(Maze, heroCo, ref Direction, HerobulletX, HerobulletY, HerobulletDirection, ref HerobulletCount);
            }
        }

        static void printHero(char[,] hero, player heroCo, char[,] Maze)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            int x = heroCo.HeroX;
            int y = heroCo.HeroY;
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(x, y);
                for (int j = 0; j < 4; j++)
                {
                    Maze[i, j] = hero[i, j];
                    Console.Write(Maze[i, j]);
                }
                Console.WriteLine();
                y++;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void eraseHero(player heroCo)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            int x = heroCo.HeroX;
            int y = heroCo.HeroY;
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(x, y);
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
                y++;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void printHeroLeft(char[,] heroLeft, player heroCo)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            int x = heroCo.HeroX;
            int y = heroCo.HeroY;
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(x, y);
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(heroLeft[i, j]);
                }
                Console.WriteLine();
                y++;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void PrintEnemy(char[,] Enemy, ref int enemyX, ref int enemyY)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            int x = enemyX;
            int y = enemyY;
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(x, y);
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(Enemy[i, j]);
                }
                Console.WriteLine();
                y++;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void EraseEnemy(ref int enemyX, ref int enemyY)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            int x = enemyX;
            int y = enemyY;
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(x, y);
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
                y++;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void createBullet(char[,] Maze, player heroCo, ref string Direction, int[] HerobulletX, int[] HerobulletY, char[] HerobulletDirection, ref int HerobulletCount)
        {
            if (Direction == "right")
            {
                Console.Beep();
                char next = Maze[heroCo.HeroY + 1, heroCo.HeroX + 4];
                if (next == ' ')
                {
                    HerobulletX[HerobulletCount] = heroCo.HeroX + 4;
                    HerobulletY[HerobulletCount] = heroCo.HeroY + 1;
                    HerobulletDirection[HerobulletCount] = 'R';
                    Console.SetCursorPosition(heroCo.HeroX + 4, heroCo.HeroY + 1);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("*");
                    HerobulletCount++;
                    Console.ForegroundColor = ConsoleColor.Red;
                }
            }

            if (Direction == "left")
            {

                char next = Maze[heroCo.HeroY + 1, heroCo.HeroX - 1];
                if (next == ' ')
                {
                    HerobulletX[HerobulletCount] = heroCo.HeroX - 1;
                    HerobulletY[HerobulletCount] = heroCo.HeroY + 1;
                    HerobulletDirection[HerobulletCount] = 'L';
                    Console.SetCursorPosition(heroCo.HeroX - 1, heroCo.HeroY + 1);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("*");
                    HerobulletCount++;
                    Console.ForegroundColor = ConsoleColor.Red;
                }
            }
        }
        static void movebullet(char[,] Maze, int[] HerobulletX, int[] HerobulletY, char[] HerobulletDirection, ref int HerobulletCount)
        {
            for (int x = 0; x < HerobulletCount; x++)
            {
                if (HerobulletDirection[x] == 'R')
                {
                    char next = Maze[HerobulletY[x], HerobulletX[x] + 1];
                    if (next != ' ')
                    {
                        eraseBullet(HerobulletX[x], HerobulletY[x]);
                        deleteBullet(x, HerobulletX, HerobulletY, HerobulletDirection, ref HerobulletCount);
                    }
                    else
                    {
                        eraseBullet(HerobulletX[x], HerobulletY[x]);
                        HerobulletX[x]++;
                        printBullet(HerobulletX[x], HerobulletY[x]);
                    }
                }

                if (HerobulletDirection[x] == 'L')
                {
                    char next = Maze[HerobulletY[x], HerobulletX[x] - 1];
                    if (next != ' ')
                    {
                        eraseBullet(HerobulletX[x], HerobulletY[x]);
                        deleteBullet(x, HerobulletX, HerobulletY, HerobulletDirection, ref HerobulletCount);
                    }
                    else
                    {
                        eraseBullet(HerobulletX[x], HerobulletY[x]);
                        HerobulletX[x]--;
                        printBullet(HerobulletX[x], HerobulletY[x]);
                    }
                }
            }
        }

        static void deleteBullet(int index, int[] HerobulletX, int[] HerobulletY, char[] HerobulletDirection, ref int HerobulletCount)
        {
            int x = index;
            while (x < HerobulletCount)
            {
                HerobulletX[x] = HerobulletX[x + 1];
                HerobulletY[x] = HerobulletY[x + 1];
                HerobulletDirection[x] = HerobulletDirection[x + 1];
                x++;
            }
            HerobulletCount--;
        }

        static void printBullet(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("*");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void eraseBullet(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(" ");
        }
        static void EnemyMotion(char[,] Maze, char[,] Enemy, ref int enemyX, ref int enemyY, ref int Enemyhealth, ref string enemydirection)
        {
            if (Enemyhealth > 0)
            {
                if (enemydirection == "up")
                {
                    char next = Maze[enemyY - 1, enemyX];
                    if (next == ' ')
                    {
                        EraseEnemy(ref enemyX, ref enemyY);
                        enemyY--;
                        PrintEnemy(Enemy, ref enemyX, ref enemyY);
                    }
                    if (next == '#')
                    {
                        enemydirection = "down";
                    }
                }
                if (enemydirection == "down")
                {
                    char next = Maze[enemyY + 3, enemyX];
                    if (next == ' ')
                    {
                        EraseEnemy(ref enemyX, ref enemyY);
                        enemyY++;
                        PrintEnemy(Enemy, ref enemyX, ref enemyY);
                    }
                    if (next == '#')
                    {
                        enemydirection = "up";
                    }
                }
            }
            if (Enemyhealth == 0)
            {
                EraseEnemy(ref enemyX, ref enemyY);
                Enemyhealth = -1;
                enemyX = 0;
                enemyY = 0;
                Console.SetCursorPosition(75, 12);
                Console.WriteLine(" Mr - Fighter Died ");
            }
        }
        static void gameover(ref int Herohealth, ref bool game)
        {
            if (Herohealth == 0)
            {
                game = false;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(20, 15);
                Console.WriteLine("GAME OVER");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void complete(ref int check, ref bool game)
        {
            game = false;
            // game2 = false;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(20, 15);
            Console.WriteLine("STAGE COMLETE :)");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        ///          idhr sy shi krna h abi namaz prh k      ////
        static void gameoverCollsion(ref int HeroX, ref int HeroY, ref int Herohealth, ref int enemyX, ref int enemyY, ref int Enemyhealth)
        {
            // enemy1
            if (Enemyhealth > 0)
            {
                for (int i = -2; i < 3; i++) // right
                {
                    if (HeroX + 3 == enemyX - 1 && HeroY == enemyY + i)
                    {
                        Herohealth = 0;
                    }
                }

                if (HeroX + 3 == enemyX - 1 && HeroY == enemyY) // right
                {
                    Herohealth = 0;
                }

                for (int i = -3; i < 8; i++) // enemy up
                {
                    if (HeroX == enemyX + i && HeroY - 1 == enemyY + 2)
                    {
                        Herohealth = 0;
                    }
                }

                for (int i = -3; i < 8; i++) // Enemy down
                {
                    if (HeroX == enemyX + i && HeroY + 2 == enemyY - 1)
                    {
                        Herohealth = 0;
                    }
                }
            }
        }
        static void printHeroHealth(ref int Buddyhealth, ref bool game, ref int Enemyhealth, ref int score)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(75, 10);
            Console.WriteLine("Hero Health: " + Buddyhealth);
            if (Enemyhealth > 0 && game == true)
            {
                Console.SetCursorPosition(75, 12);
                Console.WriteLine("Mr Fighter Health: " + Enemyhealth);
            }
            Console.SetCursorPosition(75, 8);
            Console.WriteLine("Score: " + score);
        }


        static void LoadMaze(char[,] Maze)
        {
            StreamReader file = new StreamReader("D:\\oop\\mazecraze\\maze.txt");
            string line;
            int row = 0;
            while ((line = file.ReadLine()) != null)
            {
                for (int x = 0; x < 70; x++)
                {
                    Maze[row, x] = line[x];
                }
                row++;
                if(row > 36)
                {
                    break;
                }
            }

            file.Close();
        }

        static void collision(ref int Herohealth, ref int enemyX, ref int enemyY, int[] HerobulletX, int[] HerobulletY, char[] HerobulletDirection, ref int HerobulletCount, ref int Enemyhealth, ref int score)
        {
            for (int x = 0; x < HerobulletCount; x++)
            {
                if (Enemyhealth > 0)
                {
                    if (HerobulletX[x] + 1 == enemyX && (HerobulletY[x] == enemyY || HerobulletY[x] == enemyY + 1 || HerobulletY[x] == enemyY + 2))
                    {
                        eraseBullet(HerobulletX[x], HerobulletY[x]);
                        Enemyhealth = Enemyhealth - 5;
                        score++;
                        deleteBullet(x, HerobulletX, HerobulletY, HerobulletDirection, ref HerobulletCount);
                    }
                }
            }
        }
    }
}
