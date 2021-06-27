using Humanae.Contracts.Services;
using Humanae.Dto.Parameters;
using System.Windows.Forms;

namespace Humanae.Views
{
    public partial class Login : Form
    {
        private IUserService _service { get; set; }

        public Login(IUserService service)
        {
            _service = service;
            InitializeComponent();
        }

        private async void button1_Click(object sender, System.EventArgs e)
        {
            var parameter = new AuthenticateParameter
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text
            };

            var result = await _service.Login(parameter);

            if (result.ExcecutedSuccessfully)
            {
                Main mainForm = new Main();
                mainForm.Show();

                Hide();
            }
            else
            {
                MessageBox.Show(result.Message,
                                "Error de Autenticacion",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
