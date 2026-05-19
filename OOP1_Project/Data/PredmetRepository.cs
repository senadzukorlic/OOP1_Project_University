using MySql.Data.MySqlClient;
using OOP1_Project.Models;
using System;
using System.Data;

namespace OOP1_Project.Data
{
    public class PredmetRepository
    {
        public DataTable GetAll()
        {
            string query = @"
                SELECT 
                    p.predmet_id,
                    p.naziv,
                    p.opis,
                    p.datum_kreiranja,
                    p.profesor_id,
                    CONCAT(prof.ime, ' ', prof.prezime) AS profesor,
                    p.asistent_id,
                    IFNULL(CONCAT(asist.ime, ' ', asist.prezime), 'Nema asistenta') AS asistent
                FROM predmet p
                INNER JOIN korisnik prof ON p.profesor_id = prof.korisnik_id
                LEFT JOIN korisnik asist ON p.asistent_id = asist.korisnik_id
                ORDER BY p.predmet_id DESC;
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
                    p.predmet_id,
                    p.naziv,
                    p.opis,
                    p.datum_kreiranja,
                    p.profesor_id,
                    CONCAT(prof.ime, ' ', prof.prezime) AS profesor,
                    p.asistent_id,
                    IFNULL(CONCAT(asist.ime, ' ', asist.prezime), 'Nema asistenta') AS asistent
                FROM predmet p
                INNER JOIN korisnik prof ON p.profesor_id = prof.korisnik_id
                LEFT JOIN korisnik asist ON p.asistent_id = asist.korisnik_id
                WHERE 
                    p.naziv LIKE @searchText OR
                    p.opis LIKE @searchText OR
                    CONCAT(prof.ime, ' ', prof.prezime) LIKE @searchText OR
                    CONCAT(asist.ime, ' ', asist.prezime) LIKE @searchText
                ORDER BY p.predmet_id DESC;
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

        public DataTable GetProfesori()
        {
            string query = @"
                SELECT 
                    korisnik_id,
                    CONCAT(ime, ' ', prezime) AS puno_ime
                FROM korisnik
                WHERE uloga = 'profesor'
                ORDER BY ime, prezime;
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

        public DataTable GetAsistenti()
        {
            string query = @"
                SELECT 
                    korisnik_id,
                    CONCAT(ime, ' ', prezime) AS puno_ime
                FROM korisnik
                WHERE uloga = 'asistent'
                ORDER BY ime, prezime;
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

        public void Insert(Predmet predmet)
        {
            string query = @"
                INSERT INTO predmet (naziv, opis, datum_kreiranja, profesor_id, asistent_id)
                VALUES (@naziv, @opis, @datum_kreiranja, @profesor_id, @asistent_id);
            ";

            using (MySqlConnection connection = Database.GetConnection())
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@naziv", predmet.Naziv);
                command.Parameters.AddWithValue("@opis", predmet.Opis);
                command.Parameters.AddWithValue("@datum_kreiranja", predmet.DatumKreiranja);
                command.Parameters.AddWithValue("@profesor_id", predmet.ProfesorId);

                if (predmet.AsistentId.HasValue)
                    command.Parameters.AddWithValue("@asistent_id", predmet.AsistentId.Value);
                else
                    command.Parameters.AddWithValue("@asistent_id", DBNull.Value);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(Predmet predmet)
        {
            string query = @"
                UPDATE predmet
                SET 
                    naziv = @naziv,
                    opis = @opis,
                    datum_kreiranja = @datum_kreiranja,
                    profesor_id = @profesor_id,
                    asistent_id = @asistent_id
                WHERE predmet_id = @predmet_id;
            ";

            using (MySqlConnection connection = Database.GetConnection())
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@predmet_id", predmet.PredmetId);
                command.Parameters.AddWithValue("@naziv", predmet.Naziv);
                command.Parameters.AddWithValue("@opis", predmet.Opis);
                command.Parameters.AddWithValue("@datum_kreiranja", predmet.DatumKreiranja);
                command.Parameters.AddWithValue("@profesor_id", predmet.ProfesorId);

                if (predmet.AsistentId.HasValue)
                    command.Parameters.AddWithValue("@asistent_id", predmet.AsistentId.Value);
                else
                    command.Parameters.AddWithValue("@asistent_id", DBNull.Value);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int predmetId)
        {
            string query = @"
                DELETE FROM predmet
                WHERE predmet_id = @predmet_id;
            ";

            using (MySqlConnection connection = Database.GetConnection())
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@predmet_id", predmetId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}