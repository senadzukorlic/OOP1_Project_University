using OOP1_Project.Data;
using OOP1_Project.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace OOP1_Project
{
    public partial class FrmPredmeti : Form
    {
        private readonly PredmetRepository predmetRepository = new PredmetRepository();
        private int selectedPredmetId = 0;

        public FrmPredmeti()
        {
            InitializeComponent();

            this.Text = "MiniMoodle - Predmeti";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            this.Load += FrmPredmeti_Load;

            btnDodaj.Click += btnDodaj_Click;
            btnIzmijeni.Click += btnIzmijeni_Click;
            btnObrisi.Click += btnObrisi_Click;
            btnOcisti.Click += btnOcisti_Click;
            btnZatvori.Click += btnZatvori_Click;

            txtPretraga.TextChanged += txtPretraga_TextChanged;
            dgvPredmeti.CellClick += dgvPredmeti_CellClick;
            chkBezAsistenta.CheckedChanged += chkBezAsistenta_CheckedChanged;
        }

        private void FrmPredmeti_Load(object sender, EventArgs e)
        {
            UcitajProfesore();
            UcitajAsistente();
            UcitajPredmete();

            dtpDatumKreiranja.Value = DateTime.Now;
        }

        private void UcitajProfesore()
        {
            cmbProfesor.DataSource = predmetRepository.GetProfesori();
            cmbProfesor.DisplayMember = "puno_ime";
            cmbProfesor.ValueMember = "korisnik_id";
        }

        private void UcitajAsistente()
        {
            cmbAsistent.DataSource = predmetRepository.GetAsistenti();
            cmbAsistent.DisplayMember = "puno_ime";
            cmbAsistent.ValueMember = "korisnik_id";
        }

        private void UcitajPredmete()
        {
            dgvPredmeti.DataSource = predmetRepository.GetAll();
            UrediDataGridView();
        }

        private void UrediDataGridView()
        {
            if (dgvPredmeti.Columns["predmet_id"] != null)
                dgvPredmeti.Columns["predmet_id"].Visible = false;

            if (dgvPredmeti.Columns["profesor_id"] != null)
                dgvPredmeti.Columns["profesor_id"].Visible = false;

            if (dgvPredmeti.Columns["asistent_id"] != null)
                dgvPredmeti.Columns["asistent_id"].Visible = false;

            if (dgvPredmeti.Columns["naziv"] != null)
                dgvPredmeti.Columns["naziv"].HeaderText = "Naziv";

            if (dgvPredmeti.Columns["opis"] != null)
                dgvPredmeti.Columns["opis"].HeaderText = "Opis";

            if (dgvPredmeti.Columns["datum_kreiranja"] != null)
                dgvPredmeti.Columns["datum_kreiranja"].HeaderText = "Datum kreiranja";

            if (dgvPredmeti.Columns["profesor"] != null)
                dgvPredmeti.Columns["profesor"].HeaderText = "Profesor";

            if (dgvPredmeti.Columns["asistent"] != null)
                dgvPredmeti.Columns["asistent"].HeaderText = "Asistent";

            dgvPredmeti.ReadOnly = true;
            dgvPredmeti.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPredmeti.MultiSelect = false;
            dgvPredmeti.AllowUserToAddRows = false;
            dgvPredmeti.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (!ValidacijaUnosa())
                return;

            try
            {
                Predmet predmet = new Predmet
                {
                    Naziv = txtNaziv.Text.Trim(),
                    Opis = txtOpis.Text.Trim(),
                    DatumKreiranja = dtpDatumKreiranja.Value.Date,
                    ProfesorId = Convert.ToInt32(cmbProfesor.SelectedValue),
                    AsistentId = chkBezAsistenta.Checked ? (int?)null : Convert.ToInt32(cmbAsistent.SelectedValue)
                };

                predmetRepository.Insert(predmet);

                MessageBox.Show("Predmet je uspješno dodat.", "MiniMoodle",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                UcitajPredmete();
                OcistiPolja();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom dodavanja predmeta:\n" + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIzmijeni_Click(object sender, EventArgs e)
        {
            if (selectedPredmetId == 0)
            {
                MessageBox.Show("Prvo selektujte predmet iz tabele.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidacijaUnosa())
                return;

            try
            {
                Predmet predmet = new Predmet
                {
                    PredmetId = selectedPredmetId,
                    Naziv = txtNaziv.Text.Trim(),
                    Opis = txtOpis.Text.Trim(),
                    DatumKreiranja = dtpDatumKreiranja.Value.Date,
                    ProfesorId = Convert.ToInt32(cmbProfesor.SelectedValue),
                    AsistentId = chkBezAsistenta.Checked ? (int?)null : Convert.ToInt32(cmbAsistent.SelectedValue)
                };

                predmetRepository.Update(predmet);

                MessageBox.Show("Predmet je uspješno izmijenjen.", "MiniMoodle",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                UcitajPredmete();
                OcistiPolja();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom izmjene predmeta:\n" + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (selectedPredmetId == 0)
            {
                MessageBox.Show("Prvo selektujte predmet iz tabele.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult rezultat = MessageBox.Show(
                "Da li ste sigurni da želite obrisati selektovani predmet?",
                "Potvrda brisanja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (rezultat != DialogResult.Yes)
                return;

            try
            {
                predmetRepository.Delete(selectedPredmetId);

                MessageBox.Show("Predmet je uspješno obrisan.", "MiniMoodle",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                UcitajPredmete();
                OcistiPolja();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Greška prilikom brisanja predmeta:\n" + ex.Message +
                    "\n\nNapomena: predmet koji ima lekcije ili upisane studente ne može se obrisati dok postoje povezani podaci.",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
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
                    dgvPredmeti.DataSource = predmetRepository.GetAll();
                else
                    dgvPredmeti.DataSource = predmetRepository.Search(tekst);

                UrediDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom pretrage:\n" + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPredmeti_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvPredmeti.Rows[e.RowIndex];

            selectedPredmetId = Convert.ToInt32(row.Cells["predmet_id"].Value);

            txtNaziv.Text = row.Cells["naziv"].Value.ToString();
            txtOpis.Text = row.Cells["opis"].Value.ToString();
            dtpDatumKreiranja.Value = Convert.ToDateTime(row.Cells["datum_kreiranja"].Value);

            cmbProfesor.SelectedValue = Convert.ToInt32(row.Cells["profesor_id"].Value);

            if (row.Cells["asistent_id"].Value == DBNull.Value || row.Cells["asistent_id"].Value == null)
            {
                chkBezAsistenta.Checked = true;
            }
            else
            {
                chkBezAsistenta.Checked = false;
                cmbAsistent.SelectedValue = Convert.ToInt32(row.Cells["asistent_id"].Value);
            }
        }

        private void chkBezAsistenta_CheckedChanged(object sender, EventArgs e)
        {
            cmbAsistent.Enabled = !chkBezAsistenta.Checked;
        }

        private bool ValidacijaUnosa()
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                MessageBox.Show("Naziv predmeta je obavezan.", "Validacija",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNaziv.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtOpis.Text))
            {
                MessageBox.Show("Opis predmeta je obavezan.", "Validacija",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOpis.Focus();
                return false;
            }

            if (cmbProfesor.SelectedIndex == -1)
            {
                MessageBox.Show("Profesor je obavezan.", "Validacija",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProfesor.Focus();
                return false;
            }

            if (!chkBezAsistenta.Checked && cmbAsistent.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite asistenta ili označite opciju Bez asistenta.", "Validacija",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAsistent.Focus();
                return false;
            }

            return true;
        }

        private void OcistiPolja()
        {
            selectedPredmetId = 0;

            txtNaziv.Clear();
            txtOpis.Clear();
            txtPretraga.Clear();

            dtpDatumKreiranja.Value = DateTime.Now;

            if (cmbProfesor.Items.Count > 0)
                cmbProfesor.SelectedIndex = 0;

            if (cmbAsistent.Items.Count > 0)
                cmbAsistent.SelectedIndex = 0;

            chkBezAsistenta.Checked = false;
            cmbAsistent.Enabled = true;

            txtNaziv.Focus();
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }
    }
}