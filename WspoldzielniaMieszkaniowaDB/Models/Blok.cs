using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WspoldzielniaMieszkaniowaDB.Models
{
    public class Blok : Osiedle, IEntityTypeConfiguration<Osiedle>
    {
        [Required, Column("NumerBloku")]
        public int Nr { get; set; }

        [Required, MaxLength(80), Column("Ulica")]
        public string Ulica { get; set; }
        public void Configure(EntityTypeBuilder<Blok> builder)
        {
            builder.Property(e => e.Rentowność).HasConversion<string>();
        }
    }
}
