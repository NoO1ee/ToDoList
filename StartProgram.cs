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
    public static string[] sizeList;
    public static string name;
    public static int age;
    public static void SavePerson()
    {
        bool checkBool = false;
        do
        {
            Console.WriteLine("Hello and welcome.\nIf you would like to create a list please press ENTER else press ESC:");
            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Enter)
            {
                Loading();

                Console.Write("Please enter your name: ");
                name = Console.ReadLine()!;
                Loading();

                Console.Write($"Hello {name}!\nHow old are you: ");
                age = int.Parse(Console.ReadLine()!);
                Loading();

                Console.WriteLine("How large do you want your list to be?\nEnter in numbers: ");
                int arraySize = int.Parse(Console.ReadLine()!);
                Array.Resize(ref list, arraySize);


                Loading();

                list.ToList().ForEach(x => Console.WriteLine(x.ToString()));

                //Console.Write($"[{string.Join(", ", sizeList[arraySize])}]");





                checkBool = true;

            }
        } while (checkBool);

    }


    public static void Loading()
    {
        Console.Clear();
        Console.WriteLine("Loading");
        Thread.Sleep(500);
        Console.Clear();

        Console.WriteLine("Loading.");
        Thread.Sleep(500);
        Console.Clear();


        Console.WriteLine("Loading..");
        Thread.Sleep(500);
        Console.Clear();


        Console.WriteLine("Loading...");
        Thread.Sleep(500);
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Loading done!");
        Console.ResetColor();
    }
}
