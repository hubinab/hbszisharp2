using AutokLogic;

var logic = Logic.CreateFromCSV();

Console.WriteLine($"5. feladat: {logic.HanyJogsivalRendelkezoTulajVan()} jogosítvánnyal rendelkező tulajdonos található");
Console.WriteLine("Összes dizeles autó adatai:");
var x = logic.AutokAdatai("Dízel");
foreach (var auto in x)
{
    foreach (var nev in auto.tulaj)
    {
        Console.WriteLine($"\t{auto.autok.Marka} - {auto.autok.Modell} ({auto.autok.Uzemanyag}), {auto.autok.Szin}, {nev}");
    }    
}

Console.Write("7. feladat: A tulajdonos neve: ");
var tulaj = logic.NevSzerint(Console.ReadLine()!);

if  (tulaj is null)
{
    Console.WriteLine("Ilyen néven nem található tulajdonos!");
}
else
{
    Console.WriteLine($"\tSzületési év: {tulaj.Value.tulajadatok.SzuletesiEv}");
    Console.WriteLine($"\tNév: {tulaj.Value.tulaj.TulajdonosNev}");
    Console.WriteLine($"\tMárka: {tulaj.Value.autok.Marka}");
    Console.WriteLine($"\tModell: {tulaj.Value.autok.Modell}");
    Console.WriteLine($"\tJogosítvány: {tulaj.Value.tulaj.Jogositvany}");
}

Console.WriteLine("8. feladat: A 2 legidősebb dízel");

var h = logic.KetLegidosebbDiesel();

if (h.Count != 0)
{
    foreach (var item in h)
    {
        Console.WriteLine($"\t{item.tulaj.TulajdonosNev} ({item.autok.Marka} - {item.autok.Modell}), {item.tulajadatok.Nem}, {item.tulajadatok.SzuletesiEv}");
    }
}