using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutsourceOpdracht.Interface
{
    public interface IBestellingContext
    {
        List<Bestelling> HaalBestellingOpMetKlantEmailEnBestelDatum(string klantEmail, DateTime datetime);
    }
}
