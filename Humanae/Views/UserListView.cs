using Humanae.Contracts.Services;
using Humanae.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Humanae.Views
{
    public partial class UserListView : Form
    {
        private IUserService _userService;
        public UserListView(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        private async void UserListView_Load(object sender, EventArgs e)
        {
            await GetData();
        }

        private async Task GetData()
        {
            var applicantResult = await _userService.GetAll();

            if (applicantResult.ExcecutedSuccessfully)
            {
                foreach (var item in applicantResult.Data)
                {
                    bindingSource1.Add(item);
                }

                dataGridView1.DataSource = bindingSource1;

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Usuario";
                dataGridView1.Columns[2].HeaderText = "Correo Electronico";
                dataGridView1.Columns[3].HeaderText = "Empleado";
                dataGridView1.Columns[4].HeaderText = "Estado";
            }
            else
            {
                MessageBox.Show(applicantResult.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var child = (Form)Program.ServiceProvider
                .GetService(typeof(UserNewView));

            child.Show();

            Close();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var serviceResult = await _userService.GetActives();

            if (serviceResult.ExcecutedSuccessfully)
            {
                var report = new ActiveUsers();
                report.DataSource = serviceResult.Data;
                report.CreateDocument();
                report.ExportOptions.PrintPreview.DefaultFileName = $"Reporte de usuarios activos {DateTime.Now:dd-MMM-yyyy}";
                await report.PrintAsync();
            }
        }
    }
}
