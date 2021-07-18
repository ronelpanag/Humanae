using Humanae.Contracts.Services;
using Humanae.DomainGlobal;
using Humanae.Dto;
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
    public partial class ApplicantDetailsView : Form
    {
        private IApplicantService _applicantService;
        private IExperienceService _experienceService;
        private ILanguageService _languageService;
        private ISkillService _skillService;
        private ITrainingService _trainingService;
        private IEmployeeService _employeeService;

        public ApplicantDetailsView(IApplicantService applicantService,
            IExperienceService experienceService,
            ILanguageService languageService,
            ISkillService skillService,
            ITrainingService trainingService,
            IEmployeeService employeeService)
        {
            _applicantService = applicantService;
            _experienceService = experienceService;
            _languageService = languageService;
            _skillService = skillService;
            _trainingService = trainingService;
            _employeeService = employeeService;

            InitializeComponent();
        }

        private async Task GetApplicantData()
        {
            var result = await _applicantService.GetById(StatefulHelper.CalledId);

            if (result.ExcecutedSuccessfully)
            {
                var data = result.Data;

                txtFirstName.Text = data.FirstName;
                txtLastName.Text = data.LastName;
                txtIdentification.Text = data.Identification;
                txtRecommendedBy.Text = data.RecommendedBy;
                txtDepartment.Text = data.Department;
                txtAppliedPosition.Text = data.AppliedPosition;
            }
            else
            {
                MessageBox.Show(result.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private async Task GetSkills()
        {
            var result = await _skillService.GetApplicantSkills(StatefulHelper.CalledId);

            if (result.ExcecutedSuccessfully)
            {
                if(result.Data.Count == 0)
                {
                    bsSkill.Add(new SkillDto());
                }
                else
                {
                    foreach (var item in result.Data)
                    {
                        bsSkill.Add(item);
                    }
                }
                
                dataGridView2.DataSource = bsSkill;

                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[1].HeaderText = "Descripción";
                dataGridView2.Columns[2].HeaderText = "Estado";
            }
        }

        private async Task GetExperiences()
        {
            var result = await _experienceService.GetApplicantExperiences(StatefulHelper.CalledId);

            if (result.ExcecutedSuccessfully)
            {
                if(result.Data.Count == 0)
                {
                    bsExperience.Add(new ExperienceDto());
                }
                else
                {
                    foreach (var item in result.Data)
                    {
                        bsExperience.Add(item);
                    }
                }
                
                dataGridView1.DataSource = bsExperience;

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Compañia";
                dataGridView1.Columns[2].HeaderText = "Titulo";
                dataGridView1.Columns[3].HeaderText = "Salario";
                dataGridView1.Columns[4].HeaderText = "Desde";
                dataGridView1.Columns[5].HeaderText = "Hasta";
            }
        }

        private async Task GetLanguages()
        {
            var result = await _languageService.GetApplicantLanguages(StatefulHelper.CalledId);

            if (result.ExcecutedSuccessfully)
            {
                if(result.Data.Count == 0)
                {
                    bsLanguage.Add(new LanguageDto());
                }
                else
                {
                    foreach (var item in result.Data)
                    {
                        bsLanguage.Add(item);
                    }
                }
                
                dataGridView4.DataSource = bsLanguage;

                dataGridView4.Columns[0].Visible = false;
                dataGridView4.Columns[1].HeaderText = "Nombre";
                dataGridView4.Columns[2].HeaderText = "Estado";
            }
        }

        private async Task GetTrainings()
        {
            var result = await _trainingService.GetApplicantTrainings(StatefulHelper.CalledId);

            if (result.ExcecutedSuccessfully)
            {
                if(result.Data.Count == 0)
                {
                    bsTraining.Add(new TrainingDto());
                }
                else
                {
                    foreach (var item in result.Data)
                    {
                        bsTraining.Add(item);
                    }
                }
                
                dataGridView3.DataSource = bsTraining;

                dataGridView3.Columns[0].Visible = false;
                dataGridView3.Columns[1].HeaderText = "Descripción";
                dataGridView3.Columns[2].HeaderText = "Institución";
                dataGridView3.Columns[3].HeaderText = "Nivel";
                dataGridView3.Columns[4].HeaderText = "Desde";
                dataGridView3.Columns[5].HeaderText = "Hasta";
            }
        }

        private async void ApplicantDetailsView_Load(object sender, EventArgs e)
        {
            await GetApplicantData();
            await GetExperiences();
            await GetTrainings();
            await GetSkills();
            await GetLanguages();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var child = (Form)Program.ServiceProvider
                .GetService(typeof(ExperienceCreateView));

            child.Show();

            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var child = (Form)Program.ServiceProvider
                .GetService(typeof(TrainingNewView));

            child.Show();
            
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var child = (Form)Program.ServiceProvider
                .GetService(typeof(SkillNewView));

            child.Show();
        
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var child = (Form)Program.ServiceProvider
                .GetService(typeof(LanguageNewView));

            child.Show();
        
            Close();
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            var child = (Form)Program.ServiceProvider
                .GetService(typeof(NewEmployeeNewView));

            child.Show();

            Close();
        }
    }
}
