using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupVision.ViewModel;
using DAL = GroupVision.Dal;

namespace GroupVision.Bll
{
    public class Certificado
    {
        public void CadastraCertificado(string celular, DateTime  data_emissao, DateTime  data_vencimento, int fkEmpresa, string tipo)
        {
            new DAL.Certificado().CadastraCertificado(celular, data_emissao, data_vencimento, fkEmpresa, tipo);
        }

        public List<SelecionaTodosCertificados> SelecionaTodosCertificados()
        {
            List<SelecionaTodosCertificados> rCertificados = new List<GroupVision.ViewModel.SelecionaTodosCertificados>();

            var mCertificados = new DAL.Certificado().SelecionaTodosCertificados();
            var ven = "";

            foreach (var item in mCertificados)
            {
               

                if (DateTime.Now > item.DATA_VENCIMENTO)
                {
                    ven = "Sim";
                }
                else
                {
                    ven = "Não";
                }
                rCertificados.Add(new SelecionaTodosCertificados
                {
                    celular = item.CELULAR,
                    data_emissao = item.DATA_EMISSAO.ToShortDateString(),
                    data_vencimento = item.DATA_VENCIMENTO.ToShortDateString(),
                    empresa = new Bll.Empresa().SelecionaTodasEmpresas().First().nome,
                    fkEmpresa = item.FK_EMPRESA,
                    fkUsuario = item.ID_USUARIO_ULT_ATT,
                    id = item.PK_ID_CERTIFICADO,
                    tipo = item.TIPO,
                    vencido= ven
                });
            }


            return rCertificados;
        }

        public void AtualizaCertificado(string celular, string data_emissao, string data_vencimento, int fkEmpresa, int id, string tipo)
        {
            new Dal.Certificado().AtualizaCertificado(celular, data_emissao, data_vencimento, fkEmpresa, id, tipo);
        }

        public void DesativaCertificado(int id)
        {
            new Dal.Certificado().DesativaCertificado(id);
        }

        public List<int> RetornaDadosDash()
        {
            return new Dal.Certificado().RetornaDadosDash();
        }


        public int SelecionaTodosCertificadosVencidos()
        {
            List<SelecionaTodosCertificados> rCertificados = new List<GroupVision.ViewModel.SelecionaTodosCertificados>();

            var mCertificados = new DAL.Certificado().SelecionaTodosCertificados();

            foreach (var item in mCertificados)
            {
                if (DateTime.Now > item.DATA_VENCIMENTO)
                {
                    rCertificados.Add(new SelecionaTodosCertificados
                    {
                        celular = item.CELULAR,
                        data_emissao = item.DATA_EMISSAO.ToShortDateString(),
                        data_vencimento = item.DATA_VENCIMENTO.ToShortDateString(),
                        empresa = new Bll.Empresa().SelecionaTodasEmpresas().First().nome,
                        fkEmpresa = item.FK_EMPRESA,
                        fkUsuario = item.ID_USUARIO_ULT_ATT,
                        id = item.PK_ID_CERTIFICADO,
                        tipo = item.TIPO
                    });
                }
               
            }


            return rCertificados.Count;
        }
    }
}
