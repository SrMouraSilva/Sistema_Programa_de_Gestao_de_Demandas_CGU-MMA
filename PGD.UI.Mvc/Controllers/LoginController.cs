using PGD.Application.Interfaces;
using PGD.Application.ViewModels;
using PGD.Domain.Interfaces.Service;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PGD.UI.Mvc.Controllers
{
    public class LoginController : BaseController
    {
        public LoginController(IUsuarioAppService usuarioAppService,
            IUnidadeService unidadeService)
            : base(usuarioAppService)
        {
            _unidadeService = unidadeService;
        }

        public ActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View("Index", loginViewModel);

            var usuario = Login(loginViewModel);

            if (usuario == null)
                return View(loginViewModel);

            if (!usuario.PerfilSelecionado.HasValue)
                return RedirectToAction("SelecionarPerfil", "Login");
            else
                return RedirectToAction("Index", "Pacto");
        }

        private UsuarioViewModel Login(LoginViewModel loginViewModel)
        {
            try
            {
                AutenticarLDAP(loginViewModel);

                var usuario = BuscarUsuario(loginViewModel);

                var deveSelecionarPerfil = _usuarioAppService.PodeSelecionarPerfil(usuario);

                if (!deveSelecionarPerfil)
                    usuario.PerfilSelecionado = usuario.Perfis.FirstOrDefault();

                setUserLogado(usuario);
                return usuario;
            }
            catch
            {
                ModelState.AddModelError("", "Usuário ou senha incorretos.");
                return null;
            }
        }

        private void AutenticarLDAP(LoginViewModel loginViewModel)
        {
            var ip = ConfigurationManager.AppSettings["IPLDAP"].ToString();
            var porta = int.Parse(ConfigurationManager.AppSettings["PortaLDAP"].ToString());
            var networkCredential = ConfigurationManager.AppSettings["NetworkCredentialLDAP"].ToString();

            var ldi = new LdapDirectoryIdentifier(ip, porta);
            var ldapConnection = new LdapConnection(ldi)
            {
                AuthType = AuthType.Basic
            };

            ldapConnection.SessionOptions.ProtocolVersion = 3;
            NetworkCredential nc = new NetworkCredential(string.Format(networkCredential, "admin"), "fKqeJMGV0UwnfKqqeosZnU4W3LZ29pu1");
            ldapConnection.Bind(nc);
            ldapConnection.Dispose();
        }

        public ActionResult SelecionarPerfil()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SelecionarPerfil(Domain.Enums.Perfil? perfil)
        {
            if (perfil == null)
                return View();

            var usuario = getUserLogado();
            usuario.AlterarPerfilSelecionado(perfil.Value);

            setUserLogado(usuario);

            var possuiUnidades = _usuarioAppService.PodeSelecionarUnidade(usuario);

            if (possuiUnidades)
                return RedirectToAction("SelecionarUnidade", "Login");
            else
                return RedirectToAction("Index", "Pacto");
        }

        public ActionResult SelecionarUnidade()
        {
            PrepararTempDataDropdowns();
            return View(new SelecionarUnidadeViewModel());
        }

        [HttpPost]
        public ActionResult SelecionarUnidade(SelecionarUnidadeViewModel selecionarUnidadeViewModel)
        {
            if (!ModelState.IsValid)
            {
                PrepararTempDataDropdowns();
                return View(selecionarUnidadeViewModel);
            }

            var usuario = getUserLogado();
            usuario.AlterarUnidadeSelecionada(selecionarUnidadeViewModel.IdUnidade.Value);

            setUserLogado(usuario);

            return RedirectToAction("Index", "Pacto");
        }

        [HttpPost]
        public ActionResult LogOut()
        {
            LimparSessionUsuario();

            return RedirectToAction("Index", "Login");
        }

        private void PrepararTempDataDropdowns()
        {
            TempData["lstUnidade"] = _unidadeService.ObterUnidades().ToList();
        }

        private void LimparSessionUsuario()
        {
            Session["UserLogado"] = null;
            Session["CpfUsuarioForcado"] = null;
            Session.Abandon();
        }

        private UsuarioViewModel BuscarUsuario(LoginViewModel loginViewModel)
        {
            return new UsuarioViewModel
            {
                CPF = loginViewModel.Cpf,
                Nome = "Bruno Corcino",
                Matricula = "99999",
                Perfis = new List<Domain.Enums.Perfil> { Domain.Enums.Perfil.Dirigente, Domain.Enums.Perfil.Solicitante, Domain.Enums.Perfil.Administrador }
            };
        }
    }
}