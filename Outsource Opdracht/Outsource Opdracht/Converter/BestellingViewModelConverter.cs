using Outsource_Opdracht.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutsourceOpdracht.Converter
{
    public class BestellingViewModelConverter
    {
        public Bestelling ViewModelToBestelling(BestellingDetailViewModel detailViewModel)
        {
            Bestelling b = new Bestelling();



            return b;
        }

        public BestellingDetailViewModel BestellingToViewModel(Bestelling bestelling)
        {
            BestellingDetailViewModel vm = new BestellingDetailViewModel();



            return vm;
        }
    }
}
