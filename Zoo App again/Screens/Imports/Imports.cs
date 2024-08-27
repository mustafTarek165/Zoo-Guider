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

namespace Zoo_App_again.Screens.Imports
{
    public partial class Imports : Form
    {
        private int id1 = -1;
        AppDbContext dbContext = new AppDbContext();
        GeneralUsings settings = new GeneralUsings(); 
        public Imports()
        {

            InitializeComponent();
            settings.UpdateDataBasesync(dataGridView1, dbContext, dbContext.OurImports);
            List<string> list = new List<string>()
            {
                "Birds","Mammals","Reptiles","Foods"
            };
            comboBox1.DataSource = list;
        }
       
        private  void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.CurrentRow.Selected = true;
                string? cell = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (cell != null)
                {
                    id1 = int.Parse(cell);

                    comboBox1.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["classification"].FormattedValue.ToString();
                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["type"].FormattedValue.ToString();

                    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["quantity"].FormattedValue.ToString();
                    textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["totalPrice"].FormattedValue.ToString();
                    textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["organizationImportedFrom"].FormattedValue.ToString();
                    textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["country"].FormattedValue.ToString();

                    string? s = dataGridView1.Rows[e.RowIndex].Cells["historyOfProcess"].FormattedValue.ToString();
                    if (s != null)
                        dateTimePicker1.Value = DateTime.Parse(s);
                    textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["description"].FormattedValue.ToString();
                }

            }

        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["Number"].Value = (e.RowIndex + 1).ToString();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text)
            && !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrEmpty(textBox6.Text))
            {
                Entities.Imports import1 = new Entities.Imports()
                {
                    Classification = comboBox1.SelectedItem.ToString(),
                    Type = textBox1.Text,
                    OrganizationImportedFrom = textBox4.Text,
                    Country = textBox5.Text,
                    Description = textBox6.Text,
                    HistoryOfProcess = dateTimePicker1.Value
                };
                int x; double y;
                bool valid1 = true, valid2 = true;
                if (int.TryParse(textBox2.Text, out x))
                {
                    import1.Quantity = x;
                }
                else { MessageBox.Show("Error,you must enter integer numbers only in Quantity field"); valid1 = false; }
                if (double.TryParse(textBox3.Text, out y))
                {
                    import1.TotalPrice = y;
                }
                else { MessageBox.Show("Error,you must enter numbers only in total price field"); valid2 = false; }

                bool importcheck = dbContext.OurImports.Any(x => x.Classification == import1.Classification && x.Type == import1.Type && x.Quantity == import1.Quantity
                && x.TotalPrice == import1.TotalPrice && x.OrganizationImportedFrom == import1.OrganizationImportedFrom && x.Country == import1.Country
                && x.HistoryOfProcess == import1.HistoryOfProcess && x.Description == import1.Description);

                if (!importcheck)
                {

                    if (valid1 && valid2)
                    {

                        dbContext.OurImports.Add(import1);
                        await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.OurImports);

                        if (import1.Classification != "Foods")//Animals
                        {
                            bool reptileexist =await dbContext.Animals.AnyAsync(x => x.Type == import1.Type);
                            if (reptileexist)
                            {
                                Animal? animal = await dbContext.Animals.Where(x => x.Type == import1.Type).FirstOrDefaultAsync();
                                if (animal != null)
                                    animal.Quantity += import1.Quantity;
                            }
                            else
                            {
                                //there is a exception problem about classification
                                Animal? animal = new Animal()
                                {
                                    Type = import1.Type,
                                    Classification=import1.Classification,
                                    Quantity = import1.Quantity,
                                    Description = import1.Description,
                                    PricePerOne = Math.Round(import1.TotalPrice / import1.Quantity,2),
                                    importsId = import1.Id
                                };
                                dbContext.Animals.Add(animal);
                            }
                        }
                        else//foods
                        {
                            bool foodexist =await dbContext.Foods.AnyAsync(x => x.Type == import1.Type);
                            if (foodexist)
                            {
                                Food? food = await dbContext.Foods.Where(x => x.Type == import1.Type).FirstOrDefaultAsync();
                                if (food != null)
                                    food.Quantity += import1.Quantity;
                            }
                            else
                            {
                                Food? food = new Food()
                                {
                                    Type = import1.Type,
                                    Quantity = import1.Quantity,
                                    Description = import1.Description,
                                    PricePerKilo = Math.Round(import1.TotalPrice / import1.Quantity,2),
                                    importsId = import1.Id
                                };
                                dbContext.Foods.Add(food);
                            }
                        }
                        await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.OurImports);
                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                        dataGridView1.Rows[dataGridView1.RowCount - 1].Selected = true;

                    }
                }
                else MessageBox.Show("Error,you can't add the same value twice");

            }
            else MessageBox.Show("Error,there is empty fields");
        }
        //update
        private async void button5_Click(object sender, EventArgs e)
        {
            if (id1 != -1)
            {
                var result = await dbContext.OurImports.SingleOrDefaultAsync(x => x.Id == id1);
                if (result != null)
                {
                    string? oldvalue = result.Type;

                    result.Type = textBox1.Text;
                    result.OrganizationImportedFrom = textBox4.Text;
                    result.Country = textBox5.Text;
                    result.Description = textBox6.Text;

                    int x; double y;
                    bool valid1 = true, valid2 = true;
                    if (int.TryParse(textBox2.Text, out x))
                    {
                        result.Quantity = x;

                    }
                    else { MessageBox.Show("Error,you must enter integer numbers only in Quantity field"); valid1 = false; }
                    if (double.TryParse(textBox3.Text, out y))
                    {
                        result.TotalPrice = y;

                    }
                    else { MessageBox.Show("Error,you must enter numbers only in price field"); valid2 = false; }


                    if (valid1 && valid2)
                    {
                        if (result.Classification == "Reptiles")
                        {
                            Animal? animal =await dbContext.Animals.FirstOrDefaultAsync(x => x.Type == oldvalue);

                            if (animal != null)
                            {
                                animal.Type = result.Type;
                                animal.Quantity = result.Quantity;
                                animal.PricePerOne = result.TotalPrice / result.Quantity;
                                animal.Description = result.Description;
                            }
                        }
                        else
                        {
                            Food? food =await dbContext.Foods.FirstOrDefaultAsync(x => x.Type == oldvalue);
                            if (food != null)
                            {
                                food.Type = result.Type;
                                food.Quantity = result.Quantity;
                                food.PricePerKilo = result.TotalPrice / result.Quantity;
                                food.Description = result.Description;
                            }
                        }
                        await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.OurImports);
                        MessageBox.Show("update has been done successfully");
                    }


                }
            }
        }
        //search
        private async void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox7.Text))
            {

                dataGridView1.DataSource = await dbContext.OurImports.Where(x => x.Type != null && x.Type.Contains(textBox7.Text)).ToListAsync();

            }
            else dataGridView1.DataSource =await dbContext.OurImports.ToListAsync();
        }
        //delete
        private async void button4_Click(object sender, EventArgs e)
        {
            //delete searched element
            var id = dbContext.OurImports.Where(x => x.Type == textBox7.Text);
            if (id.IsNullOrEmpty())
            {
                if (!string.IsNullOrEmpty(textBox7.Text))
                    MessageBox.Show($"{textBox7.Text} doesn't exist");
            }
            else
            {
                string? state = id.FirstOrDefault()?.Classification;
                if (state == "Reptiles")
                {
                    Animal? animal =await  dbContext.Animals.FirstOrDefaultAsync(x => x.Type == textBox7.Text);
                    if (animal != null)
                        dbContext.Animals.Remove(animal);
                }
                else
                {
                    Food? food =await dbContext.Foods.FirstOrDefaultAsync(x => x.Type == textBox7.Text);
                    if (food != null)
                        dbContext.Foods.Remove(food);
                }

                dbContext.OurImports.RemoveRange(id);
                await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.OurImports);
                MessageBox.Show("Importes was deleted successfully");
            }
            //delete selected element
            var result = dbContext.OurImports.SingleOrDefault(x => x.Id == id1);
            if (result != null)
            {
                if (result.Classification == "Reptiles")
                {
                    Animal? animal = dbContext.Animals.FirstOrDefault(x => x.Type == result.Type);
                    if (animal != null)
                        dbContext.Animals.Remove(animal);
                }
                else
                {

                    Food? food = await dbContext.Foods.FirstOrDefaultAsync(x => x.Type == result.Type);
                    if (food != null)
                        dbContext.Foods.Remove(food);
                }


                dbContext.OurImports.Remove(result);
                await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.OurImports);
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
