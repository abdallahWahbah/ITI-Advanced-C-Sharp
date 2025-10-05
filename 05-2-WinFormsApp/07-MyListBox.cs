using _18_utility2;
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
    public partial class _07_MyListBox : Form
    {
        public _07_MyListBox()
        {
            InitializeComponent();
        }

        private void _07_MyListBox_Load(object sender, EventArgs e)
        { // form load >>> double press on the form 
            lstEmployee.Items.Add(new Employee() { Id = 1, Name = "Aly", Age = 20 }); // "lstEmployee" is the second listbox name
            lstEmployee.Items.Add(new Employee() { Id = 2, Name = "Sameh", Age = 20 });
            lstEmployee.Items.Add(new Employee() { Id = 3, Name = "Bahaa", Age = 20 });
            lstEmployee.Items.Add(new Employee() { Id = 4, Name = "Sara", Age = 20 });
        }
        // to add items to ListBox, open items in the properties view and add them 
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        { // SelectedIndexChanged event on the ListBox >>> or double click on the listbox
            string s = listBox1.SelectedItem as string;
        }
        private void lstEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {// when clicking on an item (employee) in the ListBox
            Employee emp = lstEmployee.SelectedItem as Employee;
            Text = emp.Name;
        }

    }
}
