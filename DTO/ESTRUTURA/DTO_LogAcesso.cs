using System;

namespace Sistema.DTO
{
    public class DTO_LogAcesso
    {
        public int ID { get; set; }
        public string NomeEmpresa { get; set; }
        public string NomeUsuario { get; set; }
        public string DataConexao { get; set; }
        public string Terminal { get; set; }
        public string VersaoSistema { get; set; }
        public string VersaoBanco { get; set; }
        public string ChaveBanco { get; set; }
    }
}