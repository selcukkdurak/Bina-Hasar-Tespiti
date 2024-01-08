using BinaHasarTespiti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BinaHasarTespiti.Controllers
{
    public class AdressController : Controller
    {
        // GET: Adress

        [Authorize]
        public ActionResult Adress()
        {
            BinaHasarDurumEntities dbAdres = new BinaHasarDurumEntities();

            var adresler = dbAdres.Adress.ToList();
            return View(adresler);

        }
    }
}