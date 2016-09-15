using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupVision.ViewModel
{
    public class SelecionaTodasEmpresas
    {
        #region Empresa
        public int id { get; set; }

        public string cnpj { get; set; }

        public string nome { get; set; }

        public string apelido { get; set; }

        public string celular { get; set; }

        public string telefone { get; set; }

        public string email_cliente { get; set; }

        public string email_escritorio { get; set; }

        public string email_certificado { get; set; }

        public string responsavel { get; set; }

        public int idUsuario { get; set; }
        #endregion

        #region endereço
        public string logradouro { get; set; }

        public string bairro { get; set; }

        public string cidade { get; set; }

        public string estado { get; set; }

        public string cep { get; set; }

        public string complemento { get; set; }
        #endregion
    }
}
