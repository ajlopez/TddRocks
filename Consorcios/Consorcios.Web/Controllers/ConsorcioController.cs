namespace Consorcios.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Consorcios.Core;

    public class ConsorcioController : Controller
    {
        private ConsorcioRepository repositorio;

        public ConsorcioController()
            : this(new ConsorcioRepository())
        {
        }

        public ConsorcioController(ConsorcioRepository repositorio)
        {
            this.repositorio = repositorio;
        }

        public ActionResult Index()
        {
            return View(repositorio.GetList());
        }

        [HttpPost]
        public ActionResult Add(string nombre)
        {
            repositorio.Add(new Consorcio() { Nombre = nombre });
            return View();
        }
    }
}
