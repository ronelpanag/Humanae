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
            if (Context.UserInformation.Role == DomainGlobal.Role.HR)
            {
                var child = (Form)Program.ServiceProvider
                .GetService(typeof(DepartmentListView));

                child.Show();

                Close();
            }
            else
            {
                MessageBox.Show("No posee permisos para acceder a esta funcionalidad.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Context.UserInformation.Role == DomainGlobal.Role.HR)
            {
                var child = (Form)Program.ServiceProvider
                    .GetService(typeof(PositionListView));

                child.Show();

                Close();
            }
            else
            {
                MessageBox.Show("No posee permisos para acceder a esta funcionalidad.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Context.UserInformation.Role == DomainGlobal.Role.Admin)
            {
                var child = (Form)Program.ServiceProvider
                    .GetService(typeof(UserListView));

                child.Show();

                Close();
            }
            else
            {
                MessageBox.Show("No posee permisos para acceder a esta funcionalidad.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Context.UserInformation.Role == DomainGlobal.Role.HR)
            {
                var child = (Form)Program.ServiceProvider
                    .GetService(typeof(LanguageListView));

                child.Show();

                Close();
            }
            else
            {
                MessageBox.Show("No posee permisos para acceder a esta funcionalidad.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
