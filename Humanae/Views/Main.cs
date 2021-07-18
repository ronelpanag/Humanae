using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Humanae.Views
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            labelWelcome.Text = $"Hola, {Context.UserInformation.Employee}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var child = (Form)Program.ServiceProvider
                .GetService(typeof(EmployeeListView));

            child.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var child = (Form)Program.ServiceProvider
                .GetService(typeof(ApplicantListView));

            child.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var child = new SettingsView();

            child.Show();
        }
    }
}
