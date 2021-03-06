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
    public partial class TrainingNewView : Form
    {
        private ITrainingService _trainingService;
        public TrainingNewView(ITrainingService trainingService)
        {
            _trainingService = trainingService;

            InitializeComponent();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            bool validationSucceeded = true;

            if (dtFrom.Value > DateTime.Now || dtTo.Value > DateTime.Now)
            {
                validationSucceeded = false;
                MessageBox.Show("La fecha no puede ser futura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (validationSucceeded)
            {
                var parameter = new TrainingParameter
                {
                    ApplicantId = StatefulHelper.CalledId,
                    Institution = txtInstitution.Text,
                    Description = txtDescription.Text,
                    Level = comboBox1.SelectedItem.ToString(),
                    FromDate = dtFrom.Value,
                    ToDate = dtTo.Value
                };

                var result = await _trainingService.Create(parameter);

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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
