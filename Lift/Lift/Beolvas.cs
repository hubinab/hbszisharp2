using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift
{
    internal class Beolvas
    {
        static void Main() 
        {
            string fajlNev = "input.txt";
            Liftek liftek = new Liftek();
            if (!File.Exists(fajlNev))
            {
                throw new FileNotFoundException($"A(z) {fajlNev} allomany nem talalhato!");
            }

            var sorok = File.ReadAllLines(fajlNev);
            string? line = sorok[0] ?? "0";
            int db = int.Parse(line);
            int szam = 0;
            List<Lift> liftekLista = new List<Lift>();
            if (db != 0)
            {
                for (int i = 1; i <= db; i++)
                {
                    line = sorok[i] ?? "0";
                    szam = int.Parse(line);
                    if (szam != 0)
                    {
                        liftekLista.Add(new Lift(szam));
                    }
                }
                liftek = new Liftek(liftekLista);
            }
            foreach (var item in liftekLista)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------------------------");

            for (int i = db+1; i < sorok.Length; i++)
            {
                string sor = sorok[i];
                var reszek = sor.Split(";");
                int lift = int.Parse(reszek[0])-1;
                string mozgas = reszek[1];
                if (mozgas == "fel")
                {
                    liftek[lift].felfele();
                }
                else
                {
                    liftek[lift].lefele();
                }
                Console.WriteLine(liftek[lift]);
            }
        }
    }
}
