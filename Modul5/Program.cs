
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        static async Task Main()
        {
            string text = File.ReadAllText("C:\\Users\\admin\\Desktop\\numbers.txt");

            List<int> numbers = text
                .Split(' ', '\n', '\r', '\t')
                .Where(x => x != "")
                .Select(int.Parse)
                .ToList();

            int uniqueCount = numbers.AsParallel().Distinct().Count();

            Console.WriteLine("1:");
            Console.WriteLine("кол-во уник. чисел: " + uniqueCount);

            Task<int> task2 = Task.Run(() =>
            {
                int maxLength = 1;
                int currentLength = 1;

                for (int i = 1; i < numbers.Count; i++)
                {
                    if (numbers[i] > numbers[i - 1])
                    {
                        currentLength++;
                    }
                    else
                    {
                        currentLength = 1;
                    }

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                    }
                }

                return maxLength;
            });

            Task<int> task3 = Task.Run(() =>
            {
                int maxLength = 0;
                int currentLength = 0;

                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] > 0)
                    {
                        currentLength++;
                    }
                    else
                    {
                        currentLength = 0;
                    }

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                    }
                }

                return maxLength;
            });

            await Task.WhenAll(task2, task3);

            Console.WriteLine("2:");
            Console.WriteLine("макс длина: " + task2.Result);

            Console.WriteLine("3:");
            Console.WriteLine("макс длина полож. чисел: " + task3.Result);
        }
    }
}
