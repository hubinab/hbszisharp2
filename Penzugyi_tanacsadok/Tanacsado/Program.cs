using System;
using Data;

namespace Tanacsado
{
    class Program
    {
        static void Main(string[] args)
        {
            Tarolo repo = new Tarolo();
            repo.SzakteruletekFeltoltese();
            repo.TalalkozokFeltoltese();
            repo.TanacsadokFeltoltese();
            repo.UgyfelekFeltoltese();
            repo.Ugyfelek.Add(new Ugyfel { });
            Console.WriteLine($"5. feladat: {repo.HosszabbTalalkozokSzama()} találkozó tartott legalább 3 órát");
            Console.Write("6. feladat: A tanácsadó neve: ");
            string nev = Console.ReadLine()!;
            if (nev != null)
            {
                var x = repo.TanacsadoAdatok(nev);
                if (x != (null, null))
                {
                    Console.WriteLine($"\tTelefon: {x.Value.tanacsado.Telefon}");
                    Console.WriteLine($"\tEmail: {x.Value.tanacsado.Email}");
                    Console.WriteLine($"\tSzakterület: {x.Value.szakterulet}");
                    Console.WriteLine($"\tÓradíj: {x.Value.tanacsado.Oradij} Ft");
                }
                else
                {
                    Console.WriteLine("\tIlyen néven nem található tanácsadó");
                }
            }
            List<(Data.Tanacsado tanacsado, int osszeg)> z = repo.Top3Legjobbankereso();
            if (z.Count != 0)
            {
                Console.WriteLine("7.feladat: A 3 legtöbbet kereső tanácsadó:");
                foreach (var item in z)
                {
                    Console.WriteLine($"\t{item.tanacsado.Nev}: {item.osszeg} Ft");
                }

            }
        }
    }
}
