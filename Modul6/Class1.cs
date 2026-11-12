using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ClassLibrary1
{
    public class Geometry
    {
        public static double Square(double a)
        {
            return a * a;
        }

        public static double Rectangle(double a, double b)
        {
            return a * b;
        }

        public static double Triangle(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }

    public class TextTools
    {
        public static bool IsPalindrome(string text)
        {
            text = text.ToLower().Replace(" ", "");

            string reverse = "";

            for (int i = text.Length - 1; i >= 0; i--)
            {
                reverse += text[i];
            }

            return text == reverse;
        }

        public static int CountSentences(string text)
        {
            string[] sentences = Regex.Split(text, @"[.!?]+");

            int count = 0;

            foreach (string sentence in sentences)
            {
                if (sentence.Trim() != "")
                {
                    count++;
                }
            }

            return count;
        }

        public static string ReverseString(string text)
        {
            string result = "";

            for (int i = text.Length - 1; i >= 0; i--)
            {
                result += text[i];
            }

            return result;
        }
    }

    public class ContactValidator
    {
        public static bool CheckName(string name)
        {
            return Regex.IsMatch(name, @"^[а-яА-ЯёЁa-zA-Z\s-]+$");
        }

        public static bool CheckAge(string age)
        {
            return Regex.IsMatch(age, @"^\d+$");
        }

        public static bool CheckPhone(string phone)
        {
            return Regex.IsMatch(phone, @"^\+7 \(\d{3}\) \d{3}-\d{2}-\d{2}$");
        }

        public static bool CheckEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }

    public class FileOperations
    {
        public static void CopyFile(string source, string destination)
        {
            File.Copy(source, destination, true);
        }

        public static void CopyDirectory(string source, string destination)
        {
            Directory.CreateDirectory(destination);

            foreach (string file in Directory.GetFiles(source))
            {
                string name = Path.GetFileName(file);

                File.Copy(file, Path.Combine(destination, name), true);
            }

            foreach (string directory in Directory.GetDirectories(source))
            {
                string name = Path.GetFileName(directory);

                CopyDirectory(directory, Path.Combine(destination, name));
            }
        }

        public static void DeleteFile(string path, string name)
        {
            string file = Path.Combine(path, name);

            if (File.Exists(file))
            {
                File.Delete(file);
            }
        }

        public static void DeleteFiles(string path, string[] names)
        {
            foreach (string name in names)
            {
                string file = Path.Combine(path, name);

                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }
        }

        public static void DeleteByMask(string path, string mask)
        {
            string[] files = Directory.GetFiles(path, mask);

            foreach (string file in files)
            {
                File.Delete(file);
            }
        }

        public static void MoveFile(string source, string destination)
        {
            if (File.Exists(destination))
            {
                File.Delete(destination);
            }

            File.Move(source, destination);
        }
        public static void SearchWordInFile(string filePath, string word, string reportPath)
        {
            string text = File.ReadAllText(filePath);

            bool found = text.ToLower().Contains(word.ToLower());

            string report;

            if (found)
            {
                report = "Слово найдено: " + word;
            }
            else
            {
                report = "Слово не найдено: " + word;
            }

            File.WriteAllText(reportPath, report);
        }

        public static void SearchWordInDirectory(string path, string word, string reportPath)
        {
            string report = "";

            string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                string text = File.ReadAllText(file);

                if (text.ToLower().Contains(word.ToLower()))
                {
                    report += "Слово найдено в файле: " + file + Environment.NewLine;
                }
            }

            if (report == "")
            {
                report = "Слово не найдено.";
            }

            File.WriteAllText(reportPath, report);
        }
    }
}