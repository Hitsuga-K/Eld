using System;
using System.Threading;
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

        // Поток простых чисел. Пустая верхняя граница означает работу до остановки.
        internal static void GeneratePrimes(long start, long? end, ManualResetEvent pause,
            CancellationToken token, Action<long> showNumber)
        {
            long number = Math.Max(2, start);
            while (!token.IsCancellationRequested && (!end.HasValue || number <= end.Value))
            {
                pause.WaitOne();
                if (token.IsCancellationRequested) break;
                if (IsPrime(number)) showNumber(number);
                if (number == long.MaxValue) break;
                number++;
                Thread.Sleep(100);
            }
        }

        private static bool IsPrime(long number)
        {
            if (number < 2) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;
            for (long divisor = 3; divisor <= number / divisor; divisor += 2)
                if (number % divisor == 0) return false;
            return true;
        }

        // Поток чисел Фибоначчи. Используется BigInteger, чтобы последовательность не переполнялась.
        internal static void GenerateFibonacci(ManualResetEvent pause, CancellationToken token,
            Action<System.Numerics.BigInteger> showNumber)
        {
            System.Numerics.BigInteger previous = 0, current = 1;
            while (!token.IsCancellationRequested)
            {
                pause.WaitOne();
                if (token.IsCancellationRequested) break;
                showNumber(previous);
                System.Numerics.BigInteger next = previous + current;
                previous = current;
                current = next;
                Thread.Sleep(350);
            }
        }
    }
}
