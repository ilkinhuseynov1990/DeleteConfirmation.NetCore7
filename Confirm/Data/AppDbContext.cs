using Confirm.Models;
using Microsoft.EntityFrameworkCore;

namespace Confirm.Data
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {   
        }

        public DbSet<Student> students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.
                Entity<Student>().
                HasData(
                new Student { Id = 1 , Name="Resul" , Surname="Aliyarov" ,Age = 25 },
                new Student { Id = 2 , Name="Ayan" , Surname="Haciyeva" ,Age = 25 },
                new Student { Id = 3 , Name="Novruz" , Surname="Tarverdiyev" ,Age = 25 }
                ) ;
        }
    }
}
