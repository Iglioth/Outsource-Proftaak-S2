using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using OutsourceOpdracht.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace OutsourceOpdracht.Repository
{
    public class BestellingRepository
    {
        protected IBestellingContext context;

        public BestellingRepository(IBestellingContext context)
        {
            this.context = context;
        }

        public Document HaalBestellingOpMetKlantEmailEnBestelDatum(string klantEmail, DateTime dateTime)
        {
            List<Bestelling> bestellingen = context.HaalBestellingOpMetKlantEmailEnBestelDatum(klantEmail, dateTime);

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
            foreach (Bestelling bes in bestellingen)
            {
                dt.Rows.Add(bes.ProductNaam, bes.Aantal, (bes.PrijsPerStuk / 100) * 79, (bes.PrijsPerStuk / 100) * 21, bes.PrijsPerStuk, bes.PrijsPerStuk * bes.Aantal);
            };


            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
            doc.Open();

            string Header = "Your Email: " + bestellingen[1].KlantEmail + " Date of Purchase: " + bestellingen[1].BestelDatum + " Company Name: " + bestellingen[1].BedrijfNaam;
            doc.AddHeader("Bonnetje", Header);
            PdfPTable table = new PdfPTable(6);

            foreach (DataRow dr in dt.Rows)
            {
                foreach (object o in dr.ItemArray)
                {
                    PdfPCell c = new PdfPCell();
                    c.AddElement(new Chunk(o.ToString()));
                    table.AddCell(c);
                }
            }
            doc.Add(table);
            writer.CloseStream = false;
            doc.Close();

            MailMessage message = new MailMessage("Axi@domain.com", "Iglioth@gmail.com", "Pdf mail", "Bedankt voor uw aankoop bij Axi, in de bijlage van deze email vindt u uw bonnetje");
            Attachment pdf = new Attachment(memoryStream, "test.pdf");

            memoryStream.Position = 0;
            message.Attachments.Add(pdf);

            SmtpClient client2 = new SmtpClient("smtp.gmail.com", 587);
            client2.Send(message);

            return doc;
        }
    }
}
