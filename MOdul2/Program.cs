using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "--child")
            {
                RunChild(args);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        // Запуск дочернего экземпляра этой же программы.
        internal static Process StartChild(string childArguments)
        {
            string executable = Application.ExecutablePath;
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = executable;
            startInfo.Arguments = "--child " + childArguments;
            startInfo.UseShellExecute = true;
            return Process.Start(startInfo);
        }

        private static void RunChild(string[] args)
        {
            try
            {
                string mode = args.Length > 1 ? args[1] : "wait";
                if (mode == "wait")
                {
                    // Даём родительскому окну время показать запуск и управление.
                    System.Threading.Thread.Sleep(3000);
                    Environment.ExitCode = 42;
                }
                else if (mode == "calc" && args.Length >= 5)
                {
                    double first = double.Parse(args[2], CultureInfo.InvariantCulture);
                    double second = double.Parse(args[3], CultureInfo.InvariantCulture);
                    string operation = args[4];
                    double result;
                    switch (operation)
                    {
                        case "+": result = first + second; break;
                        case "-": result = first - second; break;
                        case "*": result = first * second; break;
                        case "/":
                            if (second == 0) throw new DivideByZeroException("На ноль делить нельзя.");
                            result = first / second; break;
                        default: throw new ArgumentException("Неизвестная операция.");
                    }
                    MessageBox.Show("Аргументы дочернего процесса:\nПервое число: " + first +
                        "\nВторое число: " + second + "\nОперация: " + operation +
                        "\n\nРезультат: " + result, "Дочерний процесс — калькулятор");
                }
                else if (mode == "search" && args.Length >= 4)
                {
                    string path = args[2];
                    string word = args[3];
                    string content = File.ReadAllText(path);
                    int count = CountOccurrences(content, word);
                    MessageBox.Show("Файл: " + path + "\nИскомое слово: " + word +
                        "\nКоличество вхождений: " + count, "Дочерний процесс — поиск");
                }
                else
                {
                    MessageBox.Show("Не удалось распознать аргументы дочернего процесса.", "Ошибка запуска");
                    Environment.ExitCode = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка дочернего процесса:\n" + ex.Message, "Ошибка");
                Environment.ExitCode = 1;
            }
        }

        private static int CountOccurrences(string text, string word)
        {
            if (string.IsNullOrEmpty(word)) return 0;
            int count = 0, position = 0;
            while ((position = text.IndexOf(word, position, StringComparison.OrdinalIgnoreCase)) >= 0)
            {
                count++;
                position += word.Length;
            }
            return count;
        }

        internal static string QuoteArgument(string value)
        {
            return "\"" + value.Replace("\\", "\\\\").Replace("\"", "\\\"") + "\"";
        }
    }
}
