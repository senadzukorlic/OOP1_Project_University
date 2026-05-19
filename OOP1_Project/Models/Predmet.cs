using System;

namespace OOP1_Project.Models
{
    public class Predmet
    {
        public int PredmetId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public int ProfesorId { get; set; }
        public int? AsistentId { get; set; }
    }
}