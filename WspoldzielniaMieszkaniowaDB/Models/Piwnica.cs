using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WspoldzielniaMieszkaniowaDB.Models
{
    public class Piwnica
    {  
        public int BasementId { get; set; }
        public int FlatId { get; set; }
        public Mieszkanie Flat { get; set; }
    }
}
