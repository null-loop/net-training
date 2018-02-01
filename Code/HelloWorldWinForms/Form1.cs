using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HelloWorldLibrary;

namespace HelloWorldWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void sayHelloButton_Click(object sender, EventArgs e)
        {
            var names = nameTextBox.Text;
            var namesArray = names.Split(',').Select(n => n.Trim()).Where(n => !string.IsNullOrEmpty(n)).ToArray();
            var message = HelloWorldNamer.GetHelloWorld(namesArray);
            MessageBox.Show(this, message, "Hello", MessageBoxButtons.OK);
        }
    }
}
