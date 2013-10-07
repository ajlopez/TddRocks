namespace Consorcios.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Consorcios.Web.Models;

    public class ConsorcioController : Controller
    {
        private IList<Consorcio> consorcios;

        public ConsorcioController()
            : this(new List<Consorcio>())
        {
        }

        public ConsorcioController(IList<Consorcio> consorcios)
        {
            this.consorcios = consorcios;
        }

        public ActionResult Index()
        {
            return View(this.consorcios);
        }
    }
}
