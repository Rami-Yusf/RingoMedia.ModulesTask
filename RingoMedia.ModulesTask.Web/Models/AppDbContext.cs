using Microsoft.EntityFrameworkCore;

namespace RingoMedia.ModulesTask.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Department> Departments { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define seed data for departments
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "HR", LogoPath = "/department-logos/1.jpeg", ParentDepartmentId = null },
                new Department { Id = 2, Name = "IT", LogoPath = "/department-logos/2.jpeg", ParentDepartmentId = null },
                new Department { Id = 3, Name = "Finance", LogoPath = "/department-logos/3.jpeg", ParentDepartmentId = null },
                new Department { Id = 4, Name = "Recruitment", LogoPath = "/department-logos/4.jpeg", ParentDepartmentId = 1 },
                new Department { Id = 5, Name = "Employee Relations", LogoPath = "/department-logos/5.jpeg", ParentDepartmentId = 1 },
                new Department { Id = 6, Name = "Software Development", LogoPath = "/department-logos/6.jpeg", ParentDepartmentId = 2 },
                new Department { Id = 7, Name = "Infrastructure", LogoPath = "/department-logos/7.jpeg", ParentDepartmentId = 2 },
                new Department { Id = 8, Name = "Accounting", LogoPath = "/department-logos/8.jpeg", ParentDepartmentId = 3 },
                new Department { Id = 9, Name = "Budgeting", LogoPath = "/department-logos/9.jpeg", ParentDepartmentId = 8 },
                new Department { Id = 10, Name = "Testing", LogoPath = "/department-logos/10.jpeg", ParentDepartmentId = 6 }
            );

            // Define seed data for reminders
            modelBuilder.Entity<Reminder>().HasData(
                new Reminder { Id = 1, RecipientEmail = "r.yusf@outlook.com", Title = "Team Meeting", DateTime = new DateTime(2024, 7, 25, 10, 0, 0) },
                new Reminder { Id = 2, RecipientEmail = "r.yusf@outlook.com", Title = "Project Deadline", DateTime = new DateTime(2024, 7, 30, 17, 0, 0) },
                new Reminder { Id = 3, RecipientEmail = "r.yusf@outlook.com", Title = "HR Policy Review", DateTime = new DateTime(2024, 8, 1, 9, 0, 0) },
                new Reminder { Id = 4, RecipientEmail = "r.yusf@outlook.com", Title = "IT Infrastructure Maintenance", DateTime = new DateTime(2024, 8, 5, 14, 0, 0) },
                new Reminder { Id = 5, RecipientEmail = "r.yusf@outlook.com", Title = "Finance Quarterly Report", DateTime = new DateTime(2024, 8, 10, 11, 0, 0) },
                new Reminder { Id = 6, RecipientEmail = "r.yusf@outlook.com", Title = "Recruitment Drive", DateTime = new DateTime(2024, 8, 15, 10, 0, 0) },
                new Reminder { Id = 7, RecipientEmail = "r.yusf@outlook.com", Title = "Employee Feedback Session", DateTime = new DateTime(2024, 8, 20, 15, 0, 0) },
                new Reminder { Id = 8, RecipientEmail = "r.yusf@outlook.com", Title = "Software Release", DateTime = new DateTime(2024, 8, 25, 13, 0, 0) },
                new Reminder { Id = 9, RecipientEmail = "r.yusf@outlook.com", Title = "Budget Planning Meeting", DateTime = new DateTime(2024, 8, 30, 16, 0, 0) }
            );
        }
    }

}
