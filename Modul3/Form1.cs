using System;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource primeCancel, fibonacciCancel;
        private ManualResetEvent primePause, fibonacciPause;
        private Task primeTask, fibonacciTask;

        public Form1() { InitializeComponent(); }

        private void StartPrime(bool restart)
        {
            long start = 2, endValue;
            long? end = null;
            if (!string.IsNullOrWhiteSpace(txtFrom.Text) && (!long.TryParse(txtFrom.Text, out start) || start < 2))
            { MessageBox.Show("Нижняя граница должна быть целым числом не меньше 2."); return; }
            if (!string.IsNullOrWhiteSpace(txtTo.Text))
            {
                if (!long.TryParse(txtTo.Text, out endValue) || endValue < start)
                { MessageBox.Show("Верхняя граница должна быть целым числом не меньше нижней границы."); return; }
                end = endValue;
            }
            StopPrime();
            if (restart) lstPrimes.Items.Clear();
            primeCancel = new CancellationTokenSource(); primePause = new ManualResetEvent(true);
            CancellationToken token = primeCancel.Token;
            ManualResetEvent pause = primePause;
            lblPrimeState.Text = end.HasValue ? "Генерация: " + start + "–" + end.Value : "Генерация без верхней границы...";
            primeTask = Task.Run(() => Program.GeneratePrimes(start, end, pause, token, value =>
                BeginInvoke((Action)(() => AddNumber(lstPrimes, value.ToString())))));
            primeTask.ContinueWith(t => { if (!IsDisposed && IsHandleCreated) BeginInvoke((Action)(() => { if (primeCancel != null && primeCancel.Token == token) lblPrimeState.Text = "Генерация завершена."; })); });
        }

        private void StartFibonacci(bool clear)
        {
            StopFibonacci();
            if (clear) lstFibonacci.Items.Clear();
            fibonacciCancel = new CancellationTokenSource(); fibonacciPause = new ManualResetEvent(true);
            CancellationToken token = fibonacciCancel.Token;
            ManualResetEvent pause = fibonacciPause;
            lblFibonacciState.Text = "Генерация выполняется.";
            fibonacciTask = Task.Run(() => Program.GenerateFibonacci(pause, token, value =>
                BeginInvoke((Action)(() => AddNumber(lstFibonacci, value.ToString())))));
            lblFibonacciState.Text = "Генерация выполняется.";
        }

        private void AddNumber(ListBox list, string value)
        {
            list.Items.Add(value);
            if (list.Items.Count > 1000) list.Items.RemoveAt(0);
            list.TopIndex = list.Items.Count - 1;
        }

        private void StopPrime()
        {
            if (primeCancel != null) { primeCancel.Cancel(); if (primePause != null) primePause.Set(); }
        }
        private void StopFibonacci()
        {
            if (fibonacciCancel != null) { fibonacciCancel.Cancel(); if (fibonacciPause != null) fibonacciPause.Set(); }
        }

        private void btnStartPrime_Click(object sender, EventArgs e) => StartPrime(false);
        private void btnStopPrime_Click(object sender, EventArgs e) { StopPrime(); lblPrimeState.Text = "Поток остановлен."; }
        private void btnPausePrime_Click(object sender, EventArgs e) { if (primePause != null) { primePause.Reset(); lblPrimeState.Text = "Поток приостановлен."; } }
        private void btnResumePrime_Click(object sender, EventArgs e) { if (primePause != null) { primePause.Set(); lblPrimeState.Text = "Генерация выполняется."; } }
        private void btnRestartPrime_Click(object sender, EventArgs e) => StartPrime(true);
        private void btnStartFib_Click(object sender, EventArgs e) => StartFibonacci(false);
        private void btnStopFib_Click(object sender, EventArgs e) { StopFibonacci(); lblFibonacciState.Text = "Поток остановлен."; }
        private void btnPauseFib_Click(object sender, EventArgs e) { if (fibonacciPause != null) { fibonacciPause.Reset(); lblFibonacciState.Text = "Поток приостановлен."; } }
        private void btnResumeFib_Click(object sender, EventArgs e) { if (fibonacciPause != null) { fibonacciPause.Set(); lblFibonacciState.Text = "Генерация выполняется."; } }
        private void btnRestartFib_Click(object sender, EventArgs e) => StartFibonacci(true);

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopPrime(); StopFibonacci();
            base.OnFormClosing(e);
        }
    }
}
