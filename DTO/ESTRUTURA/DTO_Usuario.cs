using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.UTIL;

namespace Sistema.DTO
{
    public class DTO_Usuario
    {
        public int ID { get; set; }
        public bool Situacao { get; set; }
        public bool MultiEmpresa { get; set; }
        public int ID_Empresa { get; set; }

        public bool Cadastrado { get; set; }
        public int TipoPessoa { get; set; }
        public int ID_Pessoa { get; set; }

        private string descricao { get; set; }
        public string Descricao
        {
            get
            {
                if (descricao == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(descricao);
            }

            set { descricao = value; }
        }

        public bool UsuarioSistema { get; set; }

        public string id_log_conecxão { get; set; }

        private string senhasistema { get; set; }
        public string SenhaSistema
        {
            get
            {
                if (senhasistema == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(senhasistema);
            }

            set { senhasistema = value; }
        }

        public bool UsuarioMobile { get; set; }

        private string senhamobile { get; set; }
        public string SenhaMobile
        {
            get
            {
                if (senhamobile == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(senhamobile);
            }

            set { senhamobile = value; }
        }       

        public int ID_Produto { get; set; }

        public List<DTO_Comissao> lst_Comissao { get; set; }

        #region CONSULTA
        public bool Filtra_Situacao { get; set; }
        public bool Filtra_Comissao { get; set; }
        public bool Comissao { get; set; }

        /// <summary>
        /// <para>1 - Libera Desconto</para>
        /// <para>2 - Exibe Resumo</para>
        /// </summary>
        public int TipoConsulta { get; set; }
        #endregion
    }

    public class DTO_Comissao
    {
        public int ID { get; set; }
        public int ID_Usuario { get; set; }
        public int ID_Produto { get; set; }
        public int ID_TipoComissao { get; set; }
        public double Comissao { get; set; }
        public string DescricaoUsuario { get; set; }
        public string DescricaoComissao { get; set; }
    }
}
