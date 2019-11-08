using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OutsourceOpdracht
{
    public class DatasetParser
    {
        public static Bestelling DatasetToBestelling(int rowIndex, DataSet set)
        {
            return new Bestelling()
            {
                BestellingID = (int)set.Tables[0].Rows[rowIndex][0],
                ProductNaam = (string)set.Tables[0].Rows[rowIndex][1],
                Aantal = (int)set.Tables[0].Rows[rowIndex][2],
                PrijsPerStuk = (int)set.Tables[0].Rows[rowIndex][3],
                KlantEmail = (string)set.Tables[0].Rows[rowIndex][4],
                BestelDatum = (DateTime)set.Tables[0].Rows[rowIndex][5],
                BedrijfNaam = (string)set.Tables[0].Rows[rowIndex][6],
                Tel = (string)set.Tables[0].Rows[rowIndex][7],
                Adres = (string)set.Tables[0].Rows[rowIndex][8],
                Postcode = (string)set.Tables[0].Rows[rowIndex][9],
                BedrijfEmail = (string)set.Tables[0].Rows[rowIndex][10]
            };
        }
    }
}
