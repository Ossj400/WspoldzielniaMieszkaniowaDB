using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WspoldzielniaMieszkaniowaDB.Models
{
    [Table("ElectricianJob")]
    public class  ZleceniaElektryków
    {
        [Key, Column("Electrician_ID")]
        public int ElectricianId { get; set; }

        public Elektryk Electrician { get; set; }


        [Key, Column("ElectricianWorkID")]
        public int ElectricianWorkId { get; set; }

        public PraceElektryczne ElectricWorks { get; set; }
    }
}
