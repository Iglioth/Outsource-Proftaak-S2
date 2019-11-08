using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutsourceOpdracht
{
    public class Bestelling
    {
        public int BestellingID { get; set; }
        public string ProductNaam { get; set; }
        public int Aantal { get; set; }
        public int PrijsPerStuk { get; set; }
        public string KlantEmail { get; set; }
        public DateTime BestelDatum { get; set; }
        public string BedrijfNaam { get; set; }
        public string Tel { get; set; }
        public string Adres { get; set; }
        public string Postcode { get; set; }
        public string BedrijfEmail { get; set; }
    }
}