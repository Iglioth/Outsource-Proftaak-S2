using OutsourceOpdracht.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutsourceOpdracht.Context
{
    public class BestellingMSSQLContext : BaseMSSQLContext, IBestellingContext
    {
        public HaalProductenOpMetklantEmailEnBestelDatum(string klantEmail, DateTime datetime)
        {
            string sql = "Select * From Bestellingen Where KlantEmail = @klantEmail and BestelDatum = @BestelDatum";
            List<KeyValuePair<object, object>> parameters = new List<KeyValuePair<object, object>>();
            parameters.Add(new KeyValuePair<object, object>("klantEmail", klantEmail));
            parameters.Add(new KeyValuePair<object, object>("BestelDatum", datetime));
        }
    }
}
