using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WspoldzielniaMieszkaniowaDB.Models
{
    [Table("Occupant")]

    public class Mieszkaniec
    {
        [Key, Column("Occupant_ID")]
        public int OccupantId { get; set; }

        [Required, MaxLength(20), Column("NAME")]
        public string Name { get; set; }

        [Required, MaxLength(20), Column("SURNAME")]
        public string Surname { get; set; }

        [Required, Column("Occupant_Age")]
        public int Age { get; set; }

        [Required, Column("Family_ID")]
        public int FkFamilyId { get; set; }

        [ForeignKey(nameof(FkFamilyId))]
        public Rodzina Family { get; set; }


    }
}
