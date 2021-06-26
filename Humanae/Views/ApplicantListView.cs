using Humanae.Contracts.Services;
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
                foreach (var item in applicantResult.Data)
                {
                    bindingSource1.Add(item);
                }

                dataGridView1.DataSource = bindingSource1;
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
            var child = (Form)Program.serviceProvider
                .GetService(typeof(ApplicantNewView));

            child.Show();
        }
    }
}
