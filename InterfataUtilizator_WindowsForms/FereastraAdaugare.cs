using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NivelAccesDate;
using CarClass;

namespace InterfataUtilizator_WindowsForms
{
    public partial class FereastraAdaugare : Form
    {
        IStocareData adminAutoturisme;
        List<Car> listAutoturismeFisier;
        const int capacitateMin = 500;
        const int capacitateMax = 15000;
        const int putereMin = 50;
        const int putereMax = 4000;
        const int pretMin = 200;
        public FereastraAdaugare()
        {
            InitializeComponent();
            adminAutoturisme = StocareFactory.GetAdministratorStocare();
            listAutoturismeFisier = adminAutoturisme.GetCarsFile();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }


        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #region Resetare Controale/Culori
        public void ResetControls()
        {
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

            foreach (RadioButton rb in panelCombustibil.Controls)
            {
                if (rb.Checked)
                    rb.Checked = false;
            }
            foreach (RadioButton rb in panelCutie.Controls)
            {
                if (rb.Checked)
                    rb.Checked = false;
            }
            foreach (RadioButton rb in panelCaroserie.Controls)
            {
                if (rb.Checked)
                    rb.Checked = false;
            }
            foreach (RadioButton rb in panelCulori.Controls)
            {
                if (rb.Checked)
                    rb.Checked = false;
            }
            foreach (CheckBox cb in panelOptiuni.Controls)
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

        #region Validare
        public static bool IsString(string s)
        {
            if (string.IsNullOrEmpty(s))
                return false;
            foreach (char c in s)
            {
                if (!char.IsLetter(c))
                    return false;
            }

            return true;
        }
        #endregion

        #region Panel SELECT
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
            foreach (CheckBox cb in panelOptiuni.Controls)
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

        private void buttonAdauga_Click(object sender, EventArgs e)
        {
            int inputInt;
            bool isCorrect = true;
            ResetColors();
            labelConfirmareAdaugare.Visible = false;
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
            if (GetCombustibilSelectat().HasValue)
                autoturism.Combustibil = (TipCombustibil)GetCombustibilSelectat();
            else
            {
                labelCombustibil.ForeColor = Color.Red;
                isCorrect = false;
            }
            if (GetTipCutieSelectat().HasValue)
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
            labelConfirmareAdaugare.Visible = true;
            adminAutoturisme.AddCar(autoturism);
            listAutoturismeFisier = adminAutoturisme.GetCarsFile();
            ResetControls();
        }

        private void buttonReseteaza_Click(object sender, EventArgs e)
        {
            labelConfirmareAdaugare.Visible = false;
            ResetControls();
            ResetColors();
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            string message = "Proiect realizat de Brumă Sebastian 3123 B An 2 Calculatoare";
            string title = "INFO";
            MessageBox.Show(message, title);
        }
    }
}
