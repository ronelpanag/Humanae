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
    public partial class LanguageNewView : Form
    {
        private ILanguageService _languageService;
        public LanguageNewView(ILanguageService languageService)
        {
            _languageService = languageService;

            InitializeComponent();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var parameter = new LanguageParameter
            {
                ApplicantId = StatefulHelper.CalledId,
                Name = textBox1.Text
            };

            var result = await _languageService.Create(parameter);

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
