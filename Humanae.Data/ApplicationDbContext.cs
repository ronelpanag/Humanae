using Humanae.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Humanae.Data
{
    public class ApplicationDbContext : DbContext
    {
        private const string ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Humanae;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString, x => x.MigrationsAssembly("Humanae.Data"));
        }

        public DbSet<Position> Positions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ApplicantExperience> ApplicantExperiences { get; set; }
        public DbSet<ApplicantSkill> ApplicantSkills { get; set; }
        public DbSet<ApplicantTraining> ApplicantTrainings { get; set; }
        public DbSet<ApplicantLanguage> ApplicantLanguages { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
