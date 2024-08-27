using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using Zoo_App_again.CustomDesign;
using Zoo_App_again.Data;
using Zoo_App_again.Entities;
using Zoo_App_again.Screens.Ticket_Reservations;

namespace Zoo_App_again.Screens.Sales
{
    public partial class Sales : Form
    {
        private double net = 0;
        private List<Cafe> _cafes = new List<Cafe>();
        private List<Ticket_Reservation> _ticket_reservations = new List<Ticket_Reservation>();
        private List<Worker> _workers = new List<Worker>();

        private List<Entities.Imports> _imports = new List<Entities.Imports>();
        private List<Entities.Exports> _exports = new List<Entities.Exports>();

        AppDbContext dbContext = new AppDbContext();
        public Sales()
        {
            InitializeComponent();

            ClearBoxes();
            GetEntities();
        }
        void GetEntities()
        {
            _cafes = dbContext.Cafes.ToList();
            _workers = dbContext.Workers.ToList();

            _ticket_reservations = dbContext.Ticket_Reservations.ToList();
            _imports = dbContext.OurImports.ToList();
            _exports = dbContext.OurExports.ToList();
        }
        void ClearBoxes()
        {
            listBox1.Items.Clear();
        }
        void UploadPieChart(List<Tuple<string, Pair<double, double>>> pairs)
        {
            LiveCharts.WinForms.PieChart pieChart1 = new LiveCharts.WinForms.PieChart();
            pieChart1.Width = panel3.Width;
            pieChart1.Height = panel3.Height;
            pieChart1.BackColorTransparent = true;

            LiveCharts.WinForms.PieChart pieChart2 = new LiveCharts.WinForms.PieChart();

            pieChart2.Width = panel6.Width;
            pieChart2.Height = panel6.Height;
            pieChart2.BackColorTransparent = true;

            SeriesCollection series1 = new SeriesCollection();//income
            SeriesCollection series2 = new SeriesCollection();//outcome

            Func<ChartPoint, string> label = chartpoint => string.Format("{0} ({1:p})", chartpoint.Y, chartpoint.Participation);

            foreach (var item in pairs)
            {

                PieSeries ser1 = new PieSeries()
                {
                    Values = new ChartValues<double>() { item.Item2.First },
                    Title = "ID" + item.Item1,
                    DataLabels = true,
                    LabelPoint = label
                };
                PieSeries ser2 = new PieSeries()
                {
                    Values = new ChartValues<double>() { item.Item2.Second },
                    Title = "ID " + item.Item1,
                    DataLabels = true,
                    LabelPoint = label
                };
                series1.Add(ser1);
                series2.Add(ser2);
            }
            pieChart1.Series = series1;
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(pieChart1);

            pieChart2.Series = series2;
            this.panel6.Controls.Clear();
            this.panel6.Controls.Add(pieChart2);
        }
        void ShowLabels()
        {
            label2.Text = "Income";
            label5.Text = "Outcome";
            if (net > 0)
                label6.Text = $"Profit = {Math.Round(net, 1)} $";
            else if (net < 0)
                label6.Text = $"Loss = {-Math.Round(net, 1)} $";
            else
                label6.Text = $"There is no Profit or loss";
            panel8.BackColor = System.Drawing.Color.Wheat;
            panel8.Controls.Add(label6);
        }
        void GetByState(int state)
        {
            if (listBox1.Items.Count > 0)
            {
                double importspay = 0, exportspay = 0, workerspay = 0, cafespay = 0, ticketspay = 0;
                double income = 0, outcome = 0;
                net = 0;
                List<Tuple<string, Pair<double, double>>> pairs = new List<Tuple<string, Pair<double, double>>>();//label,{income,outcome}

                CalculateAll(importspay, exportspay, workerspay, cafespay, ticketspay, income, outcome, pairs, state);

                UploadPieChart(pairs);
                ShowLabels();

            }
            else MessageBox.Show("Select a date");
        }
        void CalculateAll(double importspay, double exportspay, double workerspay, double cafespay, double ticketspay,
          double income, double outcome, List<Tuple<string, Pair<double, double>>> pairs, int state)
        {

            foreach (var item in listBox1.Items)
            {
                importspay = 0; exportspay = 0; workerspay = 0; cafespay = 0; ticketspay = 0;
                income = 0; outcome = 0;
                //cafes
                if (state == 1)
                {
                    cafespay += 12 * _cafes.Sum(x => x.Monthly_Rent);
                }
                else if (state == 2)
                {
                    cafespay += _cafes.Sum(x => x.Monthly_Rent);
                }

                //workers

                if (state == 1)
                {
                    workerspay += 12 * _workers.Sum(x => x.Salary);
                }
                else if (state == 2)
                {
                    workerspay += _workers.Sum(x => x.Salary);

                }



                //ticket
                if (item != null)
                {
                    var y = item.ToString();
                    if (y != null)
                    {

                        if (state == 1)
                        {
                            var t = _ticket_reservations.Where(x => x.DateOfReservation.Year == DateTime.Parse(y).Year);
                            ticketspay += t.Sum(x => x.Price);
                        }
                        else if (state == 2)
                        {
                            var t = _ticket_reservations.Where(x => x.DateOfReservation.Year == DateTime.Parse(y).Year
                            && x.DateOfReservation.Month == DateTime.Parse(y).Month);

                            ticketspay += t.Sum(x => x.Price);
                        }
                        else
                        {
                            var t = _ticket_reservations.Where
                                (x => x.DateOfReservation.Year == DateTime.Parse(y).Year
                                 && x.DateOfReservation.Month == DateTime.Parse(y).Month
                                 && x.DateOfReservation.Day == DateTime.Parse(y).Day);

                            ticketspay += t.Sum(x => x.Price);
                        }

                    }
                }
                //imports
                if (item != null)
                {
                    var y = item.ToString();
                    if (y != null)
                    {
                        if (state == 1)
                        {
                            var t = _imports.Where(x => x.HistoryOfProcess.Year == DateTime.Parse(y).Year);
                            importspay += t.Sum(x => x.TotalPrice);
                        }
                        else if (state == 2)
                        {
                            var t = _imports.Where(x => x.HistoryOfProcess.Year == DateTime.Parse(y).Year
                            && x.HistoryOfProcess.Month == DateTime.Parse(y).Month);

                            importspay += t.Sum(x => x.TotalPrice);
                        }
                        else
                        {
                            var t = _imports.Where
                                (x => x.HistoryOfProcess.Year == DateTime.Parse(y).Year
                                 && x.HistoryOfProcess.Month == DateTime.Parse(y).Month
                                 && x.HistoryOfProcess.Day == DateTime.Parse(y).Day);

                            importspay += t.Sum(x => x.TotalPrice);
                        }
                    }
                }
                //exports
                if (item != null)
                {
                    var y = item.ToString();
                    if (y != null)
                    {
                        if (state == 1)
                        {
                            var t = _exports.Where(x => x.HistoryOfProcess.Year == DateTime.Parse(y).Year);
                            exportspay += t.Sum(x => x.TotalPrice);
                        }
                        else if (state == 2)
                        {
                            var t = _exports.Where(x => x.HistoryOfProcess.Year == DateTime.Parse(y).Year
                            && x.HistoryOfProcess.Month == DateTime.Parse(y).Month);

                            exportspay += t.Sum(x => x.TotalPrice);
                        }
                        else
                        {
                            var t = _exports.Where
                                (x => x.HistoryOfProcess.Year == DateTime.Parse(y).Year
                                 && x.HistoryOfProcess.Month == DateTime.Parse(y).Month
                                 && x.HistoryOfProcess.Day == DateTime.Parse(y).Day);

                            exportspay += t.Sum(x => x.TotalPrice);
                        }
                    }

                }
                //income and outcome of each year
                income += exportspay + ticketspay + cafespay;
                outcome += importspay + workerspay;
                net += income - outcome;
                string? x = item?.ToString();
                if (x != null)
                    pairs.Add(new Tuple<string, Pair<double, double>>(x, new Pair<double, double>(income, outcome)));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(open1);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void open1()
        {
            Application.Run(new MainForm());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(open2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void open2()
        {
            Application.Run(new Form1());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!listBox1.Items.Contains(dateTimePicker1.Value.Date))
                listBox1.Items.Add(dateTimePicker1.Value.Date);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GetByState(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetByState(2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GetByState(3);
        }
    }
}
