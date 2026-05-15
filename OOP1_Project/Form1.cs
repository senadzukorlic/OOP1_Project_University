using OOP1_Project.Data;
using OOP1_Project.Models;
using System;
using System.Windows.Forms;

namespace OOP1_Project
{
    public partial class Form1 : Form
    {
        private int brojNeuspjelihPokusaja = 0;
        private readonly KorisnikRepository korisnikRepository = new KorisnikRepository();

        public Form1()
        {
            InitializeComponent();

            this.Text = "MiniMoodle - Login";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.KeyPreview = true;

            btnLogin.Click += btnLogin_Click;
            btnClear.Click += btnClear_Click;

            txtEmail.KeyDown += txtEmail_KeyDown;
            txtLozinka.KeyDown += txtLozinka_KeyDown;

            this.KeyDown += Form1_KeyDown;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string lozinka = txtLozinka.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(lozinka))
            {
                lblStatus.Text = "Unesite email i lozinku.";
                MessageBox.Show("Email i lozinka su obavezni.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Korisnik korisnik = korisnikRepository.Login(email, lozinka);

                if (korisnik != null)
                {
                    MessageBox.Show(
                        "Uspješna prijava.\nDobrodošli, " + korisnik.PunoIme + "\nUloga: " + korisnik.Uloga,
                        "MiniMoodle",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    lblStatus.Text = "Uspješna prijava.";

                    FrmMain frmMain = new FrmMain(korisnik);
                    this.Hide();
                    frmMain.ShowDialog();
                    this.Show();

                    OcistiPolja();
                }
                else
                {
                    brojNeuspjelihPokusaja++;

                    MessageBox.Show(
                        "Pogrešan email ili lozinka.\nBroj neuspjelih pokušaja: " + brojNeuspjelihPokusaja,
                        "Greška",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    OcistiPolja();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Greška prilikom prijave:\n" + ex.Message,
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            OcistiPolja();
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtLozinka.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtLozinka_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (this.ActiveControl is TextBox aktivniTextBox)
                {
                    aktivniTextBox.Clear();
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void OcistiPolja()
        {
            txtEmail.Clear();
            txtLozinka.Clear();
            txtEmail.Focus();
            lblStatus.Text = "";
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {

        }
    }
}