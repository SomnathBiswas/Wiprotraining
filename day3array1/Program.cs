//create a single dimensional array to store 5 student names by taking input from an user
//and then display

using System;

class Program
{
    static void Main(string[] args)
    {
        string[] names = new string[5];
        Console.WriteLine("Enter 5 student names:");
        for (int i = 0; i < 5; i++)
        {
            names[i] = Console.ReadLine();
        }
        Console.WriteLine("Student names are:");
        for (int i = 0; i < 5; i++)
        {
            Console.Write(" "+names[i]);
        }
    }
}
