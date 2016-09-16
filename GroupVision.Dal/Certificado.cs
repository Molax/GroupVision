using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupVision.Data;
namespace GroupVision.Dal
{
    public class Certificado
    {
        public void CadastraCertificado(string celular, DateTime data_emissao, DateTime data_vencimento, int fkEmpresa, string tipo)
        {
            using (var db = new GroupVisionDataContext())
            {
                var verifica = db.Certificados.Where(c => c.CELULAR == celular && c.DATA_EMISSAO == data_emissao && c.FK_EMPRESA == fkEmpresa && c.TIPO == tipo).ToList();
                if (verifica.Count > 0)
                {
                    verifica.First().ATIVO = true;
                    db.SubmitChanges();
                }
                else
                {
                    var certificado = new Data.Certificado
                    {
                        ATIVO = true,
                        CELULAR = celular,
                        DATA_EMISSAO = Convert.ToDateTime(data_emissao),
                        DATA_ULT_ATT = DateTime.Now,
                        DATA_VENCIMENTO = Convert.ToDateTime(data_vencimento),
                        FK_EMPRESA = fkEmpresa,
                        ID_USUARIO_ULT_ATT = 1,
                        TIPO = tipo
                    };

                    db.Certificados.InsertOnSubmit(certificado);
                    db.SubmitChanges();
                }
            }
        }

        public List<Data.Certificado> SelecionaTodosCertificados()
        {
            using (var db = new GroupVisionDataContext())
            {
                var certificados = db.Certificados.Where(c => c.ATIVO == true).ToList();
                return certificados;
            }
        }

        public void AtualizaCertificado(string celular, string data_emissao, string data_vencimento, int fkEmpresa, int id, string tipo)
        {
            using (var db = new GroupVisionDataContext())
            {
                var certificado = db.Certificados.Where(c => c.PK_ID_CERTIFICADO == id).ToList();

                certificado.First().TIPO = tipo;
                certificado.First().FK_EMPRESA = fkEmpresa;
                certificado.First().DATA_VENCIMENTO = Convert.ToDateTime(data_vencimento);
                certificado.First().DATA_EMISSAO = Convert.ToDateTime(data_emissao);
                certificado.First().CELULAR = celular;

                db.SubmitChanges();
            }
        }

        public void DesativaCertificado(int id)
        {
            using (var db = new GroupVisionDataContext())
            {
                var certificado = db.Certificados.Where(c => c.PK_ID_CERTIFICADO == id).ToList();

                certificado.First().ATIVO = false;

                db.SubmitChanges();
            }
        }


    }
}
