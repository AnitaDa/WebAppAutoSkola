using EAutoSkola.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace EAutoSkola.EF
{
    public class MyContext : IdentityDbContext<Korisnik,Rola, string>
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
       
        public MyContext() { }
        public DbSet<Kategorija> Kategorije { get; set; }
        public DbSet<Kandidat> Kandidati { get; set; }
        public DbSet<Uposlenik> Uposlenici { get; set; }
        public DbSet<TipUposlenika> TipUposlenika { get; set; }
        public DbSet<Uplata> Uplate { get; set; }
        public DbSet<UposlenikTipUposlenika> uposlenikTipUposlenika{ get; set; }
        public DbSet<Usluga> Usluge { get; set; }
        public DbSet<Vozilo> Vozila { get; set; } 
        public DbSet<RasporedCasova> RasporedCasova { get; set; }
        public DbSet<Satnica> Satnica { get; set; }
        public DbSet<TerminRasporedaCasova> TerminRasporedaCasova { get; set; }
        public DbSet<Plata> Plata { get; set; }
        public DbSet<ZdrastveniRadnik> ZdrastveniRadnik { get; set; }
        public DbSet<LjekarskoUvjerenje> LjekarskoUvjerenje { get; set; }
        public DbSet<Zahtjev> Zahtjev { get; set; }
        public DbSet<Potvrda> Potvrde { get; set; }
        public DbSet<RasporedPolaganja> RasporedPolaganja { get; set; }
        public DbSet<TerminRasporedPolaganja> TerminRasporedPolaganja { get; set; }



        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=(local);Database=EAutoSkola;trusted_connection=true;");

    }
}
