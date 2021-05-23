using System;
using CarClass;
using NivelAccesDate;
using System.Collections.Generic;
using System.Collections;


namespace InterfataUtilizator
{
    class Program
    {
        static void Main(string[] args)
        {
            IStocareData adminCars = StocareFactory.GetAdministratorStocare();
            ArrayList cars;
            List<Car> listaAutoturismeFisier = adminCars.GetCarsFile();

            //Car.LastIndexAutoturism = cars.Count;
            List<Car> listaAutoturismeCautate;
            //MARCA - MODEL - AN - CAPACITATE CILINDRICA - PUTERE - COMBUSTIBIL - CUTIE - CAROSERIE - CULOARE - PRET - NUME VAN - NUME CUMP - DATA TRANZACTIE - OPTIUNI 
            Car autoturismTest = new Car("Audi", "A3", 2012, 7000);
            Car autoturismTest2 = new Car("Audi", "A4", 2015, 8000);
            Car autoturismTest3 = new Car("AUDI", "A4");
            while (true)
            {
                Console.Clear();
                Console.WriteLine("A. Afisare masini");
                Console.WriteLine("B. Afisare masini tabel");
                Console.WriteLine("C. Creare si Adaugare");
                Console.WriteLine("F. Cautare autoturismE dupa marca si model");
                Console.WriteLine("R. Cautare si modificare autoturism");
                Console.WriteLine("T. Compara utilizand autoturism din linia de comanda");
                Console.WriteLine("X. Inchidere program");
                Console.WriteLine("Alegeti o optiune\n");
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.A:
                        cars = ConvertListToArrayList(listaAutoturismeFisier);
                        AfisareInformatii(cars);// arraylist
                        break;
                    case ConsoleKey.B:
                        //AfisareInformatiiTabel(cars); // arraylist
                        AfisareInformatiiTabel(listaAutoturismeFisier);
                        break;
                    case ConsoleKey.T:
                        //Console.WriteLine("Rezultatul Compararii:\n" + (autoturismTest < CitireComanda(args)));
                        Console.WriteLine("Rezultatul Compararii:\n" + (autoturismTest < autoturismTest2));

                        break;
                    case ConsoleKey.F:
                        Console.Write("Introduceti marca cautata: " );
                        autoturismTest3.Marca = Console.ReadLine().ToUpper().Trim();
                        Console.Write("Introduceti modelul cautat: " );
                        autoturismTest3.Model = Console.ReadLine().ToUpper().Trim();
                        listaAutoturismeCautate = adminCars.SearchCars(autoturismTest3, listaAutoturismeFisier);
                        AfisareInformatiiTabel(listaAutoturismeCautate);
                        
                        break;
                    case ConsoleKey.R:
                        Console.Write("Introduceti marca cautata: ");
                        autoturismTest3.Marca = Console.ReadLine().ToUpper().Trim();
                        Console.Write("Introduceti modelul cautat: ");
                        autoturismTest3.Model = Console.ReadLine().ToUpper().Trim();
                        listaAutoturismeFisier = adminCars.ModifyCarPrice(listaAutoturismeFisier, autoturismTest3);
                        adminCars.RewriteCars(listaAutoturismeFisier);
                        break;
                    case ConsoleKey.C:
                        Car newCarCreated = CitireTastaturaAutoturism();
                        //cars.Add(newCarCreated); // arraylist
                        listaAutoturismeFisier.Add(newCarCreated);
                        adminCars.AddCar(newCarCreated);
                        break;
                    case ConsoleKey.X:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Optiune inexistenta");
                        break;
                }
                Console.WriteLine("\nPress any key...");
                Console.ReadKey();
            }

        }
        #region Afisare
        public static void AfisareInformatii(ArrayList info)
        {
            if (info == null)
                return;
            Console.WriteLine("Informatii masini:");
            if (info.Count == 0)
            {
                Console.WriteLine("- NONE -");
                return;
            }

            for (int i = 0; i < info.Count; i++)
            {
                Console.WriteLine("\nINDEX: " + (i + 1));
                Console.WriteLine(((Car)info[i]).ConvertToString());
            }
        }
        public static void AfisareInformatiiTabel(ArrayList info)
        {
            if (info == null)
                return;

            Console.WriteLine("Informatii masini:");
            if (info.Count == 0)
            {
                Console.WriteLine("- NONE -");
                return;
            }

            for (int i = 0; i < info.Count; i++)
            {
                Console.WriteLine("\nINDEX: " + (i + 1));
                ((Car)info[i]).ShowCar();
            }
        }
        public static void AfisareInformatiiTabel(List<Car> info)
        {
            if (info == null)
                return;

            Console.WriteLine("Informatii masini:");
            if (info.Count == 0)
            {
                Console.WriteLine("- NONE -");
                return;
            }

            for (int i = 0; i < info.Count; i++)
            {
                Console.WriteLine("\nINDEX: " + (i + 1));
                ((Car)info[i]).ShowCar();
            }
        }
        #endregion

        #region Citire Tastatura
        public static Car CitireTastaturaAutoturism()
        {
            string inputMarca;
            string input = string.Empty;
            int inputInt;
            Console.WriteLine("Introduceti informatiile despre masina:");

            //Info generic
            Console.Write("Firma: ");
            inputMarca = Console.ReadLine().ToUpper().Trim();//Firma
            Console.Write("Model: ");
            input = Console.ReadLine().ToUpper().Trim();//Model

            //Creearea autoturismului
            Car autoturismCitit = new Car(inputMarca, input);

            Console.Write("An Fabricatie: ");
            int.TryParse(Console.ReadLine(), out inputInt);          //An fabricatie
            autoturismCitit.AnFabricatie = inputInt;

            //Info tehnic
            Console.Write("Capacitate Cilindrica: ");
            int.TryParse(Console.ReadLine(), out inputInt);          //An fabricatie
            autoturismCitit.CapacitateCilindrica = inputInt;

            Console.Write("Putere: ");
            int.TryParse(Console.ReadLine(), out inputInt);          //An fabricatie
            autoturismCitit.Putere = inputInt;

            Console.Write("Combustibil: ");
            autoturismCitit.Combustibil = CitireTipCombustibil();

            Console.Write("Cutie de viteze: ");
            autoturismCitit.CutieDeViteze = CitireTipCutie();

            Console.Write("Caroserie: ");
            autoturismCitit.Caroserie = CitireTipCaroserie();

            Console.Write("Culoare: ");
            autoturismCitit.Culoare = CitireCuloare();

            Console.Write("Pret: ");
            int.TryParse(Console.ReadLine(), out inputInt);          //An fabricatie
            autoturismCitit.Pret = inputInt;

            //Info Tranzactie
            Console.Write("Nume vanzator: ");
            autoturismCitit.Nume_Vanzator = Console.ReadLine().ToUpper().Trim();
            Console.Write("Prenume vanzator: ");
            autoturismCitit.Prenume_Vanzator = Console.ReadLine().ToUpper().Trim();

            Console.Write("Nume cumparator: ");
            autoturismCitit.Nume_Cumparator = Console.ReadLine().ToUpper().Trim();
            Console.Write("Prenume cumparator: ");
            autoturismCitit.Prenume_Cumparator = Console.ReadLine().ToUpper().Trim();

            //DateTime userDateTime;
            Console.Write("Data tranzactie(dd.mm.yyyy): ");
            input = Console.ReadLine();
            autoturismCitit.DataTranzactie = DateTime.Parse(input);
            //DateTime.TryParse(Console.ReadLine(), out userDateTime);

            Console.WriteLine("Introduceti optiunile (ex: ABS,Geamuri electrice, Senzori ploaie): ");
            input = Console.ReadLine().ToUpper();
            List<string> optiuni = new List<string>();

            
            string[] formatOptiuni = input.Split(',');

            for (int i = 0; i < formatOptiuni.Length; i++)
            {
                formatOptiuni[i] = formatOptiuni[i].Trim();
                optiuni.Add(formatOptiuni[i]);
            }
            autoturismCitit.Optiuni = optiuni;
            return autoturismCitit;
        }

        public static TipCombustibil CitireTipCombustibil()
        {
            var tipCombustibil = Enum.GetNames(typeof(TipCombustibil));
            int count = 1;
            foreach (var numeCombustibil in tipCombustibil)
            {
                Console.Write(count++ + "-" + numeCombustibil + " | ");
            }
            Console.Write("\nAlegeti tipul de combustibil: ");
            int.TryParse(Console.ReadLine(), out int inputOptiune);

            while (inputOptiune <= 0 || inputOptiune > tipCombustibil.Length)
            {
                Console.Write("\nAlegeti tipul de combustibil: ");
                int.TryParse(Console.ReadLine(), out inputOptiune);
            }

            return (TipCombustibil)Convert.ToInt32(inputOptiune);
        }


        public static TipCutie CitireTipCutie()
        {
            var tipCutie = Enum.GetNames(typeof(TipCutie));
            int count = 1;
            foreach (var nume in tipCutie)
            {
                Console.Write(count++ + "-" + nume + " | ");
            }

            Console.Write("\nAlegeti cutia de viteze: ");
            int.TryParse(Console.ReadLine(), out int inputOptiune);

            while (inputOptiune <= 0 || inputOptiune > tipCutie.Length)
            {
                Console.Write("\nAlegeti cutia de viteze: ");
                int.TryParse(Console.ReadLine(), out inputOptiune);
            }

            return (TipCutie)Convert.ToInt32(inputOptiune);
        }
        
        public static TipCaroserie CitireTipCaroserie()
        {
            var tipCaroserie = Enum.GetNames(typeof(TipCaroserie));
            int count = 1;
            foreach (var nume in tipCaroserie)
            {
                Console.Write(count++ + "-" + nume + " | ");
            }

            Console.Write("\nAlegeti caroseria autoturismului: ");
            int.TryParse(Console.ReadLine(), out int inputOptiune);

            while (inputOptiune <= 0 || inputOptiune > tipCaroserie.Length)
            {
                Console.Write("\nAlegeti caroseria autoturismului: ");
                int.TryParse(Console.ReadLine(), out inputOptiune);
            }

            return (TipCaroserie)Convert.ToInt32(inputOptiune);
        }

        public static Culori CitireCuloare()
        {
            var tipCaroserie = Enum.GetNames(typeof(Culori));
            int count = 1;
            foreach (var nume in tipCaroserie)
            {
                Console.Write(count++ + "-" + nume + " | ");
            }

            Console.Write("\nAlegeti culoarea autoturismului: ");
            int.TryParse(Console.ReadLine(), out int inputOptiune);

            while (inputOptiune <= 0 || inputOptiune > tipCaroserie.Length)
            {
                Console.Write("\nAlegeti culoarea autoturismului: ");
                int.TryParse(Console.ReadLine(), out inputOptiune);
            }

            return (Culori)Convert.ToInt32(inputOptiune);
        }

        #endregion

        #region Citire Comanda
        public static Car CitireComanda(string[] args)
        {
            if (args.Length == 0)
                return null;
            Console.WriteLine($"{args[0]} {args[1]} {args[2]} {args[2]}");
            Car autoturism = new Car(args[0], args[1], Convert.ToInt32(args[2]), Convert.ToInt32(args[3]));

            return autoturism ;
        }

        #endregion


        public static ArrayList ConvertListToArrayList(List<Car> listaAutoturisme)
        {
            ArrayList arr = new ArrayList();
            foreach (Car c in listaAutoturisme)
                arr.Add(c);
            return arr;
        }

    }
}
