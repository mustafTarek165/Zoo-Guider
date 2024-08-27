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
using Zoo_App_again.Screens.Animals;

namespace Zoo_App_again.Screens.Exports
{
    public partial class Exports : Form
    {
        private int id1 = -1, quaty = 0;
        private double priceforone = 0;

        AppDbContext dbContext = new AppDbContext();
        GeneralUsings settings = new GeneralUsings();
        public Exports()
        {
            InitializeComponent();
            settings.UpdateDataBasesync(dataGridView1, dbContext, dbContext.OurExports);
            LoadBox2();
        }
        void LoadBox2()
        {
            var animaltypes = dbContext.Animals.Select(x => x.Type).ToList();
            comboBox2.DataSource = animaltypes;
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

                
                    comboBox2.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["type"].FormattedValue.ToString();

                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["quantity"].FormattedValue.ToString();
                    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["totalPrice"].FormattedValue.ToString();
                    textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["organizationExportedTo"].FormattedValue.ToString();
                    textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["country"].FormattedValue.ToString();
                    textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["description"].FormattedValue.ToString();
                    string? s = dataGridView1.Rows[e.RowIndex].Cells["historyOfProcess"].FormattedValue.ToString();
                    if (s != null)
                    {
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
        private async void button12_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text)
              && !string.IsNullOrEmpty(textBox5.Text))
            {
                Entities.Exports export1 = new Entities.Exports()
                {

                    Type = comboBox2.SelectedItem.ToString(),

                };
                int x;
                bool valid1 = true;
                if (int.TryParse(textBox1.Text, out x))
                {
                    if (x > 0 && x <= quaty)
                    {
                        export1.Quantity = x;
                    }
                    else { MessageBox.Show($"Error,available quantity is {quaty},so you must enter values from 1 to {quaty}"); valid1 = false; }

                }
                else { MessageBox.Show("Error,you must enter numbers only in Quantity field"); valid1 = false; }

                if (valid1)
                {
                    export1.TotalPrice = priceforone * export1.Quantity;
                    export1.OrganizationExportedTo = textBox3.Text;
                    export1.Country = textBox4.Text;
                    export1.Description = textBox5.Text;
                    export1.HistoryOfProcess = dateTimePicker1.Value;

                    Animal? animal =await dbContext.Animals.FirstOrDefaultAsync(x => x.Type == export1.Type);
                    if (animal != null)
                    {
                        
                        animal.Quantity -= export1.Quantity;
                  
                        if (animal.Quantity == 0) dbContext.Animals.Remove(animal);
                    }
                    dbContext.OurExports.Add(export1);
                   await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.OurExports);
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Selected = true;
                }
            }
            else MessageBox.Show("Error,there is empty fields");
        }
        //update
        private async void button10_Click(object sender, EventArgs e)
        {
            if (id1 != -1)
            {
                var result =await dbContext.OurExports.SingleOrDefaultAsync(x => x.Id == id1);
                if (result != null)
                {
                    string? oldvalue = result.Type;
                    int x;
                    bool valid1 = true;
                    if (int.TryParse(textBox1.Text, out x))
                    {
                        if (x > 0 && x <= quaty)
                        {
                            result.Quantity = x;
                        }
                        else { MessageBox.Show($"Error,available quantity is {quaty},so you must enter values from 1 to {quaty}"); valid1 = false; }

                    }
                    else { MessageBox.Show("Error,you must enter numbers only in Quantity field"); valid1 = false; }

                    if (valid1)
                    {
                        result.TotalPrice = priceforone * result.Quantity;

                        result.Type = comboBox2.SelectedItem.ToString();
                        result.HistoryOfProcess = dateTimePicker1.Value;

                        result.OrganizationExportedTo = textBox3.Text;
                        result.Country = textBox4.Text;
                        result.Description = textBox5.Text;

                        await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.OurExports);
                        MessageBox.Show("update has been done successfully");
                    }
                }


            }
        }
        //search
        private async void button9_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox6.Text))
            {

                dataGridView1.DataSource =await dbContext.OurExports.Where(x => x.Type != null && x.Type.Contains(textBox6.Text)).ToListAsync();

            }
            else dataGridView1.DataSource =await dbContext.OurExports.ToListAsync();
        }
        //delete
        private async void button11_Click(object sender, EventArgs e)
        {
            //delete searched element
            var id = dbContext.OurExports.Where(x => x.Type == textBox6.Text);
            if (id.IsNullOrEmpty())
            {
                if (!string.IsNullOrEmpty(textBox6.Text))
                    MessageBox.Show($"{textBox6.Text} doesn't exist");
            }
            else
            {

                dbContext.OurExports.RemoveRange(id);
                await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.OurExports);
                MessageBox.Show("Exports was deleted successfully");
            }
            //delete selected element
            var result = await dbContext.OurExports.SingleOrDefaultAsync(x => x.Id == id1);
            if (result != null)
            {

                dbContext.OurExports.Remove(result);
                await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.OurExports);
                MessageBox.Show($"{result.Type} was deleted successfully");
            }
        }

        private void button8_Click(object sender, EventArgs e)
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

        private void button7_Click(object sender, EventArgs e)
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool exist = false;
            string? selectedmember = comboBox2.SelectedItem.ToString();
            exist = dbContext.Animals.Any(x => x.Type == selectedmember);
            if (exist)
            {
                Animal? selected = dbContext.Animals.FirstOrDefault(x => x.Type == selectedmember);
                if (selected != null)
                {
                   
                    quaty = selected.Quantity;
                    priceforone = selected.PricePerOne;
               
                }
            }
        }
    }
}
