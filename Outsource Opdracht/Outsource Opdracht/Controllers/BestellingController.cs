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
using OutsourceOpdracht.Converter;

namespace OutsourceOpdracht.Controllers
{
    public class BestellingController : Controller
    {

        //Repo
        BestellingRepository repo;

        BestellingViewModelConverter vmc = new BestellingViewModelConverter();

        //Constructor
        public BestellingController(BestellingRepository Repo)
        {
            this.repo = Repo;
        }

        [HttpGet]
        public IActionResult Pdf()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Pdf(BestellingDetailViewModel vm)
        {
            Bestelling bestelling = vmc.ViewModelToBestelling(vm);
            Document doc = repo.HaalBestellingOpMetKlantEmailEnBestelDatum(bestelling.KlantEmail, bestelling.BestelDatum);
            return View();
        }
        //Haalt Bestellingen op
    }
}


