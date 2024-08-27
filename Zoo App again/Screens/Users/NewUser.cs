using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zoo_App_again.Data;
using Zoo_App_again.Entities;

namespace Zoo_App_again.Screens.Users
{
    public partial class NewUser : Form
    {
        AppDbContext dbContext = new AppDbContext();
        public NewUser()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (IsStrongPassword(textBox2.Text))
            {
                Registration registration = new Registration();
                registration.UserName = textBox1.Text;
                registration.Password = textBox2.Text;
                dbContext.Add(registration);
                await dbContext.SaveChangesAsync();
                MessageBox.Show("A new account has created successfully!");
            }
            else MessageBox.Show("The password is weak,Try longer passwords and include lower,upper characters,digits and special characters.");

        }
        static bool IsStrongPassword(string password)
        {
            // Check length
            if (password.Length < 8)
                return false;

            // Check for at least one uppercase letter
            if (!password.Any(char.IsUpper))
                return false;

            // Check for at least one lowercase letter
            if (!password.Any(char.IsLower))
                return false;

            // Check for at least one digit
            if (!password.Any(char.IsDigit))
                return false;

            // Check for at least one special character
            var specialCharacters = new Regex(@"[!@#$%^&*(),.?""':{}|<>]");
            if (!specialCharacters.IsMatch(password))
                return false;

            // Password passed all checks
            return true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
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
            Application.Run(new Form1());
        }
    }
}
