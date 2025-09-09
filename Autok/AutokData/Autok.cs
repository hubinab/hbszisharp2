using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutokData;
public record Autok(string Marka, string Modell, string Uzemanyag, string Szin)
{
    public static Autok? CreateFromCSV(string csvLine)
    {
        string[] values = csvLine.Split(';');
        if (values.Length != 4) return null;
        return new Autok(values[0], values[1], values[2], values[3]);
    }
}
