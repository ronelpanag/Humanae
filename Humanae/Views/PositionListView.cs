using Humanae.Contracts.Services;
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
                var data = result.Data.ToList();

                if (data.Count == 0)
                {
                    bindingSource1.Add(new PositionDto());
                }
                else
                {
                    foreach (var item in result.Data)
                    {
                        bindingSource1.Add(item);
                    }
                }
                
                dataGridView1.DataSource = bindingSource1;

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Nombre";
                dataGridView1.Columns[2].HeaderText = "Nivel de Riesgo";
                dataGridView1.Columns[3].HeaderText = "Salario Minimo";
                dataGridView1.Columns[4].HeaderText = "SalarioMaximo";
                dataGridView1.Columns[5].HeaderText = "Estado";
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
            var child = (Form)Program.ServiceProvider
                .GetService(typeof(PositionNewView));

            child.Show();

            Hide();
        }
    }
}
