using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupVisao.Web.Models
{
    public class CadastraEndereco
    {
        public int id { get; set; }

        public string logradouro { get; set; }

        public string cidade { get; set; }

        public string estado { get; set; }

        public string cep { get; set; }

        public string complemento { get; set; }

        public int idEmpresa { get; set; }
    }
}