using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO; // Required for file operations like File.ReadAllLines
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS103_Grishma_A00177960_Assignment2
{
    class Task1
    {
        public static void Run()
        {
            // Input file paths - update these as needed
            string file1 = "D:\\EDUCATION\\bachelor\\Trimester 2\\ADS103\\Assignment 2\\code\\ADS103_Grishma_A00177960_Assignment2\\a2_task1_input1.txt";
            string file2 = "D:\\EDUCATION\\bachelor\\Trimester 2\\ADS103\\Assignment 2\\code\\ADS103_Grishma_A00177960_Assignment2\\a2_task1_input2.txt";

            // Process each file
            ProcessFile(file1);
            ProcessFile(file2);
        }

        static void ProcessFile(string filename)
        {
            Console.WriteLine($"\nProcessing file: {filename}");

            // Read and parse numbers from the file
            int[] data = ReadFile(filename);
            int[] copy_data = (int[])data.Clone(); // Clone original array for fair comparison

            Console.WriteLine($"Total numbers to sort: {data.Length}"); // Display count for clarity

            // Measure time taken by Bubble Sort
            Stopwatch stopwatch = Stopwatch.StartNew();
            BubbleSort(data);
            stopwatch.Stop();
            double bubbleTime = stopwatch.Elapsed.TotalMilliseconds;

            // Measure time taken by Quick Sort
            stopwatch.Restart();
            QuickSort(copy_data);
            stopwatch.Stop();
            double quickTime = stopwatch.Elapsed.TotalMilliseconds;

            // Display results with file info and 2 decimal formatting
            Console.WriteLine($"Results for file: {Path.GetFileName(filename)}");
            Console.WriteLine($"Bubble Sort Time: {bubbleTime:F2} ms");
            Console.WriteLine($"Quick Sort Time: {quickTime:F2} ms");
            Console.WriteLine($"{(bubbleTime < quickTime ? "Bubble" : "Quick")} Sort was faster.\n");
        }

        static int[] ReadFile(string filePath)
        {
            // Check if file exists before reading to avoid crash
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Error: File not found - {filePath}");
                return new int[0]; // Return empty array if file missing
            }

            string[] lines = File.ReadAllLines(filePath);

            // First line should tell us how many integers to read
            int size = int.Parse(lines[0]);

            List<int> numbersList = new List<int>();

            // Read all lines from index 1 onward and extract integers
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (string part in parts)
                {
                    if (int.TryParse(part, out int number))
                    {
                        numbersList.Add(number);
                    }
                }
            }

            // Warn if file has fewer numbers than expected
            if (numbersList.Count < size)
            {
                Console.WriteLine($"Warning: Expected {size} numbers, but found only {numbersList.Count}.");
            }

            // Only return up to 'size' numbers even if more are found
            return numbersList.Take(size).ToArray();
        }

        // Standard Bubble Sort - slow for large data, good for educational comparison
        static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        // Swap elements if they are in wrong order
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
        }

        // Wrapper to start Quick Sort
        static void QuickSort(int[] arr)
        {
            int lowPointer = 0;
            int highPointer = arr.Length - 1;
            QuickSortHelper(arr, lowPointer, highPointer);
        }

        // Recursive Quick Sort helper
        static void QuickSortHelper(int[] arr, int lowPointer, int highPointer)
        {
            if (lowPointer < highPointer)
            {
                int pi = Partition(arr, lowPointer, highPointer); // Partition index
                QuickSortHelper(arr, lowPointer, pi - 1); // Sort left half
                QuickSortHelper(arr, pi + 1, highPointer); // Sort right half
            }
        }

        // Partition method used in Quick Sort
        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high]; // Choose last element as pivot
            int i = (low - 1); // Smaller element index

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    // Swap elements to move smaller element to left
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }

            // Place pivot at the correct sorted position
            (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
            return i + 1;
        }
    }
}
