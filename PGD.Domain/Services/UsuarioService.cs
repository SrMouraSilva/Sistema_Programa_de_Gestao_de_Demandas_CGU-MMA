using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGD.Domain.Entities;
using PGD.Domain.Interfaces.Service;
using PGD.Domain.Interfaces.Repository;
using PGD.Domain.Constantes;
using PGD.Domain.Validations.Usuarios;
using PGD.Domain.Entities.Usuario;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;

namespace PGD.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AdministradorService _administradorService;

        public UsuarioService(AdministradorService classRepository)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            _administradorService = classRepository;
        }
        public IEnumerable<Usuario> ObterTodosAdministradores()
        {
            var listaUser = new List<Usuario>();
            var listaAm = _administradorService.ObterTodosAdm();
            foreach (var item in listaAm)
            {
                var user = new Usuario();
                var cpf_user = item.CPF;
                if (item.CPF.Length < 11)
                    cpf_user = item.CPF.PadLeft(11, '0');
                user = ObterPorCPF(cpf_user);
                listaUser.Add(user);
            }
            return listaUser;
        }
        public Usuario ObterPorNome(string nome)
        {
            var user = new Usuario();

            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["SIGRHAPI"].ToString()))
                return null;
            var api = ConfigurationManager.AppSettings["SIGRHAPI"].ToString();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(api);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
                client.Timeout = new TimeSpan(1, 0, 0);
                var retorno = client.GetAsync(string.Format("api/usuarios/pornome/{0}", nome)).Result;

                if (retorno.IsSuccessStatusCode)
                {
                    user = JsonConvert.DeserializeObject<Usuario>(retorno.Content.ReadAsStringAsync().Result);

                }
            }
            return user;
        }

        public Usuario ObterPorCPF(string cpf)
        {
            var user = new Usuario();
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["SIGRHAPI"].ToString()))
                return null;
            var api = ConfigurationManager.AppSettings["SIGRHAPI"].ToString();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(api);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));//"application/json"
                client.Timeout = new TimeSpan(1, 0, 0);
                var retorno = client.GetAsync(string.Format("api/usuarios/porcpf/{0}", cpf)).Result;

                if (retorno.IsSuccessStatusCode)
                {
                    user = JsonConvert.DeserializeObject<Usuario>(retorno.Content.ReadAsStringAsync().Result);

                }
            }
            return user;
        }

        public IEnumerable<Usuario> ObterTodosPorUnidade(int IdUnidade, bool incluirSubordinados = false)
        {

            var lista = new List<Usuario>();

            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["SIGRHAPI"].ToString()))
                return null;
            var api = ConfigurationManager.AppSettings["SIGRHAPI"].ToString();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(api);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));//"application/json"
                client.Timeout = new TimeSpan(1, 0, 0);
                var retorno = client.GetAsync($"api/usuarios/porUnidade/{IdUnidade.ToString()}?incluirSubordinados={incluirSubordinados}").Result;

                lista = JsonConvert.DeserializeObject<List<Usuario>>(retorno.Content.ReadAsStringAsync().Result);
            }


            return lista;

        }
        public IEnumerable<Usuario> ObterTodosDaBase()
        {
            var lista = new List<Usuario>();
            try
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["SIGRHAPI"].ToString()))
                    return null;
                var api = ConfigurationManager.AppSettings["SIGRHAPI"].ToString();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(api);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));//"application/json"
                    client.Timeout = new TimeSpan(1, 0, 0);
                    var retorno = client.GetAsync(string.Format("api/usuarios")).Result;

                    lista = JsonConvert.DeserializeObject<List<Usuario>>(retorno.Content.ReadAsStringAsync().Result);
                }
            }
            catch 
            {
                throw;
            }

            return lista;

        }


        public Usuario ObterPorEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
