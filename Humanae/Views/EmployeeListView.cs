using Humanae.Contracts.Services;
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
    public partial class EmployeeListView : Form
    {
        private IEmployeeService _employeeService;

        public EmployeeListView(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            InitializeComponent();
        }

        private async Task GetData()
        {
            var employeeResult = await _employeeService.GetAll();

            if (employeeResult.ExcecutedSuccessfully)
            {
                foreach (var item in employeeResult.Data)
                {
                    bindingSource1.Add(item);
                }

                dataGridView1.DataSource = bindingSource1;
            }
            else
            {
                MessageBox.Show(employeeResult.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private async void Employees_Load(object sender, EventArgs e)
        {
            await GetData();
        }
    }
}
