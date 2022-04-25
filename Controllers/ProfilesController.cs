using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConstruccionDeSoftware_ProyectoFinal.Controllers
{
    public class ProfilesController : Controller
    {
        // GET: Profile

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}