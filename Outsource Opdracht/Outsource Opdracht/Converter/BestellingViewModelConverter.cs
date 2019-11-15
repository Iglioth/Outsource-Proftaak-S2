using Outsource_Opdracht.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutsourceOpdracht.Converter
{
    public class BestellingViewModelConverter
    {
        public Bestelling ViewModelToBestelling(BestellingDetailViewModel vm)
        {
            Bestelling b = new Bestelling()
            {
                Aantal = vm.Aantal,
                BestelDatum = vm.BestelDatum,
                Adres = vm.Adres,
                BedrijfEmail = vm.BedrijfEmail,
                BedrijfNaam = vm.BedrijfNaam,
                BestellingID = vm.BestellingID,
                KlantEmail = vm.KlantEmail,
                Postcode = vm.Postcode,
                PrijsPerStuk = vm.PrijsPerStuk,
                ProductNaam = vm.ProductNaam,
                Tel = vm.Tel
            };



            return b;
        }

        public BestellingDetailViewModel BestellingToViewModel(Bestelling b)
        {
            BestellingDetailViewModel vm = new BestellingDetailViewModel()
            {
                Aantal = b.Aantal,
                Adres = b.Adres,
                BedrijfEmail = b.BedrijfEmail,
                BedrijfNaam = b.BedrijfNaam,
                BestelDatum = b.BestelDatum, 
                BestellingID = b.BestellingID, 
                KlantEmail = b.KlantEmail,
                Postcode = b.Postcode,
                PrijsPerStuk = b.PrijsPerStuk,
                ProductNaam = b.ProductNaam,    
                Tel = b.Tel,
            };



            return vm;
        }
    }
}
