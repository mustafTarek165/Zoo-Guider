using Microsoft.EntityFrameworkCore;
using Zoo_App_again.Data;
using Zoo_App_again.Screens.Users;

namespace Zoo_App_again
{
    public partial class Form1 : Form
    {
        AppDbContext dbContext = new AppDbContext();
        public Form1()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                var result1 = dbContext.Registrations.Where(x => x.UserName == textBox1.Text && x.Password == textBox2.Text).Count();

                if (result1 > 0)
                {
                    this.Close();
                    Thread th = new Thread(OpenForm2);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }
                else
                    MessageBox.Show("Not valid user name and/or password");
            }
            else MessageBox.Show("Error,There is empty fields");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(OpenForm1);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void OpenForm1()
        {
            Application.Run(new NewUser());
        }
        void OpenForm2()
        {
            Application.Run(new MainForm());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }
    }
}
