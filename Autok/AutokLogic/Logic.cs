using AutokData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutokLogic;
public class Logic
{
    readonly List<Autok> autok = [];
    readonly List<Tulajdonosok> tulajdonosok = [];
    readonly List<TulajdonosAdatok> tulajdonosadatok = [];

    private Logic() { }
    public static Logic CreateFromCSV(string directory = "TestData")
    {
        Logic logic = new();
        File.ReadLines(Path.Combine(directory, "autok.csv"))
            .Skip(1)
            .Select(Autok.CreateFromCSV)
            .Where(a => a is not null)
            .ToList()
            .ForEach(a => logic.autok.Add(a!));
        File.ReadLines(Path.Combine(directory, "tulajdonosok.csv"))
            .Skip(1)
            .Select(Tulajdonosok.CreateFromCSV)
            .Where(t => t is not null)
            .ToList()
            .ForEach(t => logic.tulajdonosok.Add(t!));
        File.ReadLines(Path.Combine(directory, "tulajdonosadatok.csv"))
            .Skip(1)
            .Select(TulajdonosAdatok.CreateFromCSV)
            .Where(t => t is not null)
            .ToList()
            .ForEach(t => logic.tulajdonosadatok.Add(t!));
        return logic;
    }
    public int HanyEveVanJogositvanya(int id)
    {
        var tulajdonos = tulajdonosok.First(x => x.TulajdonosId == id);
        // Ez nem tökéletes, mert ha éjfél előtt futtatjuk,
        // de átér a kövi napra, akkor 1-et fog adni 0-a helyett,
        // ha "-" van a JogositvanyMegszIdeje-ben.
        return DateTime.Now.Year - tulajdonos.DatumDate.Year;
    }
    public int HanyJogsivalRendelkezoTulajVan()
    {
        return tulajdonosok.Count(x => x.JogositvanyMegszIdeje != "-");
    }

    public List<(Autok autok, List<string> tulaj)> AutokAdatai(string uzemanyag)
    {
        return autok.Where(x => x.Uzemanyag == uzemanyag).Select(x => (x, tulajdonosok.Where(y => y.Modell == x.Modell).Select(y => y.TulajdonosNev).ToList())).ToList();
    }

    public (Tulajdonosok tulaj, TulajdonosAdatok tulajadatok, Autok autok)? NevSzerint(string nev)
    {
        var tulajdonos = tulajdonosok.FirstOrDefault(t => t.TulajdonosNev == nev);
        if (tulajdonos is null)
        {
            return null;
        }
        else
        {
            return (tulajdonos, tulajdonosadatok.FirstOrDefault(x => x.TulajdonosId == tulajdonos.TulajdonosId), autok.FirstOrDefault(x => x.Modell == tulajdonos.Modell))!;
        }
    }
    public List<(Tulajdonosok tulaj, Autok autok, TulajdonosAdatok tulajadatok)> KetLegidosebbDiesel()
    {
        // A .ToList()-re figyelmeztetést dobott, ezért lett a [.. ], amit jevasolt(nem az ai)
        return [.. tulajdonosok.Join(autok, Tulajdonosok => Tulajdonosok.Modell, Autok => Autok.Modell, 
                                    (Tulajdonosok, Autok) => (Tulajdonosok, Autok)).Where(x => x.Autok.Uzemanyag == "Dízel")
                               .Join(tulajdonosadatok, Tulajdonosok => Tulajdonosok.Tulajdonosok.TulajdonosId, TulajdonosAdatok => TulajdonosAdatok.TulajdonosId,
                                    (Tulajdonosok, TulajdonosAdatok) => (Tulajdonosok.Tulajdonosok, Tulajdonosok.Autok, TulajdonosAdatok))
                               .OrderBy(x => x.TulajdonosAdatok.SzuletesiEv).Take(2)];
    }
}
