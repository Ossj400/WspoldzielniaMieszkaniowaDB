using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WspoldzielniaMieszkaniowaDB.Models
{
    public class Rodzina
    {
        public int FamilyId { get; set; }
        public int FamilySurname { get; set; }
        public Mieszkanie Mieszkania { get; set; }



    }
}
