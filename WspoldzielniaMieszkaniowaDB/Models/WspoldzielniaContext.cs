using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace WspoldzielniaMieszkaniowaDB.Models
{
    public class WspoldzielniaContext : DbContext
    {
        public DbSet<Piwnica> Basements { get; set; }
        public DbSet<Rodzina> Families { get; set; }
        public DbSet<Mieszkanie> Flats { get; set; }
        public DbSet<Mieszkaniec> Occupants { get; set; }
        public DbSet<PraceElektryczne> ElectricWorks { get; set; }
        public DbSet<Elektryk> Electricians { get; set; }
        public DbSet<Osiedle> Osiedla { get; set; }
        public DbSet<Blok> Bloki { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=OSSJ\SQLEXPRESS;Initial Catalog=WspolMieszk.NET2;Integrated Security=True;Pooling=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //piwnica

            modelBuilder.Entity<Piwnica>()
               .ToTable("Basement");


           modelBuilder.Entity<Piwnica>()
            .HasKey(k=>k.BasementId);

            modelBuilder.Entity<Piwnica>()
                .Property(e => e.BasementId)
                .HasColumnName("BASEMENT ID");

            modelBuilder.Entity<Mieszkanie>()
                .HasOne(f => f.Basement)
                .WithOne(b => b.Flat)
                .HasForeignKey<Piwnica>(b => b.FlatId);

            //rodzina

            modelBuilder.Entity<Rodzina>()
               .ToTable("Family");


            modelBuilder.Entity<Rodzina>()
                .HasKey(k => k.FamilyId);

            modelBuilder.Entity<Rodzina>()
                .Property(e => e.FamilyId)
                .HasColumnName("FAMILY_ID");

            modelBuilder.Entity<PraceElektryczne>()
                 .HasKey(k => k.FlatId);
            modelBuilder.Entity<PraceElektryczne>()
                 .HasKey(k => k.WorkId);

            //mieszkanie: interwencja-elektryczna
            modelBuilder.Entity<Mieszkanie>()
                 .HasMany(c => c.ElectricWorks)
                 .WithOne(e => e.Flat);


            modelBuilder.Entity<ZleceniaElektryków>()
                .HasKey(bc => new { bc.ElectricianId, bc.ElectricianWorkId });
            modelBuilder.Entity<ZleceniaElektryków>()
                .HasOne(bc => bc.Electrician)
                .WithMany(b => b.ElectricWorks)
                .HasForeignKey(bc => bc.ElectricianId);
            modelBuilder.Entity<ZleceniaElektryków>()
                .HasOne(bc => bc.ElectricWorks)
                .WithMany(c => c.ElectricWorks)
                .HasForeignKey(bc => bc.ElectricianWorkId);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Klatka).Assembly);
        }

    }
}
