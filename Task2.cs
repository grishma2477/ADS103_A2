using System;
using System.Collections.Generic;

namespace ADS103_Grishma_A00177960_Assignment2
{
    class Task2
    {
        // Dictionary storing book ID and title
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

        // List to keep track of borrowed book IDs
        static List<int> borrowedBooks = new List<int>();

        // Main method to run Task 2
        public static void Run()
        {
            while (true)
            {
                // Display main menu
                Console.WriteLine("\n========= Library Menu =========");
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
                        return; // Exit the program
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
        }

        // Displays the list of borrowed books
        static void ListBorrowedBooks()
        {
            Console.WriteLine("\n========= Books on Loan =========");
            if (borrowedBooks.Count == 0)
            {
                Console.WriteLine("You have no books on loan.");
            }
            else
            {
                foreach (int id in borrowedBooks)
                {
                    Console.WriteLine($"{id}: {library[id]}");
                }
            }
            Console.WriteLine("=================================\n");
        }

        // Handles returning a borrowed book
        static void ReturnBook()
        {
            Console.Write("\nEnter book ID to return: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (!library.ContainsKey(id))
                {
                    Console.WriteLine("Invalid book ID. Please try again.");
                }
                else if (!borrowedBooks.Contains(id))
                {
                    Console.WriteLine("Book not found in your loan list.");
                }
                else
                {
                    borrowedBooks.Remove(id);
                    Console.WriteLine("------------------------------");
                    Console.WriteLine($"You have returned \"{library[id]}\".");
                    Console.WriteLine("------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        // Displays all books in the library, including borrowed status
        static void ListAllBooks()
        {
            Console.WriteLine("\n========= All Books in Library =========");
            foreach (var book in library)
            {
                string status = borrowedBooks.Contains(book.Key) ? "(Borrowed)" : "(Available)";
                Console.WriteLine($"{book.Key}: {book.Value} {status}");
            }
            Console.WriteLine("========================================\n");
        }

        // Allows borrowing a book if available
        static void BorrowBook()
        {
            Console.Write("\nEnter book ID to borrow: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (!library.ContainsKey(id))
                {
                    Console.WriteLine("Invalid book ID. Please try again.");
                }
                else if (borrowedBooks.Contains(id))
                {
                    Console.WriteLine("That book is already borrowed.");
                }
                else
                {
                    borrowedBooks.Add(id);
                    Console.WriteLine("------------------------------");
                    Console.WriteLine($"Book \"{library[id]}\" has been borrowed.");
                    Console.WriteLine("------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}
