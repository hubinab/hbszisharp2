using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutokData
{
    public record Tulajdonosok(int TulajdonosId, string TulajdonosNev, string Jogositvany, string JogositvanyMegszIdeje, string Modell)
    {
        static readonly string DateFormat = "yyyy.MM.dd";
        public static Tulajdonosok? CreateFromCSV(string csvLine)
        {
            string[] values = csvLine.Split(';');
            if (values.Length != 5) return null;
            if (!int.TryParse(values[0], out int id)) return null;
            if (values[3] != "-") 
            {
                if (!DateOnly.TryParseExact(values[3], DateFormat, out DateOnly _)) return null;
            }
            return new Tulajdonosok(id, values[1], values[2], values[3], values[4]);
        }
        public DateOnly DatumDate = JogositvanyMegszIdeje == "-" ? DateOnly.FromDateTime(DateTime.Now) : DateOnly.ParseExact(JogositvanyMegszIdeje, DateFormat);
    }
}
