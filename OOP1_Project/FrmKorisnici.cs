using OOP1_Project.Data;
using OOP1_Project.Models;
using System;
using System.Windows.Forms;

namespace OOP1_Project
{
    public partial class FrmKorisnici : Form
    {
        private readonly KorisnikRepository korisnikRepository = new KorisnikRepository();
        private int selectedKorisnikId = 0;

        public FrmKorisnici()
        {
            InitializeComponent();

            this.Text = "MiniMoodle - Korisnici";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            this.Load += FrmKorisnici_Load;

            btnDodaj.Click += btnDodaj_Click;
            btnIzmijeni.Click += btnIzmijeni_Click;
            btnObrisi.Click += btnObrisi_Click;
            btnOcisti.Click += btnOcisti_Click;
            btnZatvori.Click += btnZatvori_Click;

            txtPretraga.TextChanged += txtPretraga_TextChanged;
            dgvKorisnici.CellClick += dgvKorisnici_CellClick;
        }

        private void FrmKorisnici_Load(object sender, EventArgs e)
        {
            cmbUloga.Items.Clear();
            cmbUloga.Items.Add("student");
            cmbUloga.Items.Add("profesor");
            cmbUloga.Items.Add("asistent");
            cmbUloga.SelectedIndex = 0;

            UcitajKorisnike();
        }

        private void UcitajKorisnike()
        {
            dgvKorisnici.DataSource = korisnikRepository.GetAll();
            UrediDataGridView();
        }

        private void UrediDataGridView()
        {
            if (dgvKorisnici.Columns["korisnik_id"] != null)
                dgvKorisnici.Columns["korisnik_id"].Visible = false;

            if (dgvKorisnici.Columns["ime"] != null)
                dgvKorisnici.Columns["ime"].HeaderText = "Ime";

            if (dgvKorisnici.Columns["prezime"] != null)
                dgvKorisnici.Columns["prezime"].HeaderText = "Prezime";

            if (dgvKorisnici.Columns["email"] != null)
                dgvKorisnici.Columns["email"].HeaderText = "Email";

            if (dgvKorisnici.Columns["lozinka"] != null)
                dgvKorisnici.Columns["lozinka"].HeaderText = "Lozinka";

            if (dgvKorisnici.Columns["uloga"] != null)
                dgvKorisnici.Columns["uloga"].HeaderText = "Uloga";

            dgvKorisnici.ReadOnly = true;
            dgvKorisnici.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKorisnici.MultiSelect = false;
            dgvKorisnici.AllowUserToAddRows = false;
            dgvKorisnici.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (!ValidacijaUnosa())
                return;

            try
            {
                Korisnik korisnik = new Korisnik
                {
                    Ime = txtIme.Text.Trim(),
                    Prezime = txtPrezime.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Lozinka = txtLozinka.Text.Trim(),
                    Uloga = cmbUloga.SelectedItem.ToString()
                };

                korisnikRepository.Insert(korisnik);

                MessageBox.Show("Korisnik je uspješno dodat.", "MiniMoodle",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                UcitajKorisnike();
                OcistiPolja();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom dodavanja korisnika:\n" + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIzmijeni_Click(object sender, EventArgs e)
        {
            if (selectedKorisnikId == 0)
            {
                MessageBox.Show("Prvo selektujte korisnika iz tabele.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidacijaUnosa())
                return;

            try
            {
                Korisnik korisnik = new Korisnik
                {
                    KorisnikId = selectedKorisnikId,
                    Ime = txtIme.Text.Trim(),
                    Prezime = txtPrezime.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Lozinka = txtLozinka.Text.Trim(),
                    Uloga = cmbUloga.SelectedItem.ToString()
                };

                korisnikRepository.Update(korisnik);

                MessageBox.Show("Korisnik je uspješno izmijenjen.", "MiniMoodle",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                UcitajKorisnike();
                OcistiPolja();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom izmjene korisnika:\n" + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (selectedKorisnikId == 0)
            {
                MessageBox.Show("Prvo selektujte korisnika iz tabele.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult rezultat = MessageBox.Show(
                "Da li ste sigurni da želite obrisati selektovanog korisnika?",
                "Potvrda brisanja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (rezultat != DialogResult.Yes)
                return;

            try
            {
                korisnikRepository.Delete(selectedKorisnikId);

                MessageBox.Show("Korisnik je uspješno obrisan.", "MiniMoodle",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                UcitajKorisnike();
                OcistiPolja();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom brisanja korisnika:\n" + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOcisti_Click(object sender, EventArgs e)
        {
            OcistiPolja();
        }

        private void btnZatvori_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string tekst = txtPretraga.Text.Trim();

                if (string.IsNullOrWhiteSpace(tekst))
                    dgvKorisnici.DataSource = korisnikRepository.GetAll();
                else
                    dgvKorisnici.DataSource = korisnikRepository.Search(tekst);

                UrediDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom pretrage:\n" + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKorisnici_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvKorisnici.Rows[e.RowIndex];

            selectedKorisnikId = Convert.ToInt32(row.Cells["korisnik_id"].Value);

            txtIme.Text = row.Cells["ime"].Value.ToString();
            txtPrezime.Text = row.Cells["prezime"].Value.ToString();
            txtEmail.Text = row.Cells["email"].Value.ToString();
            txtLozinka.Text = row.Cells["lozinka"].Value.ToString();
            cmbUloga.SelectedItem = row.Cells["uloga"].Value.ToString();
        }

        private bool ValidacijaUnosa()
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                MessageBox.Show("Ime je obavezno.", "Validacija",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIme.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                MessageBox.Show("Prezime je obavezno.", "Validacija",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrezime.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email je obavezan.", "Validacija",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                MessageBox.Show("Email nije u ispravnom formatu.", "Validacija",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLozinka.Text))
            {
                MessageBox.Show("Lozinka je obavezna.", "Validacija",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLozinka.Focus();
                return false;
            }

            if (cmbUloga.SelectedIndex == -1)
            {
                MessageBox.Show("Uloga je obavezna.", "Validacija",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbUloga.Focus();
                return false;
            }

            return true;
        }

        private void OcistiPolja()
        {
            selectedKorisnikId = 0;

            txtIme.Clear();
            txtPrezime.Clear();
            txtEmail.Clear();
            txtLozinka.Clear();
            txtPretraga.Clear();

            if (cmbUloga.Items.Count > 0)
                cmbUloga.SelectedIndex = 0;

            txtIme.Focus();
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}