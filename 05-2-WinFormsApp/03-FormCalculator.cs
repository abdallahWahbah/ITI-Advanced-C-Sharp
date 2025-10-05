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
    public partial class FormCalculator : Form
    {
        public FormCalculator()
        {
            InitializeComponent();
        }

        private void Number_clicked(object sender, EventArgs e)
        {
            // to add the same function to multiple buttons >>
            // select them in the design, click on events icon in properties view
            // write the function name in the click place
            Button btn = sender as Button;
            txtCalc.Text += btn.Text;
        }

        string op = "";
        int num1, num2;
        private void Add_Sub_clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            op = btn.Text;
            num1 = int.Parse(txtCalc.Text);
            txtCalc.Text = "";
        }

        private void button11_Click(object sender, EventArgs e) // equal button
        {
            num2 = int.Parse(txtCalc.Text);

            switch(op)
            {
                case "+":
                {
                    txtCalc.Text = (num1 + num2).ToString();
                    break;
                }
                case "-":
                {
                    txtCalc.Text = (num1 - num2).ToString();
                    break;
                }
            }
        }
    }
}
