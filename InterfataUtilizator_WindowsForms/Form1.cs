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
                labelEroareIntroducere.Visible = true;
                textBoxMarca.Clear();
                return;
            }
            Car autoturism = new Car(textBoxMarca.Text.ToUpper().Trim(), textBoxModel.Text.ToUpper().Trim());
            labelMarca.ForeColor = Color.Black;
            if (int.TryParse(textBoxAnFabricatie.Text, out inputInt))
            {
                if (inputInt > 1900 && inputInt < DateTime.UtcNow.Year)
                    autoturism.AnFabricatie = inputInt;
                else
                {
                    labelAnFabricatie.ForeColor = Color.Red;
                    labelEroareIntroducere.Visible = true;
                    textBoxAnFabricatie.Clear();
                    return;
                }
            }
            else
            {
                labelAnFabricatie.ForeColor = Color.Red;
                labelEroareIntroducere.Visible = true;
                textBoxAnFabricatie.Clear();
                return;
            }
            labelAnFabricatie.ForeColor = Color.Black;

            if (int.TryParse(textBoxCapacitate.Text, out inputInt))
            {
                if (inputInt > 800 && inputInt < 10000)
                    autoturism.CapacitateCilindrica = inputInt;
                else
                {
                    labelCapacitate.ForeColor = Color.Red;
                    labelEroareIntroducere.Visible = true;
                    textBoxCapacitate.Clear();
                    return;
                }
            }
            else
            {
                labelCapacitate.ForeColor = Color.Red;
                labelEroareIntroducere.Visible = true;
                textBoxCapacitate.Clear();
                return;
            }
            labelCapacitate.ForeColor = Color.Black;

            if (int.TryParse(textBoxPutere.Text, out inputInt))
            {
                if (inputInt > 50 && inputInt < 3000)
                    autoturism.Putere = inputInt;
                else
                {
                    labelPutere.ForeColor = Color.Red;
                    labelEroareIntroducere.Visible = true;
                    textBoxPutere.Clear();
                    return;
                }
            }
            else
            {
                labelPutere.ForeColor = Color.Red;
                labelEroareIntroducere.Visible = true;
                textBoxPutere.Clear();
                return;
            }
            labelPutere.ForeColor = Color.Black;

            if (int.TryParse(textBoxPret.Text, out inputInt))
            {
                if (inputInt >= 500)
                    autoturism.Pret = inputInt;
                else
                {
                    labelPret.ForeColor = Color.Red;
                    labelEroareIntroducere.Visible = true;
                    textBoxPret.Clear();
                    return;
                }
            }
            else
            {
                labelPret.ForeColor = Color.Red;
                labelEroareIntroducere.Visible = true;
                textBoxPret.Clear();
                return;
            }
            labelPret.ForeColor = Color.Black;

            //Vanzator
            if (!IsString(textBoxNumeVanzator.Text))
            {
                labelNumeVanzator.ForeColor = Color.Red;
                labelEroareIntroducere.Visible = true;
                textBoxNumeVanzator.Clear();
                return;
            }
            labelNumeVanzator.ForeColor = Color.Black;
            if (!IsString(textBoxPrenumeVanzator.Text))
            {
                labelPrenumeVanzator.ForeColor = Color.Red;
                labelEroareIntroducere.Visible = true;
                textBoxPrenumeVanzator.Clear();
                return;
            }
            labelPrenumeVanzator.ForeColor = Color.Black;

            autoturism.Nume_Vanzator = textBoxNumeVanzator.Text.ToUpper().Trim();
            autoturism.Prenume_Vanzator = textBoxPrenumeVanzator.Text.ToUpper().Trim();

            //Cumparator
            if (!IsString(textBoxNumeCumparator.Text))
            {
                labelNumeCumparator.ForeColor = Color.Red;
                labelEroareIntroducere.Visible = true;
                textBoxNumeCumparator.Clear();
                return;
            }
            labelNumeCumparator.ForeColor = Color.Black;

            if (!IsString(textBoxPrenumeCumparator.Text))
            {
                labelPrenumeCumparator.ForeColor = Color.Red;
                labelEroareIntroducere.Visible = true;
                textBoxPrenumeCumparator.Clear();
                return;
            }
            labelPrenumeCumparator.ForeColor = Color.Black;

            autoturism.Nume_Cumparator = textBoxNumeCumparator.Text.ToUpper().Trim();
            autoturism.Prenume_Cumparator = textBoxPrenumeCumparator.Text.ToUpper().Trim();

            DateTime data;
            if (!DateTime.TryParse(textBoxDataTranzactie.Text, out data))
            {
                labelDataTranzactie.ForeColor = Color.Red;
                labelEroareIntroducere.Visible = true;
                textBoxDataTranzactie.Clear();
                return;
            }
            labelDataTranzactie.ForeColor = Color.Black;

            if (data.Year < autoturism.AnFabricatie)
            {
                labelDataTranzactie.ForeColor = Color.Red;
                labelEroareIntroducere.Visible = true;
                textBoxDataTranzactie.Clear();
                return;
            }
            labelDataTranzactie.ForeColor = Color.Black;

            autoturism.DataTranzactie = data;
            if(GetCombustibilSelectat().HasValue)
                autoturism.Combustibil = (TipCombustibil)GetCombustibilSelectat();
            if(GetTipCutieSelectat().HasValue)
                autoturism.CutieDeViteze = (TipCutie)GetTipCutieSelectat();
            if(GetTipCaroserie().HasValue)
                autoturism.Caroserie = (TipCaroserie)GetTipCaroserie();
            if(GetCuloareSelectat().HasValue)
            autoturism.Culoare = (Culori)GetCuloareSelectat();

            autoturism.Optiuni = GetOptiuniSelectate();

            rtbAfisare.AppendText(autoturism.ConvertToString());
            adminAutoturisme.AddCar(autoturism);
            Car.LastIndexAutoturism = 0;
            listAutoturismeFisier = adminAutoturisme.GetCarsFile();
            ResetControls();
        }

        private void btnAfisare_Click(object sender, EventArgs e)
        {
            rtbAfisare.Clear();

            foreach (Car c in listAutoturismeFisier)
            {
                string linieTabel = c.ConvertToString();
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

            rtbAfisare.Clear();
            labelEroareIntroducere.Visible = false;

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

            foreach(RadioButton rb in groupBoxCombustibil.Controls)
            {
                if (rb.Checked)
                    rb.Checked = false;
            }
            foreach (RadioButton rb in gpbCutie.Controls)
            {
                if (rb.Checked)
                    rb.Checked = false;
            }
            foreach (RadioButton rb in gpbCaroserie.Controls)
            {
                if (rb.Checked)
                    rb.Checked = false;
            }
            foreach (RadioButton rb in gpbCulori.Controls)
            {
                if (rb.Checked)
                    rb.Checked = false;
            }
            foreach (CheckBox cb in gpbOptiuni.Controls)
            {
                if (cb.Checked)
                    cb.Checked = false;
            }
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

        #region GROUP BOX SELECT
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
            if (rdbGalben.Checked)
                return Culori.GALBEN;
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
        public List<string> GetOptiuniSelectate()
        {
            List<string> optiuni = new List<string>();
            foreach(CheckBox cb in gpbOptiuni.Controls)
            {
                if (cb.Checked)
                {
                    optiuni.Add(cb.Text);
                }
            }
            if (optiuni.Count == 0)
                optiuni.Add("NONE");

            return optiuni;
        }
        #endregion

        private void btnCautare_Click(object sender, EventArgs e)
        {
            if (textBoxMarca.Text == string.Empty || textBoxModel.Text == string.Empty)
            {
                labelMarca.ForeColor = Color.Red;
                labelModel.ForeColor = Color.Red;
                return;
            }
            if (btnCautare.Tag.ToString() == "1")
                btnCautare.Tag = "0";
            else if (btnCautare.Tag.ToString() == "0")
                btnCautare.Tag = "1";

            DeactivateControlsForSearch();
            if (!IsString(textBoxMarca.Text))
            {
                labelMarca.ForeColor = Color.Red;
                textBoxMarca.Clear();
                return;
            }
            Car autoturismCautat = new Car(textBoxMarca.Text.ToUpper().Trim(), textBoxModel.Text.ToUpper().Trim());
            List<Car> autoturismeCautate = adminAutoturisme.SearchCars(autoturismCautat, listAutoturismeFisier);
            if(autoturismeCautate.Count == 0)
            {
                rtbAfisare.AppendText("- NONE -");
                return;
            }
            foreach(Car c in autoturismeCautate)
            {
                rtbAfisare.AppendText("ID: " +  c.IndexAutoturism + "\n" + c.ConvertToString() + "\n");
            }

        }
        public void DeactivateControlsForSearch()
        {
            rtbAfisare.Clear();
            if(btnCautare.Tag.ToString() == "1")
            {
                btnModificare.Enabled = true;
                labelID.Visible = true;
                textBoxID.Visible = true;

                textBoxAnFabricatie.Enabled = false;
                textBoxCapacitate.Enabled = false;
                textBoxPutere.Enabled = false;
                textBoxNumeVanzator.Enabled = false;
                textBoxNumeVanzator.Enabled = false;
                textBoxPrenumeVanzator.Enabled = false;
                textBoxNumeCumparator.Enabled = false;
                textBoxPrenumeCumparator.Enabled = false;
                textBoxDataTranzactie.Enabled = false;

                btnAdauga.Enabled = false;
                btnAfiseaza.Enabled = false;

                foreach (RadioButton rb in groupBoxCombustibil.Controls)
                {
                    rb.Enabled = false;
                }
                foreach (RadioButton rb in gpbCutie.Controls)
                {
                    rb.Enabled = false;
                }
                foreach (RadioButton rb in gpbCaroserie.Controls)
                {
                    rb.Enabled = false;
                }
                foreach (RadioButton rb in gpbCulori.Controls)
                {
                    rb.Enabled = false;
                }
                foreach (CheckBox cb in gpbOptiuni.Controls)
                {
                    cb.Enabled = false;
                }
            }
            else if(btnCautare.Tag.ToString() == "0")
            {
                ResetControls();
                btnModificare.Enabled = false;
                labelID.Visible = false;
                textBoxID.Visible = false;

                textBoxAnFabricatie.Enabled = true;
                textBoxCapacitate.Enabled = true;
                textBoxPutere.Enabled = true;
                textBoxNumeVanzator.Enabled = true;
                textBoxNumeVanzator.Enabled = true;
                textBoxPrenumeVanzator.Enabled = true;
                textBoxNumeCumparator.Enabled = true;
                textBoxPrenumeCumparator.Enabled = true;
                textBoxDataTranzactie.Enabled = true;

                btnAdauga.Enabled = true;
                btnAfiseaza.Enabled = true;

                foreach (RadioButton rb in groupBoxCombustibil.Controls)
                {
                    rb.Enabled = true;
                }
                foreach (RadioButton rb in gpbCutie.Controls)
                {
                    rb.Enabled = true;
                }
                foreach (RadioButton rb in gpbCaroserie.Controls)
                {
                    rb.Enabled = true;
                }
                foreach (RadioButton rb in gpbCulori.Controls)
                {
                    rb.Enabled = true;
                }
                foreach (CheckBox cb in gpbOptiuni.Controls)
                {
                    cb.Enabled = true;
                }
            }
            
        }

        private void btnModificare_Click(object sender, EventArgs e)
        {
            if (btnCautare.Tag.ToString() == "0")
                return;
            if (textBoxID.Text == string.Empty || !int.TryParse(textBoxID.Text, out int inputID))
            {
                labelID.ForeColor = Color.Red;
                return;
            }
            if (textBoxPret.Text == string.Empty || !int.TryParse(textBoxPret.Text, out int inputPret))
            {
                labelPret.ForeColor = Color.Red;
                return;
            }

            foreach(Car c in listAutoturismeFisier)
            {
                if(c.IndexAutoturism == inputID)
                {
                    c.Pret = inputPret;
                    rtbAfisare.Clear();
                    rtbAfisare.AppendText("Modificare cu succes\n\n" + c.ConvertToString());
                    break;
                }
            }
            adminAutoturisme.RewriteCars(listAutoturismeFisier);
        }
    }
}
