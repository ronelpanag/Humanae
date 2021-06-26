using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Humanae.Views
{
    public partial class DepartmentListView : Form
    {
        public DepartmentListView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var child = (Form)Program.serviceProvider
                .GetService(typeof(DepartmentNewView));

            child.ShowDialog();

            Hide();
        }
    }
}
