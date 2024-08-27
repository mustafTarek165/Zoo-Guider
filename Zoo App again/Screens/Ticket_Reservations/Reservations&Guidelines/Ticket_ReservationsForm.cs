using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
using Zoo_App_again.Data;
using Zoo_App_again.Entities;

namespace Zoo_App_again.Screens.Ticket_Reservations.Reservations_Guidelines
{
    public partial class Ticket_ReservationsForm : Form
    {
        private int id1 = -1;
        AppDbContext dbContext = new AppDbContext();
        GeneralUsings settings=new GeneralUsings();    
        public Ticket_ReservationsForm()
        {
            InitializeComponent();
             settings.UpdateDataBasesync(dataGridView1, dbContext, dbContext.Ticket_Reservations);
            List<string> list = new List<string>()
            {
                "Improved","Excellent","VIP"
            };
            comboBox1.DataSource = list;
        }
     
        //add
        private async void button3_Click(object sender, EventArgs e)
        {

            Ticket_Reservation ticket1 = new Ticket_Reservation()
            {
                TicketType = comboBox1.SelectedItem.ToString(),
                DateOfReservation = DateTime.Now,
                Price = double.Parse(textBox1.Text)
            };

            dbContext.Add(ticket1);
            await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.Ticket_Reservations);
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
            dataGridView1.Rows[dataGridView1.RowCount - 1].Selected = true;

        }
        //search
        private async void button1_Click(object sender, EventArgs e)
        {
            var time = dbContext.Ticket_Reservations.Where
          (x => x.DateOfReservation >= dateTimePicker1.Value.Date && x.DateOfReservation < dateTimePicker1.Value.Date.AddDays(1)).ToListAsync();
            dataGridView1.DataSource = time;
        }
        //delete
        private async void button4_Click(object sender, EventArgs e)
        {
            //delete searched element
            var id = dbContext.Ticket_Reservations.Where
            (x => x.DateOfReservation >= dateTimePicker1.Value.Date && x.DateOfReservation < dateTimePicker1.Value.Date.AddDays(1));

            if (id.IsNullOrEmpty()) MessageBox.Show($"There is no reservations with date {dateTimePicker1.Value.Date}");
            else
            {
                dbContext.Ticket_Reservations.RemoveRange(id);
                await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.Ticket_Reservations);
                MessageBox.Show(" Reservations were deleted successfully");
            }


            //delete selected element
            var result =await dbContext.Ticket_Reservations.SingleOrDefaultAsync(x => x.Id == id1);
            if (result != null)
            {
                dbContext.Ticket_Reservations.Remove(result);
                await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.Ticket_Reservations);
                MessageBox.Show($" Reservation with date {result.DateOfReservation} was deleted successfully");
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["Number"].Value = (e.RowIndex + 1).ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.CurrentRow.Selected = true;
                string? cell = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (cell != null)
                {
                    id1 = int.Parse(cell);
                    comboBox1.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["ticketType"].FormattedValue.ToString();
                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["price"].FormattedValue.ToString();
                }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? selectedmember = comboBox1.SelectedItem.ToString();
            if (selectedmember == "Improved")
            {
                textBox1.Text = 50.ToString();
            }
            else if (selectedmember == "Excellent")
            {
                textBox1.Text = 100.ToString();
            }
            else
            {
                textBox1.Text = 150.ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
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
            this.Close();
            Thread th = new Thread(open3);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void open3()
        {
            Application.Run(new ReservationsOrGuidelines());
        }
    }
}
