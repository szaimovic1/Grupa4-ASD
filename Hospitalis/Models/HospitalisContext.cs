using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace HospitalisOOAD.Models
{
    public class HospitalisContext : DbContext
    {
        public HospitalisContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Doktor> doktori { get; set; }
        public DbSet<Pacijent> pacijenti { get; set; }
        public DbSet<InfoAplikacije> infoA { get; set; }
        public DbSet<InfoBolnice> infoB { get; set; }
        public DbSet<Anketa> ankete { get; set; }
        public DbSet<Admin> admin { get; set; }
        public DbSet<Pregled> pregledi { get; set; }
        public Dictionary<Pregled, bool> zakazaniPregledi { get; set; }
        public DbSet<Obavjestenje> obavjestenja { get; set; }
        public DbSet<Dokumentacija> dokumentacije { get; set; }
        public DbSet<Izvjestaj> izvjestaji { get; set; }
        public DbSet<Recept> recepti { get; set; }
        public DbSet<Uputnica> uputnice { get; set; }
        public DbSet<Korisnik> korisnici { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doktor>().ToTable("Doktor");
            modelBuilder.Entity<Pacijent>().ToTable("Pacijent");
            modelBuilder.Entity<InfoAplikacije>().ToTable("InfoAplikacije");
            modelBuilder.Entity<InfoBolnice>().ToTable("InfoBolnice");
            modelBuilder.Entity<Anketa>().ToTable("Anketa");
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<Pregled>().ToTable("Pregled");
            modelBuilder.Entity<Obavjestenje>().ToTable("Obavjestenje");
            modelBuilder.Entity<Dokumentacija>().ToTable("Dokumentacija");
            modelBuilder.Entity<Izvjestaj>().ToTable("Izvjestaj");
            modelBuilder.Entity<Recept>().ToTable("Recept");
            modelBuilder.Entity<Uputnica>().ToTable("Uputnica");
            modelBuilder.Entity<Korisnik>().ToTable("Korisnik");
        }
    }
}
