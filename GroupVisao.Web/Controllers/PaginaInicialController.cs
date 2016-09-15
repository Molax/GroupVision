using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupVisao.Web.Controllers
{
    public class PaginaInicialController : Controller
    {
        // GET: PaginaInicial
        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("~/Login");
            }
        }
    }
}