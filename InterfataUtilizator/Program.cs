using System;
using CarClass;
using NivelAccesDate;
using System.Collections;


namespace InterfataUtilizator
{
    class Program
    {
        static void Main()
        {
            IStocareData adminCars = StocareFactory.GetAdministratorStocare();
            ArrayList cars = adminCars.GetCars();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("A. Afisare masini");
                Console.WriteLine("B. Afisare masini tabel");
                Console.WriteLine("C. Creare si Adaugare");
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
    }
}
