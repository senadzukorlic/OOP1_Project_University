namespace OOP1_Project
{
    partial class FrmPredmeti
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
            this.dgvPredmeti = new System.Windows.Forms.DataGridView();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.txtOpis = new System.Windows.Forms.TextBox();
            this.txtPretraga = new System.Windows.Forms.TextBox();
            this.dtpDatumKreiranja = new System.Windows.Forms.DateTimePicker();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnIzmijeni = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.btnOcisti = new System.Windows.Forms.Button();
            this.btnZatvori = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbAsistent = new System.Windows.Forms.ComboBox();
            this.cmbProfesor = new System.Windows.Forms.ComboBox();
            this.chkBezAsistenta = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPredmeti)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPredmeti
            // 
            this.dgvPredmeti.AllowUserToAddRows = false;
            this.dgvPredmeti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPredmeti.Location = new System.Drawing.Point(757, 122);
            this.dgvPredmeti.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvPredmeti.MultiSelect = false;
            this.dgvPredmeti.Name = "dgvPredmeti";
            this.dgvPredmeti.ReadOnly = true;
            this.dgvPredmeti.RowHeadersWidth = 92;
            this.dgvPredmeti.RowTemplate.Height = 37;
            this.dgvPredmeti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPredmeti.Size = new System.Drawing.Size(700, 350);
            this.dgvPredmeti.TabIndex = 0;
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(34, 10);
            this.txtNaziv.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(79, 29);
            this.txtNaziv.TabIndex = 1;
            // 
            // txtOpis
            // 
            this.txtOpis.Location = new System.Drawing.Point(34, 75);
            this.txtOpis.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtOpis.Multiline = true;
            this.txtOpis.Name = "txtOpis";
            this.txtOpis.Size = new System.Drawing.Size(79, 30);
            this.txtOpis.TabIndex = 3;
            // 
            // txtPretraga
            // 
            this.txtPretraga.Location = new System.Drawing.Point(34, 153);
            this.txtPretraga.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(79, 29);
            this.txtPretraga.TabIndex = 4;
            // 
            // dtpDatumKreiranja
            // 
            this.dtpDatumKreiranja.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatumKreiranja.Location = new System.Drawing.Point(34, 206);
            this.dtpDatumKreiranja.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpDatumKreiranja.Name = "dtpDatumKreiranja";
            this.dtpDatumKreiranja.Size = new System.Drawing.Size(158, 29);
            this.dtpDatumKreiranja.TabIndex = 5;
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(570, 367);
            this.btnDodaj.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(70, 33);
            this.btnDodaj.TabIndex = 7;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            // 
            // btnIzmijeni
            // 
            this.btnIzmijeni.Location = new System.Drawing.Point(570, 295);
            this.btnIzmijeni.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnIzmijeni.Name = "btnIzmijeni";
            this.btnIzmijeni.Size = new System.Drawing.Size(97, 52);
            this.btnIzmijeni.TabIndex = 8;
            this.btnIzmijeni.Text = "Izmijeni";
            this.btnIzmijeni.UseVisualStyleBackColor = true;
            // 
            // btnObrisi
            // 
            this.btnObrisi.Location = new System.Drawing.Point(570, 201);
            this.btnObrisi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(90, 51);
            this.btnObrisi.TabIndex = 9;
            this.btnObrisi.Text = "Obrisi";
            this.btnObrisi.UseVisualStyleBackColor = true;
            // 
            // btnOcisti
            // 
            this.btnOcisti.Location = new System.Drawing.Point(570, 136);
            this.btnOcisti.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOcisti.Name = "btnOcisti";
            this.btnOcisti.Size = new System.Drawing.Size(108, 46);
            this.btnOcisti.TabIndex = 10;
            this.btnOcisti.Text = "Ocisti";
            this.btnOcisti.UseVisualStyleBackColor = true;
            // 
            // btnZatvori
            // 
            this.btnZatvori.Location = new System.Drawing.Point(570, 64);
            this.btnZatvori.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnZatvori.Name = "btnZatvori";
            this.btnZatvori.Size = new System.Drawing.Size(108, 41);
            this.btnZatvori.TabIndex = 11;
            this.btnZatvori.Text = "Zatvori";
            this.btnZatvori.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Naziv:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "Opis:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(270, 153);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "Datum kreiranja:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 201);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Profesor:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(270, 256);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 25);
            this.label5.TabIndex = 16;
            this.label5.Text = "Asistent:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(270, 323);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 25);
            this.label6.TabIndex = 17;
            this.label6.Text = "Pretraga:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // cmbAsistent
            // 
            this.cmbAsistent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAsistent.FormattingEnabled = true;
            this.cmbAsistent.Location = new System.Drawing.Point(42, 403);
            this.cmbAsistent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbAsistent.Name = "cmbAsistent";
            this.cmbAsistent.Size = new System.Drawing.Size(96, 32);
            this.cmbAsistent.TabIndex = 18;
            // 
            // cmbProfesor
            // 
            this.cmbProfesor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfesor.FormattingEnabled = true;
            this.cmbProfesor.Location = new System.Drawing.Point(42, 367);
            this.cmbProfesor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbProfesor.Name = "cmbProfesor";
            this.cmbProfesor.Size = new System.Drawing.Size(96, 32);
            this.cmbProfesor.TabIndex = 19;
            // 
            // chkBezAsistenta
            // 
            this.chkBezAsistenta.AutoSize = true;
            this.chkBezAsistenta.Location = new System.Drawing.Point(42, 319);
            this.chkBezAsistenta.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkBezAsistenta.Name = "chkBezAsistenta";
            this.chkBezAsistenta.Size = new System.Drawing.Size(151, 29);
            this.chkBezAsistenta.TabIndex = 20;
            this.chkBezAsistenta.Text = "Bez asistenta";
            this.chkBezAsistenta.UseVisualStyleBackColor = true;
            // 
            // FrmPredmeti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1682, 753);
            this.Controls.Add(this.chkBezAsistenta);
            this.Controls.Add(this.cmbProfesor);
            this.Controls.Add(this.cmbAsistent);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnZatvori);
            this.Controls.Add(this.btnOcisti);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.btnIzmijeni);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.dtpDatumKreiranja);
            this.Controls.Add(this.txtPretraga);
            this.Controls.Add(this.txtOpis);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.dgvPredmeti);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "FrmPredmeti";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MiniMoodle - Predmeti";
            this.Load += new System.EventHandler(this.FrmPredmeti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPredmeti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPredmeti;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.TextBox txtOpis;
        private System.Windows.Forms.TextBox txtPretraga;
        private System.Windows.Forms.DateTimePicker dtpDatumKreiranja;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnIzmijeni;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button btnOcisti;
        private System.Windows.Forms.Button btnZatvori;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbAsistent;
        private System.Windows.Forms.ComboBox cmbProfesor;
        private System.Windows.Forms.CheckBox chkBezAsistenta;
    }
}