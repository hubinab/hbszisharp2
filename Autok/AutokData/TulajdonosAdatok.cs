using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutokData
{
    public record TulajdonosAdatok(int TulajdonosId, int SzuletesiEv, string Nem)
    {
        public static TulajdonosAdatok? CreateFromCSV(string csvLine)
        {
            string[] values = csvLine.Split(';');
            if (values.Length != 3) return null;
            if (!int.TryParse(values[0], out int id)) return null;
            if (!int.TryParse(values[1], out int ev)) return null;
            return new TulajdonosAdatok(id, ev, values[2]);
        }

    }
}
