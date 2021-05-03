using System;
using CarClass;
using NivelAccesDate;
using System.Collections.Generic;
using System.Collections;


namespace InterfataUtilizator
{
    class Program
    {
        static void Main()
        {
            IStocareData adminCars = StocareFactory.GetAdministratorStocare();
            ArrayList cars = adminCars.GetCars();
            List<Car> lista_cu_autoturisme;
            //MARCA - MODEL - AN - CAPACITATE CILINDRICA - PUTERE - COMBUSTIBIL - CUTIE - CAROSERIE - CULOARE - PRET - NUME VAN - NUME CUMP - DATA TRANZACTIE - OPTIUNI 

            while (true)
            {
                Console.Clear();
                Console.WriteLine("A. Afisare masini");
                Console.WriteLine("B. Afisare masini tabel");
                Console.WriteLine("C. Creare si Adaugare");
                Console.WriteLine("F. Cautare/Modificare autoturism");
                Console.WriteLine("T. TEST");
                Console.WriteLine("X. Inchidere program");
                Console.WriteLine("Alegeti o optiune\n");
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.A:
                        AfisareInformatii(cars);
                        break;
                    case ConsoleKey.B:
                        AfisareInformatiiTabel(cars);
                        break;
                    case ConsoleKey.T:
                        /*
                        Car masinaTest = new Car("Audi,A4,2010,2200,150,DIESEL,MANUALA,BERLINA,NEGRU,7500,JON SNOW,POSEIDON KAN,25.4.2018,ABS,SERVODIRECTIE,NAVIGATIE,SENZORI PLOAIE,SENZORI PARCARE");
                        masinaTest.ShowCar();
                        Console.WriteLine(masinaTest.ConvertToString());
                        Console.WriteLine(masinaTest.ConvertToString_File());
                        masinaTest = Car.ReadCarInfo();
                        masinaTest.ShowCar();
                        Console.WriteLine(masinaTest.ConvertToString());
                        Console.WriteLine(masinaTest.ConvertToString_File());
                        AfisareInformatiiTabel(cars);
                        */
                        break;
                    case ConsoleKey.F:
                        lista_cu_autoturisme = Car.CautareMarca(cars);
                        AfisareInformatiiTabel(lista_cu_autoturisme);
                        Car.ModificareDateAutoturism(lista_cu_autoturisme);
                        lista_cu_autoturisme.RemoveRange(0, lista_cu_autoturisme.Count);
                        foreach(var car in cars)
                        {
                            lista_cu_autoturisme.Add((Car)car);
                        }
                        adminCars.RewriteCars(lista_cu_autoturisme);
                        break;
                    case ConsoleKey.C:
                        Car newCarCreated = Car.ReadCarInfo();
                        cars.Add(newCarCreated);
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

        public static void AfisareInformatii(ArrayList info)
        {
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
    }
}
