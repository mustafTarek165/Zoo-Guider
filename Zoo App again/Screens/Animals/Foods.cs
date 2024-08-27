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

namespace Zoo_App_again.Screens.Animals
{
    public partial class Foods : Form
    {
        private int id1 = -1;
        AppDbContext dbContext = new AppDbContext();
        GeneralUsings settings = new GeneralUsings();  
        public Foods()
        {
            InitializeComponent();
            settings.UpdateDataBasesync(dataGridView1, dbContext, dbContext.Foods);
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
                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["type"].FormattedValue.ToString();
                    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["quantity"].FormattedValue.ToString();
                    textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["pricePerKilo"].FormattedValue.ToString();
                    textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["description"].FormattedValue.ToString();
                }

            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["Number"].Value = (e.RowIndex + 1).ToString();
        }
        //update
        private async void button2_Click(object sender, EventArgs e)
        {
            if (id1 != -1)
            {
                var result = await dbContext.Foods.FirstOrDefaultAsync(x => x.Id == id1);
                if (result != null)
                {
                    result.Type = textBox1.Text;
                    result.Description = textBox4.Text;
                    int x; double y;
                    bool valid1 = true, valid2 = true;
                    if (int.TryParse(textBox2.Text, out x))
                    {
                        result.Quantity = x;

                    }
                    else { MessageBox.Show("Error,you must enter integer numbers only in Quantity field"); valid1 = false; }
                    if (double.TryParse(textBox3.Text, out y))
                    {
                        result.PricePerKilo = y;

                    }
                    else { MessageBox.Show("Error,you must enter numbers only in Price per kilo field"); valid2 = false; }

                    if (valid1 && valid2)
                    {
                       await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.Foods);
                        MessageBox.Show("update has been done successfully");
                    }
                }


            }
        }
        //update
        private async void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox5.Text))
            {

                dataGridView1.DataSource = dbContext.Foods.Where(x => x.Type != null && x.Type.Contains(textBox5.Text)).ToListAsync();

            }
            else dataGridView1.DataSource = await dbContext.Foods.ToListAsync();
        }
        //delete
        private async void button4_Click(object sender, EventArgs e)
        {
            //delete searched element
            var id = dbContext.Foods.Where(x => x.Type == textBox5.Text);
            if (id.IsNullOrEmpty())
            {
                if (!string.IsNullOrEmpty(textBox5.Text))
                    MessageBox.Show($"{textBox5.Text} doesn't exist");
            }
            else
            {
                dbContext.Foods.RemoveRange(id);
                await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.Foods);
                MessageBox.Show($"{textBox5.Text} type was deleted from foods successfully");
            }
            //delete selected element
            var result = dbContext.Foods.SingleOrDefault(x => x.Id == id1);
            if (result != null)
            {
                dbContext.Foods.Remove(result);
                await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.Foods);
                MessageBox.Show($"{result.Type} was deleted successfully");
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

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(open2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void open2()
        {
            Application.Run(new AnimalClassifications());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(open3);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void open3()
        {
            Application.Run(new Form1());
        }
    }
}
