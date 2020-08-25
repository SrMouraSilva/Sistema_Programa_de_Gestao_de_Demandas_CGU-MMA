using CsQuery.ExtensionMethods;
using PGD.Application.Interfaces;
using PGD.Application.Util;
using PGD.Application.ViewModels;
using PGD.Application.ViewModels.Filtros;
using System.Web.Mvc;

namespace PGD.UI.Mvc.Controllers
{
    public class UsuarioController : BaseController
    {
        public UsuarioController(IUsuarioAppService usuarioAppService) : base(usuarioAppService)
        {
        }

        public ActionResult Index()
        {
            return View(new SearchUsuarioViewModel());
        }

        [HttpPost]
        public ActionResult Index(SearchUsuarioViewModel model)
        {
            if (!ModelState.IsValid) return Json(new { camposNaoPreenchidos = RetornaErrosModelState() });
            var filtro = new UsuarioFiltroViewModel
            {
                Nome = model.NomeUsuario, Matricula = model.MatriculaUsuario, IdUnidade = model.IdUnidade, IncludeUnidadesPerfis = true,
                Take = model.Take, Skip = model.Skip
            };
            var usuarios = _usuarioAppService.Buscar(filtro);
            usuarios.Lista.ForEach(x => x.CPF = x.CPF.MaskCpfCpnj());
            return Json(usuarios);
        }

        public ActionResult BuscarUnidadesPorNomeOuSigla(string query)
        {
            var retorno = _usuarioAppService.BuscarUnidades(new UnidadeFiltroViewModel {NomeOuSigla = query});
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }
    }
}