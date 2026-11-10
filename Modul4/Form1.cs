using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource pairCancel;
        private CancellationTokenSource stopCancel;
        private readonly object stopLock = new object();
        private Program.StopState stopState;
        private readonly Random random = new Random();
        private bool dayRunning;

        public Form1() { InitializeComponent(); }

        private async void btnProcessPairs_Click(object sender, EventArgs e)
        {
            int amount;
            if (!int.TryParse(txtPairCount.Text, out amount) || amount < 1 || amount > 100000)
            { MessageBox.Show("Введите количество пар от 1 до 100000."); return; }
            btnProcessPairs.Enabled = false;
            pairCancel = new CancellationTokenSource();
            string folder = Application.StartupPath;
            string source = Path.Combine(folder, "pairs.txt");
            string sums = Path.Combine(folder, "sums.txt");
            string products = Path.Combine(folder, "products.txt");
            using (ManualResetEvent generated = new ManualResetEvent(false))
            {
                try
                {
                    lblPairStatus.Text = "Три потока работают. Генератор записывает пары...";
                    Task generator = Task.Run(() => Program.GeneratePairs(amount, source, generated, pairCancel.Token));
                    Task sumWorker = Task.Run(() => Program.CalculatePairs(source, sums, generated, pairCancel.Token, p => (long)p.First + p.Second));
                    Task productWorker = Task.Run(() => Program.CalculatePairs(source, products, generated, pairCancel.Token, p => (long)p.First * p.Second));
                    await Task.WhenAll(generator, sumWorker, productWorker);
                    lblPairStatus.Text = "Готово. Результаты сохранены в папке приложения: pairs.txt, sums.txt, products.txt";
                }
                catch (Exception ex) { lblPairStatus.Text = "Ошибка: " + ex.Message; }
                finally { btnProcessPairs.Enabled = true; }
            }
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            int route, capacity;
            if (!int.TryParse(txtStopRoute.Text, out route) || route < 1 || !int.TryParse(txtStopCapacity.Text, out capacity) || capacity < 1)
            { MessageBox.Show("Введите корректный номер маршрута и вместимость."); return; }
            lock (stopLock)
            {
                stopState = new Program.StopState { BusNumber = route, BusCapacity = capacity, PassengersOnBus = chkNonTerminal.Checked ? random.Next(0, capacity + 1) : 0 };
                dayRunning = true;
            }
            lstRoutes.Items.Clear(); txtLog.Clear(); lblStopStatus.Text = "Рабочий день начался. В автобусе при прибытии: " + stopState.PassengersOnBus;
            stopCancel = new CancellationTokenSource();
            Task.Run(() => PassengerArrivalLoop(stopCancel.Token));
            Task.Run(() => BusArrivalLoop(stopCancel.Token));
        }

        private async Task PassengerArrivalLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                await Task.Delay(random.Next(1800, 4000), token).ContinueWith(t => { });
                if (token.IsCancellationRequested) break;
                int count = random.Next(1, 9);
                int route;
                lock (stopLock) route = stopState.BusNumber + random.Next(-1, 2);
                AddPassengers(count, route);
            }
        }

        private async Task BusArrivalLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                await Task.Delay(random.Next(4000, 7000), token).ContinueWith(t => { });
                if (token.IsCancellationRequested) break;
                int route;
                lock (stopLock) route = stopState.BusNumber + random.Next(-1, 2);
                ArriveBus(route, random.Next(0, 8));
            }
        }

        private void AddPassengers(int count, int route)
        {
            lock (stopLock)
            {
                if (!dayRunning) return;
                for (int i = 0; i < count; i++) stopState.Waiting.Add(new Program.Passenger(route));
                BeginInvoke((Action)(() => { RefreshRoutes(); Log("Пришли пассажиры: " + count + " чел., маршруты указаны в списке."); }));
            }
        }

        private void btnAddPassengers_Click(object sender, EventArgs e)
        {
            int count;
            if (!int.TryParse(txtPassengerCount.Text, out count) || count < 1) { MessageBox.Show("Введите положительное количество людей."); return; }
            if (!dayRunning) { MessageBox.Show("Сначала нажмите «Начать день»."); return; }
            int route = stopState.BusNumber;
            if (lstRoutes.SelectedItem != null && lstRoutes.SelectedItem.ToString().StartsWith("Маршрут "))
                int.TryParse(lstRoutes.SelectedItem.ToString().Substring(9), out route);
            // Для задания 3 пользовательский маршрут задаётся через поле номера маршрута.
            int enteredRoute;
            if (int.TryParse(txtStopRoute.Text, out enteredRoute)) route = enteredRoute;
            AddPassengers(count, route);
        }

        private void ArriveBus(int route, int getOff)
        {
            lock (stopLock)
            {
                if (!dayRunning) return;
                stopState.Arrivals++;
                stopState.PassengersOnBus = Math.Max(0, stopState.PassengersOnBus - getOff);
                int seats = stopState.BusCapacity - stopState.PassengersOnBus;
                int boarded = 0;
                for (int i = stopState.Waiting.Count - 1; i >= 0 && seats > 0; i--)
                    if (stopState.Waiting[i].Route == route)
                    {
                        stopState.Waiting.RemoveAt(i); seats--; boarded++;
                    }
                stopState.PassengersOnBus += boarded;
                stopState.TotalBoarded += boarded;
                int onboard = stopState.PassengersOnBus, waiting = stopState.Waiting.Count;
                BeginInvoke((Action)(() => { RefreshRoutes(); Log("Автобус №" + route + " приехал, высадилось " + getOff + ", вошло " + boarded + ". В салоне: " + onboard + ", ждут: " + waiting + "."); }));
            }
        }

        private void btnBusArrive_Click(object sender, EventArgs e)
        {
            if (!dayRunning) { MessageBox.Show("Сначала нажмите «Начать день»."); return; }
            int route; lock (stopLock) route = stopState.BusNumber;
            ArriveBus(route, chkNonTerminal.Checked ? random.Next(0, 6) : 0);
        }

        private void RefreshRoutes()
        {
            lstRoutes.Items.Clear();
            if (stopState == null) return;
            Dictionary<int, int> counts = new Dictionary<int, int>();
            foreach (Program.Passenger passenger in stopState.Waiting)
            {
                if (!counts.ContainsKey(passenger.Route)) counts[passenger.Route] = 0;
                counts[passenger.Route]++;
            }
            foreach (KeyValuePair<int, int> item in counts) lstRoutes.Items.Add("Маршрут " + item.Key + ": " + item.Value + " чел.");
            lblStopStatus.Text = "Ждут: " + stopState.Waiting.Count + "; в автобусе: " + stopState.PassengersOnBus + "; всего перевезено: " + stopState.TotalBoarded;
        }

        private void Log(string message) { txtLog.AppendText(DateTime.Now.ToString("HH:mm:ss") + "  " + message + Environment.NewLine); }

        private void btnStopSimulation_Click(object sender, EventArgs e)
        {
            dayRunning = false;
            if (stopCancel != null) stopCancel.Cancel();
            lblStopStatus.Text += " Рабочий день завершён.";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (pairCancel != null) pairCancel.Cancel();
            if (stopCancel != null) stopCancel.Cancel();
            base.OnFormClosing(e);
        }
    }
}
