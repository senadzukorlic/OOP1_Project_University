using System;

namespace OOP1_Project.Models
{
    public class Lekcija
    {
        public int LekcijaId { get; set; }
        public int PredmetId { get; set; }
        public string Naziv { get; set; }
        public string TipLekcije { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime DatumObjave { get; set; }
    }
}
