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

        #region Constante Informatii masina
        private const int MARCA = 0;
        private const int MODEL = 1;
        private const int ANFABRICATIE = 2;
        private const int CAPACITATE_CILINDRICA = 3;
        private const int PUTERE = 4;
        private const int COMBUSTIBIL = 5;
        private const int CUTIEDEVITEZE = 6;
        private const int CAROSERIE = 7;
        private const int CULOARE = 8;
        private const int PRET = 9;
        private const int NUMEVANZATOR = 10;
        private const int NUMECUMPARATOR = 11;
        private const int DATATRANZACTIE = 12;
        private const int OPTIUNI = 13;
        #endregion

        #region Proprietati
        public string Marca { get; set; }
        public string Model { get; set; }
        public int AnFabricatie { get; set; }
        public int CapacitateCilindrica { get; set; }
        public int Putere { get; set; }
        public string Combustibil { get; set; }
        public string CutieDeViteze { get; set; }
        public string Caroserie { get; set; }
        public string Culoare { get; set; }
        public int Pret { get; set; }
        public string NumeVanzator { get; set; }
        public string NumeCumparator { get; set; }
        public DateTime DataTranzactie { get; set; }
        public List<string> Optiuni { get; set; }
        #endregion

        #region Constructori
        public Car() { }
        public Car(string info)
        {
            string[] splitInfo = info.Split(',');
            Marca = splitInfo[MARCA];
            Model = splitInfo[MODEL];
            AnFabricatie = int.Parse(splitInfo[ANFABRICATIE]);
            CapacitateCilindrica = int.Parse(splitInfo[CAPACITATE_CILINDRICA]);
            Putere = int.Parse(splitInfo[PUTERE]);
            Combustibil = splitInfo[COMBUSTIBIL];
            CutieDeViteze = splitInfo[CUTIEDEVITEZE];
            Caroserie = splitInfo[CAROSERIE];
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
        #endregion
        
        #region Metode de afisare
        public void ShowCar()
        {
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
            Console.WriteLine($"{"Nume Vanzator",FORMAT_TABEL_STANGA} {NumeVanzator, FORMAT_TABEL_DREAPTA}");
            Console.WriteLine($"{"Nume Cumparator",FORMAT_TABEL_STANGA} {NumeCumparator, FORMAT_TABEL_DREAPTA}");
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
                   "Culoare: " + (Culoare ?? "NECUNOSCUT") + "\n" +
                   "Pret: " + (Pret.ToString() ?? "NECUNOSCUT") + "\n" +
                   "Nume Vanzator: " + (NumeVanzator ?? "NECUNOSCUT") + "\n" +
                   "Nume Cumparator: " + (NumeCumparator ?? "NECUNOSCUT") + "\n" +
                   "Data Tranzactie: " + (DataTranzactie.ToString("dd.MM.yyyy") ?? "01.01.2000") + "\n" +
                   "Optiuni:\n" + optiuni;
        }
        //MARCA - MODEL - AN - CAPACITATE CILINDRICA - PUTERE - COMBUSTIBIL - CUTIE - CAROSERIE - CULOARE - PRET - NUME VAN - NUME CUMP - DATA TRANZACTIE - OPTIUNI

        public string ConvertToString_File()
        {
            string sCarInfo;
            //
            sCarInfo = (Marca ?? "NECUNOSCUT") + SEPARATOR_SECUNDAR_FISIER +
                       (Model ?? "NECUNOSCUT") + SEPARATOR_SECUNDAR_FISIER +
                       (AnFabricatie.ToString() ?? "NECUNOSCUT") + SEPARATOR_SECUNDAR_FISIER +
                       (CapacitateCilindrica.ToString() ?? "NECUNOSCUT") + SEPARATOR_SECUNDAR_FISIER +
                       (Putere.ToString() ?? "NECUNOSCUT") + SEPARATOR_SECUNDAR_FISIER +
                       (Combustibil ?? "NECUNOSCUT") + SEPARATOR_SECUNDAR_FISIER +
                       (CutieDeViteze ?? "NECUNOSCUT") + SEPARATOR_SECUNDAR_FISIER +
                       (Caroserie ?? "NECUNOSCUT") + SEPARATOR_SECUNDAR_FISIER +
                       (Culoare ?? "NECUNOSCUT") + SEPARATOR_SECUNDAR_FISIER +
                       (Pret.ToString() ?? "0") + SEPARATOR_SECUNDAR_FISIER +
                       (NumeVanzator ?? "NECUNOSCUT") + SEPARATOR_SECUNDAR_FISIER +
                       (NumeCumparator ?? "NECUNOSCUT") + SEPARATOR_SECUNDAR_FISIER +
                       (DataTranzactie.ToString("dd.MM.yyyy") ?? "NECUNOSCUT") + SEPARATOR_SECUNDAR_FISIER;
            //
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

        #endregion

        #region Cautare/Modificare
        /// <summary>
        /// Metoda efectueaza cautarea dupa o marca de autoturism. </summary>
        /// <returns>Returneaza List<Car> ce contine autoturismele avand marca specificata.</returns>
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


        #endregion


        #region Citire Date Autoturism
        public static Car ReadCarInfo()
        {
            string carInfo = string.Empty;
            Console.WriteLine("Introduceti informatiile despre masina:");

            //Info generic
            Console.Write("Firma: ");
            carInfo = carInfo + Console.ReadLine().ToUpper().Trim() + ",";//Firma
            Console.Write("Model: ");
            carInfo = carInfo + Console.ReadLine().ToUpper().Trim() + ",";//Model
            Console.Write("An Fabricatie: ");
            carInfo = carInfo + Console.ReadLine().Trim() + ",";          //An fabricatie

            //Info tehnic
            Console.Write("Capacitate Cilindrica: ");
            carInfo = carInfo + Console.ReadLine().Trim() + ",";          //Capacitate cilindrica
            Console.Write("Putere: ");
            carInfo = carInfo + Console.ReadLine().Trim() + ",";          //Putere
            Console.Write("Combustibil: ");
            carInfo += Car.CitireTipCombustibil() + ",";

            //carInfo = carInfo + Console.ReadLine().ToUpper().Trim() + ",";//Combustibil
            Console.Write("Cutie de viteze: ");
            carInfo = carInfo + Console.ReadLine().ToUpper().Trim() + ",";//Cutie

            //Info afisare masina
            Console.Write("Caroserie: ");
            carInfo += Car.CitireTipCaroserie() + ",";

            //carInfo = carInfo + Console.ReadLine().ToUpper().Trim() + ",";//Pret
            Console.Write("Culoare: ");
            carInfo = carInfo + Console.ReadLine().ToUpper().Trim() + ",";//Culoare
            Console.Write("Pret: ");
            carInfo = carInfo + Console.ReadLine().Trim() + ",";          //Pret

            //Info Tranzactie
            Console.Write("Nume vanzator: ");
            carInfo = carInfo + Console.ReadLine().ToUpper().Trim() + ",";//Nume Vanzator
            Console.Write("Nume cumparator: ");
            carInfo = carInfo + Console.ReadLine().ToUpper().Trim() + ",";//Nume cumparator
            Console.Write("Data tranzactie(dd.mm.yyyy): ");
            carInfo = carInfo + Console.ReadLine().Trim() + ",";          //Data tranzacaatie

            Console.WriteLine("Introduceti optiunile (ex: ABS,Geamuri electrice, Senzori ploaie): ");
            string optiuni = Console.ReadLine().ToUpper();
            string[] formatOptiuni = optiuni.Split(',');
            for (int i = 0; i < formatOptiuni.Length; i++)
                formatOptiuni[i] = formatOptiuni[i].Trim();

            optiuni = string.Empty;
            optiuni = string.Join(",", formatOptiuni);
            if (optiuni != string.Empty)
                carInfo = carInfo + optiuni;
            else
                carInfo = carInfo + "NONE";

            Car newCar = new Car(carInfo);
            return newCar;
        }

        public static string CitireTipCombustibil()
        {
            string inputCombustibil;
            var tipCombustibil = Enum.GetNames(typeof(TipCombustibil));

            foreach (var numeCombustibil in tipCombustibil)
            {
                Console.Write(numeCombustibil + " ");
            }
            Console.Write("\nIntroduceti tipul de combustibil: ");

            while (true)
            {
                inputCombustibil = Console.ReadLine().ToUpper().Trim();
                foreach(var elem in tipCombustibil)
                {
                    if (inputCombustibil == elem)
                        return inputCombustibil;
                }
                Console.Write("Reintroduceti tipul de combustibil: ");
            }
        }

        public static string CitireTipCaroserie()
        {
            string inputCaroserie;
            var tipCaroserie = Enum.GetNames(typeof(TipCaroserie));

            foreach (var numbeCombustibil in tipCaroserie)
            {
                Console.Write(numbeCombustibil + " ");
            }
            Console.Write("\nIntroduceti tipul de caroserie: ");

            while (true)
            {
                inputCaroserie = Console.ReadLine().ToUpper().Trim();
                foreach (var elem in tipCaroserie)
                {
                    if (inputCaroserie == elem)
                        return inputCaroserie;
                }
                Console.Write("Reintroduceti tipul de caroserie: ");
            }
        }
        //Implementeaza celelalte metode necesare introducerii datelor
        #endregion

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