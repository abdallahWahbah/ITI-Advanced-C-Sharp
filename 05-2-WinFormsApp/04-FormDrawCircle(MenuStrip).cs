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
    public partial class FormDrawCircle : Form
    {
        public FormDrawCircle()
        {
            InitializeComponent();
        }

        private void FormDrawCircle_Load(object sender, EventArgs e)
        {

        }

        private void FormDrawCircle_MouseClick(object sender, MouseEventArgs e) // MouseClick event on the form
        {
            // to enable this function (when clicking anywhere on the form)
            // single click on the form, select events in properties view
            // double click on MouseClick

            Graphics grx = CreateGraphics();
            grx.FillEllipse(Brushes.Purple, e.X - 25, e.Y - 25, 50, 50);
            // 50 in width and height, -25 to center in the mouse click position
            // cause the circle is drown in a rectangle
        }
        SolidBrush b1 = new SolidBrush(Color.Red);
        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        { // click event on the red drop down item from menu strip
            b1 = new SolidBrush(Color.Red);
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            b1 = new SolidBrush(Color.Green);
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            b1 = new SolidBrush(Color.Blue);
        }
    }
}
