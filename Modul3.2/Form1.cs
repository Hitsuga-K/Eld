using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly Random random = new Random();
        private System.Windows.Forms.ProgressBar[] danceBars;
        private CancellationTokenSource animationCancel;
        private CancellationTokenSource raceCancel;
        private CancellationTokenSource searchCancel;

        public Form1()
        {
            InitializeComponent();
            danceBars = new System.Windows.Forms.ProgressBar[] { danceBar0, danceBar1, danceBar2, danceBar3, danceBar4, danceBar5, danceBar6, danceBar7, danceBar8, danceBar9 };
            horses = new System.Windows.Forms.ProgressBar[] { horse0, horse1, horse2, horse3, horse4 };
        }

        private async void btnBarsStart_Click(object sender, EventArgs e)
        {
            if (animationCancel != null) animationCancel.Cancel();
            animationCancel = new CancellationTokenSource();
            CancellationToken token = animationCancel.Token;
            int count = (int)numBars.Value;
            for (int i = 0; i < danceBars.Length; i++) danceBars[i].Visible = i < count;
            btnBarsStart.Enabled = false;
            try
            {
                Task[] tasks = new Task[count];
                for (int i = 0; i < count; i++)
                {
                    ProgressBar bar = danceBars[i]; int index = i;
                    tasks[i] = Task.Run(async () =>
                    {
                        while (!token.IsCancellationRequested)
                        {
                            int step = random.Next(1, 18);
                            Color color = Color.FromArgb(random.Next(50, 230), random.Next(50, 230), random.Next(50, 230));
                            if (IsDisposed || !IsHandleCreated) break;
                            BeginInvoke((Action)(() => { if (bar.Value + step >= bar.Maximum) bar.Value = 0; else bar.Value += step; bar.ForeColor = color; }));
                            await Task.Delay(random.Next(50, 250), token);
                        }
                    }, token);
                }
                await Task.WhenAll(tasks);
            }
            catch (OperationCanceledException) { }
            finally { btnBarsStart.Enabled = true; }
        }

        private async void btnRaceStart_Click(object sender, EventArgs e)
        {
            if (raceCancel != null) raceCancel.Cancel();
            raceCancel = new CancellationTokenSource(); CancellationToken token = raceCancel.Token;
            btnRaceStart.Enabled = false; txtRaceResults.Clear(); lblRaceStatus.Text = "Гонка идёт...";
            foreach (ProgressBar horse in horses) horse.Value = 0;
            List<Program.HorseResult> results = new List<Program.HorseResult>();
            object sync = new object();
            Task[] tasks = new Task[horses.Length];
            for (int i = 0; i < horses.Length; i++)
            {
                int number = i + 1; ProgressBar bar = horses[i];
                tasks[i] = Task.Run(async () =>
                {
                    DateTime start = DateTime.UtcNow;
                    while (bar.Value < bar.Maximum && !token.IsCancellationRequested)
                    {
                        await Task.Delay(random.Next(70, 220), token);
                        if (IsDisposed || !IsHandleCreated) return;
                        BeginInvoke((Action)(() => { if (bar.Value < bar.Maximum) bar.Value = Math.Min(100, bar.Value + random.Next(1, 9)); }));
                        await Task.Delay(20, token);
                        if (bar.Value >= 100) break;
                    }
                    lock (sync) results.Add(new Program.HorseResult { Number = number, Time = DateTime.UtcNow - start });
                }, token);
            }
            try
            {
                await Task.WhenAll(tasks);
                results.Sort((a, b) => a.Time.CompareTo(b.Time));
                for (int i = 0; i < results.Count; i++) results[i].Place = i + 1;
                txtRaceResults.Text = "Место\tЛошадь\tВремя\r\n";
                foreach (Program.HorseResult result in results) txtRaceResults.AppendText(result.Place + "\tЛошадь " + result.Number + "\t" + result.Time.TotalSeconds.ToString("F2") + " с\r\n");
                lblRaceStatus.Text = "Гонка завершена!";
            }
            catch (OperationCanceledException) { lblRaceStatus.Text = "Гонка остановлена."; }
            finally { btnRaceStart.Enabled = true; }
        }

        private async void btnFibStart_Click(object sender, EventArgs e)
        {
            BigInteger limit;
            if (!BigInteger.TryParse(txtFibLimit.Text, out limit) || limit < 0) { MessageBox.Show("Введите неотрицательную границу."); return; }
            btnFibStart.Enabled = false; lblFibResult.Text = "Вычисление...";
            try
            {
                string result = await Task.Run(() =>
                {
                    BigInteger a = 0, b = 1; System.Text.StringBuilder output = new System.Text.StringBuilder();
                    while (a <= limit)
                    {
                        if (output.Length > 0) output.Append(", ");
                        output.Append(a.ToString());
                        BigInteger next = a + b; a = b; b = next;
                    }
                    return output.ToString();
                });
                lblFibResult.Text = result;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка вычисления"); }
            finally { btnFibStart.Enabled = true; }
        }

        private void btnFileBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Выберите файл"; dialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                if (dialog.ShowDialog() == DialogResult.OK) txtFilePath.Text = dialog.FileName;
            }
        }

        private async void btnFileSearch_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtFilePath.Text)) { MessageBox.Show("Выберите существующий файл."); return; }
            if (string.IsNullOrWhiteSpace(txtFileWord.Text)) { MessageBox.Show("Введите слово для поиска."); return; }
            btnFileSearch.Enabled = false; lblFileResult.Text = "Идёт поиск...";
            try { int count = await Program.CountWordInFileAsync(txtFilePath.Text, txtFileWord.Text); lblFileResult.Text = "Слово найдено " + count + " раз(а)."; }
            catch (Exception ex) { lblFileResult.Text = "Ошибка: " + ex.Message; }
            finally { btnFileSearch.Enabled = true; }
        }

        private void btnDirBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                if (dialog.ShowDialog() == DialogResult.OK) txtDirPath.Text = dialog.SelectedPath;
        }

        private async void btnDirSearch_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtDirPath.Text)) { MessageBox.Show("Выберите существующую папку."); return; }
            if (string.IsNullOrWhiteSpace(txtDirWord.Text)) { MessageBox.Show("Введите слово для поиска."); return; }
            if (searchCancel != null) searchCancel.Cancel(); searchCancel = new CancellationTokenSource();
            btnDirSearch.Enabled = false; txtDirResults.Clear(); lblDirStatus.Text = "Поиск во всех папках...";
            var progress = new Progress<string>(entry => txtDirResults.AppendText(entry));
            try
            {
                List<string> result = await Program.SearchDirectoryAsync(txtDirPath.Text, txtDirWord.Text, progress, searchCancel.Token);
                lblDirStatus.Text = "Поиск завершён. Файлов с совпадениями: " + result.Count;
                if (result.Count == 0) txtDirResults.Text = "Совпадений не найдено.";
            }
            catch (OperationCanceledException) { lblDirStatus.Text = "Поиск отменён."; }
            catch (Exception ex) { lblDirStatus.Text = "Ошибка: " + ex.Message; }
            finally { btnDirSearch.Enabled = true; }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (animationCancel != null) animationCancel.Cancel();
            if (raceCancel != null) raceCancel.Cancel();
            if (searchCancel != null) searchCancel.Cancel();
            base.OnFormClosing(e);
        }
    }
}
