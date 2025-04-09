using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS103_Grishma_A00177960_Assignment2
{
    class Task1
    {
        public static void Run()
        {
            string file1 = "D:\\EDUCATION\\bachelor\\Trimester 2\\ADS103\\Assignment 2\\code\\ADS103_Grishma_A00177960_Assignment2\\a2_task1_input1.txt";
            string file2 = "D:\\EDUCATION\\bachelor\\Trimester 2\\ADS103\\Assignment 2\\code\\ADS103_Grishma_A00177960_Assignment2\\a2_task1_input2.txt";
            ProcessFile(file1);
            ProcessFile(file2);
        }

        static void ProcessFile(string filename)
        {
            Console.WriteLine($"\nProcessing file: {filename}");

            int[] data = ReadFile(filename);
            int[] copy_data = (int[])data.Clone();

            Stopwatch stopwatch = Stopwatch.StartNew();
            BubbleSort(data);
            stopwatch.Stop();
            double bubbleTime = stopwatch.Elapsed.TotalMilliseconds;

            stopwatch.Restart();
            QuickSort(copy_data);
            stopwatch.Stop();
            double quickTime = stopwatch.Elapsed.TotalMilliseconds;

            Console.WriteLine($"Bubble Sort Time: {bubbleTime} ms");
            Console.WriteLine($"Quick Sort Time: {quickTime} ms");
            Console.WriteLine($"{(bubbleTime < quickTime ? "Bubble" : "Quick")} Sort was faster.\n");
        }

        static int[] ReadFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int size = int.Parse(lines[0]); // Number of integers to read

            List<int> numbersList = new List<int>();

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

            // Only take as many numbers as specified in the first line
            if (numbersList.Count < size)
            {
                Console.WriteLine($"Warning: Expected {size} numbers, but found only {numbersList.Count}.");
            }

            return numbersList.Take(size).ToArray();
        }


        static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
        }

        static void QuickSort(int[] arr)
        {
            int lowPointer = 0;
            int highPointer = arr.Length - 1;
            QuickSortHelper(arr, lowPointer, highPointer);
        }

        static void QuickSortHelper(int[] arr, int lowPointer, int highPointer)
        {
            if (lowPointer < highPointer)
            {
                int pi = Partition(arr, lowPointer, highPointer);
                QuickSortHelper(arr, lowPointer, pi - 1);
                QuickSortHelper(arr, pi + 1, highPointer);
            }
        }

        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }

            (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
            return i + 1;
        }
    }
}

