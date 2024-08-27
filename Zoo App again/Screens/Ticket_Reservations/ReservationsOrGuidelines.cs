using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zoo_App_again.Screens.Ticket_Reservations.Reservations_Guidelines;

namespace Zoo_App_again.Screens.Ticket_Reservations
{
    public partial class ReservationsOrGuidelines : Form
    {
        public ReservationsOrGuidelines()
        {
            InitializeComponent();
        }

        private void buttonEllipse3_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(open1);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void open1()
        {
            Application.Run(new Ticket_ReservationsForm());
        }

        private void buttonEllipse7_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(open2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void open2()
        {
            Application.Run(new Guidelines());
        }
    }
}
