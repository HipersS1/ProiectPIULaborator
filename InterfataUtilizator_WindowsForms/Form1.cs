using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CarClass;
using NivelAccesDate;
using System.Linq;
using System.IO;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Form1 : Form
    {
        //LABORATOR 5 + 6
        IStocareData adminAutoturisme;
        List<Car> listAutoturismeFisier;
        string TextArea;
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

            adminAutoturisme.AddCar(autoturism);
            //Car.LastIndexAutoturism = 0;
            listAutoturismeFisier = adminAutoturisme.GetCarsFile();
            ResetControls();
            rtbAfisare.Clear();
            listBoxAfisare.Items.Clear();
            dataGridAfisare.DataSource = null;
            rtbAfisare.ForeColor = Color.Green;
            rtbAfisare.AppendText("Autoturismul a fost inregistrat cu succes\n\n");
            //Afisare();
        }


        #region Afisare

        private void Afisare()
        {
            ResetControls();
            ResetColors();
            //rtbAfisare.Clear();

            //foreach (Car c in listAutoturismeFisier)
            //{
            //    string linieTabel = c.ConvertToString();
            //    rtbAfisare.AppendText(linieTabel + "\n");
            //}

            dataGridAfisare.DataSource = null;
            dataGridAfisare.DataSource = listAutoturismeFisier;

            listBoxAfisare.Items.Clear();
            listBoxAfisare.Items.Add(String.Format($"{"Marca",-20}{"Model",-15}{"An",-5}{"CC",-7}" +
                $"{"Putere",-7}{"Combustibil",-12}{"Cutie",-11}{"Caroserie",-11}{"Culoare",-11}" +
                $"{"Pret",-10}{"Cumparator",-35}{"Vanzator",-35}{"Data Tranzacte",-17}{"Optiuni",-20}")) ;
            foreach (Car c in listAutoturismeFisier)
            {
                listBoxAfisare.Items.Add(c.ConvertToString3());
            }
        }
        private void btnAfisare_Click(object sender, EventArgs e)
        {
            Afisare();
        }
        #endregion

        #region Validari
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


        #endregion

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

            foreach (RadioButton rb in groupBoxCombustibil.Controls)
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
            foreach (CheckBox cb in gpbOptiuni.Controls)
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

        //Laborator 7  combobox
        private void btnCautare_Click(object sender, EventArgs e)
        {
            #region Cod Vechi
            /*
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

            //DeactivateControlsForSearch(autoturismeCautate);
            */

            /*
            using(CautareForms cautareForm = new CautareForms())
            {
                this.Hide();
                cautareForm.ShowDialog();
            }
            */
            #endregion

            CautareForms cautareForm = new CautareForms();
            this.Hide();
            cautareForm.ShowDialog();
            this.Show();
        }
        
        private void btnModificare_Click(object sender, EventArgs e)
        {
            if (listAutoturismeFisier.Count == 0)
                return;
            if (listBoxAfisare.SelectedIndex >= 1)
            {
                if (listBoxAfisare.SelectedIndex == 0)
                    return;
                if (listBoxAfisare.SelectedIndex == -1)
                    return;
                if (ValidareCampuri(listAutoturismeFisier.ElementAt(listBoxAfisare.SelectedIndex - 1)) == false)
                    return;
                listAutoturismeFisier.ElementAt(listBoxAfisare.SelectedIndex - 1).Marca = textBoxMarca.Text.ToUpper().Trim();
                listAutoturismeFisier.ElementAt(listBoxAfisare.SelectedIndex - 1).Model = textBoxModel.Text.ToUpper().Trim();
                listAutoturismeFisier.ElementAt(listBoxAfisare.SelectedIndex - 1).AnFabricatie = Convert.ToInt32(textBoxAnFabricatie.Text.Trim());
                listAutoturismeFisier.ElementAt(listBoxAfisare.SelectedIndex - 1).CapacitateCilindrica = Convert.ToInt32(textBoxCapacitate.Text.Trim());
                listAutoturismeFisier.ElementAt(listBoxAfisare.SelectedIndex - 1).Putere = Convert.ToInt32(textBoxPutere.Text.Trim());
                listAutoturismeFisier.ElementAt(listBoxAfisare.SelectedIndex - 1).Pret = Convert.ToInt32(textBoxPret.Text.Trim());
                DateTime data;
                DateTime.TryParse(textBoxDataTranzactie.Text.Trim(), out data);
                listAutoturismeFisier.ElementAt(listBoxAfisare.SelectedIndex - 1).DataTranzactie = data;
                listAutoturismeFisier.ElementAt(listBoxAfisare.SelectedIndex - 1).Combustibil = (TipCombustibil)GetCombustibilSelectat();
                listAutoturismeFisier.ElementAt(listBoxAfisare.SelectedIndex - 1).CutieDeViteze = (TipCutie)GetTipCutieSelectat();
                listAutoturismeFisier.ElementAt(listBoxAfisare.SelectedIndex - 1).Caroserie = (TipCaroserie)GetTipCaroserie();
                listAutoturismeFisier.ElementAt(listBoxAfisare.SelectedIndex - 1).Culoare = (Culori)GetCuloareSelectat();
                listAutoturismeFisier.ElementAt(listBoxAfisare.SelectedIndex - 1).Optiuni = GetOptiuniSelectate();

                listAutoturismeFisier.ElementAt(listBoxAfisare.SelectedIndex - 1).Nume_Vanzator = textBoxNumeVanzator.Text.ToUpper().Trim();
                listAutoturismeFisier.ElementAt(listBoxAfisare.SelectedIndex - 1).Prenume_Vanzator = textBoxPrenumeVanzator.Text.ToUpper().Trim();
                listAutoturismeFisier.ElementAt(listBoxAfisare.SelectedIndex - 1).Nume_Cumparator = textBoxNumeCumparator.Text.ToUpper().Trim();
                listAutoturismeFisier.ElementAt(listBoxAfisare.SelectedIndex - 1).Prenume_Cumparator = textBoxPrenumeCumparator.Text.ToUpper().Trim();


                adminAutoturisme.RewriteCars(listAutoturismeFisier);
                listBoxAfisare.Items.Clear();
                listBoxAfisare.Items.Add(String.Format($"{"Marca",-20}{"Model",-15}{"An",-5}{"CC",-7}" +
                    $"{"Putere",-7}{"Combustibil",-12}{"Cutie",-11}{"Caroserie",-11}{"Culoare",-11}" +
                    $"{"Pret",-10}{"Cumparator",-35}{"Vanzator",-35}{"Data Tranzacte",-15}"));
                foreach (Car c in listAutoturismeFisier)
                {
                    listBoxAfisare.Items.Add(c.ConvertToString2());
                }
                rtbAfisare.ForeColor = Color.Green;
                rtbAfisare.Text = "Modificare realizata cu succes";
            }
            if (dataGridAfisare.DataSource == null)
                return;
            if (dataGridAfisare.CurrentRow.Selected == true)
            {
                if (ValidareCampuri(listAutoturismeFisier.ElementAt(dataGridAfisare.CurrentRow.Index)) == false)
                    return;
                //Car c = (Car)dataGridAfisare.CurrentRow.DataBoundItem;
                //listAutoturismeFisier.ElementAt(dataGridAfisare.CurrentRow.Index);
                listAutoturismeFisier.ElementAt(dataGridAfisare.CurrentRow.Index).Marca = textBoxMarca.Text.ToUpper().Trim();
                listAutoturismeFisier.ElementAt(dataGridAfisare.CurrentRow.Index).Model = textBoxModel.Text.ToUpper().Trim();
                listAutoturismeFisier.ElementAt(dataGridAfisare.CurrentRow.Index).AnFabricatie = Convert.ToInt32(textBoxAnFabricatie.Text.Trim());
                listAutoturismeFisier.ElementAt(dataGridAfisare.CurrentRow.Index).CapacitateCilindrica = Convert.ToInt32(textBoxCapacitate.Text.Trim());
                listAutoturismeFisier.ElementAt(dataGridAfisare.CurrentRow.Index).Putere = Convert.ToInt32(textBoxPutere.Text.Trim());
                listAutoturismeFisier.ElementAt(dataGridAfisare.CurrentRow.Index).Pret = Convert.ToInt32(textBoxPret.Text.Trim());
                DateTime data;
                DateTime.TryParse(textBoxDataTranzactie.Text.Trim(), out data);
                listAutoturismeFisier.ElementAt(dataGridAfisare.CurrentRow.Index).DataTranzactie = data;
                listAutoturismeFisier.ElementAt(dataGridAfisare.CurrentRow.Index).Combustibil = (TipCombustibil)GetCombustibilSelectat();
                listAutoturismeFisier.ElementAt(dataGridAfisare.CurrentRow.Index).CutieDeViteze = (TipCutie)GetTipCutieSelectat();
                listAutoturismeFisier.ElementAt(dataGridAfisare.CurrentRow.Index).Caroserie = (TipCaroserie)GetTipCaroserie();
                listAutoturismeFisier.ElementAt(dataGridAfisare.CurrentRow.Index).Culoare = (Culori)GetCuloareSelectat();
                listAutoturismeFisier.ElementAt(dataGridAfisare.CurrentRow.Index).Optiuni = GetOptiuniSelectate();

                listAutoturismeFisier.ElementAt(dataGridAfisare.CurrentRow.Index).Nume_Vanzator = textBoxNumeVanzator.Text.ToUpper().Trim();
                listAutoturismeFisier.ElementAt(dataGridAfisare.CurrentRow.Index).Prenume_Vanzator = textBoxPrenumeVanzator.Text.ToUpper().Trim();
                listAutoturismeFisier.ElementAt(dataGridAfisare.CurrentRow.Index).Nume_Cumparator = textBoxNumeCumparator.Text.ToUpper().Trim();
                listAutoturismeFisier.ElementAt(dataGridAfisare.CurrentRow.Index).Prenume_Cumparator = textBoxPrenumeCumparator.Text.ToUpper().Trim();

                Afisare();
                adminAutoturisme.RewriteCars(listAutoturismeFisier);
                rtbAfisare.ForeColor = Color.Green;
                rtbAfisare.Text = "Modificare realizata cu succes";
            }

        }
        #endregion



        ///laborator 8 filedialog
        private void deschideFisierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "d:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog.FileName;

                //Read the contents of the file into a stream
                var fileStream = openFileDialog.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    TextArea = reader.ReadToEnd();
                    reader.Close();
                }
            }
            AfisareFisier cautareForm = new AfisareFisier(TextArea);
            this.Hide();
            cautareForm.ShowDialog();
            this.Show();
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        #region Selectare informatii
        private void dataGridAfisare_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ResetControls();
            if (dataGridAfisare.CurrentRow.Selected == false)
                return;
            //dataGridAfisare.ClearSelection();
            dataGridAfisare.CurrentRow.Selected = true;
            listBoxAfisare.ClearSelected();
            Car c = (Car)dataGridAfisare.CurrentRow.DataBoundItem;

            textBoxMarca.Text = c.Marca;
            textBoxModel.Text = c.Model;
            textBoxAnFabricatie.Text = c.AnFabricatie.ToString();
            textBoxCapacitate.Text = c.CapacitateCilindrica.ToString();
            textBoxPutere.Text = c.Putere.ToString();
            textBoxPret.Text = c.Pret.ToString();
            textBoxNumeVanzator.Text = c.Nume_Vanzator;
            textBoxPrenumeVanzator.Text = c.Prenume_Vanzator;
            textBoxNumeCumparator.Text = c.Nume_Cumparator;
            textBoxPrenumeCumparator.Text = c.Prenume_Cumparator;
            textBoxDataTranzactie.Text = c.DataTranzactie.ToString("dd.MM.yyyy");
            foreach (Control control in groupBoxCombustibil.Controls)
            {
                if (control.GetType() == typeof(RadioButton))
                {
                    if (c.Combustibil.ToString() == control.Text.ToUpper())
                    {
                        ((RadioButton)control).Checked = true;
                    }
                }
            }

            foreach (Control control in gpbCutie.Controls)
            {
                if (control.GetType() == typeof(RadioButton))
                {
                    if (c.CutieDeViteze.ToString() == control.Text.ToUpper())
                    {
                        ((RadioButton)control).Checked = true;
                    }
                }
            }

            foreach (Control control in gpbCaroserie.Controls)
            {
                if (control.GetType() == typeof(RadioButton))
                {
                    if (c.Caroserie.ToString() == control.Text.ToUpper())
                    {
                        ((RadioButton)control).Checked = true;
                    }
                }
            }
            foreach (Control control in gpbCulori.Controls)
            {
                if (control.GetType() == typeof(RadioButton))
                {
                    if (c.Culoare.ToString() == control.Text.ToUpper())
                    {
                        ((RadioButton)control).Checked = true;
                    }
                }
            }

            foreach (Control control in gpbOptiuni.Controls)
            {
                if (control.GetType() == typeof(CheckBox))
                {
                    foreach (string optiune in c.Optiuni)
                        if (((CheckBox)control).Text == optiune)
                            ((CheckBox)control).Checked = true;
                }
            }
        }
        private void listBoxAfisare_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridAfisare.ClearSelection();
            //dataGridAfisare.CurrentRow.Selected = false;
            ResetControls();
            if (listBoxAfisare.SelectedIndex == 0)
                return;
            if (listBoxAfisare.SelectedIndex == -1)
                return;
            Car c = listAutoturismeFisier.ElementAt(listBoxAfisare.SelectedIndex - 1);
            textBoxMarca.Text = c.Marca;
            textBoxModel.Text = c.Model;
            textBoxAnFabricatie.Text = c.AnFabricatie.ToString();
            textBoxCapacitate.Text = c.CapacitateCilindrica.ToString();
            textBoxPutere.Text = c.Putere.ToString();
            textBoxPret.Text = c.Pret.ToString();
            textBoxNumeVanzator.Text = c.Nume_Vanzator;
            textBoxPrenumeVanzator.Text = c.Prenume_Vanzator;
            textBoxNumeCumparator.Text = c.Nume_Cumparator;
            textBoxPrenumeCumparator.Text = c.Prenume_Cumparator;
            textBoxDataTranzactie.Text = c.DataTranzactie.ToString("dd.MM.yyyy");
            foreach (Control control in groupBoxCombustibil.Controls)
            {
                if (control.GetType() == typeof(RadioButton))
                {
                    if (c.Combustibil.ToString() == control.Text.ToUpper())
                    {
                        ((RadioButton)control).Checked = true;
                    }
                }
            }

            foreach (Control control in gpbCutie.Controls)
            {
                if (control.GetType() == typeof(RadioButton))
                {
                    if (c.CutieDeViteze.ToString() == control.Text.ToUpper())
                    {
                        ((RadioButton)control).Checked = true;
                    }
                }
            }

            foreach (Control control in gpbCaroserie.Controls)
            {
                if (control.GetType() == typeof(RadioButton))
                {
                    if (c.Caroserie.ToString() == control.Text.ToUpper())
                    {
                        ((RadioButton)control).Checked = true;
                    }
                }
            }
            foreach (Control control in gpbCulori.Controls)
            {
                if (control.GetType() == typeof(RadioButton))
                {
                    if (c.Culoare.ToString() == control.Text.ToUpper())
                    {
                        ((RadioButton)control).Checked = true;
                    }
                }
            }

            foreach (Control control in gpbOptiuni.Controls)
            {
                if (control.GetType() == typeof(CheckBox))
                {
                    foreach (string optiune in c.Optiuni)
                        if (((CheckBox)control).Text == optiune)
                            ((CheckBox)control).Checked = true;
                }
            }
        }
        #endregion

        private void eliminaAutoturismToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool succes = false;
            if (listAutoturismeFisier.Count == 0)
                return;
            if (listBoxAfisare.SelectedIndex >= 1)
            {
                listAutoturismeFisier.RemoveAt(listBoxAfisare.SelectedIndex - 1);
                succes = true;
            }
            if (dataGridAfisare.DataSource == null)
                return;
            if (dataGridAfisare.CurrentRow.Selected == true)
            {
                listAutoturismeFisier.RemoveAt(dataGridAfisare.CurrentRow.Index);
                succes = true;
            }
            if(succes)
            {
                Afisare();
                rtbAfisare.ForeColor = Color.Green;
                rtbAfisare.Text = "Eliminarea a avut succes";
                adminAutoturisme.RewriteCars(listAutoturismeFisier);
            }
        }
    }
}
