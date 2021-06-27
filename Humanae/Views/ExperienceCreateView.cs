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
            var parameter = new ExperienceParameter
            {
                ApplicantId = StatefulHelper.CalledId,
                CompanyName = txtCompany.Text,
                JobTitle = txtTitle.Text,
                Salary = decimal.Parse(txtSalary.Text),
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
