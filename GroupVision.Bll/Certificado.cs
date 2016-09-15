﻿using System;
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
        public void CadastraCertificado(string celular, DateTime data_emissao, DateTime data_vencimento, int fkEmpresa, string tipo)
        {
            new DAL.Certificado().CadastraCertificado(celular, data_emissao, data_vencimento, fkEmpresa, tipo);
        }

        public List<SelecionaTodosCertificados> SelecionaTodosCertificados()
        {
            List<SelecionaTodosCertificados> rCertificados = new List<GroupVision.ViewModel.SelecionaTodosCertificados>();

            var mCertificados = new DAL.Certificado().SelecionaTodosCertificados();

            foreach (var item in mCertificados)
            {
                rCertificados.Add(new SelecionaTodosCertificados
                {
                    celular = item.CELULAR,
                    data_emissao = item.DATA_EMISSAO,
                    data_vencimento = item.DATA_VENCIMENTO,
                    empresa = new Bll.Empresa().SelecionaTodasEmpresas().First().nome,
                    fkEmpresa = item.FK_EMPRESA,
                    fkUsuario = item.ID_USUARIO_ULT_ATT,
                    id = item.PK_ID_CERTIFICADO,
                    tipo = item.TIPO
                });
            }

            return rCertificados;
        }

        public void AtualizaCertificado(string celular, DateTime data_emissao, DateTime data_vencimento, int fkEmpresa, int id, string tipo)
        {
            new Dal.Certificado().AtualizaCertificado(celular, data_emissao, data_vencimento, fkEmpresa, id, tipo);
        }

        public void DesativaCertificado(int id)
        {
            new Dal.Certificado().DesativaCertificado(id);
        }
    }
}
