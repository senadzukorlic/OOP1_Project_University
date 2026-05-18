using MySql.Data.MySqlClient;
using OOP1_Project.Models;
using System;
using System.Data;

namespace OOP1_Project.Data
{
    public class KorisnikRepository
    {
        public Korisnik Login(string email, string lozinka)
        {
            string query = @"
                SELECT korisnik_id, ime, prezime, email, lozinka, uloga
                FROM korisnik
                WHERE email = @email AND lozinka = @lozinka
                LIMIT 1;
            ";

            using (MySqlConnection connection = Database.GetConnection())
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@lozinka", lozinka);

                connection.Open();

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Korisnik
                        {
                            KorisnikId = Convert.ToInt32(reader["korisnik_id"]),
                            Ime = reader["ime"].ToString(),
                            Prezime = reader["prezime"].ToString(),
                            Email = reader["email"].ToString(),
                            Lozinka = reader["lozinka"].ToString(),
                            Uloga = reader["uloga"].ToString()
                        };
                    }
                }
            }

            return null;
        }

        public DataTable GetAll()
        {
            string query = @"
                SELECT 
                    korisnik_id,
                    ime,
                    prezime,
                    email,
                    lozinka,
                    uloga
                FROM korisnik
                ORDER BY korisnik_id DESC;
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
                    korisnik_id,
                    ime,
                    prezime,
                    email,
                    lozinka,
                    uloga
                FROM korisnik
                WHERE 
                    ime LIKE @searchText OR
                    prezime LIKE @searchText OR
                    email LIKE @searchText OR
                    uloga LIKE @searchText
                ORDER BY korisnik_id DESC;
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

        public void Insert(Korisnik korisnik)
        {
            string query = @"
                INSERT INTO korisnik (ime, prezime, email, lozinka, uloga)
                VALUES (@ime, @prezime, @email, @lozinka, @uloga);
            ";

            using (MySqlConnection connection = Database.GetConnection())
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ime", korisnik.Ime);
                command.Parameters.AddWithValue("@prezime", korisnik.Prezime);
                command.Parameters.AddWithValue("@email", korisnik.Email);
                command.Parameters.AddWithValue("@lozinka", korisnik.Lozinka);
                command.Parameters.AddWithValue("@uloga", korisnik.Uloga);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(Korisnik korisnik)
        {
            string query = @"
                UPDATE korisnik
                SET 
                    ime = @ime,
                    prezime = @prezime,
                    email = @email,
                    lozinka = @lozinka,
                    uloga = @uloga
                WHERE korisnik_id = @korisnik_id;
            ";

            using (MySqlConnection connection = Database.GetConnection())
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@korisnik_id", korisnik.KorisnikId);
                command.Parameters.AddWithValue("@ime", korisnik.Ime);
                command.Parameters.AddWithValue("@prezime", korisnik.Prezime);
                command.Parameters.AddWithValue("@email", korisnik.Email);
                command.Parameters.AddWithValue("@lozinka", korisnik.Lozinka);
                command.Parameters.AddWithValue("@uloga", korisnik.Uloga);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int korisnikId)
        {
            string query = @"
                DELETE FROM korisnik
                WHERE korisnik_id = @korisnik_id;
            ";

            using (MySqlConnection connection = Database.GetConnection())
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@korisnik_id", korisnikId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}