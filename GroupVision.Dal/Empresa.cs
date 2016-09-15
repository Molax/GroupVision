using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupVision.Data;

namespace GroupVision.Dal
{
    public class Empresa
    {
        public int CadastraEmpresa(string nome, string cnpj, string apelido, string celular, string telefone, string email_cliente, string email_escritorio, string email_certificado, string responsavel, int id)
        {
            using (var db = new GroupVisionDataContext())
            {
                var verifica = db.Empresas.Where(e => e.CNPJ == cnpj).ToList();

                if (verifica.Count > 0)
                {
                    verifica.First().ATIVO = true;
                    return verifica.First().ID_USUARIO_ULT_ATT;
                }
                else

                {
                    var empresa = new Data.Empresa
                    {
                        APELIDO = apelido,
                        ATIVO = true,
                        CELULAR = celular,
                        DATA_ULTIMA_ATT = DateTime.Now,
                        EMAIL_CERTIFICADO = email_certificado,
                        EMAIL_CLIENTE = email_cliente,
                        EMAIL_ESCRITORIO = email_escritorio,
                        ID_USUARIO_ULT_ATT = id,
                        NOME = nome,
                        TELEFNE = telefone,
                        RESPONSAVEL = responsavel,
                        CNPJ = cnpj
                    };

                    db.Empresas.InsertOnSubmit(empresa);

                    db.SubmitChanges();

                    return empresa.PK_ID_EMPRESA;
                }

            }
        }

        public Endereco RetornaEnderecoEmpresa(int pK_ID_EMPRESA)
        {
            using (var db = new GroupVisionDataContext())
            {
                var mEndereco = db.Enderecos.Where(e => e.FK_EMPRESA == pK_ID_EMPRESA).ToList();

                return mEndereco.First();
            }
        }

        public List<Data.Empresa> SelecionaTodasEmpresas()
        {
            using (var db = new GroupVisionDataContext())
            {
                var empresas = db.Empresas.Where(e => e.ATIVO == true).ToList();

                return empresas;
            }
        }

        public void CadastraEndereco(string logradouro, string bairro, string cidade, string estado, string cep, string complemento, int idEmpresa)
        {
            using (var db = new GroupVisionDataContext())
            {
                var endereco = new Data.Endereco
                {
                    BAIRRO = bairro,
                    CIDADE = cidade,
                    ESTADO = estado,
                    FK_EMPRESA = idEmpresa,
                    LOGRADOURO = logradouro,
                    CEP = cep,
                    COMPLEMENTO = complemento
                };

                db.Enderecos.InsertOnSubmit(endereco);

                db.SubmitChanges();
            }
        }

        public void AtualizaEndereco(string estado, string cep, string complemento, string logradouro, string bairro, string cidade, int id)
        {
            using (var db = new GroupVisionDataContext())
            {
                try
                {
                    var mEnd = db.Enderecos.Where(e => e.FK_EMPRESA == id).ToList();

                    mEnd.First().CEP = cep;
                    mEnd.First().BAIRRO = bairro;
                    mEnd.First().CIDADE = cidade;
                    mEnd.First().COMPLEMENTO = complemento;
                    mEnd.First().ESTADO = estado;
                    mEnd.First().LOGRADOURO = logradouro;

                    db.SubmitChanges();
                }
                catch (Exception ex)
                {

                    string exp = ex.Message.ToString();
                }

            }
        }

        public void DesativaEmpresa(int id)
        {
            using (var db = new GroupVisionDataContext())
            {
                try
                {
                    var mEmpresa = db.Empresas.Where(e => e.PK_ID_EMPRESA == id).ToList();

                    mEmpresa.First().ATIVO = false;

                    db.SubmitChanges();
                }
                catch (Exception ex)
                {

                    string exp = ex.Message.ToString();
                }

            }
        }

        public void AtualizaEpresa(string nome, string cnpj, string apelido, string celular, string telefone, string email_cliente, string email_escritorio, string email_certificado, string responsavel, int id)
        {
            using (var db = new GroupVisionDataContext())
            {
                try
                {
                    var mEmpresa = db.Empresas.Where(e => e.PK_ID_EMPRESA == id).ToList();

                    mEmpresa.First().NOME = nome;
                    mEmpresa.First().ID_USUARIO_ULT_ATT = 1;
                    mEmpresa.First().APELIDO = apelido;
                    mEmpresa.First().ATIVO = true;
                    mEmpresa.First().CELULAR = celular;
                    mEmpresa.First().CNPJ = cnpj;
                    mEmpresa.First().DATA_ULTIMA_ATT = DateTime.Now;
                    mEmpresa.First().EMAIL_CERTIFICADO = email_certificado;
                    mEmpresa.First().EMAIL_CLIENTE = email_cliente;
                    mEmpresa.First().EMAIL_ESCRITORIO = email_escritorio;
                    mEmpresa.First().RESPONSAVEL = responsavel;
                    mEmpresa.First().TELEFNE = telefone;

                    db.SubmitChanges();
                }
                catch (Exception ex)
                {

                    string exx = ex.Message.ToString();
                }

            }
        }
    }
}
