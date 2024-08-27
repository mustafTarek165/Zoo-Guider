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

namespace Zoo_App_again.Screens
{
    public partial class AnimalsForm : Form
    {
        private int id1 = -1;
        AppDbContext dbContext = new AppDbContext();
        GeneralUsings settings=new GeneralUsings(); 
        public AnimalsForm()
        {
            InitializeComponent();
            LoadBox1();
            LoadBox2();
            dataGridView2.DataSource = dbContext.Animals.ToList();
            settings.UpdateDataBasesync(dataGridView2, dbContext, dbContext.Animals);
        }
        void LoadBox2()
        {
            List<string> classifications = new List<string>()
            {
                "Birds","Mammals","Reptiles"
            };

            comboBox2.DataSource = classifications;
        }
        void LoadBox1()
        {
            List<AnimalPlace> locations = dbContext.AnimalPlaces.ToList();

            comboBox1.DataSource = locations.Select(x => x.Name).ToList();
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView2.CurrentRow.Selected = true;
                string? cell = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                if (cell != null)
                {
                    id1 = int.Parse(cell);
                    textBox1.Text = dataGridView2.Rows[e.RowIndex].Cells["type"].FormattedValue.ToString();
                    textBox2.Text = dataGridView2.Rows[e.RowIndex].Cells["quantity"].FormattedValue.ToString();
                    textBox3.Text = dataGridView2.Rows[e.RowIndex].Cells["pricePerOne"].FormattedValue.ToString();
                    textBox5.Text = dataGridView2.Rows[e.RowIndex].Cells["description"].FormattedValue.ToString();
                    comboBox1.SelectedItem = dataGridView2.Rows[e.RowIndex].Cells["AnimalLocation"].FormattedValue.ToString();
                }
                

            }
        }

        private async void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView2.Rows[e.RowIndex].Cells["Number"].Value = (e.RowIndex + 1).ToString();
            if (this.dataGridView2.Rows[e.RowIndex].Cells["animalPlaceId"].Value != null)
            {
                string? cell = this.dataGridView2.Rows[e.RowIndex].Cells["animalPlaceId"].Value.ToString();
                if (cell != null)
                {
                    int foreignid = int.Parse(cell);
                    var item = await dbContext.AnimalPlaces.FirstOrDefaultAsync(x => x.Id == foreignid);
                if (item != null) {
                        string? location = item?.Name;
                        this.dataGridView2.Rows[e.RowIndex].Cells["AnimalLocation"].Value = location;
                    }     
                }
            }
            else   this.dataGridView2.Rows[e.RowIndex].Cells["AnimalLocation"].Value = "Not Located";

        }

      
        //add
        private async void button10_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox5.Text))
            {
                Animal animal1 = new Animal()
                {
                    Classification = comboBox2.Text,
                    Type = textBox1.Text,
                    Description = textBox5.Text

                };
                string? a="";
                if(comboBox1.Items.Count!=0) {  a = comboBox1.SelectedItem.ToString(); }
          
                bool valid1 = true, valid2 = true;
          

                var item = dbContext.AnimalPlaces.FirstOrDefault(x => x.Name == a);
                if (item != null)
                {
                    animal1.animalPlaceId = item.Id;
                }
                int x; double y;
          
                if (int.TryParse(textBox2.Text, out x))
                {
                    animal1.Quantity = x;

                }
                else { MessageBox.Show("Error,you must enter integer numbers only in Quantity field"); valid1 = false; }
                if (double.TryParse(textBox3.Text, out y))
                {
                    animal1.PricePerOne = y;

                }
                else { MessageBox.Show("Error,you must enter numbers only in Price For One field"); valid2 = false; }

                if (valid1 && valid2)
                {
                    Animal? animal = await dbContext.Animals.FirstOrDefaultAsync(x => x.Type == animal1.Type);
                    if (animal == null)
                    {
                        dbContext.Add(animal1);
                        await settings.UpdateDataBaseAsync(dataGridView2, dbContext, dbContext.Animals);
                        dataGridView2.FirstDisplayedScrollingRowIndex = dataGridView2.RowCount - 1;
                        dataGridView2.Rows[dataGridView2.RowCount - 1].Selected = true;
                    }
                    else MessageBox.Show("This Type of Animal already exist");

                }
            }
            else MessageBox.Show("Error,there is empty fields");
        }
        //update
        private async void button8_Click(object sender, EventArgs e)
        {
            if (id1 != -1)
            {
                var result =await dbContext.Animals.SingleOrDefaultAsync(x => x.Id == id1);
                if (result != null)
                {
                    result.Type = textBox1.Text;
                    result.Description = textBox5.Text;
                    result.Classification = comboBox2.Text;

                    string? a = comboBox1.SelectedItem.ToString();
                    var item = await dbContext.AnimalPlaces.FirstOrDefaultAsync(x => x.Name != null && x.Name == a);
                    if (item != null)
                    {
                        result.animalPlaceId = item.Id;
                    }
                    int x; double y;
                    bool valid1 = true, valid2 = true;
                    if (int.TryParse(textBox2.Text, out x))
                    {
                        result.Quantity = x;

                    }
                    else { MessageBox.Show("Error,you must enter numbers only in Quantity field"); valid1 = false; }
                    if (double.TryParse(textBox3.Text, out y))
                    {
                        result.PricePerOne = y;

                    }
                    else { MessageBox.Show("Error,you must enter numbers only in Price For One field"); valid2 = false; }

                    if (valid1 && valid2)
                    {
                        await settings.UpdateDataBaseAsync(dataGridView2, dbContext, dbContext.Animals);
                        MessageBox.Show("update has been done successfully");
                    }

                }

            }
        }
        //search
        private async void button5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox4.Text))
            {

                dataGridView2.DataSource = await dbContext.Animals.Where(x => x.Type != null && x.Type.Contains(textBox4.Text)).ToListAsync();
            }
            else dataGridView2.DataSource = await dbContext.Animals.ToListAsync();
        }
        //delete
        private async void button9_Click(object sender, EventArgs e)
        {
            //delete searched element
            var id = dbContext.Animals.Where(x => x.Type == textBox4.Text);
            if (id.IsNullOrEmpty())
            {
                if (!string.IsNullOrEmpty(textBox4.Text))
                    MessageBox.Show($"{textBox4.Text} doesn't exist");
            }
            else
            {
                dbContext.Animals.RemoveRange(id);
                await settings.UpdateDataBaseAsync(dataGridView2, dbContext, dbContext.Animals);
                MessageBox.Show("Mammals was deleted successfully");
            }



            //delete selected element
            var result = await dbContext.Animals.SingleOrDefaultAsync(x => x.Id == id1);
            if (result != null)
            {
                dbContext.Animals.Remove(result);
                await settings.UpdateDataBaseAsync(dataGridView2, dbContext, dbContext.Animals);
                MessageBox.Show($"{result.Type} was deleted successfully");
            }

        }

        private void button4_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
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
