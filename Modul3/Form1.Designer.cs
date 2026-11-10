namespace WindowsFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblFrom, lblTo, lblPrimeState, lblFibonacciState;
        private System.Windows.Forms.TextBox txtFrom, txtTo;
        private System.Windows.Forms.ListBox lstPrimes, lstFibonacci;
        private System.Windows.Forms.Button btnStartPrime, btnStopPrime, btnPausePrime, btnResumePrime, btnRestartPrime;
        private System.Windows.Forms.Button btnStartFib, btnStopFib, btnPauseFib, btnResumeFib, btnRestartFib;
        private System.Windows.Forms.GroupBox grpPrime, grpFibonacci;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblFrom = new System.Windows.Forms.Label(); this.lblTo = new System.Windows.Forms.Label();
            this.lblPrimeState = new System.Windows.Forms.Label(); this.lblFibonacciState = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox(); this.txtTo = new System.Windows.Forms.TextBox();
            this.lstPrimes = new System.Windows.Forms.ListBox(); this.lstFibonacci = new System.Windows.Forms.ListBox();
            this.btnStartPrime = new System.Windows.Forms.Button(); this.btnStopPrime = new System.Windows.Forms.Button();
            this.btnPausePrime = new System.Windows.Forms.Button(); this.btnResumePrime = new System.Windows.Forms.Button(); this.btnRestartPrime = new System.Windows.Forms.Button();
            this.btnStartFib = new System.Windows.Forms.Button(); this.btnStopFib = new System.Windows.Forms.Button();
            this.btnPauseFib = new System.Windows.Forms.Button(); this.btnResumeFib = new System.Windows.Forms.Button(); this.btnRestartFib = new System.Windows.Forms.Button();
            this.grpPrime = new System.Windows.Forms.GroupBox(); this.grpFibonacci = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            this.Text = "Многопоточность: простые числа и Фибоначчи"; this.ClientSize = new System.Drawing.Size(900, 610); this.MinimumSize = new System.Drawing.Size(916, 649); this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.lblFrom.SetBounds(20, 15, 125, 24); this.lblFrom.Text = "Нижняя граница:";
            this.txtFrom.SetBounds(150, 13, 130, 24); this.txtFrom.Text = "2";
            this.lblTo.SetBounds(310, 15, 125, 24); this.lblTo.Text = "Верхняя граница:";
            this.txtTo.SetBounds(440, 13, 130, 24);
            this.grpPrime.SetBounds(15, 50, 425, 540); this.grpPrime.Text = "Простые числа";
            this.lstPrimes.SetBounds(15, 25, 395, 330); this.lstPrimes.IntegralHeight = false;
            this.btnStartPrime.SetBounds(15, 365, 120, 32); this.btnStartPrime.Text = "Запустить"; this.btnStartPrime.Click += btnStartPrime_Click;
            this.btnStopPrime.SetBounds(145, 365, 120, 32); this.btnStopPrime.Text = "Остановить"; this.btnStopPrime.Click += btnStopPrime_Click;
            this.btnPausePrime.SetBounds(15, 405, 120, 32); this.btnPausePrime.Text = "Пауза"; this.btnPausePrime.Click += btnPausePrime_Click;
            this.btnResumePrime.SetBounds(145, 405, 120, 32); this.btnResumePrime.Text = "Продолжить"; this.btnResumePrime.Click += btnResumePrime_Click;
            this.btnRestartPrime.SetBounds(275, 405, 130, 32); this.btnRestartPrime.Text = "Перезапустить"; this.btnRestartPrime.Click += btnRestartPrime_Click;
            this.lblPrimeState.SetBounds(15, 455, 395, 45); this.lblPrimeState.Text = "Поток не запущен.";
            this.grpPrime.Controls.Add(this.lstPrimes); this.grpPrime.Controls.Add(this.btnStartPrime); this.grpPrime.Controls.Add(this.btnStopPrime); this.grpPrime.Controls.Add(this.btnPausePrime); this.grpPrime.Controls.Add(this.btnResumePrime); this.grpPrime.Controls.Add(this.btnRestartPrime); this.grpPrime.Controls.Add(this.lblPrimeState);
            this.grpFibonacci.SetBounds(455, 50, 425, 540); this.grpFibonacci.Text = "Числа Фибоначчи";
            this.lstFibonacci.SetBounds(15, 25, 395, 330); this.lstFibonacci.IntegralHeight = false;
            this.btnStartFib.SetBounds(15, 365, 120, 32); this.btnStartFib.Text = "Запустить"; this.btnStartFib.Click += btnStartFib_Click;
            this.btnStopFib.SetBounds(145, 365, 120, 32); this.btnStopFib.Text = "Остановить"; this.btnStopFib.Click += btnStopFib_Click;
            this.btnPauseFib.SetBounds(15, 405, 120, 32); this.btnPauseFib.Text = "Пауза"; this.btnPauseFib.Click += btnPauseFib_Click;
            this.btnResumeFib.SetBounds(145, 405, 120, 32); this.btnResumeFib.Text = "Продолжить"; this.btnResumeFib.Click += btnResumeFib_Click;
            this.btnRestartFib.SetBounds(275, 405, 130, 32); this.btnRestartFib.Text = "Перезапустить"; this.btnRestartFib.Click += btnRestartFib_Click;
            this.lblFibonacciState.SetBounds(15, 455, 395, 45); this.lblFibonacciState.Text = "Поток не запущен.";
            this.grpFibonacci.Controls.Add(this.lstFibonacci); this.grpFibonacci.Controls.Add(this.btnStartFib); this.grpFibonacci.Controls.Add(this.btnStopFib); this.grpFibonacci.Controls.Add(this.btnPauseFib); this.grpFibonacci.Controls.Add(this.btnResumeFib); this.grpFibonacci.Controls.Add(this.btnRestartFib); this.grpFibonacci.Controls.Add(this.lblFibonacciState);
            this.Controls.Add(this.lblFrom); this.Controls.Add(this.txtFrom); this.Controls.Add(this.lblTo); this.Controls.Add(this.txtTo); this.Controls.Add(this.grpPrime); this.Controls.Add(this.grpFibonacci);
            this.ResumeLayout(false); this.PerformLayout();
        }
    }
}
