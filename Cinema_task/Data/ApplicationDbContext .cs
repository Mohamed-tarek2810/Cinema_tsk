using Cinema_task.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema_task.Data
{
    public class ApplicationDbContext : DbContext 
    {

        public DbSet<Cinemas> Cinemas { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Actors> Actors { get; set; }
        public DbSet<ActorMovies> ActorMovies { get; set; }
      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=LAPTOP-F7MI2PIT\\MSSQLSERVERMO;Initial Catalog=Cinema_task;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;");
        }
    }
}
