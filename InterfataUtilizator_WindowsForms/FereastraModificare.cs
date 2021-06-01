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
    public partial class FereastraModificare : Form
    {
        Car autoturismModificat;//retin ce autoturism trebuie schimbat
        IStocareData adminAutoturisme;
        List<Car> listAutoturismeFisier;
        const int capacitateMin = 500;
        const int capacitateMax = 15000;
        const int putereMin = 50;
        const int putereMax = 4000;
        const int pretMin = 200;
        //int index;
        public FereastraModificare()
        {
            InitializeComponent();
            adminAutoturisme = StocareFactory.GetAdministratorStocare();
            listAutoturismeFisier = adminAutoturisme.GetCarsFile();
            dataGridAfisare.DataSource = null;
            dataGridAfisare.DataSource = listAutoturismeFisier;
            dataGridAfisare.ColumnHeadersDefaultCellStyle.Font = new Font("Lucida Console", 10, FontStyle.Bold);
        }

        public FereastraModificare(Car c)
        {
            InitializeComponent();
            adminAutoturisme = StocareFactory.GetAdministratorStocare();
            listAutoturismeFisier = adminAutoturisme.GetCarsFile();
            panelAfisareListaAutoturisme.Visible = false;
            panelBackground.Visible = true;
            buttonModificare.Visible = true;
            autoturismModificat = c;

            IntroducereDate(c);
            dataGridAfisare.ColumnHeadersDefaultCellStyle.Font = new Font("Lucida Console", 10, FontStyle.Bold);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }


        private void buttonReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridAfisare_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            autoturismModificat = (Car)dataGridAfisare.CurrentRow.DataBoundItem;
            panelAfisareListaAutoturisme.Visible = false;
            panelBackground.Visible = true;
            buttonModificare.Visible = true;
            buttonSelecteaza.Visible = true;
            buttonElimina.Visible = true;

            IntroducereDate(autoturismModificat);
        }

        private void IntroducereDate(Car autoturism)
        {
            textBoxMarca.Text = autoturism.Marca;
            textBoxModel.Text = autoturism.Model;
            textBoxAnFabricatie.Text = autoturism.AnFabricatie.ToString();
            textBoxCapacitate.Text = autoturism.CapacitateCilindrica.ToString();
            textBoxPutere.Text = autoturism.Putere.ToString();
            textBoxPret.Text = autoturism.Pret.ToString();
            textBoxNumeVanzator.Text = autoturism.Nume_Vanzator;
            textBoxPrenumeVanzator.Text = autoturism.Prenume_Vanzator;
            textBoxNumeCumparator.Text = autoturism.Nume_Cumparator;
            textBoxPrenumeCumparator.Text = autoturism.Prenume_Cumparator;
            textBoxDataTranzactie.Text = autoturism.DataTranzactie.ToString("dd.MM.yyyy");

            foreach (Control control in panelCombustibil.Controls)
            {
                if (control.GetType() == typeof(RadioButton))
                {
                    if (autoturism.Combustibil.ToString() == control.Text.ToUpper())
                    {
                        ((RadioButton)control).Checked = true;
                    }
                }
            }

            foreach (Control control in panelCutie.Controls)
            {
                if (control.GetType() == typeof(RadioButton))
                {
                    if (autoturism.CutieDeViteze.ToString() == control.Text.ToUpper())
                    {
                        ((RadioButton)control).Checked = true;
                    }
                }
            }

            foreach (Control control in panelCaroserie.Controls)
            {
                if (control.GetType() == typeof(RadioButton))
                {
                    if (autoturism.Caroserie.ToString() == control.Text.ToUpper())
                    {
                        ((RadioButton)control).Checked = true;
                    }
                }
            }
            foreach (Control control in panelCulori.Controls)
            {
                if (control.GetType() == typeof(RadioButton))
                {
                    if (autoturism.Culoare.ToString() == control.Text.ToUpper())
                    {
                        ((RadioButton)control).Checked = true;
                    }
                }
            }

            foreach (Control control in panelOptiuni.Controls)
            {
                if (control.GetType() == typeof(CheckBox))
                {
                    foreach (string optiune in autoturism.Optiuni)
                        if (((CheckBox)control).Text == optiune)
                            ((CheckBox)control).Checked = true;
                }
            }
        }

        private void buttonModificare_Click(object sender, EventArgs e)
        {
            if (autoturismModificat == null)
                return;
            ResetColors();
            labelConfirmareAdaugare.Visible = false;
            labelEroareIntroducere.Visible = false;
            listAutoturismeFisier = adminAutoturisme.GetCarsFile();
            if (dataGridAfisare.DataSource == null ||dataGridAfisare.CurrentRow.Index == -1)
            {
                int index;
                index = CautaElement(autoturismModificat);
                ModificaElement(index);
                if (ValidareCampuri(listAutoturismeFisier.ElementAt(index)) == false)
                    return;
            }
            else
            {
                if (ValidareCampuri(listAutoturismeFisier.ElementAt(dataGridAfisare.CurrentRow.Index)) == false)
                    return;
                ModificaElement(dataGridAfisare.CurrentRow.Index);
            }
            labelConfirmareAdaugare.Text = "Autoturismul a fost modificat";
            labelConfirmareAdaugare.Visible = true;
            adminAutoturisme.RewriteCars(listAutoturismeFisier);
        }

        private int CautaElement(Car c)
        {
            int contor = 0;
            bool gasit = true;

            foreach (Car autoturism in listAutoturismeFisier)
            {
                gasit = true;
                if (autoturism.Marca != c.Marca || autoturism.Model != c.Model || autoturism.AnFabricatie != c.AnFabricatie)
                    gasit = false;
                if (autoturism.CapacitateCilindrica != c.CapacitateCilindrica || autoturism.Putere != c.Putere || autoturism.Combustibil != c.Combustibil)
                    gasit = false;
                if (autoturism.CutieDeViteze != c.CutieDeViteze || autoturism.Caroserie != c.Caroserie|| autoturism.Culoare != c.Culoare || autoturism.Pret != c.Pret)
                    gasit = false;
                if (autoturism.Nume_Vanzator != c.Nume_Vanzator || autoturism.Prenume_Vanzator != c.Prenume_Vanzator)
                    gasit = false;
                if (autoturism.Nume_Cumparator != c.Nume_Cumparator || autoturism.Prenume_Cumparator != c.Prenume_Cumparator)
                    gasit = false;
                if (autoturism.DataTranzactie != c.DataTranzactie)
                    gasit = false;
                if (autoturism.Optiuni.Count != c.Optiuni.Count)
                    gasit = false;
                else
                {
                    for (int i = 0; i < autoturism.Optiuni.Count; i++)
                    {
                        if (autoturism.Optiuni[i] != c.Optiuni[i])
                            gasit = false;
                    }
                }
                
                if(gasit == true)
                {
                    return contor;
                }
                contor++;
            }
            return contor;
        }
        private void ModificaElement(int  _index)
        {
            listAutoturismeFisier.ElementAt(_index).Marca = textBoxMarca.Text.ToUpper().Trim();
            listAutoturismeFisier.ElementAt(_index).Model = textBoxModel.Text.ToUpper().Trim();
            listAutoturismeFisier.ElementAt(_index).AnFabricatie = Convert.ToInt32(textBoxAnFabricatie.Text.Trim());
            listAutoturismeFisier.ElementAt(_index).CapacitateCilindrica = Convert.ToInt32(textBoxCapacitate.Text.Trim());
            listAutoturismeFisier.ElementAt(_index).Putere = Convert.ToInt32(textBoxPutere.Text.Trim());
            listAutoturismeFisier.ElementAt(_index).Pret = Convert.ToInt32(textBoxPret.Text.Trim());
            DateTime data;
            DateTime.TryParse(textBoxDataTranzactie.Text.Trim(), out data);
            listAutoturismeFisier.ElementAt(_index).DataTranzactie = data;
            listAutoturismeFisier.ElementAt(_index).Combustibil = (TipCombustibil)GetCombustibilSelectat();
            listAutoturismeFisier.ElementAt(_index).CutieDeViteze = (TipCutie)GetTipCutieSelectat();
            listAutoturismeFisier.ElementAt(_index).Caroserie = (TipCaroserie)GetTipCaroserie();
            listAutoturismeFisier.ElementAt(_index).Culoare = (Culori)GetCuloareSelectat();
            listAutoturismeFisier.ElementAt(_index).Optiuni = GetOptiuniSelectate();

            listAutoturismeFisier.ElementAt(_index).Nume_Vanzator = textBoxNumeVanzator.Text.ToUpper().Trim();
            listAutoturismeFisier.ElementAt(_index).Prenume_Vanzator = textBoxPrenumeVanzator.Text.ToUpper().Trim();
            listAutoturismeFisier.ElementAt(_index).Nume_Cumparator = textBoxNumeCumparator.Text.ToUpper().Trim();
            listAutoturismeFisier.ElementAt(_index).Prenume_Cumparator = textBoxPrenumeCumparator.Text.ToUpper().Trim();
        }


        #region Validare
        private bool ValidareCampuri(Car c)
        {
            int inputInt;
            bool isCorrect = true;
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

            if (int.TryParse(textBoxAnFabricatie.Text, out inputInt))
            {
                if (inputInt < 1900 || inputInt > DateTime.UtcNow.Year)
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
                if (inputInt < capacitateMin || inputInt > capacitateMax)
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
                if (inputInt < putereMin || inputInt > putereMax)
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
                if (inputInt < pretMin)
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

            DateTime data;
            if (!DateTime.TryParse(textBoxDataTranzactie.Text, out data))
            {
                labelDataTranzactie.ForeColor = Color.Red;
                textBoxDataTranzactie.Clear();
                isCorrect = false;
            }

            if (data.Year < c.AnFabricatie)
            {
                labelDataTranzactie.ForeColor = Color.Red;
                textBoxDataTranzactie.Clear();
                isCorrect = false;
            }

            if (!GetCombustibilSelectat().HasValue)
            {
                labelCombustibil.ForeColor = Color.Red;
                isCorrect = false;
            }
            if (!GetTipCutieSelectat().HasValue)
            {
                labelCutieDeViteze.ForeColor = Color.Red;
                isCorrect = false;
            }
            if (!GetTipCaroserie().HasValue)
            {
                labelCaroserie.ForeColor = Color.Red;
                isCorrect = false;
            }
            if (!GetCuloareSelectat().HasValue)
            {
                labelCuloare.ForeColor = Color.Red;
                isCorrect = false;
            }

            //autoturism.Optiuni = GetOptiuniSelectate();

            if (!isCorrect)
            {
                labelEroareIntroducere.Visible = true;
                return false;
            }

            return true;
        }
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

        #region Selectare optiuni
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

        #region Resetare
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

        private void buttonAfisare_Click_1(object sender, EventArgs e)
        {
            listAutoturismeFisier = adminAutoturisme.GetCarsFile();
            if (listAutoturismeFisier == null)
                return;
            if (listAutoturismeFisier.Count == 0)
                return;
            labelConfirmareAdaugare.Visible = false;
            labelEroareIntroducere.Visible = false;
            buttonSelecteaza.Visible = false;
            buttonModificare.Visible = false;
            buttonElimina.Visible = false;
            panelBackground.Visible = false;
            panelAfisareListaAutoturisme.Visible = true;
            dataGridAfisare.DataSource = listAutoturismeFisier;
            ResetControls();
        }

        private void buttonElimina_Click(object sender, EventArgs e)
        {
            bool succes = false;
            if (listAutoturismeFisier.Count == 0)
                return;
            if (dataGridAfisare.DataSource == null)
                return;
            labelConfirmareAdaugare.Visible = false;
            if (dataGridAfisare.CurrentRow.Selected == true)
            {
                listAutoturismeFisier.RemoveAt(dataGridAfisare.CurrentRow.Index);
                succes = true;
            }
            if (succes)
            {
                autoturismModificat = null; 
                //rtbAfisare.Text = "Eliminarea a avut succes
                ResetControls();
                ResetColors();
                adminAutoturisme.RewriteCars(listAutoturismeFisier);
                labelConfirmareAdaugare.Text = "Autoturismul a fost eliminat";
                labelConfirmareAdaugare.Visible = true;
            }
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            string message = "Proiect realizat de Brumă Sebastian 3123 B An 2 Calculatoare";
            string title = "INFO";
            MessageBox.Show(message, title);
        }
    }
}
