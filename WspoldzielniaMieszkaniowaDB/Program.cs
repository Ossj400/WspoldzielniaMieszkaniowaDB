using System;
using WspoldzielniaMieszkaniowaDB.Models;

namespace WspoldzielniaMieszkaniowaDB
{
    class Program
    {
        static void Main()
        {
            WspoldzielniaContext db = new WspoldzielniaContext();
            var osiedle = new Osiedle() { NazwaOs = "Gwiazdy", Rentowność= Rentowność.Powyżej_Normy };
            var blok = new Blok() { Nr = 1, Ulica = "Mochnackiego", NazwaOs=osiedle.NazwaOs, Rentowność = Rentowność.Norma,  };
            var klatka = new Klatka() { NrKlatki = "A1", Oplaty = 8960, NazwaOs = osiedle.NazwaOs, Rentowność = Rentowność.Krytycznie_Niska,Ulica="Mochnackiego",Nr=2 };
            db.Add(osiedle);
            db.Add(blok);
            db.Add(klatka);
            db.SaveChanges();

            foreach (var d in db.Osiedla)
            {
                Console.WriteLine($"Rentownosc : {d.Rentowność}");
            }

            //foreach (var p in db.Bloki)
            //{
            //      Console.WriteLine($"Rentowność w blokach, tzn. ogolnie: {p.Rentowność}");
            //}

        }
    }
}
