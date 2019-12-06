using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WspoldzielniaMieszkaniowaDB.Models
{
    [Table("Electric_Works")]
    public class PraceElektryczne
    {


        [Required]
        [Key, Column("WorkID")]
        public int WorkId { get; set; }

        [ForeignKey(nameof(FlatId))]
        public Mieszkanie Flat { get; set; }

        [Required]
        [Key, Column("Flat_ID")]
        public int FlatId { get; set; }

        [Required, Column("COST", TypeName = "money")]
        public decimal Cost { get; set; }

        [Required, Column("DATE")]
        public DateTime WorkDate { get; set; }

        public ICollection<ZleceniaElektryków> ElectricWorks { get; set; }

    }
}
