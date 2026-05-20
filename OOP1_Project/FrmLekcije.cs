using OOP1_Project.Data;
using OOP1_Project.Models;
using System;
using System.Windows.Forms;

namespace OOP1_Project
{
    public partial class FrmLekcije : Form
    {
        private readonly LekcijaRepository lekcijaRepository = new LekcijaRepository();
        private int selectedLekcijaId = 0;

        public FrmLekcije()
        {
            InitializeComponent();

            this.Text = "MiniMoodle - Lekcije";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            this.Load += FrmLekcije_Load;

            btnDodaj.Click += btnDodaj_Click;
            btnIzmijeni.Click += btnIzmijeni_Click;
            btnObrisi.Click += btnObrisi_Click;
            btnOcisti.Click += btnOcisti_Click;
            btnZatvori.Click += btnZatvori_Click;

            txtPretraga.TextChanged += txtPretraga_TextChanged;
            dgvLekcije.CellClick += dgvLekcije_CellClick;
        }

        private void FrmLekcije_Load(object sender, EventArgs e)
        {
            UcitajPredmete();
            UcitajTipoveLekcije();
            UcitajLekcije();

            dtpDatumObjave.Value = DateTime.Now;
        }

        private void UcitajPredmete()
        {
            cmbPredmet.DataSource = lekcijaRepository.GetPredmeti();
            cmbPredmet.DisplayMember = "naziv";
            cmbPredmet.ValueMember = "predmet_id";
        }

        private void UcitajTipoveLekcije()
        {
            cmbTipLekcije.Items.Clear();
            cmbTipLekcije.Items.Add("pdf");
            cmbTipLekcije.Items.Add("zadatak");
            cmbTipLekcije.SelectedIndex = 0;
        }

        private void UcitajLekcije()
        {
            dgvLekcije.DataSource = lekcijaRepository.GetAll();
            UrediDataGridView();
        }

        private void UrediDataGridView()
        {
            if (dgvLekcije.Columns["lekcija_id"] != null)
                dgvLekcije.Columns["lekcija_id"].Visible = false;

            if (dgvLekcije.Columns["predmet_id"] != null)
                dgvLekcije.Columns["predmet_id"].Visible = false;

            if (dgvLekcije.Columns["predmet"] != null)
                dgvLekcije.Columns["predmet"].HeaderText = "Predmet";

            if (dgvLekcije.Columns["naziv"] != null)
                dgvLekcije.Columns["naziv"].HeaderText = "Naziv";

            if (dgvLekcije.Columns["tip_lekcije"] != null)
                dgvLekcije.Columns["tip_lekcije"].HeaderText = "Tip lekcije";

            if (dgvLekcije.Columns["sadrzaj"] != null)
                dgvLekcije.Columns["sadrzaj"].HeaderText = "Sadržaj";

            if (dgvLekcije.Columns["datum_objave"] != null)
                dgvLekcije.Columns["datum_objave"].HeaderText = "Datum objave";

            dgvLekcije.ReadOnly = true;
            dgvLekcije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLekcije.MultiSelect = false;
            dgvLekcije.AllowUserToAddRows = false;
            dgvLekcije.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (!ValidacijaUnosa())
                return;

            try
            {
                Lekcija lekcija = new Lekcija
                {
                    PredmetId = Convert.ToInt32(cmbPredmet.SelectedValue),
                    Naziv = txtNaziv.Text.Trim(),
                    TipLekcije = cmbTipLekcije.SelectedItem.ToString(),
                    Sadrzaj = txtSadrzaj.Text.Trim(),
                    DatumObjave = dtpDatumObjave.Value.Date
                };

                lekcijaRepository.Insert(lekcija);

                MessageBox.Show("Lekcija je uspješno dodata.", "MiniMoodle",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                UcitajLekcije();
                OcistiPolja();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom dodavanja lekcije:\n" + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIzmijeni_Click(object sender, EventArgs e)
        {
            if (selectedLekcijaId == 0)
            {
                MessageBox.Show("Prvo selektujte lekciju iz tabele.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidacijaUnosa())
                return;

            try
            {
                Lekcija lekcija = new Lekcija
                {
                    LekcijaId = selectedLekcijaId,
                    PredmetId = Convert.ToInt32(cmbPredmet.SelectedValue),
                    Naziv = txtNaziv.Text.Trim(),
                    TipLekcije = cmbTipLekcije.SelectedItem.ToString(),
                    Sadrzaj = txtSadrzaj.Text.Trim(),
                    DatumObjave = dtpDatumObjave.Value.Date
                };

                lekcijaRepository.Update(lekcija);

                MessageBox.Show("Lekcija je uspješno izmijenjena.", "MiniMoodle",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                UcitajLekcije();
                OcistiPolja();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom izmjene lekcije:\n" + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (selectedLekcijaId == 0)
            {
                MessageBox.Show("Prvo selektujte lekciju iz tabele.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult rezultat = MessageBox.Show(
                "Da li ste sigurni da želite obrisati selektovanu lekciju?",
                "Potvrda brisanja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (rezultat != DialogResult.Yes)
                return;

            try
            {
                lekcijaRepository.Delete(selectedLekcijaId);

                MessageBox.Show("Lekcija je uspješno obrisana.", "MiniMoodle",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                UcitajLekcije();
                OcistiPolja();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom brisanja lekcije:\n" + ex.Message,
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
                    dgvLekcije.DataSource = lekcijaRepository.GetAll();
                else
                    dgvLekcije.DataSource = lekcijaRepository.Search(tekst);

                UrediDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom pretrage:\n" + ex.Message,
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLekcije_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvLekcije.Rows[e.RowIndex];

            selectedLekcijaId = Convert.ToInt32(row.Cells["lekcija_id"].Value);

            cmbPredmet.SelectedValue = Convert.ToInt32(row.Cells["predmet_id"].Value);
            txtNaziv.Text = row.Cells["naziv"].Value.ToString();
            cmbTipLekcije.SelectedItem = row.Cells["tip_lekcije"].Value.ToString();
            txtSadrzaj.Text = row.Cells["sadrzaj"].Value.ToString();
            dtpDatumObjave.Value = Convert.ToDateTime(row.Cells["datum_objave"].Value);
        }

        private bool ValidacijaUnosa()
        {
            if (cmbPredmet.SelectedIndex == -1)
            {
                MessageBox.Show("Predmet je obavezan.", "Validacija",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPredmet.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                MessageBox.Show("Naziv lekcije je obavezan.", "Validacija",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNaziv.Focus();
                return false;
            }

            if (cmbTipLekcije.SelectedIndex == -1)
            {
                MessageBox.Show("Tip lekcije je obavezan.", "Validacija",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipLekcije.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSadrzaj.Text))
            {
                MessageBox.Show("Sadržaj lekcije je obavezan.", "Validacija",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSadrzaj.Focus();
                return false;
            }

            return true;
        }

        private void OcistiPolja()
        {
            selectedLekcijaId = 0;

            txtNaziv.Clear();
            txtSadrzaj.Clear();
            txtPretraga.Clear();

            if (cmbPredmet.Items.Count > 0)
                cmbPredmet.SelectedIndex = 0;

            if (cmbTipLekcije.Items.Count > 0)
                cmbTipLekcije.SelectedIndex = 0;

            dtpDatumObjave.Value = DateTime.Now;

            txtNaziv.Focus();
        }
    }
}