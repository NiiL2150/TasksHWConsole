using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TasksHWConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task23();
            Task4();
            Task5();

            Console.ReadKey();
        }

        static void Task1()
        {
            Task task1 = new Task(() => { Console.WriteLine(DateTime.Now + " 1st task"); });
            task1.Start();
            Task.Factory.StartNew(() => { Console.WriteLine(DateTime.Now + " 2nd task"); });
            Task.Run(() => { Console.WriteLine(DateTime.Now + " 3rd task"); });
        }

        static void Task23()
        {
            int start = Int32.Parse(Console.ReadLine());
            int end = Int32.Parse(Console.ReadLine());
            foreach (var item in PrimeNumberFinder.NumbersBetween(start, end))
            {
                Console.WriteLine(item);
            }
        }

        static void Task4()
        {
            int[] tmp= new int[]{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Task<int> task1 = Task.Run(() =>
            {
                int min = tmp[0];
                foreach (var item in tmp)
                {
                    if(min > item)
                    {
                        min = item;
                    }
                }
                return min;
            });
            Task<int> task2 = Task.Run(() =>
            {
                int max = tmp[0];
                foreach (var item in tmp)
                {
                    if (max < item)
                    {
                        max = item;
                    }
                }
                return max;
            });
            Task<int> task3 = Task.Run(() =>
            {
                int sum = 0;
                foreach (var item in tmp)
                {
                    sum += item;
                }
                return sum / tmp.Length;
            });
            Task<int> task4 = Task.Run(() =>
            {
                int sum = 0;
                foreach (var item in tmp)
                {
                    sum += item;
                }
                return sum;
            });
            Task.WaitAll(task1, task2, task3, task4);

            Console.WriteLine($"Min - {task1.Result};");
            Console.WriteLine($"Max - {task2.Result};");
            Console.WriteLine($"Avg - {task3.Result};");
            Console.WriteLine($"Sum - {task4.Result};");
        }

        static void Task5()
        {
            List<int> list = new List<int>() { 5, 4, 3, 5, 33, 7, 4, 2, 6, 8, 6, 3, 2, 45, 6 };
            Task task1 = Task.Run(() =>
            {
                for (int i = 0; i < list.Count; i++)
                {
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        if (list[i] == list[j])
                        {
                            list.RemoveAt(j--);
                        }
                    }
                }
            });

            task1.ContinueWith((task2) =>
            {
                list.Sort();
            });

            task1.ContinueWith((task3) =>
            {
                int tmp = Int32.Parse(Console.ReadLine());
                Console.WriteLine(list.BinarySearch(tmp));
            });
        }
    }
}
