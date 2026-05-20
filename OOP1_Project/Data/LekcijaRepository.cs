using MySql.Data.MySqlClient;
using OOP1_Project.Models;
using System;
using System.Data;

namespace OOP1_Project.Data
{
    public class LekcijaRepository
    {
        public DataTable GetAll()
        {
            string query = @"
                SELECT
                    l.lekcija_id,
                    l.predmet_id,
                    p.naziv AS predmet,
                    l.naziv,
                    l.tip_lekcije,
                    l.sadrzaj,
                    l.datum_objave
                FROM lekcija l
                INNER JOIN predmet p ON l.predmet_id = p.predmet_id
                ORDER BY l.lekcija_id DESC;
            ";

            using (MySqlConnection connection = Database.GetConnection())
            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
            {
                DataTable tabela = new DataTable();
                adapter.Fill(tabela);
                return tabela;
            }
        }

        public DataTable Search(string searchText)
        {
            string query = @"
                SELECT
                    l.lekcija_id,
                    l.predmet_id,
                    p.naziv AS predmet,
                    l.naziv,
                    l.tip_lekcije,
                    l.sadrzaj,
                    l.datum_objave
                FROM lekcija l
                INNER JOIN predmet p ON l.predmet_id = p.predmet_id
                WHERE
                    l.naziv LIKE @searchText OR
                    l.tip_lekcije LIKE @searchText OR
                    l.sadrzaj LIKE @searchText OR
                    p.naziv LIKE @searchText
                ORDER BY l.lekcija_id DESC;
            ";

            using (MySqlConnection connection = Database.GetConnection())
            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                DataTable tabela = new DataTable();
                adapter.Fill(tabela);
                return tabela;
            }
        }

        public DataTable GetPredmeti()
        {
            string query = @"
                SELECT
                    predmet_id,
                    naziv
                FROM predmet
                ORDER BY naziv;
            ";

            using (MySqlConnection connection = Database.GetConnection())
            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
            {
                DataTable tabela = new DataTable();
                adapter.Fill(tabela);
                return tabela;
            }
        }

        public void Insert(Lekcija lekcija)
        {
            string query = @"
                INSERT INTO lekcija (predmet_id, naziv, tip_lekcije, sadrzaj, datum_objave)
                VALUES (@predmet_id, @naziv, @tip_lekcije, @sadrzaj, @datum_objave);
            ";

            using (MySqlConnection connection = Database.GetConnection())
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@predmet_id", lekcija.PredmetId);
                command.Parameters.AddWithValue("@naziv", lekcija.Naziv);
                command.Parameters.AddWithValue("@tip_lekcije", lekcija.TipLekcije);
                command.Parameters.AddWithValue("@sadrzaj", lekcija.Sadrzaj);
                command.Parameters.AddWithValue("@datum_objave", lekcija.DatumObjave);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(Lekcija lekcija)
        {
            string query = @"
                UPDATE lekcija
                SET
                    predmet_id = @predmet_id,
                    naziv = @naziv,
                    tip_lekcije = @tip_lekcije,
                    sadrzaj = @sadrzaj,
                    datum_objave = @datum_objave
                WHERE lekcija_id = @lekcija_id;
            ";

            using (MySqlConnection connection = Database.GetConnection())
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@lekcija_id", lekcija.LekcijaId);
                command.Parameters.AddWithValue("@predmet_id", lekcija.PredmetId);
                command.Parameters.AddWithValue("@naziv", lekcija.Naziv);
                command.Parameters.AddWithValue("@tip_lekcije", lekcija.TipLekcije);
                command.Parameters.AddWithValue("@sadrzaj", lekcija.Sadrzaj);
                command.Parameters.AddWithValue("@datum_objave", lekcija.DatumObjave);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int lekcijaId)
        {
            string query = @"
                DELETE FROM lekcija
                WHERE lekcija_id = @lekcija_id;
            ";

            using (MySqlConnection connection = Database.GetConnection())
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@lekcija_id", lekcijaId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}