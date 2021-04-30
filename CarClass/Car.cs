using System;
using System.Collections.Generic;

/*
La un târg de mașini trebuie înregistrate toate mașinile care au fost vândute (cumpărate).
Pentru fiecare mașină se vor indica: nume vânzător, nume cumpărător, tip mașină (nume
firmă + model, exp.: Firma: Opel, Model: Astra 1.4), an fabricație, culoare, optiuni, data
tranzacție, preț. Pe lângă operațiile de introducere, editare și ștergere, aplicația trebuie să
afișeze următoarele rapoarte:
• cea mai căutată mașină ca și firmă sau ca model, într-o anumită perioadă;
• un grafic al prețului pentru un anumit model, pe o anumită perioadă de timp;
• afișarea tranzacțiilor dintr-o anumită zi.
Observație: la introducerea unei noi tranzacții, se va avertiza printr-un mesaj dacă există o
persoană care cumpără mai multe mașini în aceeași zi sau dacă o persoană vinde mai multe
mașini în aceeași zi.
*/

namespace CarClass
{
    public class Car
    {
        private const string SEPARATOR_AFISARE = " ";
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const char SEPARATOR_SECUNDAR_FISIER = ',';

        private const int FIRMA = 0;
        private const int MODEL = 1;
        private const int ANFABRICATIE = 2;
        private const int CULOARE = 3;
        private const int PRET = 4;
        private const int NUMEVANZATOR = 5;
        private const int NUMECUMPARATOR = 6;
        private const int DATATRANZACTIE = 7;
        private const int OPTIUNI = 8;


        public string NumeVanzator { get; set; }
        public string NumeCumparator { get; set; }
        public string Firma { get; set; }
        public string Model { get; set; }
        public int AnFabricatie { get; set; }
        public string Culoare { get; set; }
        public List<string> Optiuni { get; set; }
        public DateTime DataTranzactie { get; set; }
        public float Pret { get; set; }

        public Car() { }

        public Car(string info)
        {
            string[] splitInfo = info.Split(',');
            Firma = splitInfo[FIRMA];
            Model = splitInfo[MODEL];
            AnFabricatie = int.Parse(splitInfo[ANFABRICATIE]);
            Culoare = splitInfo[CULOARE];
            Pret = int.Parse(splitInfo[PRET]);
            NumeVanzator = splitInfo[NUMEVANZATOR];
            NumeCumparator = splitInfo[NUMECUMPARATOR];
            DataTranzactie = DateTime.Parse(splitInfo[DATATRANZACTIE]);

            List<string> opt = new List<string>();
            for (int i = OPTIUNI; i < splitInfo.Length; i++)
                opt.Add(splitInfo[i]);
            Optiuni = opt;
        }

        public static Car ReadCarInfo()
        {
            string carInfo = string.Empty;
            Console.WriteLine("Introduceti informatiile despre masina:");

            Console.Write("Firma: ");
            carInfo = carInfo + Console.ReadLine().ToUpper() + ",";//Firma
            Console.Write("Model: ");
            carInfo = carInfo + Console.ReadLine().ToUpper() + ",";//Model
            Console.Write("An Fabricatie: ");
            carInfo = carInfo + Console.ReadLine() + ",";          //An fabricatie
            Console.Write("Culoare: ");
            carInfo = carInfo + Console.ReadLine().ToUpper() + ",";//Culoare
            Console.Write("Pret: ");
            carInfo = carInfo + Console.ReadLine() + ",";          //Pret
            Console.Write("Nume vanzator: ");
            carInfo = carInfo + Console.ReadLine().ToUpper() + ",";//Nume Vanzator
            Console.Write("Nume cumparator: ");
            carInfo = carInfo + Console.ReadLine().ToUpper() + ",";//Nume cumparator
            Console.Write("Data tranzactie(dd.mm.yyyy): ");
            carInfo = carInfo + Console.ReadLine() + ",";          //Data tranzacaatie

            Console.WriteLine("Introduceti optiunile (ex: ABS,Geamuri electrice, Senzori ploaie): ");
            string optiuni = Console.ReadLine().ToUpper();

            if (optiuni != string.Empty)
                carInfo = carInfo + optiuni;
            else
                carInfo = carInfo + "NONE";

            Car newCar = new Car(carInfo);
            return newCar;
        }


        public void ShowCar()
        {
            Console.WriteLine($"{"Firma",-20} {Firma,-10}");
            Console.WriteLine($"{"Model",-20} {Model,-10}");
            Console.WriteLine($"{"An Fabricatie",-20} {AnFabricatie,-10}");
            Console.WriteLine($"{"Culoare",-20} {Culoare,-10}");
            Console.WriteLine($"{"Pret",-20} {Pret + " Euro",-10}");
            Console.WriteLine($"{"Nume Vanzator",-20} {NumeVanzator,-10}");
            Console.WriteLine($"{"Nume Cumparator",-20} {NumeCumparator,-10}");
            Console.WriteLine($"{"Data tranzactie",-20} {DataTranzactie.ToString("dd.MM.yyyy"),-10}");
            Console.WriteLine($"{"Optiuni",-20}");
            foreach (var optiune in Optiuni)
            {
                Console.Write($"{"",-20} {optiune,-10}\n");
            }
        }

        public string ConvertToString()
        {
            string optiuni = string.Empty;
            for (int i = 0; i < Optiuni.Count; i++)
                optiuni += Optiuni[i] + "\n";

            return "Firma: " + (Firma ?? "NECUNOSCUT") + "\n" +
                   "Model: " + (Model ?? "NECUNOSCUT") + "\n" +
                   "An Fabricatie: " + (AnFabricatie.ToString() ?? "NECUNOSCUT") + "\n" +
                   "Culoare: " + (Culoare ?? "NECUNOSCUT") + "\n" +
                   "Pret: " + (Pret.ToString() ?? "NECUNOSCUT") + "\n" +
                   "Nume Vanzator: " + (NumeVanzator ?? "NECUNOSCUT") + "\n" +
                   "Nume Cumparator: " + (NumeCumparator ?? "NECUNOSCUT") + "\n" +
                   "Data Tranzactie: " + (DataTranzactie.ToString("dd.MM.yyyy") ?? "01.01.2000") + "\n" +
                   "Optiuni:\n" + optiuni;
        }

        public string ConvertToString_File()
        {
            string sCarInfo;
            //
            sCarInfo = (Firma ?? "NECUNOSCUT") + SEPARATOR_SECUNDAR_FISIER +
                       (Model ?? "NECUNOSCUT") + SEPARATOR_SECUNDAR_FISIER +
                       (AnFabricatie.ToString() ?? "NECUNOSCUT") + SEPARATOR_SECUNDAR_FISIER +
                       (Culoare ?? "NECUNOSCUT") + SEPARATOR_SECUNDAR_FISIER +
                       (Pret.ToString() ?? "0") + SEPARATOR_SECUNDAR_FISIER +
                       (NumeVanzator ?? "NECUNOSCUT") + SEPARATOR_SECUNDAR_FISIER +
                       (NumeCumparator ?? "NECUNOSCUT") + SEPARATOR_SECUNDAR_FISIER +
                       (DataTranzactie.ToString("dd.MM.yyyy") ?? "NECUNOSCUT") + SEPARATOR_SECUNDAR_FISIER;
            //
            Console.WriteLine(Optiuni.Count);
            if (Optiuni.Count > 0)
            {
                for (int i = 0; i < Optiuni.Count; i++)
                {
                    if (i == (Optiuni.Count - 1))
                        sCarInfo = sCarInfo + Optiuni[i];
                    else
                        sCarInfo = sCarInfo + Optiuni[i] + SEPARATOR_SECUNDAR_FISIER;
                }
            }
            else
            {
                sCarInfo += "NONE";
            }


            return sCarInfo;
        }

        public static Car PriceCompare(Car a, Car b)
        {
            if (a.Pret > b.Pret)
                return a;
            else if (b.Pret > a.Pret)
                return b;
            else
                if (a.AnFabricatie > b.AnFabricatie)
                return a;
            else
                return b;
        }


    }
}