using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Humanae.Views
{
    public partial class SettingsView : Form
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var child = (Form)Program.serviceProvider
                .GetService(typeof(DepartmentListView));

            child.Show();

            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var child = (Form)Program.serviceProvider
                .GetService(typeof(PositionListView));

            child.Show();

            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var child = (Form)Program.serviceProvider
                .GetService(typeof(UserListView));

            child.Show();

            Hide();
        }
    }
}
