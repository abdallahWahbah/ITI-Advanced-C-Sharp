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
    public partial class FormDrawMouseMove_Hover_ : Form
    {
        public FormDrawMouseMove_Hover_()
        {
            InitializeComponent();
        }

        private void FormDrawMouseMove_Hover__Load(object sender, EventArgs e)
        {

        }

        private void FormDrawMouseMove_Hover__MouseMove(object sender, MouseEventArgs e)
        { // MouseMove event on the form itself
            Graphics grx = CreateGraphics();
            Brush eraseBrush = new SolidBrush(BackColor); // the current background of the form

            if(e.Button == MouseButtons.Left) // if you "keep" clicking (cause the event is MouseMove) on the left mouse button
                grx.FillEllipse(Brushes.Red, e.X - 25, e.Y - 25, 50, 50);
            else if(e.Button == MouseButtons.Right)
                grx.FillEllipse(eraseBrush, e.X - 25, e.Y - 25, 50, 50);
        }
    }
}
