using Humanae.Contracts.Repositories;
using Humanae.Contracts.Services;
using Humanae.Domain.Entities;
using Humanae.Repositories;
using Humanae.Services;
using Humanae.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace Humanae
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            ConfigureServices(services);

            using (ServiceProvider provider = services.BuildServiceProvider())
            {
                var login = provider.GetRequiredService<Login>();

                Application.Run(login);

            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services
                .AddScoped<IRepository<Skill>, Repository<Skill>>()
                .AddScoped<IRepository<Training>, Repository<Training>>()
                .AddScoped<IRepository<Language>, Repository<Language>>()
                .AddScoped<IRepository<Experience>, Repository<Experience>>()
                .AddScoped<IRepository<Applicant>, Repository<Applicant>>()
                .AddScoped<IRepository<User>, Repository<User>>()
                .AddScoped<IRepository<Position>, Repository<Position>>()
                .AddScoped<IRepository<Department>, Repository<Department>>()
                .AddScoped<IRepository<Employee>, Repository<Employee>>()
                .AddScoped<IDepartmentService, DepartmentService>()
                .AddScoped<ISkillService, SkillService>()
                .AddScoped<ILanguageService, LanguageService>()
                .AddScoped<IPositionService, PositionService>()
                .AddScoped<IApplicantService, ApplicantService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IExperienceService, ExperienceService>()
                .AddScoped<ITrainingService, TrainingService>()
                .AddScoped<IEmployeeService, EmployeeService>()
                .AddScoped<Login>();
        }
    }
}
