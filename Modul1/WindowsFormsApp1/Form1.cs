using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInfo_Click(object sender, EventArgs e) => Program.ShowPersonalInfo();

        private void btnWindow_Click(object sender, EventArgs e)
        {
            IntPtr handle = Program.FindDemoWindow(txtWindowTitle.Text);
            if (handle == IntPtr.Zero)
            {
                MessageBox.Show("Окно с таким заголовком не найдено. Убедитесь, что заголовок указан правильно.", "Поиск окна");
                return;
            }
            if (cmbAction.SelectedIndex == 0) Program.SetWindowTitle(handle, txtNewTitle.Text);
            else Program.CloseWindow(handle);
            MessageBox.Show("Команда отправлена найденному окну.", "Поиск окна");
        }

        private async void btnSound_Click(object sender, EventArgs e)
        {
            btnSound.Enabled = false;
            try { await System.Threading.Tasks.Task.Run(() => Program.PlayBeeps((int)numCount.Value, (int)numInterval.Value)); }
            finally { btnSound.Enabled = true; }
        }

        private void btnStyle_Click(object sender, EventArgs e)
        {
            lblStyle.Text = cmbStyle.SelectedIndex == 1 ? "Выделенный элемент" : "Обычный элемент";
            lblStyle.BackColor = cmbStyle.SelectedIndex == 1 ? System.Drawing.Color.LightSteelBlue : System.Drawing.SystemColors.Control;
            lblStyle.Font = new System.Drawing.Font(lblStyle.Font.FontFamily, chkLarge.Checked ? 14F : 9F,
                chkBold.Checked ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular);
        }
    }
}
