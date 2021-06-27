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
    public partial class ApplicantListView : Form
    {
        private IApplicantService _applicantService;

        public ApplicantListView(IApplicantService applicantService)
        {
            _applicantService = applicantService;

            InitializeComponent();
        }

        private async Task GetData()
        {
            var applicantResult = await _applicantService.GetAll();

            if (applicantResult.ExcecutedSuccessfully)
            {
                var data = applicantResult.Data.ToList();

                if (data.Count == 0)
                {
                    bindingSource1.Add(new ApplicantDto());
                }
                else
                {
                    foreach (var item in applicantResult.Data)
                    {
                        bindingSource1.Add(item);
                    }
                }

                dataGridView1.DataSource = bindingSource1;

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Nombre";
                dataGridView1.Columns[2].HeaderText = "Apellido";
                dataGridView1.Columns[3].HeaderText = "Identificación";
                dataGridView1.Columns[4].HeaderText = "Posición a la que aplica";
                dataGridView1.Columns[5].HeaderText = "Departamento";
                dataGridView1.Columns[6].HeaderText = "Recomendado por";
                dataGridView1.Columns[7].HeaderText = "Disponible";
            }
            else
            {
                MessageBox.Show(applicantResult.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private async void ApplicantListView_Load(object sender, EventArgs e)
        {
            await GetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var child = (Form)Program.ServiceProvider
                .GetService(typeof(ApplicantNewView));

            child.Show();

            Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            StatefulHelper.CalledId = (int) dataGridView1.Rows[e.RowIndex].Cells[0].Value;

            var child = (Form)Program.ServiceProvider
                .GetService(typeof(ApplicantDetailsView));

            child.Show();

            Close();
        }
    }
}
