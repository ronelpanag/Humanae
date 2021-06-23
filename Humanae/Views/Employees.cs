using Humanae.Contracts.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Humanae.Views
{
    public partial class Employees : Form
    {
        private IEmployeeService _employeeService;

        public Employees(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            InitializeComponent();
        }

        private async void GetData()
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
                                "Error de Autenticacion",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
