using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading;

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
        #region Constante afisare
        private const string SEPARATOR_AFISARE = " ";
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const char SEPARATOR_SECUNDAR_FISIER = ',';
        private const int FORMAT_TABEL_STANGA = -25;
        private const int FORMAT_TABEL_DREAPTA = -10;
        #endregion

        #region Proprietati
        public static int LastIndexAutoturism { get; set; } = 0;
        public int IndexAutoturism { get; set; }
        public string Marca { get; set; }
        public string Model { get; set; }
        public int AnFabricatie { get; set; }
        public int CapacitateCilindrica { get; set; }
        public int Putere { get; set; }
        public TipCombustibil Combustibil { get; set; }
        public TipCutie CutieDeViteze { get; set; }
        public TipCaroserie Caroserie { get; set; }
        public Culori Culoare { get; set; }
        public int Pret { get; set; }
        public string Nume_Vanzator { get; set; }
        public string Prenume_Vanzator { get; set; }
        public string Nume_Cumparator { get; set; }
        public string Prenume_Cumparator { get; set; }
        public DateTime DataTranzactie { get; set; }
        public List<string> Optiuni { get; set; }
        #endregion

        #region Constructori
        public Car() { }

        public Car(string pMarca, string pModel)
        {
            Marca = pMarca;
            Model = pModel;
        }
        public Car(string info)
        {
            string[] splitInfo = info.Split(SEPARATOR_PRINCIPAL_FISIER);
            Marca = splitInfo[(int)CampuriAutoturism.MARCA];
            Model = splitInfo[(int)CampuriAutoturism.MODEL];
            AnFabricatie = int.Parse(splitInfo[(int)CampuriAutoturism.ANFABRICATIE]);
            CapacitateCilindrica = int.Parse(splitInfo[(int)CampuriAutoturism.CAPACITATE_CILINDRICA]);
            Putere = int.Parse(splitInfo[(int)CampuriAutoturism.PUTERE]);
            Combustibil = (TipCombustibil) Convert.ToInt32(splitInfo[(int)CampuriAutoturism.COMBUSTIBIL]);
            CutieDeViteze = (TipCutie) Convert.ToInt32(splitInfo[(int)CampuriAutoturism.CUTIE_VITEZE]);
            Caroserie = (TipCaroserie) Convert.ToInt32(splitInfo[(int)CampuriAutoturism.CAROSERIE]);
            Culoare = (Culori) Convert.ToInt32(splitInfo[(int)CampuriAutoturism.CULOARE]);
            Pret = int.Parse(splitInfo[(int)CampuriAutoturism.PRET]);
            Nume_Vanzator = splitInfo[(int)CampuriAutoturism.NUME_VANZATOR];
            Prenume_Vanzator = splitInfo[(int)CampuriAutoturism.PRENUME_VANZATOR];
            Nume_Cumparator = splitInfo[(int)CampuriAutoturism.NUME_CUMPARATOR];
            Prenume_Cumparator = splitInfo[(int)CampuriAutoturism.PRENUME_CUMPARATOR];
            DataTranzactie = DateTime.Parse(splitInfo[(int)CampuriAutoturism.DATA_TRANZACTIE]);

            List<string> opt = new List<string>();
            for (int i = (int)CampuriAutoturism.OPTIUNI; i < splitInfo.Length; i++)
                opt.Add(splitInfo[i]);
            Optiuni = opt;

            LastIndexAutoturism++;
            IndexAutoturism = LastIndexAutoturism;
        }
        #endregion
        
        #region Metode de afisare
        public void ShowCar()
        {
            Console.WriteLine($"{"Firma",FORMAT_TABEL_STANGA} {IndexAutoturism,FORMAT_TABEL_DREAPTA}");
            Console.WriteLine($"{"Firma",FORMAT_TABEL_STANGA} {Marca, FORMAT_TABEL_DREAPTA}");
            Console.WriteLine($"{"Model",FORMAT_TABEL_STANGA} {Model, FORMAT_TABEL_DREAPTA}");
            Console.WriteLine($"{"An Fabricatie",FORMAT_TABEL_STANGA} {AnFabricatie, FORMAT_TABEL_DREAPTA}");
            Console.WriteLine($"{"Capacitate cilindrica",FORMAT_TABEL_STANGA} {CapacitateCilindrica + " cm^3", FORMAT_TABEL_DREAPTA}");
            Console.WriteLine($"{"Putere",FORMAT_TABEL_STANGA} {Putere+" CP", FORMAT_TABEL_DREAPTA}");
            Console.WriteLine($"{"Combustibil",FORMAT_TABEL_STANGA} {Combustibil, FORMAT_TABEL_DREAPTA}");
            Console.WriteLine($"{"Cutie de viteze",FORMAT_TABEL_STANGA} {CutieDeViteze, FORMAT_TABEL_DREAPTA}");
            Console.WriteLine($"{"Caroserie",FORMAT_TABEL_STANGA} {Caroserie, FORMAT_TABEL_DREAPTA}");
            Console.WriteLine($"{"Culoare",FORMAT_TABEL_STANGA} {Culoare, FORMAT_TABEL_DREAPTA}");
            Console.WriteLine($"{"Pret",FORMAT_TABEL_STANGA} {Pret + " Euro", FORMAT_TABEL_DREAPTA}");
            Console.WriteLine($"{"Nume Vanzator",FORMAT_TABEL_STANGA} {Nume_Vanzator + " " + Prenume_Vanzator, FORMAT_TABEL_DREAPTA}");
            Console.WriteLine($"{"Nume Cumparator",FORMAT_TABEL_STANGA} {Nume_Cumparator + " " + Prenume_Cumparator, FORMAT_TABEL_DREAPTA}");
            Console.WriteLine($"{"Data tranzactie",FORMAT_TABEL_STANGA} {DataTranzactie.ToString("dd.MM.yyyy"), FORMAT_TABEL_DREAPTA}");
            Console.WriteLine($"{"Optiuni",FORMAT_TABEL_STANGA}");
            foreach (var optiune in Optiuni)
            {
                Console.Write($"{"",FORMAT_TABEL_STANGA} {optiune,FORMAT_TABEL_DREAPTA}\n");
            }
        }
        public string ConvertToString()
        {
            string optiuni = string.Empty;
            for (int i = 0; i < Optiuni.Count; i++)
                optiuni += Optiuni[i] + "\n";

            return "Firma: " + (Marca ?? "NECUNOSCUT") + "\n" +
                   "Model: " + (Model ?? "NECUNOSCUT") + "\n" +
                   "An Fabricatie: " + (AnFabricatie.ToString() ?? "NECUNOSCUT") + "\n" +
                   "Capacitate Cilindrica: " + (CapacitateCilindrica.ToString() ?? "NECUNOSCUT") + "\n" +
                   "Putere: " + (Putere.ToString() ?? "NECUNOSCUT") + "\n" +
                   "Combustibil: " + (Combustibil.ToString() ?? "NECUNOSCUT") + "\n" +
                   "Cutie de viteze: " + (CutieDeViteze.ToString() ?? "NECUNOSCUT") + "\n" +
                   "Caroserie: " + (Caroserie.ToString() ?? "NECUNOSCUT") + "\n" +
                   "Culoare: " + (Culoare.ToString() ?? "NECUNOSCUT") + "\n" +
                   "Pret: " + (Pret.ToString() ?? "NECUNOSCUT") + "\n" +
                   "Nume Vanzator: " + (Nume_Vanzator + " " + Prenume_Vanzator ?? "NECUNOSCUT") + "\n" +
                   "Nume Cumparator: " + (Nume_Cumparator + " " + Prenume_Vanzator ?? "NECUNOSCUT") + "\n" +
                   "Data Tranzactie: " + (DataTranzactie.ToString("dd.MM.yyyy") ?? "01.01.2000") + "\n" +
                   "Optiuni:\n" + optiuni;
        }

        public string ConvertToString_File()
        {
            string sCarInfo;
            //
            sCarInfo = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}{0}{11}{0}{12}{0}{13}{0}{14}{0}{15}{0}",
                SEPARATOR_PRINCIPAL_FISIER, Marca, Model, AnFabricatie, CapacitateCilindrica, Putere, Convert.ToInt32(Combustibil), Convert.ToInt32(CutieDeViteze), Convert.ToInt32(Caroserie),
                Convert.ToInt32(Culoare), Pret, Nume_Vanzator, Prenume_Vanzator, Nume_Cumparator, Prenume_Cumparator, DataTranzactie.ToString("dd.MM.yyyy"));


            if (Optiuni.Count > 0)
            {
                for (int i = 0; i < Optiuni.Count; i++)
                {
                    if (i == (Optiuni.Count - 1))
                        sCarInfo += Optiuni[i];
                    else
                        sCarInfo = sCarInfo + Optiuni[i] + SEPARATOR_PRINCIPAL_FISIER;
                }
            }
            else
            {
                sCarInfo += "NONE";
            }


            return sCarInfo;
        }

        #endregion

        #region Cautare/Modificare
        /*
        public static List<Car> CautareMarca(ArrayList list_Masini)
        {
            List<Car> list_MarcaCautata = new List<Car>();
            string cautare_Marca;
            bool marcaGasita = false;
            Console.Write("Introduceti marca: ");
            cautare_Marca = Console.ReadLine().ToUpper().Trim();
            foreach(Car masina in list_Masini)
            {
                if(masina.Marca == cautare_Marca)
                {
                    list_MarcaCautata.Add(masina);/////probleme
                    marcaGasita = true;
                }
            }

            //Verific daca utilizatorul doreste o cautare avansata dupa modelul masinii
            if (marcaGasita == true)
                if (CautareDupaModel(cautare_Marca))
                    return CautareModel(list_MarcaCautata);

            Console.WriteLine("Marca nu a fost gasita.");
            return null;
        }

        public static List<Car> CautareModel(List<Car> list_Masini)
        {
            if(list_Masini != null)
            {
                List<Car> list_ModelCautat = new List<Car>();
                string cautare_Marca;
                bool model_Gasit = false;
                Console.Write("Introduceti modelul: ");
                cautare_Marca = Console.ReadLine().ToUpper().Trim();
                foreach (Car masina in list_Masini)
                {
                    if (masina.Model == cautare_Marca)
                    {
                        list_ModelCautat.Add(masina);
                        model_Gasit = true;
                    }
                }
                if(!model_Gasit)
                {
                    Console.WriteLine("Nu exista modelul introdus.");
                    return null;
                }
                return list_ModelCautat;
            }
            return null;
        }

        public static bool CautareDupaModel(string marcaAleasa)
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine($"Marca: {marcaAleasa}");
                Console.WriteLine("Doriti sa cautati un model specific? [Y/N]");
                var key = Console.ReadKey(true).Key;
                switch(key)
                {
                    case ConsoleKey.Y:
                        return true;
                    case ConsoleKey.N:
                        return false;
                    default:
                        Console.WriteLine("Optiune incorecta.");
                        break;
                }
                Console.WriteLine("\nPress any key...");
            }
        }
        
        /// <summary>
        /// Utilizeaza o lista cu autoturisme si permite modificarea datelor ale acestora.
        /// </summary>
        public static List<Car> ModificareDateAutoturism(List<Car> list_Autoturisme)
        {
            if(list_Autoturisme == null)
            {
                return null;
            }

            bool modificaDate = false;
            bool isTrue = true;
            
            while (isTrue)
            {
                Console.WriteLine("Doriti sa modificati un autoturism? [Y/N]");
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.Y:
                        modificaDate = true;
                        isTrue = false;
                        break;
                    case ConsoleKey.N:
                        modificaDate = false;
                        isTrue = false;
                        break;
                    default:
                        Console.WriteLine("Optiune incorecta.");
                        break;
                }
                if(isTrue)
                {
                    Console.WriteLine("\nPress any key...");
                    Console.ReadKey();
                }
            }

            if(modificaDate)
            {
                Console.Write("Introduceti indexul autoturismului: ");
                if (int.TryParse(Console.ReadLine(), out int indexAutoturism))
                {
                    indexAutoturism -= 1;//Reduc cu 1 pentru a putea lucra cu indexuri de la 0 - Max
                    int intParseInput;
                    if (indexAutoturism < list_Autoturisme.Count)
                    {
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Panou modificare date autoturism");
                            Console.WriteLine("1 - Model");
                            Console.WriteLine("2 - An fabricatie");
                            Console.WriteLine("3 - Capacitate cilindrica");
                            Console.WriteLine("4 - Putere");
                            Console.WriteLine("5 - Combustibil");
                            Console.WriteLine("6 - Cutie de viteze");
                            Console.WriteLine("7 - Caroserie");
                            Console.WriteLine("8 - Culoare");
                            Console.WriteLine("V - Nume vanzator");
                            Console.WriteLine("C - Nume cumparator");
                            Console.WriteLine("T - Data tranzactie");
                            Console.WriteLine("O - Optiuni");
                            Console.WriteLine("ESC - Iesire panou\n\n");
                            Console.WriteLine(list_Autoturisme[indexAutoturism].ConvertToString());
                            
                            var key = Console.ReadKey(true).Key;
                            switch (key)
                            {
                                case ConsoleKey.D1:
                                    Console.Write("Introduceti modelul: ");
                                    list_Autoturisme[indexAutoturism].Model = Console.ReadLine().ToUpper().Trim();
                                    break;
                                case ConsoleKey.D2:
                                    Console.Write("Introduceti anul fabricatiei: ");
                                    if (int.TryParse(Console.ReadLine(), out intParseInput))
                                        list_Autoturisme[indexAutoturism].AnFabricatie = intParseInput;
                                    else
                                        Console.WriteLine("Introducere incorecta");
                                    break;
                                case ConsoleKey.D3:
                                    Console.Write("Introduceti capacitatea cilindrica: ");
                                    if (int.TryParse(Console.ReadLine(), out intParseInput))
                                        list_Autoturisme[indexAutoturism].CapacitateCilindrica = intParseInput;
                                    else
                                        Console.WriteLine("Introducere incorecta");
                                    break;
                                case ConsoleKey.D4:
                                    Console.Write("Introduceti puterea [CP]: ");
                                    if (int.TryParse(Console.ReadLine(), out intParseInput))
                                        list_Autoturisme[indexAutoturism].Putere = intParseInput;
                                    else
                                        Console.WriteLine("Introducere incorecta");
                                    break;
                                case ConsoleKey.D5:
                                    Console.Write("Introduceti tipul de combustibil: ");
                                    list_Autoturisme[indexAutoturism].Combustibil = Console.ReadLine().ToUpper().Trim();
                                    break;
                                case ConsoleKey.D6:
                                    Console.Write("Introduceti tipul cutiei de viteze: ");
                                    list_Autoturisme[indexAutoturism].CutieDeViteze = Console.ReadLine().ToUpper().Trim();
                                    break;
                                case ConsoleKey.D7:
                                    Console.Write("Introduceti tipul caroseriei: ");
                                    list_Autoturisme[indexAutoturism].Caroserie = Console.ReadLine().ToUpper().Trim();
                                    break;
                                case ConsoleKey.D8:
                                    Console.Write("Introduceti culoare: ");
                                    list_Autoturisme[indexAutoturism].Culoare = Console.ReadLine().ToUpper().Trim();
                                    break;
                                case ConsoleKey.V:
                                    throw new NotImplementedException();
                                    break;
                                case ConsoleKey.C:
                                    throw new NotImplementedException();
                                    break;
                                case ConsoleKey.T:
                                    throw new NotImplementedException();
                                    break;
                                case ConsoleKey.O:
                                    throw new NotImplementedException();
                                    break;
                                case ConsoleKey.Escape:
                                    return list_Autoturisme;
                                default:
                                    break;
                            }
                        }
                    }
                }
                else
                    return list_Autoturisme;
            }

            return list_Autoturisme;
        }

        */

        #endregion

        public static Car PriceCompare(Car a, Car b)///De modificat utilizand supraincarcare op
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