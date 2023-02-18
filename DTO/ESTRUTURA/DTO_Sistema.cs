using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.DTO
{
    public class DTO_Sistema
    {
        public int ID { get; set; }
        public int VersaoSistema { get; set; }
        public int VersaoBanco { get; set; }
        public int VersaoAtualBanco { get; set; }

        /// <summary>
        /// <para>1 - EXECUTA COMANDO / CONSULTA COMANDO</para>
        /// <para>2 - EXECUTA COMANDO RESPOSTA / RETORNA TABELAS</para>
        /// </summary>
        public int TipoComando { get; set; }
        public string ComandoSQL { get; set; }
    }

    public class DTO_Log
    {
        public int ID { get; set; }
        public int ID_Usuario { get; set; }
        public int ID_Empresa { get; set; }
        public DateTime Data { get; set; }
        public string Terminal { get; set; }
    }


}
