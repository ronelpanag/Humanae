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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Humanae.Views
{
    public partial class ApplicantNewView : Form
    {
        private IApplicantService _applicantService;
        private IPositionService _positionService;
        private List<PositionDto> Positions = new List<PositionDto>();

        public ApplicantNewView(IApplicantService applicantService,
            IPositionService positionService)
        {
            _applicantService = applicantService;
            _positionService = positionService;
            InitializeComponent();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var selectedItem = cmbAppliedPosition.SelectedIndex.ToString();
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

            var serviceResult = await _applicantService.Create(model);

            if (serviceResult.ExcecutedSuccessfully)
            {
                var dialogResult = MessageBox.Show(serviceResult.Message,
                    "Operacion exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                if (dialogResult == DialogResult.OK)
                {
                    Close();
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
    }
}
