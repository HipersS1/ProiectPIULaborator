using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CarClass;
using NivelAccesDate;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Form1 : Form
    {
        IStocareData adminAutoturisme;
        List<Car> listAutoturismeFisier;
        public Form1()
        {
            InitializeComponent();
            adminAutoturisme = StocareFactory.GetAdministratorStocare();
            listAutoturismeFisier = adminAutoturisme.GetCarsFile();
        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            int inputInt;

            if(!IsString(textBoxMarca.Text))
            {
                labelMarca.ForeColor = Color.Red;
                textBoxMarca.Clear();
                return;
            }
            Car autoturism = new Car(textBoxMarca.Text.ToUpper().Trim(), textBoxModel.Text.ToUpper().Trim());

            if(int.TryParse(textBoxAnFabricatie.Text, out inputInt))
            {
                if (inputInt > 1900 && inputInt < 2030)
                    autoturism.AnFabricatie = inputInt;
                else
                {
                    labelAnFabricatie.ForeColor = Color.Red;
                    textBoxAnFabricatie.Clear();
                    return;
                }
            }
            else
            {
                labelAnFabricatie.ForeColor = Color.Red;
                textBoxAnFabricatie.Clear();
                return;
            }

            if (int.TryParse(textBoxCapacitate.Text, out inputInt))
            {
                if (inputInt > 800 && inputInt < 10000)
                    autoturism.CapacitateCilindrica = inputInt;
                else
                {
                    labelCapacitate.ForeColor = Color.Red;
                    textBoxCapacitate.Clear();
                    return;
                }
            }
            else
            {
                labelCapacitate.ForeColor = Color.Red;
                textBoxCapacitate.Clear();
                return;
            }

            if (int.TryParse(textBoxPutere.Text, out inputInt))
            {
                if (inputInt > 50 && inputInt < 3000)
                    autoturism.Putere = inputInt;
                else
                {
                    labelPutere.ForeColor = Color.Red;
                    textBoxPutere.Clear();
                    return;
                }
            }
            else
            {
                labelPutere.ForeColor = Color.Red;
                textBoxPutere.Clear();
                return;
            }

            if (int.TryParse(textBoxPret.Text, out inputInt))
            {
                if (inputInt >= 500)
                    autoturism.Pret = inputInt;
                else
                {
                    labelPret.ForeColor = Color.Red;
                    textBoxPret.Clear();
                    return;
                }
            }
            else
            {
                labelPret.ForeColor = Color.Red;
                textBoxPret.Clear();
                return;
            }
            //Vanzator
            if (!IsString(textBoxNumeVanzator.Text))
            {
                labelNumeVanzator.ForeColor = Color.Red;
                textBoxNumeVanzator.Clear();
                return;
            }
            if (!IsString(textBoxPrenumeVanzator.Text))
            {
                labelPrenumeVanzator.ForeColor = Color.Red;
                textBoxPrenumeVanzator.Clear();
                return;
            }
            autoturism.Nume_Vanzator = textBoxNumeVanzator.Text.ToUpper().Trim();
            autoturism.Prenume_Vanzator = textBoxPrenumeVanzator.Text.ToUpper().Trim();

            //Cumparator
            if (!IsString(textBoxNumeCumparator.Text))
            {
                labelNumeCumparator.ForeColor = Color.Red;
                textBoxNumeCumparator.Clear();
                return;
            }
            if (!IsString(textBoxPrenumeCumparator.Text))
            {
                labelPrenumeCumparator.ForeColor = Color.Red;
                textBoxPrenumeCumparator.Clear();
                return;
            }
            autoturism.Nume_Cumparator = textBoxNumeCumparator.Text.ToUpper().Trim();
            autoturism.Prenume_Cumparator = textBoxPrenumeCumparator.Text.ToUpper().Trim();

            DateTime data;
            if (!DateTime.TryParse(textBoxDataTranzactie.Text, out data))
            {
                labelDataTranzactie.ForeColor = Color.Red;
                textBoxDataTranzactie.Clear();
                return;
            }
            //ProgramStudiu? specializareSelectata = GetProgramStudiuSelectat();
            
            
            autoturism.DataTranzactie = data;

            autoturism.Combustibil = (TipCombustibil)GetCombustibilSelectat();
            autoturism.CutieDeViteze = (TipCutie)GetTipCutieSelectat();
            autoturism.Caroserie = (TipCaroserie)GetTipCaroserie();
            autoturism.Culoare = (Culori)GetCuloareSelectat();

            rtbAfisare.AppendText(ConvertToStringRTB(autoturism));

            //adminAutoturisme.AddCar(autoturism);
            //listAutoturismeFisier.Add(autoturism);
            ResetControls();
        }

        private void btnAfisare_Click(object sender, EventArgs e)
        {
            rtbAfisare.Clear();
            //var antetTabel = String.Format("{0,-5}{1,-35}{2,20}{3,10}\n", "Id", "Nume Prenume", "ProgramStudiu", "Medie");
            //rtbAfisare.AppendText(antetTabel);

            /*
            List<Car> cars = adminAutoturisme.GetCarsFile();
            foreach (Car c in cars)
            {
                var linieTabel = c.ConvertToString();
                rtbAfisare.AppendText(linieTabel);
            }
            */

            foreach (Car c in listAutoturismeFisier)
            {
                var linieTabel = c.ConvertToString();
                rtbAfisare.AppendText(linieTabel + "\n");
            }

        }

        private void btnIesire_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }


        public static bool IsString(string s)
        {
            foreach(char c in s)
            {
                if (!char.IsLetter(c))
                    return false;
            }


            return true;
        }

        public void ResetControls()
        {
            labelMarca.ForeColor = Color.Black;
            textBoxMarca.Clear();
            labelModel.ForeColor = Color.Black;
            textBoxModel.Clear();
            labelAnFabricatie.ForeColor = Color.Black;
            textBoxAnFabricatie.Clear();
            labelCapacitate.ForeColor = Color.Black;
            textBoxCapacitate.Clear();
            labelPutere.ForeColor = Color.Black;
            textBoxPutere.Clear();
            labelPret.ForeColor = Color.Black;
            textBoxPret.Clear();
            labelNumeVanzator.ForeColor = Color.Black;
            textBoxNumeVanzator.Clear();

            labelNumeVanzator.ForeColor = Color.Black;
            textBoxNumeVanzator.Clear();
            labelPrenumeVanzator.ForeColor = Color.Black;
            textBoxPrenumeVanzator.Clear();

            labelNumeCumparator.ForeColor = Color.Black;
            textBoxNumeCumparator.Clear();
            labelPrenumeCumparator.ForeColor = Color.Black;
            textBoxPrenumeCumparator.Clear();

            labelDataTranzactie.ForeColor = Color.Black;
            textBoxDataTranzactie.Clear();
        }

        public string ConvertToStringRTB(Car a)
        {

            return "Firma: " + (a.Marca ?? "NECUNOSCUT") + "\n" +
                   "Model: " + (a.Model ?? "NECUNOSCUT") + "\n" +
                   "An Fabricatie: " + (a.AnFabricatie.ToString() ?? "NECUNOSCUT") + "\n" +
                   "Capacitate Cilindrica: " + (a.CapacitateCilindrica.ToString() ?? "NECUNOSCUT") + "\n" +
                   "Putere: " + (a.Putere.ToString() ?? "NECUNOSCUT") + "\n" +
                   "Combustibil: " + (a.Combustibil.ToString() ?? "NECUNOSCUT") + "\n" +
                   "Cutie de viteze: " + (a.CutieDeViteze.ToString() ?? "NECUNOSCUT") + "\n" +
                   "Caroserie: " + (a.Caroserie.ToString() ?? "NECUNOSCUT") + "\n" +
                   "Culoare: " + (a.Culoare.ToString() ?? "NECUNOSCUT") + "\n" +
                   "Pret: " + (a.Pret.ToString() ?? "NECUNOSCUT") + "\n" +
                   "Nume Vanzator: " + (a.Nume_Vanzator + " " + a.Prenume_Vanzator ?? "NECUNOSCUT") + "\n" +
                   "Nume Cumparator: " + (a.Nume_Cumparator + " " + a.Prenume_Cumparator ?? "NECUNOSCUT") + "\n" +
                   "Data Tranzactie: " + (a.DataTranzactie.ToString("dd.MM.yyyy") ?? "01.01.2000") + "\n";
        }
        public TipCombustibil? GetCombustibilSelectat()
        {
            if (rdbBenzina.Checked)
                return TipCombustibil.BENZINA;
            if (rdbDiesel.Checked)
                return TipCombustibil.DIESEL;
            if (rdbGpl.Checked)
                return TipCombustibil.GPL;
            if (rdbHibrid.Checked)
                return TipCombustibil.HIBRID;
            if (rdbElectric.Checked)
                return TipCombustibil.ELECTRIC;
            if (rdbBenzinaGpl.Checked)
                return TipCombustibil.BENZINA_GPL;

            return null;
        }

        public TipCutie? GetTipCutieSelectat()
        {
            if (rdbCutieManuala.Checked)
                return TipCutie.MANUALA;
            if (rdbCutieAutomata.Checked)
                return TipCutie.AUTOMATA;
            return null;
        }

        public TipCaroserie? GetTipCaroserie()
        {
            if (rdbCabrio.Checked)
                return TipCaroserie.CABRIO;
            if (rdbBerlina.Checked)
                return TipCaroserie.BERLINA;
            if (rdbCoupe.Checked)
                return TipCaroserie.COUPE;
            if (rdbPickup.Checked)
                return TipCaroserie.PICKUP;
            if (rdbBreak.Checked)
                return TipCaroserie.BREAK;
            if (rdbHatchback.Checked)
                return TipCaroserie.HATCHBACK;
            if (rdbOffroad.Checked)
                return TipCaroserie.OFF_ROAD;
            if (rdbMinibus.Checked)
                return TipCaroserie.MINIBUS;
            if (rdbMonovolum.Checked)
                return TipCaroserie.MONOVOLUM;
            if (rdbSUV.Checked)
                return TipCaroserie.SUV;

            return null;
        }

        public Culori? GetCuloareSelectat()
        {
            if (rdbNegru.Checked)
                return Culori.NEGRU;
            if (rdbAlb.Checked)
                return Culori.ALB;
            if (rdbGri.Checked)
                return Culori.GRI;
            if (rdbRosu.Checked)
                return Culori.ROSU;
            if (rdbAlbastru.Checked)
                return Culori.ALBASTRU;
            if (rdbVerde.Checked)
                return Culori.VERDE;
            if (rdbPortocaliu.Checked)
                return Culori.PORTOCALIU;
            if (rdbMov.Checked)
                return Culori.MOV;

            return null;
        }
    }
}
