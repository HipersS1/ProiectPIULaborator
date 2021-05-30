using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading;


namespace CarClass
{
    public class Car
    {
        #region Constante afisare
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const int FTS = -40;//FORMAT TABEL STANGA
        private const int FTD = -10;//FORMAT TABEL DREAPTA
        #endregion

        #region Proprietati
        //public static int LastIndexAutoturism { get; set; } = 0;
        //public int IndexAutoturism { get; set; }
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
        public Car(string pMarca, string pModel, int pAn, int pPret)
        {
            Marca = pMarca;
            Model = pModel;
            AnFabricatie = pAn;
            Pret = pPret;
        }

        public Car(string pMarca, string pModel, int pAn, int pCapacitate, int pPutere, int pPret,
                   string numeV, string prenumeV, string numeC, string prenumeC)
        {
            Marca = pMarca;
            Model = pModel;
            AnFabricatie = pAn;
            CapacitateCilindrica = pCapacitate;
            Putere = pPutere;
            Pret = pPret;
            Nume_Vanzator = numeV;
            Prenume_Vanzator = prenumeV;
            Nume_Cumparator = numeC;
            Prenume_Cumparator = prenumeC;
        }

        //LABORATOR 2 EX 1
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

            //LastIndexAutoturism++;
            //IndexAutoturism = LastIndexAutoturism;
        }
        #endregion
        
        #region Metode de afisare
        public void ShowCar()
        {
            //Console.WriteLine($"{"ID",FTS} {IndexAutoturism}");
            Console.WriteLine($"{"Firma",FTS} {Marca}");
            Console.WriteLine($"{"Model",FTS} {Model}");
            Console.WriteLine($"{"An Fabricatie",FTS} {AnFabricatie}");
            Console.WriteLine($"{"Capacitate cilindrica",FTS} {CapacitateCilindrica + " cm^3", FTD}");
            Console.WriteLine($"{"Putere",FTS} {Putere+" CP", FTD}");
            Console.WriteLine($"{"Combustibil",FTS} {Combustibil}");
            Console.WriteLine($"{"Cutie de viteze",FTS} {CutieDeViteze}");
            Console.WriteLine($"{"Caroserie",FTS} {Caroserie}");
            Console.WriteLine($"{"Culoare",FTS} {Culoare}");
            Console.WriteLine($"{"Pret",FTS} {Pret + " Euro", FTD}");
            Console.WriteLine($"{"Nume Vanzator",FTS} {Nume_Vanzator + " " + Prenume_Vanzator, FTD}");
            Console.WriteLine($"{"Nume Cumparator",FTS} {Nume_Cumparator + " " + Prenume_Cumparator, FTD}");
            Console.WriteLine($"{"Data tranzactie",FTS} {DataTranzactie.ToString("dd.MM.yyyy"), FTD}");
            Console.WriteLine($"{"Optiuni",FTS}");
            foreach (var optiune in Optiuni)
            {
                Console.Write($"{"",FTS} {optiune}\n");
            }
        }

        //LABORATOR2 EX 2
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
                   "Nume Cumparator: " + (Nume_Cumparator + " " + Prenume_Cumparator ?? "NECUNOSCUT") + "\n" +
                   "Data Tranzactie: " + (DataTranzactie.ToString("dd.MM.yyyy") ?? "01.01.2000") + "\n" +
                   "Optiuni:\n" + optiuni;
        }

        public string ConvertToString2()
        {
            return $"{Marca,-20}{Model,-15}{AnFabricatie.ToString(),-5}{CapacitateCilindrica.ToString(), -7}" +
                   $"{Putere.ToString(), -7}{Combustibil.ToString(), -12}{CutieDeViteze.ToString(), -11}{Caroserie.ToString(), -11}{Culoare.ToString(), -11}" +
                   $"{Pret.ToString(), -10}{Nume_Cumparator + " " + Prenume_Cumparator, -35}{Nume_Vanzator + " " + Prenume_Cumparator, -35}{DataTranzactie.ToString("dd.MM.yyyy"), -17}";
        }

        public string ConvertToString3()
        {
            string s = $"{Marca,-20}{Model,-15}{AnFabricatie.ToString(),-5}{CapacitateCilindrica.ToString(),-7}" +
                   $"{Putere.ToString(),-7}{Combustibil.ToString(),-12}{CutieDeViteze.ToString(),-11}{Caroserie.ToString(),-11}{Culoare.ToString(),-11}" +
                   $"{Pret.ToString(),-10}{Nume_Cumparator + " " + Prenume_Cumparator,-35}{Nume_Vanzator + " " + Prenume_Cumparator,-35}{DataTranzactie.ToString("dd.MM.yyyy"),-17}";
            foreach(string str in Optiuni)
            { s += str +  ","; }

            return s;
        }


        public string ConvertToString_File()
        {
            string sCarInfo;
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

        //LABORATOR 2 EX 3
        #region Comparare
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

        public static string operator <(Car a, Car b)
        {
            if (a == null || b == null)
                return "Eroare";
            if (a.Pret < b.Pret)
                return $"{b.Marca} {b.Model}  {b.AnFabricatie} {b.Pret}";
            if(a.Pret > b.Pret)
                return $"{a.Marca} {a.Model}  {a.AnFabricatie} {a.Pret}";
            return "Preturile masinilor sunt egale.";
        }
        public static string operator >(Car a, Car b)
        {
            if (a == null || b == null)
                return "Eroare";
            if (a.Pret > b.Pret)
                return $"{a.Marca} {a.Model}  {a.AnFabricatie} {a.Pret}";
            if (a.Pret < b.Pret)
                return $"{b.Marca} {b.Model}  {b.AnFabricatie} {b.Pret}";
            return "Preturile masinilor sunt egale.";
        }
        #endregion
    }
}