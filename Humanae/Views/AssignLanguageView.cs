using Humanae.Contracts.Services;
using Humanae.DomainGlobal;
using Humanae.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Humanae.Views
{
    public partial class AssignLanguageView : Form
    {
        private ILanguageService _languageService;
        List<LanguageDto> Languages = new List<LanguageDto>();
        public AssignLanguageView(ILanguageService languageService)
        {
            _languageService = languageService;
            InitializeComponent();
        }

        private async Task<IEnumerable<LanguageDto>> GetData()
        {
            var serviceResult = await _languageService.GetAll();

            if (!serviceResult.ExcecutedSuccessfully)
            {
                MessageBox.Show("No se han encontrado Posiciones. Favor configurarlas o contactar al administrador de sistemas.",
                                "Error de Busqueda",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

            }

            return serviceResult.Data;
        }

        private async void AssignLanguageView_Load(object sender, EventArgs e)
        {
            var data = await GetData();

            foreach (var item in data)
            {
                comboBox1.Items.Add(item.Name);
            }

            Languages.AddRange(data);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var selectedItem = comboBox1.SelectedItem.ToString();
            var selectedLanguage = Languages
                .FirstOrDefault(x => x.Name == selectedItem);

            var result = await _languageService
                .AssignToApplicant(StatefulHelper.CalledId, selectedLanguage.Id);

            if (result.ExcecutedSuccessfully)
            {
                var dialogResult = MessageBox.Show(result.Message,
                    "Operacion exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                if (dialogResult == DialogResult.OK)
                {
                    Close();
                }

                var child = (Form)Program.ServiceProvider
                    .GetService(typeof(ApplicantListView));

                child.Show();
            }
            else
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
