﻿using System;
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
            try
            {
                new Bll.Certificado().CadastraCertificado(cert.celular, cert.data_emissao, cert.data_vencimento, cert.fkEmpresa, cert.tipo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public List<VM.SelecionaTodosCertificados> SelecionaTodosCertificados()
        {
            return new Bll.Certificado().SelecionaTodosCertificados();
        }

        [HttpDelete]
        public void DesativaCertificado(int id)
        {
            try
            {
                new Bll.Certificado().DesativaCertificado(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public void AtualizaCertificado(VM.SelecionaTodosCertificados certificaco)
        {
            try
            {
                new Bll.Certificado().AtualizaCertificado(certificaco.celular, certificaco.data_emissao, certificaco.data_vencimento, certificaco.fkEmpresa, certificaco.id, certificaco.tipo);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
