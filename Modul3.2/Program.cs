using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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

        internal sealed class HorseResult
        {
            public int Number;
            public int Place;
            public TimeSpan Time;
        }

        // Подсчёт вхождений без учёта регистра.
        internal static int CountWord(string text, string word)
        {
            if (string.IsNullOrEmpty(word)) return 0;
            int count = 0, index = 0;
            while ((index = text.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) >= 0)
            {
                count++;
                index += word.Length;
            }
            return count;
        }

        internal static async Task<int> CountWordInFileAsync(string path, string word)
        {
            string text = await Task.Run(() => File.ReadAllText(path));
            return CountWord(text, word);
        }

        internal static async Task<List<string>> SearchDirectoryAsync(string root, string word,
            IProgress<string> progress, CancellationToken token)
        {
            List<string> report = new List<string>();
            await Task.Run(() =>
            {
                Stack<string> folders = new Stack<string>();
                folders.Push(root);
                while (folders.Count > 0)
                {
                    token.ThrowIfCancellationRequested();
                    string folder = folders.Pop();
                    string[] files;
                    try { files = Directory.GetFiles(folder); }
                    catch (UnauthorizedAccessException) { continue; }
                    catch (IOException) { continue; }
                    foreach (string file in files)
                    {
                        token.ThrowIfCancellationRequested();
                        try
                        {
                            string text = File.ReadAllText(file);
                            int count = CountWord(text, word);
                            if (count > 0)
                            {
                                string entry = "Название файла: " + Path.GetFileName(file) + Environment.NewLine +
                                    "Путь к файлу: " + file + Environment.NewLine +
                                    "Количество вхождений слова: " + count + Environment.NewLine + Environment.NewLine;
                                report.Add(entry);
                                progress.Report(entry);
                            }
                        }
                        catch (UnauthorizedAccessException) { }
                        catch (IOException) { }
                    }
                    try
                    {
                        foreach (string subfolder in Directory.GetDirectories(folder)) folders.Push(subfolder);
                    }
                    catch (UnauthorizedAccessException) { }
                    catch (IOException) { }
                }
            }, token);
            return report;
        }
    }
}
