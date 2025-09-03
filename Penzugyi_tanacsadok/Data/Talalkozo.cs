using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data 
{
    public class Talalkozo
    {
        public int TalalkozoId {  get; set; }
        public int TanacsadoId { get; set; }
        public int UgyfelId { get; set; }
        public DateOnly Datum {  get; set; }
        public TimeOnly Idopont {  get; set; }
        public int Idotartam {  get; set; }
        public int TalalkozoAra(int oradij) => oradij * Idotartam;

    }
}
