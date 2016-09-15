using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupVisao.Web.Controllers
{
    public class CertificadoController : Controller
    {
        // GET: Certificado
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