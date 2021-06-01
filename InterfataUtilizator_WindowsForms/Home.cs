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
    public partial class Home : Form
    {
        IStocareData adminAutoturisme;
        List<Car> listAutoturismeFisier;
        public Home()
        {
            InitializeComponent();
            adminAutoturisme = StocareFactory.GetAdministratorStocare();
            listAutoturismeFisier = adminAutoturisme.GetCarsFile();
            dataGridAfisare.ColumnHeadersDefaultCellStyle.Font = new Font("Lucida Console", 10, FontStyle.Bold);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonAdauga_Click(object sender, EventArgs e)
        {
            dataGridAfisare.DataSource = null;
            using (FereastraAdaugare Form = new FereastraAdaugare())
            {
                this.Hide();
                Form.ShowDialog();
                this.Show();
            }
                
        }

        private void buttonAfisare_Click(object sender, EventArgs e)
        {
            listAutoturismeFisier = adminAutoturisme.GetCarsFile();
            if (listAutoturismeFisier== null)
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

        private void buttonCautare_Click(object sender, EventArgs e)
        {
            using (FereastraCautare Form = new FereastraCautare())
            {
                this.Hide();
                Form.ShowDialog();
                this.Show();
            }
        }

        private void buttonModificare_Click(object sender, EventArgs e)
        {
            using (FereastraModificare Form = new FereastraModificare())
            {
                this.Hide();
                Form.ShowDialog();
                this.Show();
            }
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            string message = "Proiect realizat de Brumă Sebastian 3123 B An 2 Calculatoare";
            string title = "INFO";
            MessageBox.Show(message, title);
        }

        private void buttonDeschideFisier_Click(object sender, EventArgs e)
        {
            using (FereastraDeschideFisier Form = new FereastraDeschideFisier())
            {
                this.Hide();
                Form.ShowDialog();
                this.Show();
            }
        }
    }
}
