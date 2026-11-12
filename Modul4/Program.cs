using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ConsoleApp8
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Выберите:");
            Console.WriteLine("1 - парами чисел");
            Console.WriteLine("2 - автобусная остановка");
            Console.WriteLine("3 - автобусы с разными номерами");
            Console.WriteLine("4 - остановка не конечная");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
                Task1();

            if (choice == 2)
                BusStation(false, false);

            if (choice == 3)
                BusStation(true, false);

            if (choice == 4)
                BusStation(true, true);
        }

        static void Task1()
        {
            AutoResetEvent generated = new AutoResetEvent(false);

            Thread thread1 = new Thread(() =>
            {
                Random random = new Random();

                using (StreamWriter writer = new StreamWriter("pairs.txt"))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        int a = random.Next(1, 20);
                        int b = random.Next(1, 20);

                        writer.WriteLine(a + " " + b);
                    }
                }

                generated.Set();
            });

            Thread thread2 = new Thread(() =>
            {
                generated.WaitOne();

                using (StreamReader reader = new StreamReader("pairs.txt"))
                using (StreamWriter writer = new StreamWriter("sums.txt"))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] numbers = line.Split(' ');

                        int a = int.Parse(numbers[0]);
                        int b = int.Parse(numbers[1]);

                        writer.WriteLine(a + b);
                    }
                }

            });

            Thread thread3 = new Thread(() =>
            {
                generated.WaitOne();

                using (StreamReader reader = new StreamReader("pairs.txt"))
                using (StreamWriter writer = new StreamWriter("products.txt"))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] numbers = line.Split(' ');

                        int a = int.Parse(numbers[0]);
                        int b = int.Parse(numbers[1]);

                        writer.WriteLine(a * b);
                    }
                }

            });

            thread1.Start();
            thread2.Start();
            thread3.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();

            generated.Dispose();

        }

        static void BusStation(bool differentBuses, bool nonFinal)
        {
            List<Passenger> passengers = new List<Passenger>();

            object locker = new object();

            Random random = new Random();

            int[] busNumbers = { 175, 200, 250 };

            int busCapacity = 30;
            int busCount = 10;

            Thread peopleThread = new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    int count = random.Next(1, 16);

                    lock (locker)
                    {
                        for (int j = 0; j < count; j++)
                        {
                            int number = differentBuses
                                ? busNumbers[random.Next(busNumbers.Length)]
                                : 175;

                            passengers.Add(new Passenger(number));

                        }

                        Console.WriteLine("Пришло людей: " + count);
                        Console.WriteLine("Людей на остановке: " + passengers.Count);
                    }

                    Thread.Sleep(500);
                }
            });

            Thread busThread = new Thread(() =>
            {
                for (int i = 0; i < busCount; i++)
                {
                    Thread.Sleep(1000);

                    int busNumber = differentBuses
                        ? busNumbers[random.Next(busNumbers.Length)]
                        : 175;

                    int freeSeats = busCapacity;

                    if (nonFinal)
                    {
                        int passengersInside = random.Next(0, busCapacity + 1);

                        freeSeats -= passengersInside;

                        Console.WriteLine("В автобусе уже пассажиров: " + passengersInside);
                    }

                    lock (locker)
                    {
                        int boarded = 0;

                        for (int j = passengers.Count - 1; j >= 0; j--)
                        {
                            if (freeSeats == 0)
                                break;

                            if (passengers[j].BusNumber == busNumber)
                            {
                                passengers.RemoveAt(j);
                                freeSeats--;
                                boarded++;
                            }
                        }

                        Console.WriteLine("\nАвтобус №" + busNumber + " приехал.");
                        Console.WriteLine("Зашло пассажиров: " + boarded);
                        Console.WriteLine("Свободных мест: " + freeSeats);
                        Console.WriteLine("Осталось людей: " + passengers.Count);
                    }
                }
            });

            peopleThread.Start();
            busThread.Start();

            peopleThread.Join();
            busThread.Join();

            Console.WriteLine("Осталось пассажиров: " + passengers.Count);
        }
    }

    class Passenger
    {
        public int BusNumber;

        public Passenger(int busNumber)
        {
            BusNumber = busNumber;
        }
    }
}