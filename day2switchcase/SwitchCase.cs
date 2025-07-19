using System;

class SwitchCase
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter The Choice you have to perform (Odd (1)/ Even (2)/ Prime(3)): ");
        int choice = Convert.ToInt32(Console.ReadLine());


        switch (choice)
        {
            case 1:
                Console.WriteLine("Enter the Number: ");
                int number = Convert.ToInt32(Console.ReadLine());
                if (number % 2 == 0)
                {
                    Console.WriteLine("Entered the Even Number!!");
                }
                else
                {
                    Console.WriteLine("Odd Number");
                }
                break;

            case 2:
                Console.WriteLine("Enter the Number: ");
                int number1 = Convert.ToInt32(Console.ReadLine());
                if (number1 % 2 == 1)
                {
                    Console.WriteLine("Entered the Odd Number!!");
                }
                else
                {
                    Console.WriteLine("Even Number");
                }
                break;

            case 3:
                Console.WriteLine("Enter the Number: ");
                int num = Convert.ToInt32(Console.ReadLine());

                bool isPrime = true;

                if (num <= 1)
                {
                    isPrime = false;
                }
                else
                {
                    for (int i = 2; i < num; i++)
                    {
                        if (num % i == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                }

                if (isPrime)
                    Console.WriteLine(num + " is a Prime number.");
                else
                    Console.WriteLine(num + " is not a Prime number.");
                break;
            default:
                Console.WriteLine("Thank  you");
                break;
        }
    }
}