using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _18_WinFormsApp
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            string fullName = $"{txtFirstName.Text} {txtLastName.Text}";
            MessageBox.Show(fullName, "Name"); // "Name": title of the MessageBox
        }

        private void btnFullname_Click(object sender, EventArgs e)
        {
            FormGetFullName fullNameForm = new FormGetFullName();
            if (fullNameForm.ShowDialog() == DialogResult.OK)
            {
                string fullName = fullNameForm.Name;
                var fullNameArray = fullName.Split(" ");
                txtFirstName.Text = fullNameArray[0];
                txtLastName.Text = fullNameArray[1];
            }
        }
    }
}
