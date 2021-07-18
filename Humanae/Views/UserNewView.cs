using Humanae.Contracts.Services;
using Humanae.DomainGlobal;
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
    public partial class UserNewView : Form
    {
        private IUserService _userService;
        private IEmployeeService _employeeService;
        private List<EmployeeDto> Employees = new List<EmployeeDto>();

        public UserNewView(IUserService userService,
            IEmployeeService employeeService)
        {
            _userService = userService;
            _employeeService = employeeService;

            InitializeComponent();
        }

        private async Task GetEmployeeData()
        {
            var result = await _employeeService.GetAll();

            foreach (var item in result.Data)
            {
                comboBox1.Items.Add($"{item.FirstName} {item.LastName}");
            }

            Employees.AddRange(result.Data);
        }

        private async void UserNewView_Load(object sender, EventArgs e)
        {
            await GetEmployeeData();

            comboBox2.DataSource = Enum.GetNames(typeof(Role));
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var eMailValidator = new System.Net.Mail.MailAddress(txtEmail.Text);

                var selectedItem = comboBox1.SelectedItem.ToString();
                var selectedEmployee = Employees
                    .FirstOrDefault(x => x.FirstName + " " + x.LastName == selectedItem);

                Role role;
                Enum.TryParse<Role>(comboBox2.SelectedValue.ToString(), out role);

                var parameter = new CreateUserParameter
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    Email = txtPassword.Text,
                    EmployeeId = selectedEmployee.Id,
                    Role = role
                };

                var result = await _userService.Create(parameter);

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
                        .GetService(typeof(UserListView));

                    child.Show();
                }
                else
                {
                    MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
