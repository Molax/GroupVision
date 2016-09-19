using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bll = GroupVision.Bll;
namespace GroupVisao.Web.Controllers
{
    public class PaginaInicialController : Controller
    {
        // GET: PaginaInicial
        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                var x = new bll.Certificado().RetornaDadosDash();
                ViewBag.CertificadoVencido = new bll.Certificado().SelecionaTodosCertificadosVencidos();
                ViewBag.Certificado = x[0];
                ViewBag.Empresa = x[1];
                return View();
            }
            else
            {
                return Redirect("~/Login");
            }
        }
    }
}