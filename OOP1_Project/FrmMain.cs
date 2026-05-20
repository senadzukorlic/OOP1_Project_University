using OOP1_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP1_Project
{
    internal class FrmMain : Form
    {
        private Label lblNaslov;
        private Button btnKorisnici;
        private Button btnPredmeti;
        private Button btnLekcije;
        private Button btnUpisi;
        private Button btnLogout;
        private Label lblKorisnik;

        private readonly Korisnik ulogovaniKorisnik;

        public FrmMain()
        {
            InitializeComponent();
        }

        public FrmMain(Korisnik korisnik) : this()
        {
            ulogovaniKorisnik = korisnik;

            this.Text = "MiniMoodle - Glavni meni";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            lblKorisnik.Text = "Ulogovani korisnik: " +
                               ulogovaniKorisnik.PunoIme +
                               " | Uloga: " +
                               ulogovaniKorisnik.Uloga;

            btnKorisnici.Click += btnKorisnici_Click;
            btnPredmeti.Click += btnPredmeti_Click;
            btnLekcije.Click += btnLekcije_Click;
            btnUpisi.Click += btnUpisi_Click;
            btnLogout.Click += btnLogout_Click;
        }

        private void btnKorisnici_Click(object sender, EventArgs e)
        {
            FrmKorisnici frmKorisnici = new FrmKorisnici();
            frmKorisnici.ShowDialog();
        }

        private void btnPredmeti_Click(object sender, EventArgs e)
        {
            FrmPredmeti frmPredmeti = new FrmPredmeti();
            frmPredmeti.ShowDialog();
        }

        private void btnLekcije_Click(object sender, EventArgs e)
        {
            FrmLekcije frmLekcije = new FrmLekcije();
            frmLekcije.ShowDialog();
        }

        private void btnUpisi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ovdje ćemo otvoriti formu za upise.", "MiniMoodle");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
        private void InitializeComponent()
        {
            this.lblNaslov = new System.Windows.Forms.Label();
            this.lblKorisnik = new System.Windows.Forms.Label();
            this.btnKorisnici = new System.Windows.Forms.Button();
            this.btnPredmeti = new System.Windows.Forms.Button();
            this.btnLekcije = new System.Windows.Forms.Button();
            this.btnUpisi = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNaslov
            // 
            this.lblNaslov.AutoSize = true;
            this.lblNaslov.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblNaslov.Location = new System.Drawing.Point(210, 25);
            this.lblNaslov.Name = "lblNaslov";
            this.lblNaslov.Size = new System.Drawing.Size(344, 37);
            this.lblNaslov.TabIndex = 0;
            this.lblNaslov.Text = "MiniMoodle Admin Panel";
            // 
            // lblKorisnik
            // 
            this.lblKorisnik.AutoSize = true;
            this.lblKorisnik.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKorisnik.Location = new System.Drawing.Point(27, 67);
            this.lblKorisnik.Name = "lblKorisnik";
            this.lblKorisnik.Size = new System.Drawing.Size(0, 23);
            this.lblKorisnik.TabIndex = 1;
            // 
            // btnKorisnici
            // 
            this.btnKorisnici.Location = new System.Drawing.Point(55, 330);
            this.btnKorisnici.Name = "btnKorisnici";
            this.btnKorisnici.Size = new System.Drawing.Size(119, 70);
            this.btnKorisnici.TabIndex = 3;
            this.btnKorisnici.Text = "Korisnici";
            this.btnKorisnici.UseVisualStyleBackColor = true;
            // 
            // btnPredmeti
            // 
            this.btnPredmeti.Location = new System.Drawing.Point(51, 152);
            this.btnPredmeti.Name = "btnPredmeti";
            this.btnPredmeti.Size = new System.Drawing.Size(123, 46);
            this.btnPredmeti.TabIndex = 4;
            this.btnPredmeti.Text = "Predmeti";
            this.btnPredmeti.UseVisualStyleBackColor = true;
            this.btnPredmeti.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnLekcije
            // 
            this.btnLekcije.Location = new System.Drawing.Point(51, 222);
            this.btnLekcije.Name = "btnLekcije";
            this.btnLekcije.Size = new System.Drawing.Size(104, 74);
            this.btnLekcije.TabIndex = 5;
            this.btnLekcije.Text = "Lekcije";
            this.btnLekcije.UseVisualStyleBackColor = true;
            // 
            // btnUpisi
            // 
            this.btnUpisi.Location = new System.Drawing.Point(63, 446);
            this.btnUpisi.Name = "btnUpisi";
            this.btnUpisi.Size = new System.Drawing.Size(111, 55);
            this.btnUpisi.TabIndex = 6;
            this.btnUpisi.Text = " Upisi";
            this.btnUpisi.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(638, 156);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(105, 42);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.ClientSize = new System.Drawing.Size(1482, 753);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnUpisi);
            this.Controls.Add(this.btnLekcije);
            this.Controls.Add(this.btnPredmeti);
            this.Controls.Add(this.btnKorisnici);
            this.Controls.Add(this.lblKorisnik);
            this.Controls.Add(this.lblNaslov);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MiniMoodle - Glavni meni ";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
