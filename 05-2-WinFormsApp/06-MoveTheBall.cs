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
    public partial class _06_MoveTheBall : Form
    {
        public _06_MoveTheBall()
        {
            InitializeComponent();
        }
        int x = 0;
        bool flag = true; // move from left to right  (when true)
        private void _06_MoveTheBall_Paint(object sender, PaintEventArgs e)
        { // point event on the form
            Graphics grx = e.Graphics;
            grx.FillEllipse(Brushes.Red, x, 30, 50, 50);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // put a timer on the design (you will not find it on the form, just put it), fires every 100ms
            // then open the Tick event on the timer
            if (flag) x += 10;
            else x -= 10;
            if (x > this.ClientSize.Width - 50) flag = false; // move to left
            if (x < 0) flag = true; // move to right
            this.Invalidate(); // repaint
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // the timer will work every 100ms
            timer1.Enabled = !timer1.Enabled;
            if (timer1.Enabled) btnStart.Text = "Stop";
            else btnStart.Text = "Start";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void _06_MoveTheBall_Load(object sender, EventArgs e)
        {

        }
    }
}
