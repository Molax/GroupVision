using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bll = GroupVision.Bll;
using VM = GroupVision.ViewModel;

namespace GroupVisao.Web.Controllers
{
    public class API_CertificadoController : ApiController
    {
        [HttpPost]
        public void CadastraCertificado(Models.CadastroCertificado cert)
        {
            new Bll.Certificado().CadastraCertificado(cert.celular,cert.data_emissao,cert.data_vencimento,cert.fkEmpresa,cert.tipo);
        }

        [HttpGet]
        public List<VM.SelecionaTodosCertificados> SelecionaTodosCertificados()
        {
            return new Bll.Certificado().SelecionaTodosCertificados();
        }

        [HttpDelete]
        public void DesativaCertificado(int id)
        {
            new Bll.Certificado().DesativaCertificado(id);
        }

        [HttpPut]
        public void AtualizaCertificado(VM.SelecionaTodosCertificados certificaco)
        {
            new Bll.Certificado().AtualizaCertificado(certificaco.celular, certificaco.data_emissao, certificaco.data_vencimento, certificaco.fkEmpresa, certificaco.id, certificaco.tipo);
        }
    }
}
