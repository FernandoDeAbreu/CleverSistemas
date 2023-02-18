using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.UTIL;

namespace Sistema.DTO
{
    public class DTO_Cartao
    {
        public int ID { get; set; }
        public int ID_Empresa { get; set; }
        public int ID_Pagamento { get; set; }
        public DateTime Emissao { get; set; }
        public DateTime Vencimento { get; set; }
        public double Valor { get; set; }
        public int QuantidadeParcela { get; set; }
        public int Parcela { get; set; }

        public double Aliquota { get; set; }

        public bool Baixado { get; set; }
        public DateTime Data_Baixa { get; set; }

        public int ID_CReceber { get; set; }
        public List<DTO_CReceber> lst_CReceber { get; set; }

        public double Valor_Previsao { get; set; }

        #region CONSULTA
        private DTO_Data consulta_vencimento { get; set; }
        private DTO_Data consulta_emissao { get; set; }
        private DTO_Data consulta_baixa { get; set; }

        public DTO_Data Consulta_Vencimento
        {
            get
            {
                if (consulta_vencimento == null)
                {
                    consulta_vencimento = new DTO_Data();
                    return consulta_vencimento;
                }
                else
                    return consulta_vencimento;
            }
            set
            {
                consulta_vencimento = new DTO_Data();
                consulta_vencimento = value;
            }
        }

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

        public DTO_Data Consulta_Baixa
        {
            get
            {
                if (consulta_baixa == null)
                {
                    consulta_baixa = new DTO_Data();
                    return consulta_baixa;
                }
                else
                    return consulta_baixa;
            }
            set
            {
                consulta_emissao = new DTO_Data();
                consulta_emissao = value;
            }
        }

        public bool Filtra_Baixado { get; set; }
        #endregion
    }
}
