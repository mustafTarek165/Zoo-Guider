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
using Zoo_App_again;
namespace Zoo_App_again.Screens.Museums
{
    public partial class Museums : Form
    {
        private int id1 = -1;
        AppDbContext dbContext = new AppDbContext();
        GeneralUsings settings = new GeneralUsings();
        public Museums()
        {
            InitializeComponent();
            settings.UpdateDataBasesync(dataGridView1,dbContext,dbContext.Museums);
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
                    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["founder"].FormattedValue.ToString();
                    textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["historicalInformation"].FormattedValue.ToString();
                    string? s = dataGridView1.Rows[e.RowIndex].Cells["historyOfConstruction"].FormattedValue.ToString();
                    if (s != null)
                    {
                        DateTime y;
                        if (DateTime.TryParse(s, out y))
                            dateTimePicker1.Value = DateTime.Parse(s);
                    }

                }

            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["Number"].Value = (e.RowIndex + 1).ToString();

        }

        //add
        private async void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                Museum museum1 = new Museum()
                {
                    Name = textBox1.Text,
                    Founder = textBox2.Text,
                    HistoricalInformation = textBox3.Text,
                    HistoryOfConstruction = dateTimePicker1.Value
                };
                Museum? museum =await dbContext.Museums.FirstOrDefaultAsync(x => x.Name == museum1.Name);
                if (museum == null)
                {
                    dbContext.Add(museum1);
                    await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.Museums);
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Selected = true;
                }
                else MessageBox.Show("This Museum already exists");
            }
            else MessageBox.Show("Error,there is empty fields");
        }
        //update
        private async void button5_Click(object sender, EventArgs e)
        {

            if (id1 != -1)
            {
                var result = dbContext.Museums.SingleOrDefault(x => x.Id == id1);
                if (result != null)
                {
                    result.Name = textBox1.Text;
                    result.Founder = textBox2.Text;
                    result.HistoricalInformation = textBox3.Text;
                    result.HistoryOfConstruction = dateTimePicker1.Value;
                    await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.Museums);
                    MessageBox.Show("Update has been done successfully");
                }

            }
        }
        //search
        private async void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox4.Text))
            {

                dataGridView1.DataSource = await dbContext.Museums.Where(x => x.Name != null && x.Name.Contains(textBox4.Text)).ToListAsync();

            }
            else dataGridView1.DataSource = await dbContext.Museums.ToListAsync();
        }
        //delete
        private async void button6_Click(object sender, EventArgs e)
        { //delete searched element
            var id = dbContext.Museums.Where(x => x.Name == textBox4.Text);
            if (id.IsNullOrEmpty())
            {
                if (!string.IsNullOrEmpty(textBox4.Text))
                    MessageBox.Show($"{textBox4.Text} doesn't exist");
            }
            else
            {
                dbContext.Museums.RemoveRange(id);
                await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.Museums);
                MessageBox.Show("Museums was deleted successfully");
            }



            //delete selected element
            var result = await dbContext.Museums.SingleOrDefaultAsync(x => x.Id == id1);
            if (result != null)
            {
                 dbContext.Museums.Remove(result);
                await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.Museums);
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

        
    }

}
