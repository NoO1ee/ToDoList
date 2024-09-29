using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList;


internal class StartProgram
{
    public static string[] list;
    public static bool[] isDone;
    public static string formattedList;
    public static string ToDoListFormatted;
    public static string name;
    public static int age;
    public static void SavePerson()
    {
        bool checkBool = false;
        do
        {
            Console.Title = "To Do List //NoO1e";
            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteLine($"Hello and welcome.\nIf you would like to create a list please press {Green("Enter")} or {Red("ESC")} to exit:");
            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Enter)
            {
                Loading();
                name = CheckPlayerName();
                Loading();

                age = CheckPlayerAge();
                Loading();

                list = CheckSizeList();
                Loading();

                CheckInfo();
                Loading();

                list = CreateToDoStuff();
                Loading();

                CheckIfDone();
                Loading();
                checkBool = true;

            }
            else if (key == ConsoleKey.Escape)
            {
                Console.Clear();
                Console.WriteLine("Good bye.");
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Invalid input...\nPlease press {Green("Enter")} or {Red("ESC")}");
                Thread.Sleep(1000);
            }
        } while (!checkBool);
        Console.Clear();
        Console.WriteLine("Good job you are now done!\nPlease take the day off now :)\n");
        PrintToDoList(list, isDone);
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();


    }

    private static bool CheckIfDone()
    {
        bool checkBool = false;
        do
        {

            Console.Clear();
            PrintToDoList(list, isDone);

            if (isDone.All(done => done))
            {
                Console.WriteLine("All tasks are done!");
                return true;
            }

            Console.WriteLine("\nPlease Enter the number that you are done with and the list will update.");
            if (int.TryParse(Console.ReadLine(), out int pick))
            {
                if (pick == 0)
                {
                    return false;
                }

                pick--;

                if (pick < 0 || pick >= list.Length)
                {
                    Console.WriteLine("That number does not exist in the list...");
                }
                else
                {
                    isDone[pick] = true;
                }
            }
            else
            {
                Console.WriteLine("Invalid input...");
                Thread.Sleep(500);
            }

        } while (!checkBool);
        return true;

    }

    private static void PrintToDoList(string[] list, bool[] isDone)
    {
        for (int i = 0; i < list.Length; i++)
        {
            string status = isDone[i] ? Green("✓") : Red("×");
            Console.WriteLine($"{i + 1}. {list[i]} - {status}");
            Console.ResetColor();
        }
    }

    private static string Green(string v)
    {
        return $"\u001b[32m{v}\u001b[0m";
    }

    private static string Red(string v)
    {
        return $"\u001b[31m{v}\u001b[0m";
    }

    private static string[] CreateToDoStuff()
    {
        bool checkValid = false;
        do
        {
            Console.WriteLine("Please enter the stuff you have to do.");


            for (int i = 0; i < list.Length; i++)
            {
                list[i] = Console.ReadLine()!;
                Console.WriteLine($"{i + 1}: {list[i]}");
            }
            checkValid = true;
        } while (!checkValid);
        return list;
    }

    private static void CheckInfo()
    {
        Console.WriteLine($"This is the input we got.\nCheck if it's is right.\n\nName: {name}\nAge: {age}\nList size: {formattedList}\n\nIs the information right? If yes press {Green("ANY KEY")}. Else press {Red("ESC")}.");
        var key = Console.ReadKey(true).Key;

        if (key == ConsoleKey.Escape)
        {
            //Loading();
            string[] menu = { "Name", "Age", "List size", "All done" };
            int menuSelect = 0;
            bool checkValid = true;
            while (checkValid)
            {
                Console.Clear();
                Console.WriteLine($"Name: {name}\nAge: {age}\nList size: {formattedList}\n");

                for (int i = 0; i < menu.Length; i++)
                {
                    if (i == menuSelect)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"-->\t[ {menu[i]} ]\t<--");
                        Console.ResetColor();
                    }
                    else
                        Console.WriteLine(menu[i]);
                }

                var keyMenu = Console.ReadKey(true).Key;

                if (keyMenu == ConsoleKey.DownArrow && menuSelect < menu.Length - 1)
                    menuSelect++;
                else if (keyMenu == ConsoleKey.UpArrow && menuSelect >= 1)
                    menuSelect--;
                else if (keyMenu == ConsoleKey.Enter)
                {
                    switch (menuSelect)
                    {
                        case 0:
                            name = CheckPlayerName();
                            break;
                        case 1:
                            age = CheckPlayerAge();
                            break;
                        case 2:
                            list = CheckSizeList();
                            break;
                        case 3:
                            Console.ResetColor();
                            Loading();
                            checkValid = false;
                            break;
                    }
                }
            }
        }


    }

    static string[] CheckSizeList()
    {
        bool checkValid = false;
        do
        {
            Console.Write("How large do you want your list to be?\nEnter in numbers: ");
            if (int.TryParse(Console.ReadLine(), out int arraySize))
            {
                if (arraySize <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("You can't have a list that is 0 or negative.");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                else
                {
                    list = new string[arraySize];
                    isDone = new bool[arraySize];
                    for (int i = 0; i < arraySize; i++)
                    {
                        list[i] = (i + 1).ToString();
                        isDone[i] = false;
                    }

                    formattedList = $"[{string.Join(", ", list)}]";
                    Console.WriteLine($"Your list size {formattedList}");
                    checkValid = true;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Thread.Sleep(1000);
                Console.Clear();
            }
        } while (!checkValid);
        return list;
    }

    private static int CheckPlayerAge()
    {
        bool checkValid = false;
        int userage;


        do
        {
            Console.Write($"Hello {Green(name)}!\nHow old are you: ");
            if (int.TryParse(Console.ReadLine(), out userage))
            {
                if (userage <= 10)
                {
                    Console.WriteLine("You are a minor. Please get your parents..");
                    Thread.Sleep(500);
                    Console.Clear();
                }
                else if(userage > 10)
                    checkValid = true;

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid age...");
                Thread.Sleep(1000);
                Console.Clear();
                checkValid = false;

            }
        } while (!checkValid);

        return userage;
    }

    public static string CheckPlayerName()
    {
        bool checkValid = false;
        string username;


        do
        {
            Console.Write("Please enter your name: ");
            username = Console.ReadLine()!;

            if (username.Length < 2)
            {
                Console.WriteLine("Invalid input!");
                Thread.Sleep(500);
                Console.Clear();
            }
            else
                checkValid = true;
        } while (!checkValid);

        return username;
    }


    public static void Loading()
    {

        Console.Clear();
        Console.Write("Loading");
        Thread.Sleep(500);

        for (int i = 0; i < 3; i++)
        {
            Console.Write(".");
            Thread.Sleep(500);
        }
        Console.Clear();
        Console.WriteLine(Green("Loading done!"));

    }
}
