using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GroupVision.ViewModel;
using GroupVision.Bll;

namespace GroupVisao.Web.Controllers
{
    public class API_EmpresaController : ApiController
    {
        [HttpPost]
        public int CadastraEmpresa(Models.CadastroEmpresa empresa)
        {
            return new Empresa().CadastraEmpresa(empresa.apelido, empresa.cnpj, empresa.celular, empresa.cep, empresa.cidade,
                                                                empresa.complemento, empresa.email_certificado,
                                                                empresa.email_cliente, empresa.email_escritorio, empresa.estado, empresa.logradouro,
                                                                empresa.nome, empresa.responsavel, empresa.telefone, empresa.idUsuario, empresa.bairro);
        }

        [HttpGet]
        public List<SelecionaTodasEmpresas> SelecionaTodasEmpresas()
        {
            return new Empresa().SelecionaTodasEmpresas();
        }

        [HttpPut]
        public void AtualizaEpresa(Models.AtualizaEmpersa empresa)
        {
            new Empresa().AtualizaEpresa(empresa.apelido, empresa.cnpj, empresa.celular, empresa.cep, empresa.cidade,
                                                                empresa.complemento, empresa.email_certificado,
                                                                empresa.email_cliente, empresa.email_escritorio, empresa.estado, empresa.logradouro,
                                                                empresa.nome, empresa.responsavel, empresa.telefone, empresa.idUsuario, empresa.bairro, empresa.id);
        }

        [HttpGet]
        public List<PopulaDropDownEmpresa> PopulaDropDownEmpresa()
        {
            return new Empresa().PopulaDropDownEmpresa();
        }

        [HttpDelete]
        public void DesativaEmpresa(int id)
        {
            new Empresa().DesativaEmpresa(id);
        }
    }
}
