using MySql.Data.MySqlClient;
using OOP1_Project.Models;
using System;

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
    }
}