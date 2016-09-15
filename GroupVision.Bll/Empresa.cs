using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupVision.ViewModel;
using GroupVision.Data;

namespace GroupVision.Bll
{
    public class Empresa
    {
        public int CadastraEmpresa(string apelido, string cnpj, string celular, string cep, string cidade, string complemento, string email_certificado,
            string email_cliente, string email_escritorio, string estado, string logradouro, string nome, string responsavel, string telefone, int id, string bairro)
        {
            int idEmpresa = new Dal.Empresa().CadastraEmpresa(nome, cnpj, apelido, celular, telefone, email_cliente, email_escritorio, email_certificado, responsavel, id);

            new Dal.Empresa().CadastraEndereco(logradouro, bairro, cidade, estado, cep, complemento, idEmpresa);


            return id;
        }

        public List<SelecionaTodasEmpresas> SelecionaTodasEmpresas()
        {
            List<SelecionaTodasEmpresas> rEmpresas = new List<ViewModel.SelecionaTodasEmpresas>();

            List<Data.Empresa> mEmpresa = new Dal.Empresa().SelecionaTodasEmpresas();

            foreach (var item in mEmpresa)
            {
                Data.Endereco mEnderecco = new Dal.Empresa().RetornaEnderecoEmpresa(item.PK_ID_EMPRESA);

                rEmpresas.Add(new SelecionaTodasEmpresas
                {
                    apelido = item.APELIDO,
                    bairro = mEnderecco.BAIRRO,
                    celular = item.CELULAR,
                    cep = mEnderecco.CEP,
                    cidade = mEnderecco.CIDADE,
                    cnpj = item.CNPJ,
                    complemento = mEnderecco.COMPLEMENTO,
                    email_certificado = item.EMAIL_CERTIFICADO,
                    email_cliente = item.EMAIL_CLIENTE,
                    email_escritorio = item.EMAIL_ESCRITORIO,
                    estado = mEnderecco.ESTADO,
                    id = item.PK_ID_EMPRESA,
                    logradouro = mEnderecco.LOGRADOURO,
                    responsavel = item.RESPONSAVEL,
                    nome = item.NOME,
                    telefone = item.TELEFNE
                });
            }

            return rEmpresas;
        }

        public List<PopulaDropDownEmpresa> PopulaDropDownEmpresa()
        {
            List<PopulaDropDownEmpresa> rEmpresa = new List<ViewModel.PopulaDropDownEmpresa>();

            List<Data.Empresa> mEmpresa = new Dal.Empresa().SelecionaTodasEmpresas();

            foreach (var item in mEmpresa)
            {
                rEmpresa.Add(new PopulaDropDownEmpresa {
                   id = item.PK_ID_EMPRESA,
                   nome = item.NOME
                });
            }

            return rEmpresa;
        }

        public void DesativaEmpresa(int id)
        {
            new Dal.Empresa().DesativaEmpresa(id);
        }

        public void AtualizaEpresa(string apelido, string cnpj, string celular, string cep, string cidade, string complemento, string email_certificado, string email_cliente, string email_escritorio, string estado, string logradouro, string nome, string responsavel, string telefone, int idUsuario, string bairro, int id)
        {
            new Dal.Empresa().AtualizaEpresa(nome, cnpj, apelido, celular, telefone, email_cliente, email_escritorio, email_certificado, responsavel, id);

            new Dal.Empresa().AtualizaEndereco(estado, cep, complemento, logradouro, bairro, cidade, id);
        }
    }
}
