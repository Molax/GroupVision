using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupVision.ViewModel
{
    public class SelecionaTodosCertificados
    {
        public int id { get; set; }

        public string tipo { get; set; }

        public string data_emissao { get; set; }

        public string data_vencimento { get; set; }

        public string celular { get; set; }

        public int fkEmpresa { get; set; }

        public int fkUsuario { get; set; }

        public string empresa { get; set; }

        public string vencido { get; set; }
    }
}