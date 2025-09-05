using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Tarolo
    {
        public List<Tanacsado> SzurtTanacsadok(int szakteruletid)
        { 
            return Tanacsadok.Where(t => t.SzakteruletId == szakteruletid)
                    .OrderBy(t => t.Nev)
                    .ToList();
        }
        public List<(Tanacsado tanacsado, int osszeg)> Top3Legjobbankereso()
        {
            return Tanacsadok.Select(t => (t,Talalkozok.Where(tal => tal.TanacsadoId == t.TanacsadoId).Sum(tal => tal.TalalkozoAra(t.Oradij))))
                .OrderByDescending(x => x.Item2)
                .Take(3)
                .ToList();
        }
        public int HosszabbTalalkozokSzama(int minOra = 3)
        {
            return Talalkozok.Count(t => t.Idotartam >= minOra);
        }
        public (Tanacsado tanacsado, string? szakterulet)? TanacsadoAdatok (string nev)
        {
            return Tanacsadok.Where(x => x.Nev == nev)
                    .Select(x => (x, Szakteruletek
                    .Where(s => s.SzakteruletId == x.SzakteruletId)
                    .Select(s => s.Megnevezes)
                    .FirstOrDefault()))
                    .FirstOrDefault();
        }
        public List<Ugyfel> Ugyfelek { get; private set; } = new();
        public List<Tanacsado> Tanacsadok { get; private set; } = new();
        public List<Szakterulet> Szakteruletek { get; private set; } = new();
        public List<Talalkozo> Talalkozok { get; private set; } = new();

        public void UgyfelekFeltoltese()
        {
            using (StreamReader fileBe = new StreamReader("ugyfel.csv"))
            {
                fileBe.ReadLine();
                string[] sorok = fileBe.ReadToEnd().Trim().Split('\n');
                foreach (var sor in sorok)
                {
                    string[] adatok = sor.Trim().Split(';');
                    Ugyfelek.Add(new Ugyfel 
                    { 
                        UgyfelId = int.Parse(adatok[0]), 
                        Nev = adatok[1], 
                        Telefon = adatok[2], 
                        Email = adatok[3] 
                    });
                }
            }
        }
        public void TalalkozokFeltoltese()
        {
            using (StreamReader fileBe = new StreamReader("talalkozo.csv"))
            {
                fileBe.ReadLine();
                string[] sorok = fileBe.ReadToEnd().Trim().Split('\n');
                foreach (var sor in sorok)
                {
                    string[] adatok = sor.Trim().Split(';');
                    Talalkozok.Add(new Talalkozo
                    {
                        TalalkozoId = int.Parse(adatok[0]), 
                        TanacsadoId = int.Parse(adatok[1]), 
                        UgyfelId = int.Parse(adatok[2]), 
                        Datum = DateOnly.Parse(adatok[3]), 
                        Idopont = TimeOnly.Parse(adatok[4]), 
                        Idotartam = int.Parse(adatok[5])
                    });
                }
            }
        }
        public void SzakteruletekFeltoltese()
        {
            using (StreamReader fileBe = new StreamReader("szakterulet.csv"))
            {
                fileBe.ReadLine();
                string[] sorok = fileBe.ReadToEnd().Trim().Split('\n');
                foreach (var sor in sorok)
                {
                    string[] adatok = sor.Trim().Split(';');
                    Szakteruletek.Add(new Szakterulet { SzakteruletId = int.Parse(adatok[0]), Megnevezes = adatok[1] });
                }
            }
        }
        public void TanacsadokFeltoltese()
        {
            using (StreamReader fileBe = new StreamReader("tanacsado.csv"))
            {
                fileBe.ReadLine();
                string[] sorok = fileBe.ReadToEnd().Trim().Split('\n');
                foreach (var sor in sorok)
                {
                    string[] adatok = sor.Trim().Split(';');
                    Tanacsadok.Add(new Tanacsado
                    {
                        TanacsadoId = int.Parse(adatok[0]), 
                        Nev = adatok[1], 
                        SzakteruletId = int.Parse(adatok[2]), 
                        Oradij = int.Parse(adatok[3]), 
                        Telefon = adatok[4], 
                        Email = adatok[5] 
                    });
                }
            }
        }
    }
}
