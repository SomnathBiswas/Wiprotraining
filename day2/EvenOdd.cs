using System;

namespace Program
{
    public class EvenOdd
    {
        static void Main(string[] args)
        {
            int number;
            Console.WriteLine("Enter the number: ");
            number = Convert.ToInt32(Console.ReadLine());
            if (number % 2 == 0)
            {
                Console.WriteLine(number + " " + "is an Even Number");
            }

            else
            {
                Console.WriteLine(number + " " + "is odd number");
            }

            Console.ReadKey();
        }
    }
}