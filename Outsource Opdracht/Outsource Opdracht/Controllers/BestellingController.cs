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

namespace OutsourceOpdracht.Controllers
{
    public class BestellingController : Controller
    {
        BestellingRepository repo;

        public BestellingController(BestellingRepository Repo)
        {
            this.repo = Repo;
        }

        public IActionResult Pdf()
        {
            return View();
        }

        public List<Bestelling> GetBesteldeProducten(DateTime dateTime, string KlantEmail)
        {
            List<Bestelling> bestellingen = new List<Bestelling>();
            bestellingen = repo.HaalBestellingOpMetKlantEmailEnBestelDatum(KlantEmail, dateTime);
            return bestellingen;
        }

        protected void Page_Load()
        {

            DateTime dtp = new DateTime();
            string klantEmail = "Test@gmail.com";
            List<Bestelling> Producten = new List<Bestelling>();
            Producten = GetBesteldeProducten(dtp, klantEmail);

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
