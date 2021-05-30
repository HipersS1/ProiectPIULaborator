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
    public partial class CautareForms : Form
    {
        IStocareData adminAutoturisme;
        List<Car> listAutoturismeFisier;
        public CautareForms()
        {
            InitializeComponent();
            adminAutoturisme = StocareFactory.GetAdministratorStocare();
            listAutoturismeFisier = adminAutoturisme.GetCarsFile();
            dataGridMarca.ReadOnly = true;
        }

        private void btnCautare_Click(object sender, EventArgs e)
        {
            labelCautareMarca.ForeColor = Color.Black;
            labelCautareMarca.Text = "Introduceti Marca";
            dataGridMarca.DataSource = null;
            //dataGridMarca.DataSource = listAutoturismeFisier;

            bool marcaGasita = false;
            List<Car> marcaGasitaLista = new List<Car>();
            foreach(Car c in listAutoturismeFisier)
            {
                if(textBoxCautareMarca.Text.ToUpper().Trim() == c.Marca)
                {
                    marcaGasitaLista.Add(c);
                    marcaGasita = true;
                }
            }

            if(marcaGasita)
            {
                dataGridMarca.DataSource = marcaGasitaLista;
            }
            else
            {
                labelCautareMarca.ForeColor = Color.DarkRed;
                labelCautareMarca.Text = "Marca nu exista";
            }

        }

        private void btnRevenire_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
