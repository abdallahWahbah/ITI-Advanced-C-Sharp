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
    public partial class FormGetFullName : Form
    {
        public string Name { get; set; }
        public FormGetFullName()
        {
            InitializeComponent();
        }

        private void FormGetFullName_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Name = txtFullName.Text;
        }
    }
}
