using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WspoldzielniaMieszkaniowaDB.Models
{
    public class Klatka : Blok
    {

        [Required, MaxLength(5), Column("NrKlatki")]   // np 51A
        public string NrKlatki { get; set; }
        [Required, Column("OplatyZaMediaWspoldzielone")]
        public float Oplaty { get; set; }
        public void Configure(EntityTypeBuilder<Klatka> builder)
        {
            builder.Property(e => e.Rentowność).HasConversion<string>();
        }
    }
}
