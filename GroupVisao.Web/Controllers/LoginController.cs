using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroupVisao.Web.Models;
using GroupVision.Bll;

namespace GroupVisao.Web.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
    {
            if (Session["usuarioLogadoID"] != null)
            {
                return Redirect("PaginaInicial");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(GroupVisao.Web.Models.Login usuario)
        {
            if (ModelState.IsValid)
            {
                var userId = new GroupVision.Bll.Login().LoginUser(usuario.login, usuario.password);
                if (userId != 0)
                {
                    Session["usuarioLogadoID"] = userId;

                    return Redirect("PaginaInicial");
                }
                else
                {
                    ViewBag.errorMessage = "Usuário e senha inválidos!";
                    return View();
                }
            }
            else
            {
                ViewBag.errorMessage = "Digite todos os campos corretamente!";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["usuarioLogadoID"] = null;
            return RedirectToAction("Index");
        }
    }
}