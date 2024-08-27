using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zoo_App_again.Screens.Animals;
using Zoo_App_again.Screens.Cafes;
using Zoo_App_again.Screens.Exports;
using Zoo_App_again.Screens.Imports;
using Zoo_App_again.Screens.Museums;
using Zoo_App_again.Screens.Sales;
using Zoo_App_again.Screens.Ticket_Reservations;
using Zoo_App_again.Screens.Workers;

namespace Zoo_App_again
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonEllipse1_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(open1);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void open1()
        {
            Application.Run(new AnimalClassifications());
        }

        private void buttonEllipse3_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(open2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void open2()
        {
            Application.Run(new Sales());
        }

        private void buttonEllipse7_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(open3);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void open3()
        {
            Application.Run(new Workers());
        }

        private void buttonEllipse2_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(open4);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void open4()
        {
            Application.Run(new ReservationsOrGuidelines());
        }

        private void buttonEllipse5_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(open5);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void open5()
        {
            Application.Run(new Imports());
        }

        private void buttonEllipse8_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(open6);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void open6()
        {
            Application.Run(new Cafes());
        }

        private void buttonEllipse4_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(open7);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void open7()
        {
            Application.Run(new Exports());
        }

        private void buttonEllipse6_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(open8);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void open8()
        {
            Application.Run(new Museums());
        }

    }
}
