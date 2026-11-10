namespace WindowsFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabInfo, tabWindow, tabSound, tabStyles;
        private System.Windows.Forms.Label lblName, lblGroup, lblWindowTitle, lblNewTitle, lblStyle;
        private System.Windows.Forms.TextBox txtWindowTitle, txtNewTitle;
        private System.Windows.Forms.ComboBox cmbAction, cmbStyle;
        private System.Windows.Forms.Button btnInfo, btnWindow, btnSound, btnStyle;
        private System.Windows.Forms.NumericUpDown numCount, numInterval;
        private System.Windows.Forms.CheckBox chkBold, chkLarge;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabInfo = new System.Windows.Forms.TabPage(); this.tabWindow = new System.Windows.Forms.TabPage();
            this.tabSound = new System.Windows.Forms.TabPage(); this.tabStyles = new System.Windows.Forms.TabPage();
            this.lblName = new System.Windows.Forms.Label(); this.lblGroup = new System.Windows.Forms.Label();
            this.lblWindowTitle = new System.Windows.Forms.Label(); this.lblNewTitle = new System.Windows.Forms.Label(); this.lblStyle = new System.Windows.Forms.Label();
            this.txtWindowTitle = new System.Windows.Forms.TextBox(); this.txtNewTitle = new System.Windows.Forms.TextBox();
            this.cmbAction = new System.Windows.Forms.ComboBox(); this.cmbStyle = new System.Windows.Forms.ComboBox();
            this.btnInfo = new System.Windows.Forms.Button(); this.btnWindow = new System.Windows.Forms.Button(); this.btnSound = new System.Windows.Forms.Button(); this.btnStyle = new System.Windows.Forms.Button();
            this.numCount = new System.Windows.Forms.NumericUpDown(); this.numInterval = new System.Windows.Forms.NumericUpDown();
            this.chkBold = new System.Windows.Forms.CheckBox(); this.chkLarge = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            this.Text = "Демонстрация функций Windows API"; this.ClientSize = new System.Drawing.Size(700, 430); this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Controls.Add(this.tabInfo); this.tabs.Controls.Add(this.tabWindow); this.tabs.Controls.Add(this.tabSound); this.tabs.Controls.Add(this.tabStyles);
            tabInfo.Text = "MessageBox"; tabWindow.Text = "Поиск окна"; tabSound.Text = "Звуковые сигналы"; tabStyles.Text = "Стили элементов";
            lblName.SetBounds(30, 35, 580, 30); lblName.Text = "Имя: Максим"; lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            lblGroup.SetBounds(30, 75, 580, 30); lblGroup.Text = "Группа: укажите свою группу"; lblGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            btnInfo.SetBounds(30, 130, 250, 38); btnInfo.Text = "Показать информацию в MessageBox"; btnInfo.Click += btnInfo_Click;
            tabInfo.Controls.AddRange(new System.Windows.Forms.Control[] { lblName, lblGroup, btnInfo });
            lblWindowTitle.SetBounds(25, 30, 130, 25); lblWindowTitle.Text = "Заголовок окна:";
            txtWindowTitle.SetBounds(165, 28, 300, 25); txtWindowTitle.Text = "Демонстрация функций Windows API";
            lblNewTitle.SetBounds(25, 75, 130, 25); lblNewTitle.Text = "Новый заголовок:";
            txtNewTitle.SetBounds(165, 73, 300, 25); txtNewTitle.Text = "Новый заголовок";
            cmbAction.SetBounds(165, 115, 300, 25); cmbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; cmbAction.Items.AddRange(new object[] { "Изменить заголовок", "Закрыть окно" }); cmbAction.SelectedIndex = 0;
            btnWindow.SetBounds(165, 160, 200, 35); btnWindow.Text = "Найти и выполнить"; btnWindow.Click += btnWindow_Click;
            tabWindow.Controls.AddRange(new System.Windows.Forms.Control[] { lblWindowTitle, txtWindowTitle, lblNewTitle, txtNewTitle, cmbAction, btnWindow });
            numCount.SetBounds(190, 35, 100, 25); numCount.Minimum = 1; numCount.Maximum = 20; numCount.Value = 5;
            numInterval.SetBounds(190, 80, 100, 25); numInterval.Minimum = 100; numInterval.Maximum = 5000; numInterval.Increment = 100; numInterval.Value = 700;
            System.Windows.Forms.Label soundLabel1 = new System.Windows.Forms.Label(); soundLabel1.Text = "Количество сигналов:"; soundLabel1.SetBounds(25, 35, 155, 25);
            System.Windows.Forms.Label soundLabel2 = new System.Windows.Forms.Label(); soundLabel2.Text = "Интервал (мс):"; soundLabel2.SetBounds(25, 80, 155, 25);
            btnSound.SetBounds(190, 130, 180, 35); btnSound.Text = "Запустить сигналы"; btnSound.Click += btnSound_Click;
            tabSound.Controls.AddRange(new System.Windows.Forms.Control[] { soundLabel1, soundLabel2, numCount, numInterval, btnSound });
            lblStyle.SetBounds(25, 30, 120, 25); lblStyle.Text = "Пример элемента:";
            cmbStyle.SetBounds(160, 28, 250, 28); cmbStyle.Items.AddRange(new object[] { "Обычный", "Выделенный" }); cmbStyle.SelectedIndex = 0;
            chkBold.SetBounds(160, 75, 150, 25); chkBold.Text = "Полужирный текст";
            chkLarge.SetBounds(160, 110, 150, 25); chkLarge.Text = "Увеличить размер";
            btnStyle.SetBounds(160, 155, 200, 35); btnStyle.Text = "Применить стиль"; btnStyle.Click += btnStyle_Click;
            tabStyles.Controls.AddRange(new System.Windows.Forms.Control[] { lblStyle, cmbStyle, chkBold, chkLarge, btnStyle });
            this.Controls.Add(tabs); this.ResumeLayout(false);
        }
    }
}
