using Microsoft.EntityFrameworkCore;

namespace ZaFirmu.Data
{
    public class MojContext : DbContext
    {
        public MojContext(DbContextOptions options) : base(options) { }

        public DbSet<Student> Student { get; set; }
    
        public DbSet<Statuscs> Statuscs { get; set; }
          
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    StudentId = 1,
                    brIndeksa = 12,
                    Ime = "Petrovic",
                    Prezime = "Petar",
                    Godina = "2018",
                    IDStatusa = 1
                },
                new Student()
                {
                    StudentId = 2,
                    brIndeksa = 14,
                    Ime = "Goranj",
                    Prezime = "Njegos",
                    Godina = "2019",
                    IDStatusa = 2
                }
                );

            modelBuilder.Entity<Statuscs>().HasData(
                new Statuscs()
                {
                    StutusStudenta = 1,
                    NazivStatusa = "Redovan"
                },
                 new Statuscs()
                 {
                     StutusStudenta = 2,
                     NazivStatusa = "Vanredan"
                 }
                );
                    }
    }
}
