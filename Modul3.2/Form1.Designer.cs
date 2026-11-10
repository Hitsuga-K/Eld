namespace WindowsFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabBars, tabRace, tabFibonacci, tabFile, tabDirectory;
        private System.Windows.Forms.Button btnBarsStart, btnRaceStart, btnFibStart, btnFileBrowse, btnFileSearch, btnDirBrowse, btnDirSearch;
        private System.Windows.Forms.NumericUpDown numBars;
        private System.Windows.Forms.ProgressBar danceBar0, danceBar1, danceBar2, danceBar3, danceBar4, danceBar5, danceBar6, danceBar7, danceBar8, danceBar9;
        private System.Windows.Forms.ProgressBar[] horses;
        private System.Windows.Forms.ProgressBar horse0, horse1, horse2, horse3, horse4;
        private System.Windows.Forms.TextBox txtFibLimit, txtFilePath, txtFileWord, txtDirPath, txtDirWord;
        private System.Windows.Forms.Label lblRaceStatus, lblFibResult, lblFileResult, lblDirStatus;
        private System.Windows.Forms.Label lblFibLimit, lblFilePath, lblFileWord, lblDirPath, lblDirWord;
        private System.Windows.Forms.TextBox txtRaceResults, txtDirResults;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabBars = new System.Windows.Forms.TabPage(); this.tabRace = new System.Windows.Forms.TabPage();
            this.tabFibonacci = new System.Windows.Forms.TabPage(); this.tabFile = new System.Windows.Forms.TabPage(); this.tabDirectory = new System.Windows.Forms.TabPage();
            this.btnBarsStart = new System.Windows.Forms.Button(); this.btnRaceStart = new System.Windows.Forms.Button(); this.btnFibStart = new System.Windows.Forms.Button();
            this.btnFileBrowse = new System.Windows.Forms.Button(); this.btnFileSearch = new System.Windows.Forms.Button(); this.btnDirBrowse = new System.Windows.Forms.Button(); this.btnDirSearch = new System.Windows.Forms.Button();
            this.numBars = new System.Windows.Forms.NumericUpDown(); this.horses = new System.Windows.Forms.ProgressBar[5];
            this.danceBar0 = new System.Windows.Forms.ProgressBar(); this.danceBar1 = new System.Windows.Forms.ProgressBar(); this.danceBar2 = new System.Windows.Forms.ProgressBar(); this.danceBar3 = new System.Windows.Forms.ProgressBar(); this.danceBar4 = new System.Windows.Forms.ProgressBar(); this.danceBar5 = new System.Windows.Forms.ProgressBar(); this.danceBar6 = new System.Windows.Forms.ProgressBar(); this.danceBar7 = new System.Windows.Forms.ProgressBar(); this.danceBar8 = new System.Windows.Forms.ProgressBar(); this.danceBar9 = new System.Windows.Forms.ProgressBar();
            this.txtFibLimit = new System.Windows.Forms.TextBox(); this.txtFilePath = new System.Windows.Forms.TextBox(); this.txtFileWord = new System.Windows.Forms.TextBox(); this.txtDirPath = new System.Windows.Forms.TextBox(); this.txtDirWord = new System.Windows.Forms.TextBox();
            this.lblFibLimit = new System.Windows.Forms.Label(); this.lblFilePath = new System.Windows.Forms.Label(); this.lblFileWord = new System.Windows.Forms.Label(); this.lblDirPath = new System.Windows.Forms.Label(); this.lblDirWord = new System.Windows.Forms.Label();
            this.lblRaceStatus = new System.Windows.Forms.Label(); this.lblFibResult = new System.Windows.Forms.Label(); this.lblFileResult = new System.Windows.Forms.Label(); this.lblDirStatus = new System.Windows.Forms.Label();
            this.txtRaceResults = new System.Windows.Forms.TextBox(); this.txtDirResults = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            this.Text = "Многопоточность и асинхронность"; this.ClientSize = new System.Drawing.Size(850, 570); this.MinimumSize = new System.Drawing.Size(866, 609); this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill; this.tabs.Controls.Add(this.tabBars); this.tabs.Controls.Add(this.tabRace); this.tabs.Controls.Add(this.tabFibonacci); this.tabs.Controls.Add(this.tabFile); this.tabs.Controls.Add(this.tabDirectory);
            this.tabBars.Text = "Танцующие бары"; this.tabRace.Text = "Скачки"; this.tabFibonacci.Text = "Фибоначчи"; this.tabFile.Text = "Поиск в файле"; this.tabDirectory.Text = "Поиск в папке";
            this.numBars.SetBounds(20, 20, 100, 25); this.numBars.Minimum = 1; this.numBars.Maximum = 10; this.numBars.Value = 5;
            this.btnBarsStart.SetBounds(140, 17, 170, 32); this.btnBarsStart.Text = "Запустить анимацию"; this.btnBarsStart.Click += btnBarsStart_Click;
            this.danceBar0.SetBounds(25, 65, 750, 25); this.danceBar0.Visible = true; this.tabBars.Controls.Add(this.danceBar0);
            this.danceBar1.SetBounds(25, 103, 750, 25); this.danceBar1.Visible = true; this.tabBars.Controls.Add(this.danceBar1);
            this.danceBar2.SetBounds(25, 141, 750, 25); this.danceBar2.Visible = true; this.tabBars.Controls.Add(this.danceBar2);
            this.danceBar3.SetBounds(25, 179, 750, 25); this.danceBar3.Visible = true; this.tabBars.Controls.Add(this.danceBar3);
            this.danceBar4.SetBounds(25, 217, 750, 25); this.danceBar4.Visible = true; this.tabBars.Controls.Add(this.danceBar4);
            this.danceBar5.SetBounds(25, 255, 750, 25); this.danceBar5.Visible = false; this.tabBars.Controls.Add(this.danceBar5);
            this.danceBar6.SetBounds(25, 293, 750, 25); this.danceBar6.Visible = false; this.tabBars.Controls.Add(this.danceBar6);
            this.danceBar7.SetBounds(25, 331, 750, 25); this.danceBar7.Visible = false; this.tabBars.Controls.Add(this.danceBar7);
            this.danceBar8.SetBounds(25, 369, 750, 25); this.danceBar8.Visible = false; this.tabBars.Controls.Add(this.danceBar8);
            this.danceBar9.SetBounds(25, 407, 750, 25); this.danceBar9.Visible = false; this.tabBars.Controls.Add(this.danceBar9);
            this.tabBars.Controls.Add(this.numBars); this.tabBars.Controls.Add(this.btnBarsStart);
            this.horse0 = new System.Windows.Forms.ProgressBar(); this.horse1 = new System.Windows.Forms.ProgressBar(); this.horse2 = new System.Windows.Forms.ProgressBar(); this.horse3 = new System.Windows.Forms.ProgressBar(); this.horse4 = new System.Windows.Forms.ProgressBar();
            this.horse0.SetBounds(120, 25, 620, 28); this.tabRace.Controls.Add(this.horse0);
            this.horse1.SetBounds(120, 70, 620, 28); this.tabRace.Controls.Add(this.horse1);
            this.horse2.SetBounds(120, 115, 620, 28); this.tabRace.Controls.Add(this.horse2);
            this.horse3.SetBounds(120, 160, 620, 28); this.tabRace.Controls.Add(this.horse3);
            this.horse4.SetBounds(120, 205, 620, 28); this.tabRace.Controls.Add(this.horse4);
            this.btnRaceStart.SetBounds(20, 260, 150, 35); this.btnRaceStart.Text = "Старт гонки"; this.btnRaceStart.Click += btnRaceStart_Click;
            this.lblRaceStatus.SetBounds(190, 265, 550, 25); this.lblRaceStatus.Text = "Нажмите «Старт гонки».";
            this.txtRaceResults.SetBounds(20, 310, 780, 180); this.txtRaceResults.Multiline = true; this.txtRaceResults.ReadOnly = true; this.txtRaceResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tabRace.Controls.Add(this.btnRaceStart); this.tabRace.Controls.Add(this.lblRaceStatus); this.tabRace.Controls.Add(this.txtRaceResults);
            this.lblFibLimit.Text = "Верхняя граница:"; this.lblFibLimit.SetBounds(25, 30, 130, 25); this.tabFibonacci.Controls.Add(this.lblFibLimit); this.txtFibLimit.SetBounds(165, 28, 180, 25); this.txtFibLimit.Text = "1000000";
            this.btnFibStart.SetBounds(365, 25, 180, 32); this.btnFibStart.Text = "Посчитать числа"; this.btnFibStart.Click += btnFibStart_Click;
            this.lblFibResult.SetBounds(25, 75, 780, 440); this.lblFibResult.Text = "Введите предел числа Фибоначчи и нажмите кнопку."; this.lblFibResult.AutoSize = false;
            this.tabFibonacci.Controls.Add(this.txtFibLimit); this.tabFibonacci.Controls.Add(this.btnFibStart); this.tabFibonacci.Controls.Add(this.lblFibResult);
            this.lblFilePath.Text = "Путь к файлу:"; this.lblFilePath.SetBounds(25, 35, 125, 25); this.tabFile.Controls.Add(this.lblFilePath); this.txtFilePath.SetBounds(160, 33, 500, 25);
            this.btnFileBrowse.SetBounds(675, 31, 120, 29); this.btnFileBrowse.Text = "Обзор..."; this.btnFileBrowse.Click += btnFileBrowse_Click;
            this.lblFileWord.Text = "Искомое слово:"; this.lblFileWord.SetBounds(25, 80, 125, 25); this.tabFile.Controls.Add(this.lblFileWord); this.txtFileWord.SetBounds(160, 78, 220, 25); this.txtFileWord.Text = "bicycle";
            this.btnFileSearch.SetBounds(400, 75, 180, 32); this.btnFileSearch.Text = "Найти"; this.btnFileSearch.Click += btnFileSearch_Click;
            this.lblFileResult.SetBounds(25, 130, 780, 50); this.lblFileResult.Text = "Выберите файл и укажите слово.";
            this.tabFile.Controls.Add(this.txtFilePath); this.tabFile.Controls.Add(this.btnFileBrowse); this.tabFile.Controls.Add(this.txtFileWord); this.tabFile.Controls.Add(this.btnFileSearch); this.tabFile.Controls.Add(this.lblFileResult);
            this.lblDirPath.Text = "Путь к папке:"; this.lblDirPath.SetBounds(25, 25, 125, 25); this.tabDirectory.Controls.Add(this.lblDirPath); this.txtDirPath.SetBounds(160, 23, 500, 25);
            this.btnDirBrowse.SetBounds(675, 21, 120, 29); this.btnDirBrowse.Text = "Обзор..."; this.btnDirBrowse.Click += btnDirBrowse_Click;
            this.lblDirWord.Text = "Искомое слово:"; this.lblDirWord.SetBounds(25, 65, 125, 25); this.tabDirectory.Controls.Add(this.lblDirWord); this.txtDirWord.SetBounds(160, 63, 220, 25); this.txtDirWord.Text = "bicycle";
            this.btnDirSearch.SetBounds(400, 60, 180, 32); this.btnDirSearch.Text = "Искать во всех папках"; this.btnDirSearch.Click += btnDirSearch_Click;
            this.lblDirStatus.SetBounds(25, 100, 780, 25); this.lblDirStatus.Text = "Подпапки также будут проверены.";
            this.txtDirResults.SetBounds(25, 135, 780, 370); this.txtDirResults.Multiline = true; this.txtDirResults.ReadOnly = true; this.txtDirResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tabDirectory.Controls.Add(this.txtDirPath); this.tabDirectory.Controls.Add(this.btnDirBrowse); this.tabDirectory.Controls.Add(this.txtDirWord); this.tabDirectory.Controls.Add(this.btnDirSearch); this.tabDirectory.Controls.Add(this.lblDirStatus); this.tabDirectory.Controls.Add(this.txtDirResults);
            this.Controls.Add(this.tabs); this.ResumeLayout(false);
        }
}
}
