namespace WindowsFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabEvents, tabStop;
        private System.Windows.Forms.Label lblPairCount, lblPairStatus, lblStopRoute, lblStopCapacity, lblPassengerCount, lblStopStatus;
        private System.Windows.Forms.TextBox txtPairCount, txtStopRoute, txtStopCapacity, txtPassengerCount, txtLog;
        private System.Windows.Forms.Button btnProcessPairs, btnStartStop, btnAddPassengers, btnBusArrive, btnStopSimulation;
        private System.Windows.Forms.CheckBox chkNonTerminal;
        private System.Windows.Forms.ListBox lstRoutes;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabs = new System.Windows.Forms.TabControl(); this.tabEvents = new System.Windows.Forms.TabPage(); this.tabStop = new System.Windows.Forms.TabPage();
            this.lblPairCount = new System.Windows.Forms.Label(); this.lblPairStatus = new System.Windows.Forms.Label(); this.lblStopRoute = new System.Windows.Forms.Label(); this.lblStopCapacity = new System.Windows.Forms.Label(); this.lblPassengerCount = new System.Windows.Forms.Label(); this.lblStopStatus = new System.Windows.Forms.Label();
            this.txtPairCount = new System.Windows.Forms.TextBox(); this.txtStopRoute = new System.Windows.Forms.TextBox(); this.txtStopCapacity = new System.Windows.Forms.TextBox(); this.txtPassengerCount = new System.Windows.Forms.TextBox(); this.txtLog = new System.Windows.Forms.TextBox();
            this.btnProcessPairs = new System.Windows.Forms.Button(); this.btnStartStop = new System.Windows.Forms.Button(); this.btnAddPassengers = new System.Windows.Forms.Button(); this.btnBusArrive = new System.Windows.Forms.Button(); this.btnStopSimulation = new System.Windows.Forms.Button();
            this.chkNonTerminal = new System.Windows.Forms.CheckBox(); this.lstRoutes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            this.Text = "Потоки, события и автобусная остановка"; this.ClientSize = new System.Drawing.Size(850, 590); this.MinimumSize = new System.Drawing.Size(866, 629); this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill; this.tabs.Controls.Add(this.tabEvents); this.tabs.Controls.Add(this.tabStop);
            this.tabEvents.Text = "События между потоками"; this.tabStop.Text = "Автобусная остановка";
            this.lblPairCount.Text = "Количество пар:"; this.lblPairCount.SetBounds(25, 30, 130, 25); this.tabEvents.Controls.Add(this.lblPairCount);
            this.txtPairCount.SetBounds(165, 28, 120, 25); this.txtPairCount.Text = "20"; this.tabEvents.Controls.Add(this.txtPairCount);
            this.btnProcessPairs.SetBounds(310, 25, 250, 34); this.btnProcessPairs.Text = "Запустить обработку"; this.btnProcessPairs.Click += btnProcessPairs_Click; this.tabEvents.Controls.Add(this.btnProcessPairs);
            this.lblPairStatus.SetBounds(25, 80, 770, 45); this.lblPairStatus.Text = "Создадутся файлы pairs.txt, sums.txt и products.txt."; this.tabEvents.Controls.Add(this.lblPairStatus);
            this.lblStopRoute.Text = "Номер маршрута:"; this.lblStopRoute.SetBounds(20, 20, 130, 25); this.tabStop.Controls.Add(this.lblStopRoute);
            this.txtStopRoute.SetBounds(160, 18, 100, 25); this.txtStopRoute.Text = "175"; this.tabStop.Controls.Add(this.txtStopRoute);
            this.lblStopCapacity.Text = "Вместимость:"; this.lblStopCapacity.SetBounds(280, 20, 100, 25); this.tabStop.Controls.Add(this.lblStopCapacity);
            this.txtStopCapacity.SetBounds(390, 18, 80, 25); this.txtStopCapacity.Text = "40"; this.tabStop.Controls.Add(this.txtStopCapacity);
            this.chkNonTerminal.Text = "Остановка не конечная (автобус уже с пассажирами)"; this.chkNonTerminal.SetBounds(490, 18, 330, 25); this.chkNonTerminal.Checked = true; this.tabStop.Controls.Add(this.chkNonTerminal);
            this.lblPassengerCount.Text = "Новых людей:"; this.lblPassengerCount.SetBounds(20, 65, 130, 25); this.tabStop.Controls.Add(this.lblPassengerCount);
            this.txtPassengerCount.SetBounds(160, 63, 100, 25); this.txtPassengerCount.Text = "10"; this.tabStop.Controls.Add(this.txtPassengerCount);
            this.btnAddPassengers.SetBounds(280, 60, 180, 32); this.btnAddPassengers.Text = "Люди пришли"; this.btnAddPassengers.Click += btnAddPassengers_Click; this.tabStop.Controls.Add(this.btnAddPassengers);
            this.btnBusArrive.SetBounds(475, 60, 170, 32); this.btnBusArrive.Text = "Автобус приехал"; this.btnBusArrive.Click += btnBusArrive_Click; this.tabStop.Controls.Add(this.btnBusArrive);
            this.btnStartStop.SetBounds(20, 110, 165, 32); this.btnStartStop.Text = "Начать день"; this.btnStartStop.Click += btnStartStop_Click; this.tabStop.Controls.Add(this.btnStartStop);
            this.btnStopSimulation.SetBounds(200, 110, 165, 32); this.btnStopSimulation.Text = "Завершить день"; this.btnStopSimulation.Click += btnStopSimulation_Click; this.tabStop.Controls.Add(this.btnStopSimulation);
            this.lblStopStatus.SetBounds(20, 155, 800, 30); this.lblStopStatus.Text = "Симуляция остановлена."; this.tabStop.Controls.Add(this.lblStopStatus);
            this.lstRoutes.SetBounds(20, 195, 200, 280); this.lstRoutes.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended; this.tabStop.Controls.Add(this.lstRoutes);
            this.txtLog.SetBounds(235, 195, 585, 340); this.txtLog.Multiline = true; this.txtLog.ReadOnly = true; this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical; this.tabStop.Controls.Add(this.txtLog);
            this.Controls.Add(this.tabs); this.ResumeLayout(false);
        }
    }
}
