using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        internal sealed class Pair
        {
            public int First;
            public int Second;
            public Pair(int first, int second) { First = first; Second = second; }
        }

        // Первый поток генерирует пары и поднимает событие после записи файла.
        internal static void GeneratePairs(int amount, string path, ManualResetEvent generated, CancellationToken token)
        {
            Random random = new Random();
            List<Pair> pairs = new List<Pair>();
            for (int i = 0; i < amount && !token.IsCancellationRequested; i++)
                pairs.Add(new Pair(random.Next(1, 101), random.Next(1, 101)));
            using (StreamWriter writer = new StreamWriter(path, false))
                foreach (Pair pair in pairs) writer.WriteLine(pair.First + ";" + pair.Second);
            generated.Set();
        }

        // Второй и третий потоки ждут событие генератора и формируют свои файлы.
        internal static void CalculatePairs(string sourcePath, string resultPath, ManualResetEvent generated,
            CancellationToken token, Func<Pair, long> operation)
        {
            generated.WaitOne();
            if (token.IsCancellationRequested) return;
            using (StreamReader reader = new StreamReader(sourcePath))
            using (StreamWriter writer = new StreamWriter(resultPath, false))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(';');
                    Pair pair = new Pair(int.Parse(values[0]), int.Parse(values[1]));
                    writer.WriteLine(pair.First + " и " + pair.Second + " = " + operation(pair));
                }
            }
        }

        internal sealed class Passenger
        {
            public int Route;
            public Passenger(int route) { Route = route; }
        }

        internal sealed class StopState
        {
            public readonly List<Passenger> Waiting = new List<Passenger>();
            public int TotalBoarded;
            public int BusNumber = 175;
            public int BusCapacity = 40;
            public int PassengersOnBus;
            public int Arrivals;
        }
    }
}
