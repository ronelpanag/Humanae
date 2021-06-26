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
    public partial class PositionListView : Form
    {
        private IPositionService _positionService;
        public PositionListView(IPositionService positionService)
        {
            _positionService = positionService;
            InitializeComponent();
        }

        private async Task GetData()
        {
            var result = await _positionService.GetAll();

            if (result.ExcecutedSuccessfully)
            {
                foreach (var item in result.Data)
                {
                    bindingSource1.Add(item);
                }

                dataGridView1.DataSource = bindingSource1;
            }
            else
            {
                MessageBox.Show(result.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private async void PositionListView_Load(object sender, EventArgs e)
        {
            await GetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var child = new PositionNewView();

            child.ShowDialog();
        }
    }
}
