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

namespace Zoo_App_again.Screens.Animals
{
    public partial class AnimalPlaces : Form
    {
        private int id1 = -1;
        AppDbContext dbContext = new AppDbContext();
        GeneralUsings settings=new GeneralUsings();
        public AnimalPlaces()
        {
            InitializeComponent();
            settings.UpdateDataBasesync(dataGridView1, dbContext, dbContext.AnimalPlaces);
        }
       
        //add
        private async void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                AnimalPlace AnimalPlace1 = new AnimalPlace()
                {
                    Name = textBox1.Text
                };
                AnimalPlace? animalplace = dbContext.AnimalPlaces.FirstOrDefault(x => x.Name == AnimalPlace1.Name);
                if (animalplace == null)
                {
                    dbContext.Add(AnimalPlace1);
                    await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.AnimalPlaces);
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                    dataGridView1.Rows[dataGridView1.RowCount - 1].Selected = true;
                }
                else MessageBox.Show("This Location already exists");


            }
            else MessageBox.Show("Error,there is empty fields");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                dataGridView1.CurrentRow.Selected = true;
                string? x = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (x != null)
                {
                    id1 = int.Parse(x);
                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
                }

            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["Number"].Value = (e.RowIndex + 1).ToString();
        }
        //edit
        private async void button5_Click(object sender, EventArgs e)
        {
            if (id1 != -1)
            {

                var result = dbContext.AnimalPlaces.SingleOrDefault(x => x.Id == id1);
                if (result != null)
                {
                    result.Name = textBox1.Text;
                    await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.AnimalPlaces);
                }

            }
        }
        //delete
        private async void button4_Click(object sender, EventArgs e)
        {
            //delete searched element

            var id = await dbContext.AnimalPlaces.Where(x => x.Name == textBox1.Text).FirstOrDefaultAsync();
            if (id != null)
            {
                if (id.ToString().IsNullOrEmpty())
                {
                    if (!string.IsNullOrEmpty(textBox1.Text))
                        MessageBox.Show($"{textBox1.Text} doesn't exist");
                }
                else
                {
                    bool check = await dbContext.Animals.AnyAsync(x => x.animalPlaceId == id.Id);

                    if (check) MessageBox.Show("There are animals in that place,You can't remove this place before moving existing animals");
                    else
                    {
                        dbContext.AnimalPlaces.RemoveRange(id);
                        await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.AnimalPlaces);
                        MessageBox.Show("Animals was deleted successfully");
                    }
                }
            }


            var result = dbContext.AnimalPlaces.SingleOrDefault(x => x.Id == id1);
            if (result != null)
            {
                //logic


                bool check = await  dbContext.Animals.AnyAsync(x => x.animalPlaceId == id1);
                if (check) MessageBox.Show("There are animals in that place,You can't remove this place before moving existing animals");
                else
                {
                    dbContext.AnimalPlaces.Remove(result);
                    await settings.UpdateDataBaseAsync(dataGridView1, dbContext, dbContext.AnimalPlaces);
                    MessageBox.Show($"{result.Name} was deleted successfully");
                }


            }
        }
        //search
        private async void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {

                dataGridView1.DataSource = await dbContext.AnimalPlaces.Where(x => x.Name != null && x.Name.Contains(textBox1.Text)).ToListAsync();

            }
            else dataGridView1.DataSource = dbContext.AnimalPlaces.ToListAsync();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if(listBox1.Items.Count!=0)
            {
                listBox1.DataSource=null;
            }
            
            var id =await dbContext.AnimalPlaces.Where(x => x.Name == textBox1.Text).Select(x => x.Id).FirstOrDefaultAsync();
            var animals =await dbContext.Animals.Where(x => x.animalPlaceId == id).Select(x=>x.Type).ToListAsync();
            listBox1.DataSource = animals;
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
            Application.Run(new AnimalsForm());
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
            Application.Run(new Form1());
        }
    }
}
