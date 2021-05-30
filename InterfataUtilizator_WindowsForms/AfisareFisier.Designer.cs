
namespace InterfataUtilizator_WindowsForms
{
    partial class AfisareFisier
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxAfisare = new System.Windows.Forms.ComboBox();
            this.btnMeniu = new System.Windows.Forms.Button();
            this.richTextBoxAfisareSelectie = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // comboBoxAfisare
            // 
            this.comboBoxAfisare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAfisare.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAfisare.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboBoxAfisare.FormattingEnabled = true;
            this.comboBoxAfisare.Location = new System.Drawing.Point(12, 75);
            this.comboBoxAfisare.MaxDropDownItems = 10;
            this.comboBoxAfisare.Name = "comboBoxAfisare";
            this.comboBoxAfisare.Size = new System.Drawing.Size(959, 24);
            this.comboBoxAfisare.TabIndex = 0;
            this.comboBoxAfisare.SelectedIndexChanged += new System.EventHandler(this.comboBoxAfisare_SelectedIndexChanged);
            // 
            // btnMeniu
            // 
            this.btnMeniu.Location = new System.Drawing.Point(417, 420);
            this.btnMeniu.Name = "btnMeniu";
            this.btnMeniu.Size = new System.Drawing.Size(127, 41);
            this.btnMeniu.TabIndex = 1;
            this.btnMeniu.Text = "MENIU";
            this.btnMeniu.UseVisualStyleBackColor = true;
            this.btnMeniu.Click += new System.EventHandler(this.btnMeniu_Click);
            // 
            // richTextBoxAfisareSelectie
            // 
            this.richTextBoxAfisareSelectie.BackColor = System.Drawing.Color.Silver;
            this.richTextBoxAfisareSelectie.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxAfisareSelectie.Location = new System.Drawing.Point(12, 213);
            this.richTextBoxAfisareSelectie.Name = "richTextBoxAfisareSelectie";
            this.richTextBoxAfisareSelectie.Size = new System.Drawing.Size(959, 134);
            this.richTextBoxAfisareSelectie.TabIndex = 2;
            this.richTextBoxAfisareSelectie.Text = "";
            // 
            // AfisareFisier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(983, 473);
            this.Controls.Add(this.richTextBoxAfisareSelectie);
            this.Controls.Add(this.btnMeniu);
            this.Controls.Add(this.comboBoxAfisare);
            this.Name = "AfisareFisier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AfisareFisier";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAfisare;
        private System.Windows.Forms.Button btnMeniu;
        private System.Windows.Forms.RichTextBox richTextBoxAfisareSelectie;
    }
}