using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayRoll
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_adminname.Text == "admin" && txt_password.Text == "admin")
            {
                Home a = new Home();
                a.Show();
                this.Hide();

            }
            else if (txt_adminname.Text == "" || txt_password.Text == "")
            {
                MessageBox.Show("Please fill up all fields");
            }
            else
            {
                MessageBox.Show("Incorrect Username/Password");
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_adminname.Text = "";
            txt_password.Text = "";
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
