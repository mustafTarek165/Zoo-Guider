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

namespace Zoo_App_again.Screens.Workers
{
    public partial class Workers : Form
    {
        private int id1 = -1;
        AppDbContext dbContext = new AppDbContext();
        GeneralUsings settings=new GeneralUsings();
        public Workers()
        {
            InitializeComponent();
            settings.UpdateDataBasesync(dataGridView1, dbContext, dbContext.Workers);
        }
      
        //add
        private async void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                Worker worker1 = new Worker()
                {
                    Name = textBox1.Text,
                    Job = textBox2.Text
                };
                double y;
                bool valid1 = true;
                if (double.TryParse(textBox3.Text, out y))
                {
                    worker1.Salary = y;

                }
                else { MessageBox.Show("Error,you must enter numbers only in Salary field"); valid1 = false; }

                if (valid1)
                {
                    Worker? worker = await dbContext.Workers.FirstOrDefaultAsync(x => x.Name == worker1.Name);
                    if (worker == null)
                    {
                        dbContext.Add(worker1);
                        await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.Workers);
                    }
                    else MessageBox.Show("This Worker Name already exists");

                }
            }
            else MessageBox.Show("Error,there is empty fields");
        }
        //edit
        private async void button2_Click(object sender, EventArgs e)
        {
            if (id1 != -1)
            {
                var result = await dbContext.Workers.SingleOrDefaultAsync(x => x.Id == id1);
                if (result != null)
                {
                    result.Name = textBox1.Text;
                    result.Job = textBox2.Text;
                    double y;
                    bool valid1 = true;

                    if (double.TryParse(textBox3.Text, out y))
                    {
                        result.Salary = y;

                    }
                    else { MessageBox.Show("Error,you must enter numbers only in Salary field"); valid1 = false; }

                    if (valid1)
                    {
                        await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.Workers);
                        MessageBox.Show("Update has been done successfully");
                    }
                }

            }
        }
        //delete
        private async void button1_Click(object sender, EventArgs e)
        {
            //delete searched element
            var id = await dbContext.Workers.Where(x => x.Name == textBox4.Text).ToListAsync();
            if (id.IsNullOrEmpty())
            {
                if (!string.IsNullOrEmpty(textBox4.Text))
                    MessageBox.Show($"{textBox4.Text} doesn't exist in workers");
            }
            else
            {
                dbContext.Workers.RemoveRange(id);
                await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.Workers);
                MessageBox.Show("Workers were deleted successfully");
            }



            //delete selected element
            var result = await dbContext.Workers.SingleOrDefaultAsync(x => x.Id == id1);
            if (result != null)
            {
                dbContext.Workers.Remove(result);
                await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.Workers);
                MessageBox.Show($"{result.Name} was deleted from workers successfully");
            }
        }
        //search
        private async void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox4.Text))
            {

                dataGridView1.DataSource = await dbContext.Workers.Where(x => x.Name != null && x.Name.Contains(textBox4.Text)).ToListAsync();

            }
            else dataGridView1.DataSource = await dbContext.Workers.ToListAsync();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["Number"].Value = (e.RowIndex + 1).ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            string? x = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[0].Value.ToString() != null)
            {
                if (x != null)
                {
                    id1 = int.Parse(x);
                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
                    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["job"].FormattedValue.ToString();
                    textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["salary"].FormattedValue.ToString();
                }

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

        private void button5_Click(object sender, EventArgs e)
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

    }
}
