using System.Globalization;
using System.Reflection;

namespace LINQGyak2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Diak> diakok = File.ReadAllLines("diakok.csv")
                .Skip(1)
                .Select(sor =>
                {
                    string[] adatok = sor.Split(";");
                    return new Diak(
                        adatok[0],
                        int.Parse(adatok[1]),
                        adatok[2],
                        double.Parse(adatok[3], CultureInfo.GetCultureInfo("hu-HU"))
                    );
                })
                .ToList();
            /*

            var eredmeny = diakok.Where(d => d.Eletkor >= 18 && d.Atlag >= 4.0);

            foreach (Diak d in eredmeny)
            {
                Console.WriteLine($"{d.Nev}, {d.Eletkor} éves, átlaga: {d.Atlag}");
            }

            var eredmeny = diakok.Where(d => d.Osztaly == "11A" || d.Osztaly == "13A");

            foreach (Diak d in eredmeny)
            {
                Console.WriteLine($"{d.Nev}, osztálya: {d.Osztaly}");
            }

            var eredmeny = diakok.Where(d => d.Osztaly != "12B");

            foreach (Diak d in eredmeny)
            {
                Console.WriteLine($"{d.Nev}, osztálya: {d.Osztaly}");
            }


            foreach (Diak d in diakok)
            {
                Console.WriteLine($"{d.Nev}");
            }

            var nevek = diakok.Select(d => d.Nev);

            foreach (string nev in nevek)
            {
                Console.WriteLine(nev);
            }

            var eletkorok = diakok.Select(d => d.Eletkor * 2);

            foreach (int eletkor in eletkorok)
            {
                Console.WriteLine(eletkor);
            }

            var adatok = diakok.Select(d => new
            {
                d.Nev,
                d.Osztaly
            });

            foreach (var adat in adatok)
            {
                Console.WriteLine($"{adat.Nev}, osztály: {adat.Osztaly}");
            }

            var sorok = diakok.Select(d => $"{d.Nev} {d.Osztaly}");

            foreach (string sor in sorok)
            {
                Console.WriteLine(sor);
            }

            var nevek = diakok.Where(d => d.Atlag >= 4.0).Select(d => d.Nev);

            foreach (string nev in nevek)
            {
                Console.WriteLine(nev);
            }

            var eredmeny = diakok.OrderBy(d => d.Eletkor);

            foreach (Diak d in eredmeny)
            {
                Console.WriteLine($"{d.Nev}, életkor: {d.Eletkor}");
            }


            var eredmeny = diakok.OrderByDescending(d => d.Atlag);

            foreach (Diak d in eredmeny)
            {
                Console.WriteLine($"{d.Nev}, átlag: {d.Atlag}");
            }

            var eredmeny = diakok.OrderBy(d => d.Osztaly).ThenByDescending(d => d.Atlag);

            foreach (Diak d in eredmeny)
            {
                Console.WriteLine($"{d.Nev} {d.Osztaly} {d.Atlag}");
            }

            var eredmeny = diakok.OrderByDescending(d => d.Atlag).Take(3);

            foreach (Diak d in eredmeny)
            {
                Console.WriteLine($"{d.Nev} {d.Atlag}");
            }

            var eredmeny = diakok.OrderByDescending(d => d.Atlag).Skip(3);

            foreach (Diak d in eredmeny)
            {
                Console.WriteLine($"{d.Nev} {d.Atlag}");
            }

            Diak elso = diakok.First();
            Console.WriteLine(elso.Nev);

            Diak? keresett = diakok.FirstOrDefault(d=> d.Nev == "Zoltán");

            if(keresett == null)
            {
                Console.WriteLine("Nincs ilyen diák");
            }
            else
            {
                Console.WriteLine(keresett.Nev);
            }

            Diak? legjobb = diakok.Where(d => d.Atlag >= 4.5).FirstOrDefault();

            Console.WriteLine($"{legjobb.Nev}, {legjobb.Atlag}");

            Diak? legjobb = diakok.OrderByDescending(d => d.Atlag).FirstOrDefault();
            
            Console.WriteLine($"{legjobb.Nev}, {legjobb.Atlag}");

            Diak utolso = diakok.Last();

            Console.WriteLine(utolso.Nev);

            Diak diak = diakok.Single(d => d.Nev == "Anna");
            Console.WriteLine(diak.Nev);

            bool vanJelesTanulo = diakok.Any(d => d.Atlag >= 4.5);

            Console.WriteLine(vanJelesTanulo? "Van": "Nincs");

            int osszesen = diakok.Count();
            Console.WriteLine(osszesen);

            int nagykoruak = diakok.Count(d => d.Eletkor >= 18);
            Console.WriteLine(nagykoruak);

            int osszeg = diakok.Sum(d => d.Eletkor);
            Console.WriteLine(osszeg);

            double atlagEletkor = diakok.Average(d => d.Eletkor);
            Console.WriteLine(atlagEletkor);

            double legroszabb = diakok.Min(d => d.Atlag);
            double legjobb = diakok.Max(d => d.Atlag);
            Console.WriteLine(legroszabb);
            Console.WriteLine(legjobb);

            var osztalyok = diakok.Select(d => d.Osztaly).Distinct();
            foreach (var osztaly in osztalyok)
            {
                Console.WriteLine(osztaly);
            }

            var csoportok = diakok.GroupBy(d => d.Osztaly);

            foreach (var csoport in csoportok)
            {
                Console.WriteLine(csoport.Key);

                foreach (Diak d in csoport)
                {
                    Console.WriteLine(d.Nev);
                }
            }
            var eredmeny = diakok.GroupBy(d => d.Osztaly).Select(csoport => new
            {
                Osztaly = csoport.Key,
                Letszam = csoport.Count()

            });
                foreach (var adat in eredmeny)
            {
                Console.WriteLine($"Osztály: {adat.Osztaly}: {adat.Letszam} fő");
            }

            var eredmeny = diakok.Where(d => d.Atlag >= 4.0);
            diakok.Add(new Diak("Iván", 18, "12.B", 4.9));

            foreach (Diak d in eredmeny)
            {
                Console.WriteLine(d.Nev);
            }

            //#1
            var eredmeny = diakok.GroupBy(d => d.Osztaly);

            foreach (var csoport in eredmeny)
            {
                Console.WriteLine($"{csoport.Key}: {csoport.Average(d => d.Atlag)}");
            }

            //#2
            var eredmeny = diakok.GroupBy(d => d.Osztaly)
                .Select(csoport => new
                {
                    Osztaly = csoport.Key,
                    Atlag = csoport.Average(d => d.Atlag)
                })
                .OrderByDescending(c => c.Atlag);

                foreach (var osztaly in eredmeny)
                {
                    Console.WriteLine($"{osztaly.Osztaly}: {osztaly.Atlag}");
                }

            //#3
            var eredmeny = diakok.GroupBy(d => d.Osztaly);

            foreach (var csoport in eredmeny)
            {
                Diak legjobb = csoport.OrderByDescending(d => d.Atlag).First();

                Console.WriteLine($"{csoport.Key}: {legjobb.Nev}, átlaga: {legjobb.Atlag}");
            }

            //#4
            var eredmeny = diakok.GroupBy(d => d.Eletkor);

            foreach (var csoport in eredmeny)
            {
                Console.WriteLine($"{csoport.Key} éves: {csoport.Count()} fő");
            }

            //#5
            var eredmeny = diakok.GroupBy(d => d.Osztaly);

            foreach (var csoport in eredmeny)
            {
                double legjobbAtlag = csoport.Max(d => d.Atlag);

                var legjobbak = csoport.Where(d => d.Atlag == legjobbAtlag);

                foreach (Diak d in legjobbak)
                {
                    Console.WriteLine($"{csoport.Key}: {d.Nev}, átlaga: {d.Atlag}");
                }
            }
            */

            //#6
            var eredmeny = diakok.Where(d => d.Atlag < 2.0);

            if (eredmeny.Any())
            {
                foreach (Diak d in eredmeny)
                {
                    Console.WriteLine(d.Nev);
                }
            }
            else
            {
                Console.WriteLine("Nincs 2.0 alatti átlagú diák.");
            }
        }
    }
}
