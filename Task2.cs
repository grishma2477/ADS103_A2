using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS103_Grishma_A00177960_Assignment2
{
    class Task2
    {
        static Dictionary<int, string> library = new Dictionary<int, string>()
    {
        {1, "Moby Dick"},
        {2, "Charlie and the Chocolate Factory"},
        {3, "Pride and Prejudice"},
        {4, "1984"},
        {5, "To Kill a Mockingbird"},
        {6, "The Great Gatsby"},
        {7, "The Catcher in the Rye"},
        {8, "Jane Eyre"},
        {9, "Brave New World"},
        {10, "The Wizard of Oz"}
    };

        static List<int> borrowedBooks = new List<int>();

        public static void Run()
        {
            while (true)
            {
                Console.WriteLine("\nWhat would you like to do:");
                Console.WriteLine("1) List all books you have on loan");
                Console.WriteLine("2) Return a book");
                Console.WriteLine("3) List all books in the library");
                Console.WriteLine("4) Borrow a book");
                Console.WriteLine("5) Exit");
                Console.Write("Enter choice (1–5): ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ListBorrowedBooks();
                        break;
                    case "2":
                        ReturnBook();
                        break;
                    case "3":
                        ListAllBooks();
                        break;
                    case "4":
                        BorrowBook();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void ListBorrowedBooks()
        {
            if (borrowedBooks.Count == 0)
            {
                Console.WriteLine("You have no books on loan.");
            }
            else
            {
                Console.WriteLine("------------------------------");
                foreach (int id in borrowedBooks)
                {
                    Console.WriteLine($"{id}: {library[id]}");
                }
                Console.WriteLine("------------------------------");
            }
        }

        static void ReturnBook()
        {
            Console.Write("Enter book ID to return: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (borrowedBooks.Contains(id))
                {
                    borrowedBooks.Remove(id);
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Book returned.");
                    Console.WriteLine("------------------------------");
                }
                else
                {
                    Console.WriteLine("Book not found in your loan list.");
                }
            }
        }

        static void ListAllBooks()
        {
            Console.WriteLine("------------------------------");
            foreach (var book in library)
            {
                Console.WriteLine($"{book.Key}: {book.Value}");
            }
            Console.WriteLine("------------------------------");
        }

        static void BorrowBook()
        {
            Console.Write("Enter book ID to borrow: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (library.ContainsKey(id) && !borrowedBooks.Contains(id))
                {
                    borrowedBooks.Add(id);
                    Console.WriteLine("------------------------------");
                    Console.WriteLine($"Book \"{library[id]}\" borrowed.");
                    Console.WriteLine("------------------------------");
                }
                else
                {
                    Console.WriteLine("Book not available or already borrowed.");
                }
            }
        }
    }
}