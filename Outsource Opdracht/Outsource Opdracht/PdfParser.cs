using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using OutsourceOpdracht.Controllers;

namespace OutsourceOpdracht
{
    public class PdfParser
    {
        protected void Page_Load()
        {
            DateTime dtp = new DateTime();
            List<Bestelling> Producten = new List<Bestelling>();
            Producten = BestellingController.GetBesteldeProducten(dtp);
            string companyName = "checkCompany";
            int orderNo = 1234;
            DataTable dt = new DataTable();
            //Data die op de pdf een keer moet komen zijn de KlantEmail, BestelDatum, Bedrijfnaam

            //Data die op pdf moet komen in rijen zijn de Productnaam, Aantal, PrijsPerStuk
            dt.Columns.AddRange(new DataColumn[6] {
                            new DataColumn("ProductNaam", typeof(string)),
                            new DataColumn("Aantal", typeof(int)),
                            new DataColumn("Prijs per product Exclusief BTW", typeof(int)),
                            new DataColumn("BTW per product", typeof(int)),
                            new DataColumn("Totaal Prijs Per Product", typeof(int)),
                            new DataColumn("Totaal Productprijs", typeof(int))
            });
            foreach (Bestelling b in Producten)
            {
                dt.Rows.Add();
            };
        }
    }
}
