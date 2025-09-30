using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift
{
    internal class Liftek
    {
        private readonly List<Lift> liftek;

        public Liftek()
        {
            liftek = new List<Lift>();
        }

        public Liftek(IEnumerable<Lift> liftek)
        {
            this.liftek = liftek.ToList();
        }

        public Lift this[int i]
        {
            get
            {
                if (i >= 0 && i < liftek.Count )
                {
                    return liftek[i];
                }
                else
                {
                    throw new IndexOutOfRangeException("Hibás index!");
                }
            }
        }
    }
}
