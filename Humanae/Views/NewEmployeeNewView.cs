using Humanae.Contracts.Services;
using Humanae.DomainGlobal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Humanae.Views
{
    public partial class NewEmployeeNewView : Form
    {
        private IApplicantService _applicantService;
        public NewEmployeeNewView(IApplicantService applicantService)
        {
            _applicantService = applicantService;

            InitializeComponent();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var salary = decimal.Parse(textBox1.Text);
            var startDate = dateTimePicker1.Value;

            var result = await _applicantService.ConvertToEmployee(StatefulHelper.CalledId,
                salary, startDate);

            if (result.ExcecutedSuccessfully)
            {
                var child = (Form)Program.ServiceProvider
                    .GetService(typeof(DepartmentListView));

                child.Show();

                Hide();
            }
            else
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
