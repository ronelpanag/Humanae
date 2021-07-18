using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting.Preview;
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
using System.Linq;
using Humanae.Dto;

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
            var result = await _employeeService.GetAll();

            if (result.ExcecutedSuccessfully)
            {
                if (result.Data.Count == 0)
                {
                    bindingSource1.Add(new EmployeeDto());
                }
                else
                {
                    foreach (var item in result.Data)
                    {
                        bindingSource1.Add(item);
                    }
                }

                dataGridView1.DataSource = bindingSource1;

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].HeaderText = "Nombre";
                dataGridView1.Columns[4].HeaderText = "Apellido";
                dataGridView1.Columns[5].HeaderText = "Identificación";
                dataGridView1.Columns[6].HeaderText = "Departamento";
                dataGridView1.Columns[7].HeaderText = "Posición";
                dataGridView1.Columns[8].HeaderText = "Salario";
                dataGridView1.Columns[9].HeaderText = "Estado";
            }
            else
            {
                MessageBox.Show(result.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private async void Employees_Load(object sender, EventArgs e)
        {
            await GetData();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var serviceResult = await _employeeService.GetActives();

            if (serviceResult.ExcecutedSuccessfully)
            {
                var report = new ActiveEmployees();
                report.DataSource = serviceResult.Data.ToList();
                report.CreateDocument();
                await report.PrintAsync();
            }
        }
    }
}
