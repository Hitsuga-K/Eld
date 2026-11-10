namespace WindowsFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabWait, tabArguments;
        private System.Windows.Forms.Button btnWait, btnMode, btnCalculate, btnBrowse, btnSearch;
        private System.Windows.Forms.Label lblStatus, lblFirst, lblSecond, lblOperation, lblPath, lblWord;
        private System.Windows.Forms.TextBox txtFirst, txtSecond, txtPath, txtWord;
        private System.Windows.Forms.ComboBox cmbOperation;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabWait = new System.Windows.Forms.TabPage(); this.tabArguments = new System.Windows.Forms.TabPage();
            this.btnWait = new System.Windows.Forms.Button(); this.btnMode = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button(); this.btnBrowse = new System.Windows.Forms.Button(); this.btnSearch = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label(); this.lblFirst = new System.Windows.Forms.Label(); this.lblSecond = new System.Windows.Forms.Label();
            this.lblOperation = new System.Windows.Forms.Label(); this.lblPath = new System.Windows.Forms.Label(); this.lblWord = new System.Windows.Forms.Label();
            this.txtFirst = new System.Windows.Forms.TextBox(); this.txtSecond = new System.Windows.Forms.TextBox(); this.txtPath = new System.Windows.Forms.TextBox(); this.txtWord = new System.Windows.Forms.TextBox();
            this.cmbOperation = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            this.Text = "Работа с дочерними процессами"; this.ClientSize = new System.Drawing.Size(720, 430); this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill; this.tabs.Controls.Add(this.tabWait); this.tabs.Controls.Add(this.tabArguments);
            this.tabWait.Text = "Запуск и завершение"; this.tabArguments.Text = "Передача аргументов";
            this.btnWait.SetBounds(30, 30, 270, 38); this.btnWait.Text = "Задание 1: запустить и дождаться"; this.btnWait.Click += btnWait_Click;
            this.btnMode.SetBounds(30, 85, 420, 38); this.btnMode.Text = "Задание 2: запуск с выбором действия"; this.btnMode.Click += btnMode_Click;
            this.lblStatus.SetBounds(30, 150, 640, 90); this.lblStatus.Text = "Здесь появится состояние процесса и его код завершения.";
            this.tabWait.Controls.Add(this.btnWait); this.tabWait.Controls.Add(this.btnMode); this.tabWait.Controls.Add(this.lblStatus);
            this.lblFirst.SetBounds(30, 30, 120, 25); this.lblFirst.Text = "Первое число:";
            this.txtFirst.SetBounds(160, 28, 170, 25); this.txtFirst.Text = "7";
            this.lblSecond.SetBounds(30, 70, 120, 25); this.lblSecond.Text = "Второе число:";
            this.txtSecond.SetBounds(160, 68, 170, 25); this.txtSecond.Text = "3";
            this.lblOperation.SetBounds(30, 110, 120, 25); this.lblOperation.Text = "Операция:";
            this.cmbOperation.SetBounds(160, 108, 170, 25); this.cmbOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbOperation.Items.AddRange(new object[] { "+", "-", "*", "/" }); this.cmbOperation.SelectedIndex = 0;
            this.btnCalculate.SetBounds(160, 150, 220, 35); this.btnCalculate.Text = "Задание 3: вычислить"; this.btnCalculate.Click += btnCalculate_Click;
            this.lblPath.SetBounds(30, 220, 120, 25); this.lblPath.Text = "Путь к файлу:";
            this.txtPath.SetBounds(160, 218, 360, 25);
            this.btnBrowse.SetBounds(530, 216, 130, 28); this.btnBrowse.Text = "Обзор..."; this.btnBrowse.Click += btnBrowse_Click;
            this.lblWord.SetBounds(30, 260, 120, 25); this.lblWord.Text = "Слово для поиска:";
            this.txtWord.SetBounds(160, 258, 170, 25); this.txtWord.Text = "bicycle";
            this.btnSearch.SetBounds(160, 300, 290, 35); this.btnSearch.Text = "Задание 4: найти слово в файле"; this.btnSearch.Click += btnSearch_Click;
            this.tabArguments.Controls.Add(this.lblFirst); this.tabArguments.Controls.Add(this.txtFirst); this.tabArguments.Controls.Add(this.lblSecond); this.tabArguments.Controls.Add(this.txtSecond);
            this.tabArguments.Controls.Add(this.lblOperation); this.tabArguments.Controls.Add(this.cmbOperation); this.tabArguments.Controls.Add(this.btnCalculate);
            this.tabArguments.Controls.Add(this.lblPath); this.tabArguments.Controls.Add(this.txtPath); this.tabArguments.Controls.Add(this.btnBrowse); this.tabArguments.Controls.Add(this.lblWord); this.tabArguments.Controls.Add(this.txtWord); this.tabArguments.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tabs); this.ResumeLayout(false);
        }
    }
}
