namespace OOP1_Project.Models
{
    public class Korisnik
    {
        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
        public string Uloga { get; set; }

        public string PunoIme
        {
            get { return Ime + " " + Prezime; }
        }
    }
}