using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Outsource_Opdracht.Models;
using OutsourceOpdracht.Context;
using OutsourceOpdracht.Repository;
using System.Web;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Xml;

namespace OutsourceOpdracht.Controllers
{
    public class BestellingController : Controller
    {

        //Repo
        BestellingRepository repo;

        //Constructor
        public BestellingController(BestellingRepository Repo)
        {
            this.repo = Repo;
        }

        public IActionResult Pdf()
        {
            HaalBesteldeProductenOp(DateTime.Now, string klant);
            return View();
        }

        //Haalt Bestellingen op
        public List<Bestelling> HaalBesteldeProductenOp(DateTime dateTime, string KlantEmail)
        {

            List<Bestelling> bestellingen = new List<Bestelling>();
            bestellingen = repo.HaalBestellingOpMetKlantEmailEnBestelDatum(KlantEmail, dateTime);
            return bestellingen;
        }

        protected void Pagina_Laden()
        {

            DateTime dtp = new DateTime();

            //Verander deze email naar waar jullie de email ophalen
            string klantEmail = "Test@gmail.com";
            List<Bestelling> Producten = new List<Bestelling>();
            Producten = HaalBesteldeProductenOp(dtp, klantEmail);

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
                dt.Rows.Add(b.ProductNaam, b.Aantal, (b.PrijsPerStuk / 100) * 79, (b.PrijsPerStuk / 100) * 21, b.PrijsPerStuk, b.PrijsPerStuk * b.Aantal);
            };
            
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter pdf = PdfWriter.GetInstance(doc, new FileStream("test.pdf", FileMode.Create));
            doc.Open();

            PdfPTable table = new PdfPTable(6);
            
            foreach(DataRow dr in dt.Rows)
            {
                foreach (object o in dr.ItemArray)
                {
                    PdfPCell c = new PdfPCell();
                    c.AddElement(new Chunk(o.ToString()));
                    table.AddCell(c);
                }
            }
            doc.Add(table);
            doc.Close();


        }
    }
}


