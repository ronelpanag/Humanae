using Humanae.Contracts.Services;
using Humanae.Dto;
using Humanae.Dto.Parameters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Humanae.Views
{
    public partial class PositionNewView : Form
    {
        private IPositionService _positionService;
        private IDepartmentService _departmentService;
        List<DepartmentDto> departments = new List<DepartmentDto>();
        int SelectDepartmentId = 0;

        public PositionNewView(IPositionService positionService,
            IDepartmentService departmentService)
        {
            _positionService = positionService;
            _departmentService = departmentService;

            InitializeComponent();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            SelectDepartmentId = departments
                .Where(x => x.Name == cmbDepartment.SelectedItem.ToString())
                .Select(x => x.Id)
                .FirstOrDefault();

            var parameter = new PositionParameter
            {
                Name = txtName.Text,
                DepartmentId = SelectDepartmentId,
                RiskLevel = txtRiskLevel.Text
            };

            bool validationSucceeded = true;

            decimal minSalary = 0;
            decimal.TryParse(txtMinSalary.Text, out minSalary);

            if (minSalary <= 0)
            {
                validationSucceeded = false;
                MessageBox.Show("Salario Minimo no puede ser menor o igual a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            decimal maxSalary = 0;
            decimal.TryParse(txtMinSalary.Text, out maxSalary);

            if (maxSalary <= 0)
            {
                validationSucceeded = false;
                MessageBox.Show("Salario Máximo no puede ser menor o igual a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (minSalary > maxSalary)
            {
                validationSucceeded = false;
                MessageBox.Show("Salario Máximo no puede ser menor que el Salario Minimo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (validationSucceeded)
            {
                var result = await _positionService.Create(parameter);

                if (result.ExcecutedSuccessfully)
                {
                    MessageBox.Show(result.Message,
                        "Registro exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    Hide();
                }
                else
                {
                    MessageBox.Show(result.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private async void PositionNewView_Load(object sender, EventArgs e)
        {
            var departmentsData = await _departmentService.GetAll();

            departments.AddRange(departmentsData.Data);

            cmbDepartment.Items.AddRange(departments.Select(x => x.Name).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var child = (Form)Program.ServiceProvider
                .GetService(typeof(PositionListView));

            child.Show();

            Close();
        }
    }
}
