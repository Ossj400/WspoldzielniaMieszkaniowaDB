using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using System.Text;

namespace WspoldzielniaMieszkaniowaDB.Models
{
    [Table("Flat")]
    public class Mieszkanie
    {
        [Key, Column("Flat_ID")]
        public int FlatId { get; set; }

        [Required, Column("Flat_COST", TypeName = "money")]
        public decimal FlatCost { get; set; }

        [Required, Column("Family_ID")]
        public int FkFamilyId { get; set; }

        [ForeignKey(nameof(FkFamilyId))]
        public Rodzina Family { get; set; }

        public Piwnica Basement { get; set; }

        public ICollection<PraceElektryczne> ElectricWorks { get; set; }

    }
}
