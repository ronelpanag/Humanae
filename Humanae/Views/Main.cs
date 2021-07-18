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
            if (Context.UserInformation.Role == DomainGlobal.Role.HR ||
                Context.UserInformation.Role == DomainGlobal.Role.Admin)
            {
                var child = (Form)Program.ServiceProvider
                .GetService(typeof(EmployeeListView));

                child.Show();
            }
            else
            {
                MessageBox.Show("No posee permisos para acceder a esta funcionalidad.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Context.UserInformation.Role == DomainGlobal.Role.HR ||
                Context.UserInformation.Role == DomainGlobal.Role.Admin)
            {
                var child = (Form)Program.ServiceProvider
                .GetService(typeof(ApplicantListView));

                child.Show();
            }
            else
            {
                MessageBox.Show("No posee permisos para acceder a esta funcionalidad.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var child = new SettingsView();

            child.Show();
        }
    }
}
