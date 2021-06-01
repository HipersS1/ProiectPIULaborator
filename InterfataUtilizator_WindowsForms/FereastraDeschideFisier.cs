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
using System.IO;

namespace InterfataUtilizator_WindowsForms
{
    public partial class FereastraDeschideFisier : Form
    {
        IStocareData adminAutoturisme;
        List<Car> listAutoturismeFisier;
        public FereastraDeschideFisier()
        {
            InitializeComponent();
            adminAutoturisme = StocareFactory.GetAdministratorStocare();
            listAutoturismeFisier = adminAutoturisme.GetCarsFile();

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
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

        private void buttonDeschideFisier_Click(object sender, EventArgs e)
        {
            listBoxAfisareFisier.Items.Clear();
            string TextArea;
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
                if (string.IsNullOrEmpty(TextArea))
                {
                    this.DialogResult = DialogResult.OK;
                    return;
                }
                listBoxAfisareFisier.Items.Add(String.Format($"{"Marca",-20}{"Model",-15}{"An",-5}{"CC",-7}" +
                $"{"Putere",-7}{"Combustibil",-12}{"Cutie",-11}{"Caroserie",-11}{"Culoare",-11}" +
                $"{"Pret",-10}{"Cumparator",-35}{"Vanzator",-35}{"Data Tranzacte",-17}{"Optiuni",-20}"));
                string[] str = TextArea.Split('\n');

                for (int i = 0; i < str.Length - 1; i++)
                {
                    str[i] = str[i].Remove(str[i].IndexOf('\r'));
                    Car auto = new Car(str[i]);
                    listBoxAfisareFisier.Items.Add(auto.ConvertToString3());
                }
            }
        }
    }
}
