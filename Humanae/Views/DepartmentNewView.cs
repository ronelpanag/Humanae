using Humanae.Contracts.Services;
using Humanae.Dto.Parameters;
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
    public partial class DepartmentNewView : Form
    {
        private IDepartmentService _departmentService;

        public DepartmentNewView(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var param = new DepartmentParameter
            {
                Name = textBox1.Text
            };

            var result = await _departmentService.Create(param);

            if (result.ExcecutedSuccessfully)
            {
                var child = (Form)Program.ServiceProvider
                .GetService(typeof(DepartmentListView));

                child.Show();
            
                Hide();
            }
            else
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
