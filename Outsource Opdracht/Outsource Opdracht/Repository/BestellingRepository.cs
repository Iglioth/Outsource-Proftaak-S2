using OutsourceOpdracht.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutsourceOpdracht.Repository
{
    public class BestellingRepository
    {
        protected IBestellingContext context;

        public BestellingRepository(IBestellingContext context)
        {
            this.context = context ?? throw new NotImplementedException("IBestellingContext is leeg");
        }

        public List<Bestelling> HaalBestellingOpMetKlantEmailEnBestelDatum(string klantEmail, DateTime dateTime)
        {
            return context.HaalBestellingOpMetKlantEmailEnBestelDatum(klantEmail, dateTime);
        }
    }
}
