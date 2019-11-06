using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Outsource_Opdracht.Models;

namespace OutsourceOpdracht.Controllers
{
    public class BestellingController : Controller
    {
        public IActionResult Pdf()
        {
            return View();
        }

        internal static List<Bestelling> GetBesteldeProducten(DateTime dateTime)
        {
            throw new NotImplementedException();
        }
    }
}
