using Humanae.Contracts.Services;
using Humanae.Dto;
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
    public partial class LanguageListView : Form
    {
        private ILanguageService _languageService;
        public LanguageListView(ILanguageService languageService)
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var child = (Form)Program.ServiceProvider
                .GetService(typeof(LanguageNewView));

            child.Show();

            Close();
        }

        private async Task GetLanguages()
        {
            var result = await _languageService.GetAll();

            if (result.ExcecutedSuccessfully)
            {
                if (result.Data.Count == 0)
                {
                    bsLanguage.Add(new LanguageDto());
                }
                else
                {
                    foreach (var item in result.Data)
                    {
                        bsLanguage.Add(item);
                    }
                }

                dataGridView4.DataSource = bsLanguage;

                dataGridView4.Columns[0].Visible = false;
                dataGridView4.Columns[1].HeaderText = "Nombre";
                dataGridView4.Columns[2].HeaderText = "Estado";
            }
        }

        private async void LanguageListView_Load(object sender, EventArgs e)
        {
            await GetLanguages();
        }
    }
}
