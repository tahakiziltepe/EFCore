using EFCore.Data.Models;
using Microsoft.

namespace EFCore.Data.Context
{
    public class ApplicationDbClass : DbContext
    {
        public ApplicationDbClass(DbContextOptions<ApplicationDbClass> options) : base(options)
        {
        }

        protected ApplicationDbClass()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
            { 
                 // configuration
                 optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=efcore;Integrated Security=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("students");

                entity.Property(i => i.Id).HasColumnName("id").HasColumnType("int").UseIdentityColumn(1, 1).IsRequired();
                entity.Property(i => i.FirstName).HasColumnName("first_name").HasColumnType("varchar").HasMaxLength(100);
                entity.Property(i => i.LastName).HasColumnName("last_name").HasColumnType("varchar").HasMaxLength(100);
                entity.Property(i => i.Number).HasColumnName("number");
                entity.Property(i => i.BirthDate).HasColumnName("birth_date");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("teachers");

                entity.Property(i => i.Id).HasColumnName("id").HasColumnType("int").UseIdentityColumn(1, 1);
                entity.Property(i => i.FirstName).HasColumnName("first_name").HasColumnType("varchar").HasMaxLength(100);
                entity.Property(i => i.LastName).HasColumnName("last_name").HasColumnType("varchar").HasMaxLength(100);
                entity.Property(i => i.BirthDate).HasColumnName("birth_date");
            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.ToTable("courses");

                entity.Property(i => i.Id).HasColumnName("id").HasColumnType("int").UseIdentityColumn(1, 1);
                entity.Property(i => i.Name).HasColumnName("first_name").HasColumnType("varchar").HasMaxLength(100);
                entity.Property(i => i.IsActive).HasColumnName("is_active");
            });



            base.OnModelCreating(modelBuilder);
        }

    }
}
