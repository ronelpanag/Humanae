using Humanae.Contracts.Services;
using Humanae.DomainGlobal;
using Humanae.Dto.Parameters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Humanae.Views
{
    public partial class ExperienceCreateView : Form
    {
        private IExperienceService _experienceService;
        public ExperienceCreateView(IExperienceService experienceService)
        {
            _experienceService = experienceService;

            InitializeComponent();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            bool validationSucceeded = true;

            decimal salary = 0;
            decimal.TryParse(txtSalary.Text, out salary);

            if (salary <= 0)
            {
                validationSucceeded = false;
                MessageBox.Show("Salario no puede ser menor o igual a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (dtFrom.Value > DateTime.Now || dtTo.Value > DateTime.Now)
            {
                validationSucceeded = false;
                MessageBox.Show("La fecha no puede ser futura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (validationSucceeded)
            {
                var parameter = new ExperienceParameter
                {
                    ApplicantId = StatefulHelper.CalledId,
                    CompanyName = txtCompany.Text,
                    JobTitle = txtTitle.Text,
                    Salary = salary,
                    FromDate = dtFrom.Value,
                    ToDate = dtTo.Value
                };

                var result = await _experienceService.Create(parameter);

                if (result.ExcecutedSuccessfully)
                {
                    MessageBox.Show(result.Message, "Registro exitoso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Close();
                }
                else
                {
                    MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
