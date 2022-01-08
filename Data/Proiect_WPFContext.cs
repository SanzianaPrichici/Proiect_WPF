using Microsoft.EntityFrameworkCore;
using Proiect_WPF.Models;

namespace Proiect_WPF.Data
{
    public class Proiect_WPFContext : DbContext
    {
        public Proiect_WPFContext (DbContextOptions<Proiect_WPFContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_WPF.Models.Bilet> Bilet { get; set; }

        public DbSet<Proiect_WPF.Models.Client> Client { get; set; }

        public DbSet<Proiect_WPF.Models.Zbor> Zbor { get; set; }

        public DbSet<Proiect_WPF.Models.Aeroport> Aeroport { get; set; }
    }
}
