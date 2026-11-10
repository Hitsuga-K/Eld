using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1() { InitializeComponent(); }

        private async void btnWait_Click(object sender, EventArgs e)
        {
            await RunAndWait("wait", "Задание 1");
        }

        private async void btnMode_Click(object sender, EventArgs e)
        {
            DialogResult choice = MessageBox.Show("Да — дождаться завершения и показать код.\nНет — принудительно завершить через 1 секунду.",
                "Выбор действия", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (choice == DialogResult.Cancel) return;
            Process child = null;
            try
            {
                child = Program.StartChild("wait");
                lblStatus.Text = "Дочерний процесс запущен. PID: " + child.Id;
                if (choice == DialogResult.Yes)
                {
                    await System.Threading.Tasks.Task.Run(() => child.WaitForExit());
                    lblStatus.Text = "Процесс завершён. Код завершения: " + child.ExitCode;
                }
                else
                {
                    await System.Threading.Tasks.Task.Delay(1000);
                    if (!child.HasExited) child.Kill();
                    await System.Threading.Tasks.Task.Run(() => child.WaitForExit());
                    lblStatus.Text = "Процесс принудительно завершён. Код завершения: " + child.ExitCode;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка процесса"); }
            finally { if (child != null) child.Dispose(); }
        }

        private async System.Threading.Tasks.Task RunAndWait(string mode, string caption)
        {
            Process child = null;
            try
            {
                child = Program.StartChild(mode);
                lblStatus.Text = "Дочерний процесс запущен. PID: " + child.Id + ". Ожидаю завершения...";
                await System.Threading.Tasks.Task.Run(() => child.WaitForExit());
                lblStatus.Text = "Дочерний процесс завершён. Код завершения: " + child.ExitCode;
                MessageBox.Show("Код завершения дочернего процесса: " + child.ExitCode, caption);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка запуска"); }
            finally { if (child != null) child.Dispose(); }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double first, second;
            if (!double.TryParse(txtFirst.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out first) ||
                !double.TryParse(txtSecond.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out second))
            {
                MessageBox.Show("Введите два корректных числа.", "Проверка данных"); return;
            }
            string arguments = "calc " + Program.QuoteArgument(first.ToString(CultureInfo.InvariantCulture)) + " " +
                Program.QuoteArgument(second.ToString(CultureInfo.InvariantCulture)) + " " + Program.QuoteArgument(cmbOperation.SelectedItem.ToString());
            try { Program.StartChild(arguments); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка запуска"); }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Выберите текстовый файл"; dialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                if (dialog.ShowDialog() == DialogResult.OK) txtPath.Text = dialog.FileName;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtPath.Text)) { MessageBox.Show("Выберите существующий файл.", "Проверка данных"); return; }
            if (string.IsNullOrWhiteSpace(txtWord.Text)) { MessageBox.Show("Введите слово для поиска.", "Проверка данных"); return; }
            try { Program.StartChild("search " + Program.QuoteArgument(txtPath.Text) + " " + Program.QuoteArgument(txtWord.Text)); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка запуска"); }
        }
    }
}
