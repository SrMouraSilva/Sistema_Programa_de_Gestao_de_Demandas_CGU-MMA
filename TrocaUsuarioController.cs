using PGD.Application.Interfaces;
using PGD.Application.ViewModels;
using PGD.Domain.Enums;
using PGD.UI.Mvc.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PGD.UI.Mvc.Controllers
{
    [AuthorizePerfil(Perfil.Administrador)]
    public class TrocaUsuarioController : BaseController
    {
        IUsuarioAppService _Usuarioservice;

        public TrocaUsuarioController(IUsuarioAppService usuarioAppService) : base(usuarioAppService)
        {
            _Usuarioservice = usuarioAppService;
        }

        // GET: TrocaUsuario
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Troca(UsuarioViewModel user)
        {
            Session["UserLogado"] = null;
            Session["CpfUsuarioForcado"] = user.CpfUsuario;
            return RedirectToAction("Index", "Home");
        }
    }
}