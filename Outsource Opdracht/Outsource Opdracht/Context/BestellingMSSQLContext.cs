using OutsourceOpdracht.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OutsourceOpdracht.Context
{
    public class BestellingMSSQLContext : BaseMSSQLContext, IBestellingContext
    {
        public List<Bestelling> HaalBestellingOpMetKlantEmailEnBestelDatum(string klantEmail, DateTime datetime)
        {
            string sql = "Select * From Bestellingen Where KlantEmail = @klantEmail and BestelDatum = @BestelDatum";
            List<KeyValuePair<object, object>> parameters = new List<KeyValuePair<object, object>>();
            parameters.Add(new KeyValuePair<object, object>("klantEmail", klantEmail));
            parameters.Add(new KeyValuePair<object, object>("BestelDatum", datetime));
            List<Bestelling> bestellingen = new List<Bestelling>();
            DataSet results = ExecuteSql(sql, parameters);

            if(results != null && results.Tables[0].Rows.Count > 0)
            {
                for(int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    Bestelling b = DatasetParser.DatasetToBestelling(x, results);
                    bestellingen.Add(b);
                }
            }

            else
            {
                return null;
            }

            return bestellingen;
        }
    }
}
