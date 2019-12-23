using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WspoldzielniaMieszkaniowaDB.Models
{
    public enum Rozrozniacz : byte { Klatka, Blok, Osiedlaa }

    [Table("OSIEDLA")]

    public class Osiedle : IEntityTypeConfiguration<Osiedle>
    {
        [Key, Column("Id")]
        public int Id { get; set; }

        [Column("NazwaOsiedla")]
        public string NazwaOs { get; set; }
        public Rentowność Rentowność { get; set; }

        public void Configure(EntityTypeBuilder<Osiedle> builder)
        {
                builder.Property<string>("RentownośćRozróżnianie").IsRequired().HasConversion<string>().
                    HasColumnName("TypSpółdzielni");
                builder.HasDiscriminator<string>("RentownośćRozróżnianie").
                    HasValue<Blok>(Rozrozniacz.Blok.ToString()).
                    HasValue<Klatka>(Rozrozniacz.Klatka.ToString()).
                    HasValue<Osiedle>(Rozrozniacz.Osiedlaa.ToString());
                builder.Property(e => e.Rentowność).HasConversion<string>()
                    .HasColumnName("WskaźnikRentowności");
        }
    }
}
