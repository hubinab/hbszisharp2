using AutokData;
using AutokLogic;

var logic = Logic.CreateFromCSV();

Console.WriteLine($"5. feladat: {logic.HanyJogsivalRendelkezoTulajVan()} jogosítvánnyal rendelkező tulajdonos található");
Console.WriteLine("Összes dizeles autó adatai:");
List<(Autok autok, List<string> tulaj)> x = logic.AutokAdatai("Dízel");
foreach (var auto in x)
{
    foreach (var nev in auto.tulaj)
    {
        Console.WriteLine($"\t{auto.autok.Marka} - {auto.autok.Modell} ({auto.autok.Uzemanyag}), {auto.autok.Szin}, {nev}");
    }    
}
