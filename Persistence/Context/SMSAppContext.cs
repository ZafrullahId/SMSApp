using Domain.Contracts;
using Domain.Entity;
using Domain.Entity.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class SMSAppContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public SMSAppContext(DbContextOptions<SMSAppContext> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user = new User { Email = "Oga@Admin", Password = "password", FullName = "Oga@Admin", PhoneNumber = "1234567890", };
            var role = new Role { Name = "Admin", Description = "Oga pata pata" };
            var department1 = new Department { Name = "Science", Description = "Science" };
            var department2 = new Department { Name = "Art", Description = "Att" };
            var department3 = new Department { Name = "Commercial", Description = "Commercial" };
            modelBuilder.Entity<User>()
            .HasIndex(p => p.Email)
            .IsUnique();
            modelBuilder.Entity<Role>()
                .HasData(
                    role,
                    new Role { Name = "Teacher", Description = "Omo ishe" },
                    new Role { Name = "Student", Description = "Student" }
                );
            modelBuilder.Entity<User>()
                .HasData(user);
            modelBuilder.Entity<Staff>()
                .HasData(
                    new Staff { UserId = user.Id}
                );
            modelBuilder.Entity<UserRole>()
                .HasData(
                    new UserRole { UserId = user.Id, RoleId = role.Id}
                );
            modelBuilder.Entity<Level>()
                .HasData(
                    new Level { Name = "SSS1", Description = "SSS1" },
                    new Level { Name = "SSS2", Description = "SSS2" },
                    new Level { Name = "SSS3", Description = "SSS3" }
                );
            modelBuilder.Entity<Department>()
                .HasData(
                department1, department2, department3
            );
            modelBuilder.Entity<Subject>()
                .HasData(
               new Subject { Name = "Mathematics", Description = "Mathematics", DepartmentId = department1.Id },
               new Subject { Name = "English", Description = "English vocabulary", },
               new Subject { Name = "Physics", Description = "Physics", DepartmentId = department1.Id },
               new Subject { Name = "Chemistry", Description = "Chemistry", DepartmentId = department1.Id },
               new Subject { Name = "Biology", Description = "Biology" },
               new Subject { Name = "ICT", Description = "ICT", DepartmentId = department1.Id },
               new Subject { Name = "Further Mathematics", Description = "Further Mathematics", DepartmentId = department1.Id },
               new Subject { Name = "Geography", Description = "Geography", DepartmentId = department1.Id },
               new Subject { Name = "Agric Science", Description = "Agric Science", DepartmentId = department1.Id },
               new Subject { Name = "Commerce", Description = "Commerce", DepartmentId = department3.Id },
               new Subject { Name = "Account", Description = "Account", DepartmentId = department3.Id },
               new Subject { Name = "Government", Description = "Government", DepartmentId = department2.Id },
               new Subject { Name = "History", Description = "History", DepartmentId = department2.Id },
               new Subject { Name = "CRS", Description = "CRS", DepartmentId = department2.Id },
               new Subject { Name = "IRS", Description = "IRS", DepartmentId = department2.Id },
               new Subject { Name = "Literature-in-English", Description = "Literature-in-English", DepartmentId = department2.Id }
            );
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Choice> Options { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ExamSubjects> SubjectExams { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Paper> Papers { get; set; }
        public DbSet<StudentPaper> StudentPaper { get; set; }
        public DbSet<StaffsSubjects> StaffsSubjects { get; set; }
        public DbSet<StaffsLevels> StaffsLevels { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }
        public DbSet<SubjectTimeTable> SubjectTimeTables { get; set; }
        public DbSet<LevelTimeTable> LevelTimeTables { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<PaymentRequest> Payment { get; set; }
    }
}