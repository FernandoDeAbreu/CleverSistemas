using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.UTIL;

namespace Sistema.DTO
{
    public class DTO_CFe_SAT
    {
        public CFe_SAT_Funcao Funcao { get; set; }
        public int NumeroSessao { get; set; }
        public string Cod_Ativacao { get; set; }
        public string CNPJ { get; set; }
        public int ID_UF { get; set; }
        public string XML { get; set; }
        public string Chave { get; set; }
        public string Assinatura { get; set; }
        public string Cod_Ativacao_New { get; set; }
        public int Tipo_Opcao { get; set; }
    }

    public class DTO_CFe_SAT_Retorno
    {
        public bool Status { get; set; }
        public int NumeroSessao { get; set; }
        public int ID_CFe { get; set; }
        public string Cod_Retorno { get; set; }
        public string Cod_Erro { get; set; }
        public string Mensagem { get; set; }
        public string Cod_msg_SEFAZ { get; set; }
        public string Mensagem_SEFAZ { get; set; }
        public string XML_CFe { get; set; }
        public DateTime Data_HoraEmissao { get; set; }
        public string Chave { get; set; }
        public string AssinaturaQR { get; set; }
        public string StatusOperacional { get; set; }
        public string Logs { get; set; }
    }
}
