using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WspoldzielniaMieszkaniowaDB.Models;

namespace WspoldzielniaMieszkaniowaDB
{
    class Program
    {
        static void Main()
        {
            WspoldzielniaContext db = new WspoldzielniaContext();
            //var osiedle = new Osiedle() { NazwaOs = "Gwiazdy", Rentowność= Rentowność.Powyżej_Normy };
            //var blok = new Blok() { Nr = 1, Ulica = "Mochnackiego", NazwaOs=osiedle.NazwaOs, Rentowność = Rentowność.Norma,  };
            //var klatka = new Klatka() { NrKlatki = "A1", Oplaty = 8960, NazwaOs = osiedle.NazwaOs, Rentowność = Rentowność.Krytycznie_Niska,Ulica="Mochnackiego",Nr=2 };

            //var osiedle1 = new Osiedle() { NazwaOs = "Szombierki", Rentowność = Rentowność.Powyżej_Normy };
            //var blok1 = new Blok() { Nr = 10, Ulica = "Wyzwolenia", NazwaOs = osiedle.NazwaOs, Rentowność = Rentowność.Norma, };
            //var klatka1 = new Klatka() { NrKlatki = "B", Oplaty = 8960, NazwaOs = osiedle.NazwaOs, Rentowność = Rentowność.Krytycznie_Niska, Ulica = "Wyzwolenia", Nr = 22 };

            //var osiedle2 = new Osiedle() { NazwaOs = "Bobrek", Rentowność = Rentowność.Krytycznie_Niska };
            //var blok2 = new Blok() { Nr = 1, Ulica = "Wolności", NazwaOs = osiedle.NazwaOs, Rentowność = Rentowność.Poniżej_Normy, };
            //var klatka2 = new Klatka() { NrKlatki = "Z1", Oplaty = 8960, NazwaOs = osiedle.NazwaOs, Rentowność = Rentowność.Krytycznie_Niska, Ulica = "Wolności", Nr = 21 };
            //db.Add(osiedle);
            //db.Add(blok);
            //db.Add(klatka);
            //db.Add(osiedle1);
            //db.Add(blok1);
            //db.Add(klatka1);
            //db.Add(osiedle2);
            //db.Add(blok2);
            //db.Add(klatka2);
            //db.SaveChanges();

            Rodzina rodzina = new Rodzina { FamilyId = 0 , FamilySurname = "Nowak" };
            Elektryk elektryk = new Elektryk { ElectricianId = 0, ElName = "Adam", ElSurname = "Hofman" };
            Mieszkanie mieszkanie = new Mieszkanie {  FlatId = 1, FlatCost = 100};
            PraceElektryczne praceElektryczne = new PraceElektryczne { FlatId = 1, Cost = 100, WorkDate = DateTime.Now };
            db.Add(rodzina);
            db.Add(elektryk);
            db.Add(mieszkanie);
            db.Add(praceElektryczne);
            db.SaveChanges();
            var mieszkania = db.ElectricWorks
            .Include(a => a.Flat)
             .ThenInclude(a => a.Family)
             .ToList();
            foreach (var m in mieszkania)
            {
                Console.WriteLine($"Numer mieszkania: {m.FlatId}");
                Console.WriteLine($"Posiada następujące terminy prac elektrycznych: ");
                foreach (var x in m.ElectricWorks)
                {
                    Console.WriteLine($" {x.ElectricWorks.WorkDate}");
                }
                Console.WriteLine("========================");
            }

        

        }
    }
}
