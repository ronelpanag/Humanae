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
    public partial class DepartmentListView : Form
    {
        private IDepartmentService _departmentService;

        public DepartmentListView(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
            InitializeComponent();
        }

        private async Task GetData()
        {
            var result = await _departmentService.GetAll();

            if (result.ExcecutedSuccessfully)
            {
                var data = result.Data.ToList();

                if(data.Count == 0)
                {
                    bindingSource1.Add(new DepartmentDto());
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
                dataGridView1.Columns[2].HeaderText = "Estado";

            }
            else
            {
                MessageBox.Show(result.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var child = (Form)Program.ServiceProvider
                .GetService(typeof(DepartmentNewView));

            child.Show();

            Hide();
        }

        private async void DepartmentListView_Load(object sender, EventArgs e)
        {
            await GetData();
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }
    }
}
