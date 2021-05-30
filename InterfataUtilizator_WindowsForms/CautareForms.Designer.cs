
namespace InterfataUtilizator_WindowsForms
{
    partial class CautareForms
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
            this.labelCautareMarca = new System.Windows.Forms.Label();
            this.textBoxCautareMarca = new System.Windows.Forms.TextBox();
            this.dataGridMarca = new System.Windows.Forms.DataGridView();
            this.btnCautare = new System.Windows.Forms.Button();
            this.btnRevenire = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMarca)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCautareMarca
            // 
            this.labelCautareMarca.AutoSize = true;
            this.labelCautareMarca.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCautareMarca.Location = new System.Drawing.Point(346, 37);
            this.labelCautareMarca.Name = "labelCautareMarca";
            this.labelCautareMarca.Size = new System.Drawing.Size(119, 22);
            this.labelCautareMarca.TabIndex = 0;
            this.labelCautareMarca.Tag = "";
            this.labelCautareMarca.Text = "Introduceti Marca";
            // 
            // textBoxCautareMarca
            // 
            this.textBoxCautareMarca.Location = new System.Drawing.Point(262, 62);
            this.textBoxCautareMarca.Name = "textBoxCautareMarca";
            this.textBoxCautareMarca.Size = new System.Drawing.Size(286, 22);
            this.textBoxCautareMarca.TabIndex = 1;
            // 
            // dataGridMarca
            // 
            this.dataGridMarca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMarca.Location = new System.Drawing.Point(12, 134);
            this.dataGridMarca.Name = "dataGridMarca";
            this.dataGridMarca.RowHeadersWidth = 51;
            this.dataGridMarca.RowTemplate.Height = 24;
            this.dataGridMarca.Size = new System.Drawing.Size(776, 252);
            this.dataGridMarca.TabIndex = 2;
            // 
            // btnCautare
            // 
            this.btnCautare.Location = new System.Drawing.Point(350, 90);
            this.btnCautare.Name = "btnCautare";
            this.btnCautare.Size = new System.Drawing.Size(117, 38);
            this.btnCautare.TabIndex = 3;
            this.btnCautare.Text = "Cautare";
            this.btnCautare.UseVisualStyleBackColor = true;
            this.btnCautare.Click += new System.EventHandler(this.btnCautare_Click);
            // 
            // btnRevenire
            // 
            this.btnRevenire.Location = new System.Drawing.Point(348, 400);
            this.btnRevenire.Name = "btnRevenire";
            this.btnRevenire.Size = new System.Drawing.Size(117, 38);
            this.btnRevenire.TabIndex = 4;
            this.btnRevenire.Text = "MENIU";
            this.btnRevenire.UseVisualStyleBackColor = true;
            this.btnRevenire.Click += new System.EventHandler(this.btnRevenire_Click);
            // 
            // CautareForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRevenire);
            this.Controls.Add(this.btnCautare);
            this.Controls.Add(this.dataGridMarca);
            this.Controls.Add(this.textBoxCautareMarca);
            this.Controls.Add(this.labelCautareMarca);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CautareForms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CautareForms";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMarca)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCautareMarca;
        private System.Windows.Forms.TextBox textBoxCautareMarca;
        private System.Windows.Forms.DataGridView dataGridMarca;
        private System.Windows.Forms.Button btnCautare;
        private System.Windows.Forms.Button btnRevenire;
    }
}