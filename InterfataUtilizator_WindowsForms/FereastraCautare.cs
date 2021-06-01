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
    public partial class FereastraCautare : Form
    {
        IStocareData adminAutoturisme;
        List<Car> listAutoturismeFisier;
        public FereastraCautare()
        {
            InitializeComponent();
            adminAutoturisme = StocareFactory.GetAdministratorStocare();
            listAutoturismeFisier = adminAutoturisme.GetCarsFile();
            dataGridAfisare.ColumnHeadersDefaultCellStyle.Font = new Font("Lucida Console", 10, FontStyle.Bold);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void buttonAfisare_Click(object sender, EventArgs e)
        {
            if (listAutoturismeFisier == null)
                return;
            if (listAutoturismeFisier.Count == 0)
                return;

            if (dataGridAfisare.DataSource != null)
            {
                dataGridAfisare.DataSource = null;
                return;
            }
            panelAfisare.Visible = true;
            dataGridAfisare.Visible = true;
            dataGridAfisare.DataSource = null;
            listAutoturismeFisier = adminAutoturisme.GetCarsFile();
            dataGridAfisare.DataSource = listAutoturismeFisier;
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCautare_Click(object sender, EventArgs e)
        {
            
            labelCautareMarca.ForeColor = Color.Black;
            labelCautareMarca.Text = "INTRODUCETI MARCA";
            dataGridAfisare.DataSource = null;
            listAutoturismeFisier = adminAutoturisme.GetCarsFile();
            if (textBoxCautareMarca.Text == string.Empty)
                return;
            bool marcaGasita = false;
            List<Car> marcaGasitaLista = new List<Car>();
            foreach (Car c in listAutoturismeFisier)
            {
                if (textBoxCautareMarca.Text.ToUpper().Trim() == c.Marca)
                {
                    marcaGasitaLista.Add(c);
                    marcaGasita = true;
                }
            }

            if (marcaGasita)
            {
                dataGridAfisare.DataSource = marcaGasitaLista;
            }
            else
            {
                labelCautareMarca.ForeColor = Color.FromArgb(255, 193, 64);
                labelCautareMarca.Text = "MARCA INEXISTENTA";
            }
            textBoxCautareMarca.Clear();
        }

        private void buttonModificare_Click(object sender, EventArgs e)
        {
            if (dataGridAfisare.DataSource == null)
                return;
            if (dataGridAfisare.CurrentCell.RowIndex == -1)
                return;
            
            using (FereastraModificare Form = new FereastraModificare((Car)dataGridAfisare.CurrentRow.DataBoundItem))
            {
                this.Hide();
                Form.ShowDialog();
                this.Show();
            }
            listAutoturismeFisier = adminAutoturisme.GetCarsFile();
            dataGridAfisare.DataSource = listAutoturismeFisier;
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            string message = "Proiect realizat de Brumă Sebastian 3123 B An 2 Calculatoare";
            string title = "INFO";
            MessageBox.Show(message, title);
        }
    }
}
