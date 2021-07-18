using Humanae.Contracts.Services;
using Humanae.DomainGlobal;
using Humanae.Dto;
using Humanae.Dto.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Humanae.Views
{
    public partial class ApplicantNewView : Form
    {
        private IApplicantService _applicantService;
        private IPositionService _positionService;
        List<PositionDto> Positions = new List<PositionDto>();

        public ApplicantNewView(IApplicantService applicantService,
            IPositionService positionService)
        {
            _applicantService = applicantService;
            _positionService = positionService;
            InitializeComponent();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            bool isValidForm = ValidationHelper.ValidateIdentification(txtIdentification.Text);

            txtIdentification.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (!isValidForm)
            {
                MessageBox.Show("Cedula invalida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txtIdentification.TextMaskFormat = MaskFormat.IncludeLiterals;

                var selectedItem = cmbAppliedPosition.SelectedItem.ToString();
                var selectedPosition = Positions
                    .FirstOrDefault(x => x.Name == selectedItem);

                var model = new ApplicantParameter
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Identification = txtIdentification.Text,
                    RecommendedBy = txtRecommendedBy.Text,
                    AppliedPositionId = selectedPosition.Id
                };

                var result = await _applicantService.Create(model);

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

        private async void ApplicantNewView_Load(object sender, EventArgs e)
        {
            var data = await GetPositionData();

            foreach (var item in data)
            {
                cmbAppliedPosition.Items.Add(item.Name);
            }

            Positions.AddRange(data);
        }

        private async Task<IEnumerable<PositionDto>> GetPositionData()
        {
            var serviceResult = await _positionService.GetAll();

            if (!serviceResult.ExcecutedSuccessfully)
            {
                MessageBox.Show("No se han encontrado Posiciones. Favor configurarlas o contactar al administrador de sistemas.",
                                "Error de Busqueda",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

            }
            
            return serviceResult.Data;
        }

        private void cmbAppliedPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = cmbAppliedPosition.SelectedItem.ToString();

            textBox4.Text = Positions.FirstOrDefault(x => x.Name == selectedItem).Department;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var child = (Form)Program.ServiceProvider
                .GetService(typeof(ApplicantListView));

            child.Show();

            Close();
        }
    }
}
