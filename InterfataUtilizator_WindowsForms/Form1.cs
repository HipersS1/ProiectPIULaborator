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
        //LABORATOR 5 + 6
        IStocareData adminAutoturisme;
        List<Car> listAutoturismeFisier;
        const int capacitateMin = 500;
        const int capacitateMax = 15000;
        const int putereMin = 50;
        const int putereMax = 4000;
        const int pretMin = 200;


        public Form1()
        {
            InitializeComponent();
            adminAutoturisme = StocareFactory.GetAdministratorStocare();
            listAutoturismeFisier = adminAutoturisme.GetCarsFile();
        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            int inputInt;
            bool isCorrect = true;
            ResetColors();
            if(!IsString(textBoxMarca.Text))
            {
                labelMarca.ForeColor = Color.Red;
                textBoxMarca.Clear();
                isCorrect = false;
            }
            if (string.IsNullOrEmpty(textBoxModel.Text))
            {
                labelModel.ForeColor = Color.Red;
                isCorrect = false;
            }
            Car autoturism = new Car(textBoxMarca.Text.ToUpper().Trim(), textBoxModel.Text.ToUpper().Trim());

            if (int.TryParse(textBoxAnFabricatie.Text, out inputInt))
            {
                if (inputInt > 1900 && inputInt < DateTime.UtcNow.Year)
                    autoturism.AnFabricatie = inputInt;
                else
                {
                    labelAnFabricatie.ForeColor = Color.Red;
                    textBoxAnFabricatie.Clear();
                    isCorrect = false;
                }
            }
            else
            {
                labelAnFabricatie.ForeColor = Color.Red;
                textBoxAnFabricatie.Clear();
                isCorrect = false;
            }

            if (int.TryParse(textBoxCapacitate.Text, out inputInt))
            {
                if (inputInt > capacitateMin && inputInt < capacitateMax)
                    autoturism.CapacitateCilindrica = inputInt;
                else
                {
                    labelCapacitate.ForeColor = Color.Red;
                    textBoxCapacitate.Clear();
                    isCorrect = false;
                }
            }
            else
            {
                labelCapacitate.ForeColor = Color.Red;
                textBoxCapacitate.Clear();
                isCorrect = false;
            }

            if (int.TryParse(textBoxPutere.Text, out inputInt))
            {
                if (inputInt > putereMin && inputInt < putereMax)
                    autoturism.Putere = inputInt;
                else
                {
                    labelPutere.ForeColor = Color.Red;
                    textBoxPutere.Clear();
                    isCorrect = false;
                }
            }
            else
            {
                labelPutere.ForeColor = Color.Red;
                textBoxPutere.Clear();
                isCorrect = false;
            }

            if (int.TryParse(textBoxPret.Text, out inputInt))
            {
                if (inputInt >= pretMin)
                    autoturism.Pret = inputInt;
                else
                {
                    labelPret.ForeColor = Color.Red;
                    textBoxPret.Clear();
                    isCorrect = false;
                }
            }
            else
            {
                labelPret.ForeColor = Color.Red;
                textBoxPret.Clear();
                isCorrect = false;
            }

            //Vanzator
            if (!IsString(textBoxNumeVanzator.Text))
            {
                labelNumeVanzator.ForeColor = Color.Red;
                textBoxNumeVanzator.Clear();
                isCorrect = false;
            }

            if (!IsString(textBoxPrenumeVanzator.Text))
            {
                labelPrenumeVanzator.ForeColor = Color.Red;
                textBoxPrenumeVanzator.Clear();
                isCorrect = false;
            }

            autoturism.Nume_Vanzator = textBoxNumeVanzator.Text.ToUpper().Trim();
            autoturism.Prenume_Vanzator = textBoxPrenumeVanzator.Text.ToUpper().Trim();

            //Cumparator
            if (!IsString(textBoxNumeCumparator.Text))
            {
                labelNumeCumparator.ForeColor = Color.Red;
                textBoxNumeCumparator.Clear();
                isCorrect = false;
            }

            if (!IsString(textBoxPrenumeCumparator.Text))
            {
                labelPrenumeCumparator.ForeColor = Color.Red;
                textBoxPrenumeCumparator.Clear();
                isCorrect = false;
            }

            autoturism.Nume_Cumparator = textBoxNumeCumparator.Text.ToUpper().Trim();
            autoturism.Prenume_Cumparator = textBoxPrenumeCumparator.Text.ToUpper().Trim();

            DateTime data;
            if (!DateTime.TryParse(textBoxDataTranzactie.Text, out data))
            {
                labelDataTranzactie.ForeColor = Color.Red;
                textBoxDataTranzactie.Clear();
                isCorrect = false;
            }

            if (data.Year < autoturism.AnFabricatie)
            {
                labelDataTranzactie.ForeColor = Color.Red;
                textBoxDataTranzactie.Clear();
                isCorrect = false;
            }

            autoturism.DataTranzactie = data;
            if(GetCombustibilSelectat().HasValue)
                autoturism.Combustibil = (TipCombustibil)GetCombustibilSelectat();
            else
            {
                labelCombustibil.ForeColor = Color.Red;
                isCorrect = false;
            }
            if(GetTipCutieSelectat().HasValue)
                autoturism.CutieDeViteze = (TipCutie)GetTipCutieSelectat();
            else
            {
                labelCutieDeViteze.ForeColor = Color.Red;
                isCorrect = false;
            }
            if (GetTipCaroserie().HasValue)
                autoturism.Caroserie = (TipCaroserie)GetTipCaroserie();
            else
            {
                labelCaroserie.ForeColor = Color.Red;
                isCorrect = false;
            }
            if (GetCuloareSelectat().HasValue)
            autoturism.Culoare = (Culori)GetCuloareSelectat();
            else
            {
                labelCuloare.ForeColor = Color.Red;
                isCorrect = false;
            }

            autoturism.Optiuni = GetOptiuniSelectate();

            if (!isCorrect)
            {
                labelEroareIntroducere.Visible = true;
                return;
            }

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
            if (string.IsNullOrEmpty(s))
                return false;
            foreach(char c in s)
            {
                if (!char.IsLetter(c))
                    return false;
            }

            return true;
        }

        #region Reset CONTROLS / COLORS
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

        public void ResetColors()
        {
            labelMarca.ForeColor = Color.Black;
            labelModel.ForeColor = Color.Black;
            labelAnFabricatie.ForeColor = Color.Black;
            labelCapacitate.ForeColor = Color.Black;
            labelPutere.ForeColor = Color.Black;
            labelPret.ForeColor = Color.Black;
            labelNumeVanzator.ForeColor = Color.Black;
            labelPrenumeVanzator.ForeColor = Color.Black;
            labelNumeCumparator.ForeColor = Color.Black;
            labelPrenumeCumparator.ForeColor = Color.Black;
            labelDataTranzactie.ForeColor = Color.Black;
            labelCombustibil.ForeColor = Color.Black;
            labelCutieDeViteze.ForeColor = Color.Black;
            labelCaroserie.ForeColor = Color.Black;
            labelCuloare.ForeColor = Color.Black;

        }

        #endregion

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

        #region Cautare/Modificare
        private void btnCautare_Click(object sender, EventArgs e)
        {
            bool isCorrect = true;
            ResetColors();
            rtbAfisare.Clear();
            //ActivateControls();
            if (!IsString(textBoxMarca.Text))
            {
                labelMarca.ForeColor = Color.Red;
                textBoxMarca.Clear();
                isCorrect = false;
            }
            if (string.IsNullOrEmpty(textBoxModel.Text))
            {
                labelModel.ForeColor = Color.Red;
                isCorrect = false;
            }
            //Daca datele au fost introduse corect se va face cautarea
            if (!isCorrect)
                return;

            Car autoturismCautat = new Car(textBoxMarca.Text.ToUpper().Trim(), textBoxModel.Text.ToUpper().Trim());
            List<Car> autoturismeCautate = adminAutoturisme.SearchCars(autoturismCautat, listAutoturismeFisier);

            foreach(Car c in autoturismeCautate)
            {
                rtbAfisare.AppendText("ID: " +  c.IndexAutoturism + "\n" + c.ConvertToString() + "\n");
            }

            DeactivateControlsForSearch(autoturismeCautate);

        }

        public void ActivateControls()
        {
            ResetControls();
            //btnModificare.Enabled = false;
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

        public void DeactivateControlsForSearch(List<Car> autoturismeCautate)
        {
            //rtbAfisare.Clear();
            if(autoturismeCautate.Count > 0)
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
            else
            {
                ActivateControls();
                rtbAfisare.AppendText(" - None - ");
            }
        }
        private void btnModificare_Click(object sender, EventArgs e)
        {
            if (labelID.Visible == false)
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
            adminAutoturisme.RewriteCars(listAutoturismeFisier);
            rtbAfisare.AppendText("Informatiile au fost actualizate");
        }
        #endregion
    }
}
