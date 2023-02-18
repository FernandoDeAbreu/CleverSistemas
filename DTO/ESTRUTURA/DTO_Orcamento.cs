using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.UTIL;

namespace Sistema.DTO
{
    public class DTO_Orcamento
    {
        public int ID { get; set; }
        public int ID_Empresa { get; set; }
        public int TipoPessoa { get; set; }
        public int ID_Pessoa { get; set; }
        public DateTime Data { get; set; }
        public DateTime Entrega { get; set; }

        private string informacao { get; set; }
        public string Informacao
        {
            get
            {
                if (informacao == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(informacao);
            }

            set { informacao = value; }
        }

        public int ID_UsuarioComissao1 { get; set; }

        public int ID_Pagamento { get; set; }
        public int Situacao { get; set; }

        public List<DTO_Produto_Item> Item { get; set; }

        #region CONSULTA
        private DTO_Data consulta_emissao { get; set; }
        public DTO_Data Consulta_Emissao
        {
            get
            {
                if (consulta_emissao == null)
                {
                    consulta_emissao = new DTO_Data();
                    return consulta_emissao;
                }
                else
                    return consulta_emissao;
            }
            set
            {
                consulta_emissao = new DTO_Data();
                consulta_emissao = value;
            }
        }
        #endregion
    }
}
