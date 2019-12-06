using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WspoldzielniaMieszkaniowaDB.Models
{
    [Table("Electricians")]
    public class Elektryk
    {
        [Key, Column("Electrician_ID")]
        public int ElectricianId { get; set; }

        [Required, MaxLength(20), Column("EL_FIRTS_NAME")]
        public string ElName { get; set; }

        [Required, MaxLength(20), Column("EL_LAST_NAME")]
        public string ElSurname { get; set; }

        public ICollection<ZleceniaElektryków> ElectricWorks { get; set; }


    }
}
