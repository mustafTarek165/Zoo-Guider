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

namespace Zoo_App_again.Screens.Cafes
{
    public partial class Cafes : Form
    {
        private int id1 = -1;

        AppDbContext dbContext = new AppDbContext();
        GeneralUsings settings =new GeneralUsings();
        public Cafes()
        {
            InitializeComponent();
           settings.UpdateDataBasesync(dataGridView1, dbContext, dbContext.Cafes);
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
                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
                    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["monthlyRent"].FormattedValue.ToString();
                    textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["rentDuration"].FormattedValue.ToString();
                }

            }
        }
      

        private async void button3_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                Cafe cafe1 = new Cafe()
                {
                    Name = textBox1.Text
                };
                int x; double y;
                bool valid1 = true, valid2 = true;
                if (int.TryParse(textBox3.Text, out x))
                {
                    cafe1.Rent_Duration = x;

                }
                else { MessageBox.Show("Error,you must enter numbers only in Rent Duration field"); valid1 = false; }
                if (double.TryParse(textBox2.Text, out y))
                {
                    cafe1.Monthly_Rent = y;

                }
                else { MessageBox.Show("Error,you must enter numbers only in Monthly Rent field"); valid2 = false; }

                if (valid1 && valid2)
                {
                    Cafe? cafe = await dbContext.Cafes.FirstOrDefaultAsync(x => x.Name == cafe1.Name);
                    if (cafe == null)
                    {
                        dbContext.Add(cafe1);
                        await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.Cafes);
                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Selected = true;
                    }
                    else MessageBox.Show("This Cafe already exist");
                }
            }
            else MessageBox.Show("Error,there is empty fields");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (id1 != -1)
            {
                var result = await dbContext.Cafes.SingleOrDefaultAsync(x => x.Id == id1);
                if (result != null)
                {
                    result.Name = textBox1.Text;
                    int x; double y;
                    bool valid1 = true, valid2 = true;
                    if (int.TryParse(textBox3.Text, out x))
                    {
                        result.Rent_Duration = x;

                    }
                    else { MessageBox.Show("Error,you must enter numbers only in Rent Duration field"); valid1 = false; }
                    if (double.TryParse(textBox2.Text, out y))
                    {
                        result.Monthly_Rent = y;

                    }
                    else { MessageBox.Show("Error,you must enter numbers only in Monthly Rent field"); valid2 = false; }

                    if (valid1 && valid2)
                    {
                        await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.Cafes);
                        MessageBox.Show("Update has been done successfully");
                    }
                }
            }
        }
        //search
        private async void button5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox4.Text))
            {

                dataGridView1.DataSource =await dbContext.Cafes.Where(x => x.Name != null && x.Name.Contains(textBox4.Text)).ToListAsync();

            }
            else dataGridView1.DataSource =await dbContext.Cafes.ToListAsync();
        }
        //delete
        private async void button4_Click(object sender, EventArgs e)
        {
            //delete searched element
            var id = dbContext.Cafes.Where(x => x.Name == textBox4.Text);
            if (id.IsNullOrEmpty())
            {
                if (!string.IsNullOrEmpty(textBox4.Text))
                    MessageBox.Show($"{textBox4.Text} doesn't exist");
            }
            else
            {
                dbContext.Cafes.RemoveRange(id);
                await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.Cafes);
                MessageBox.Show("Cafes was deleted successfully");
            }
            //delete selected element
            var result = dbContext.Cafes.SingleOrDefault(x => x.Id == id1);
            if (result != null)
            {
                dbContext.Cafes.Remove(result);
                await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.Cafes);
                MessageBox.Show($"{result.Name} was deleted successfully");
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

        private void dataGridView1_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["Number"].Value = (e.RowIndex + 1).ToString();
        }
    }
}
