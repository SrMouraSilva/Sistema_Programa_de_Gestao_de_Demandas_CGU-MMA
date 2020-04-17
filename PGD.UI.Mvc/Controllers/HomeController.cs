using PGD.Application.Interfaces;
using PGD.Application.ViewModels;
using PGD.UI.Mvc.Filters;
using PGD.UI.Mvc.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PGD.UI.Mvc.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public HomeController(IUsuarioAppService usuarioAppService)
            : base(usuarioAppService)
        {
        }

        [SelecionarPerfilActionFilter]
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Pacto");
        }
    }
}