﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using CarClass;

namespace NivelAccesDate
{
    public class AdministrareMasini_FisierText : IStocareData
    {
        string NumeFisier { get; set; }

        public AdministrareMasini_FisierText(string numeFisier)
        {
            this.NumeFisier = numeFisier;
            Stream sFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            sFisierText.Close();
        }

        public void AddCar(Car car)
        {
            try
            {
                using (StreamWriter swFisierText = new StreamWriter(NumeFisier, true))
                {
                    swFisierText.WriteLine(car.ConvertToString_File());
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
        }

        public void RewriteCars(List<Car> listOfCars)
        {
            try
            {
                File.Delete(NumeFisier);
                using (StreamWriter swFisierText = new StreamWriter(NumeFisier, true))
                {
                    foreach (var car in listOfCars)
                    {
                        swFisierText.WriteLine(car.ConvertToString_File());

                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
        }


        public ArrayList GetCars()
        {
            ArrayList cars = new ArrayList();

            try
            {
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;

                    //citeste cate o linie si creaza un obiect de tip Student pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        Car masinaDinFisier = new Car(line);
                        cars.Add(masinaDinFisier);
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }

            return cars;
        }

        public List<Car> SearchCars(Car autoCautat, List<Car> listaAutoturisme)
        {
            //List<Car> autoFisier = GetCarsFile();
            List<Car> autoGasite = new List<Car>();
            foreach(Car c in listaAutoturisme)
            {
                if (autoCautat.Marca == c.Marca && autoCautat.Model == c.Model)
                    autoGasite.Add(c);
            }

            return autoGasite; 
        }
        public List<Car> GetCarsFile()
        {
            List<Car> cars = new List<Car>();

            try
            {
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;

                    //citeste cate o linie si creaza un obiect de tip Student pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        Car masinaDinFisier = new Car(line);
                        cars.Add(masinaDinFisier);
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {

                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }

            return cars;
        }

        public List<Car> ModifyCarPrice(List<Car> listaAutoturisme, Car carToBeModified)
        {
            List<Car> autoturismeSpecifice = SearchCars(carToBeModified, listaAutoturisme);
            if (autoturismeSpecifice == null)
                return listaAutoturisme;

            Console.WriteLine("Informatii masini:");
            if (autoturismeSpecifice.Count == 0)
            {
                Console.WriteLine("- NONE -");
                return listaAutoturisme;
            }

            for (int i = 0; i < autoturismeSpecifice.Count; i++)
            {
                ((Car)autoturismeSpecifice[i]).ShowCar();
            }

            bool idGasit;
            do
            {
                idGasit = true;
                Console.Write("Introduceti ID-ul masinii pentru a modifica pretul: ");
                if(int.TryParse(Console.ReadLine(), out int input))
                {        
                    foreach (Car c in autoturismeSpecifice)
                    {
                        if (input == c.IndexAutoturism)
                        {
                            idGasit = false;
                            Console.WriteLine("Autoturism: " + c.Marca + " " + c.Model + " " + c.Pret);
                            do
                            {
                                Console.Write("Introduceti pretul nou al masinii: ");
                                if (int.TryParse(Console.ReadLine(), out input) && input >= 0)
                                    break;
                            } while (true);
                            c.Pret = input;
                        }
                    }
                }
            } while (idGasit);

            return listaAutoturisme;
        }

    }
}
