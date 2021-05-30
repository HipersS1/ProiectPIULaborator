using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarClass;

namespace InterfataUtilizator_WindowsForms
{
    public partial class AfisareFisier : Form
    {
        string infoFisier;
        public AfisareFisier()
        {
            InitializeComponent();
        }


        public AfisareFisier(string info)
        {
            InitializeComponent();
            infoFisier = info;
            if (string.IsNullOrEmpty(infoFisier))
            {
                this.DialogResult = DialogResult.OK;
                return;
            }
            comboBoxAfisare.Text = "Lista autoturisme";
            string[] str = infoFisier.Split('\n');

            for(int i = 0; i < str.Length-1; i++)
            {
                str[i] = str[i].Remove(str[i].IndexOf('\r'));
                Car auto = new Car(str[i]);
                comboBoxAfisare.Items.Add(auto.ConvertToString3());
            }
        }

        private void btnMeniu_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void comboBoxAfisare_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBoxAfisareSelectie.Clear();
            richTextBoxAfisareSelectie.AppendText(comboBoxAfisare.SelectedItem.ToString());
        }
    }
}
