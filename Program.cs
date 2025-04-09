using System;

namespace ADS103_Grishma_A00177960_Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Which task would you like to run?");
            Console.WriteLine("1. Sorting Algorithm Performance");
            Console.WriteLine("2. Book Management System");
            Console.Write("Enter 1 or 2: ");

            string input = Console.ReadLine();
            if (input == "1")
            {
                Task1.Run();
            }
            else if (input == "2")
            {
                Task2.Run();
            }
            else
            {
                Console.WriteLine("Invalid input. Please restart and enter 1 or 2.");
            }
        }
    }
}