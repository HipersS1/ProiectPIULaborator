
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
            this.SuspendLayout();
            // 
            // comboBoxAfisare
            // 
            this.comboBoxAfisare.FormattingEnabled = true;
            this.comboBoxAfisare.Location = new System.Drawing.Point(12, 75);
            this.comboBoxAfisare.Name = "comboBoxAfisare";
            this.comboBoxAfisare.Size = new System.Drawing.Size(959, 24);
            this.comboBoxAfisare.TabIndex = 0;
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
            // AfisareFisier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(983, 473);
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
    }
}