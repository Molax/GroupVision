using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupVisao.Web.Models
{
    public class CadastroCertificado
    {
        public string tipo { get; set; }

        public DateTime data_emissao { get; set; }

        public DateTime data_vencimento { get; set; }

        public string celular { get; set; }

        public int fkEmpresa { get; set; }

        public int fkUsuario { get; set; }
    }
}