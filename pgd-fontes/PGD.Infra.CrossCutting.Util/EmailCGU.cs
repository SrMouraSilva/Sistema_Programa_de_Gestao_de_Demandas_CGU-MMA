using CGU.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGD.Infra.CrossCutting.Util
{
    public class EmailCGU
    {
        public void EnviarEmail(String mensagemHTML, String assunto, String destinatario)
        {

            MailManagerComum mailManager = new MailManagerComum();
            

            String ambiente = System.Configuration.ConfigurationManager.AppSettings["Ambiente"].ToString();
            bool gravarEmailEmArquivo = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["GravarEmailEmArquivo"].ToString());

            mailManager.EnviarEmail(assunto, mensagemHTML, true, destinatario, gravarEmArquivo: gravarEmailEmArquivo);            
        }


    }
}
