using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lift
{
    internal class Lift : IMozog
    {
        public int EmeletSzam { get; init; }
        private int AktEmelet { get; set; }
        public Lift(int emeletszam) 
        {
            EmeletSzam = emeletszam;
            AktEmelet = new Random().Next(1, EmeletSzam);
        }
        public void felfele()
        {
            if (AktEmelet == EmeletSzam)
            {
                throw new HibasIranyException();
            }
            else
            {
                AktEmelet++;
            }
        }

        public void lefele()
        {
            if (AktEmelet == 1)
            {
                throw new HibasIranyException();
            }
            else
            {
                AktEmelet--;
            }
        }

        public override string ToString()
        {
            return $"Aktuális emelet: {AktEmelet}, Emeletek száma: {EmeletSzam}";
        }
    }
}
