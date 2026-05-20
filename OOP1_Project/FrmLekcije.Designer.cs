namespace OOP1_Project
{
    partial class FrmLekcije
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
            this.dgvLekcije = new System.Windows.Forms.DataGridView();
            this.cmbPredmet = new System.Windows.Forms.ComboBox();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.cmbTipLekcije = new System.Windows.Forms.ComboBox();
            this.txtSadrzaj = new System.Windows.Forms.TextBox();
            this.dtpDatumObjave = new System.Windows.Forms.DateTimePicker();
            this.txtPretraga = new System.Windows.Forms.TextBox();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnZatvori = new System.Windows.Forms.Button();
            this.btnOcisti = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.btnIzmijeni = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLekcije)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLekcije
            // 
            this.dgvLekcije.AllowUserToAddRows = false;
            this.dgvLekcije.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLekcije.Location = new System.Drawing.Point(417, 64);
            this.dgvLekcije.MultiSelect = false;
            this.dgvLekcije.Name = "dgvLekcije";
            this.dgvLekcije.ReadOnly = true;
            this.dgvLekcije.RowHeadersWidth = 51;
            this.dgvLekcije.RowTemplate.Height = 31;
            this.dgvLekcije.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLekcije.Size = new System.Drawing.Size(750, 370);
            this.dgvLekcije.TabIndex = 0;
            // 
            // cmbPredmet
            // 
            this.cmbPredmet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPredmet.FormattingEnabled = true;
            this.cmbPredmet.Location = new System.Drawing.Point(110, 65);
            this.cmbPredmet.Name = "cmbPredmet";
            this.cmbPredmet.Size = new System.Drawing.Size(121, 32);
            this.cmbPredmet.TabIndex = 1;
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(110, 121);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(100, 29);
            this.txtNaziv.TabIndex = 2;
            // 
            // cmbTipLekcije
            // 
            this.cmbTipLekcije.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipLekcije.FormattingEnabled = true;
            this.cmbTipLekcije.Location = new System.Drawing.Point(110, 177);
            this.cmbTipLekcije.Name = "cmbTipLekcije";
            this.cmbTipLekcije.Size = new System.Drawing.Size(121, 32);
            this.cmbTipLekcije.TabIndex = 3;
            // 
            // txtSadrzaj
            // 
            this.txtSadrzaj.Location = new System.Drawing.Point(110, 230);
            this.txtSadrzaj.Name = "txtSadrzaj";
            this.txtSadrzaj.Size = new System.Drawing.Size(100, 29);
            this.txtSadrzaj.TabIndex = 4;
            // 
            // dtpDatumObjave
            // 
            this.dtpDatumObjave.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatumObjave.Location = new System.Drawing.Point(110, 292);
            this.dtpDatumObjave.Name = "dtpDatumObjave";
            this.dtpDatumObjave.Size = new System.Drawing.Size(134, 29);
            this.dtpDatumObjave.TabIndex = 5;
            // 
            // txtPretraga
            // 
            this.txtPretraga.Location = new System.Drawing.Point(110, 361);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(100, 29);
            this.txtPretraga.TabIndex = 6;
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(1218, 64);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(75, 32);
            this.btnDodaj.TabIndex = 7;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnZatvori
            // 
            this.btnZatvori.Location = new System.Drawing.Point(1218, 292);
            this.btnZatvori.Name = "btnZatvori";
            this.btnZatvori.Size = new System.Drawing.Size(87, 29);
            this.btnZatvori.TabIndex = 8;
            this.btnZatvori.Text = "Zatvori";
            this.btnZatvori.UseVisualStyleBackColor = true;
            // 
            // btnOcisti
            // 
            this.btnOcisti.Location = new System.Drawing.Point(1218, 230);
            this.btnOcisti.Name = "btnOcisti";
            this.btnOcisti.Size = new System.Drawing.Size(87, 35);
            this.btnOcisti.TabIndex = 9;
            this.btnOcisti.Text = "Ocisti";
            this.btnOcisti.UseVisualStyleBackColor = true;
            // 
            // btnObrisi
            // 
            this.btnObrisi.Location = new System.Drawing.Point(1218, 175);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(87, 34);
            this.btnObrisi.TabIndex = 10;
            this.btnObrisi.Text = "Obrisi";
            this.btnObrisi.UseVisualStyleBackColor = true;
            // 
            // btnIzmijeni
            // 
            this.btnIzmijeni.Location = new System.Drawing.Point(1218, 121);
            this.btnIzmijeni.Name = "btnIzmijeni";
            this.btnIzmijeni.Size = new System.Drawing.Size(87, 29);
            this.btnIzmijeni.TabIndex = 11;
            this.btnIzmijeni.Text = "Izmijeni";
            this.btnIzmijeni.UseVisualStyleBackColor = true;
            this.btnIzmijeni.Click += new System.EventHandler(this.btnIzmijeni_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(304, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Predmet:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "Naziv:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(304, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "Tip lekcije:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(304, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Sadrzaj:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(273, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 25);
            this.label5.TabIndex = 16;
            this.label5.Text = "Datum objave:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(304, 365);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 25);
            this.label6.TabIndex = 17;
            this.label6.Text = "Pretraga:";
            // 
            // FrmLekcije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1682, 753);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIzmijeni);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.btnOcisti);
            this.Controls.Add(this.btnZatvori);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.txtPretraga);
            this.Controls.Add(this.dtpDatumObjave);
            this.Controls.Add(this.txtSadrzaj);
            this.Controls.Add(this.cmbTipLekcije);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.cmbPredmet);
            this.Controls.Add(this.dgvLekcije);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmLekcije";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MiniMoodle - Lekcije";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLekcije)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLekcije;
        private System.Windows.Forms.ComboBox cmbPredmet;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.ComboBox cmbTipLekcije;
        private System.Windows.Forms.TextBox txtSadrzaj;
        private System.Windows.Forms.DateTimePicker dtpDatumObjave;
        private System.Windows.Forms.TextBox txtPretraga;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnZatvori;
        private System.Windows.Forms.Button btnOcisti;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button btnIzmijeni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}