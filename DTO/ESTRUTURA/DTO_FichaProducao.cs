using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.UTIL;

namespace Sistema.DTO
{
    public class DTO_FichaProducao
    {
        public int ID { get; set; }
        public int ID_Empresa { get; set; }
        public int ID_Venda { get; set; }

        /// <summary>
        /// <para>1 - AGUARDANDO PAGAMENTO</para>
        /// <para>2 - EM PRODUÇÃO</para>
        /// <para>1 - CONCLUÍDO</para>
        /// </summary>
        public int Situacao { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }

        private string transportadora;
        public string Transportadora
        {
            get
            {
                if (transportadora == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(transportadora);
            }

            set { transportadora = value; }
        }

        public int ID_Item_Venda { get; set; }

        private string anomodelo;
        public string AnoModelo
        {
            get
            {
                if (anomodelo == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(anomodelo);
            }

            set { anomodelo = value; }
        }

        private string corcouro;
        public string CorCouro
        {
            get
            {
                if (corcouro == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(corcouro);
            }

            set { corcouro = value; }
        }

        private string costura;
        public string Costura
        {
            get
            {
                if (costura == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(costura);
            }

            set { costura = value; }
        }

        /// <summary>
        /// <para>1 - SEM LOGO</para>
        /// <para>2 - BORDADA</para>
        /// <para>1 - CARIMBADA</para>
        /// </summary>
        public int Logomarca { get; set; }
        public int Laterais_Porta { get; set; }
        public int ApoioCabeca { get; set; }

        private string tipoacento;
        public string TipoAcento
        {
            get
            {
                if (tipoacento == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(tipoacento);
            }

            set { tipoacento = value; }
        }

        private string tipoencosto;
        public string TipoEncosto
        {
            get
            {
                if (tipoencosto == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(tipoencosto);
            }

            set { tipoencosto = value; }
        }

        private string abd;
        public string ABD
        {
            get
            {
                if (abd == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(abd);
            }

            set { abd = value; }
        }

        private string abt;
        public string ABT
        {
            get
            {
                if (abt == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(abt);
            }

            set { abt = value; }
        }

        private string observacao;
        public string Observacao
        {
            get
            {
                if (observacao == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(observacao);
            }

            set { observacao = value; }
        }

        #region CONSULTA
        public int ID_Pessoa { get; set; }

        private string descricaopessoa;
        public string DescricaoPessoa
        {
            get
            {
                if (descricaopessoa == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(descricaopessoa);
            }

            set { descricaopessoa = value; }
        }

        private DTO_Data consulta_entrada;
        public DTO_Data Consulta_Entrada
        {
            get
            {
                if (consulta_entrada == null)
                {
                    consulta_entrada = new DTO_Data();
                    return consulta_entrada;
                }
                else
                    return consulta_entrada;
            }
            set
            {
                consulta_entrada = new DTO_Data();
                consulta_entrada = value;
            }
        }


        private DTO_Data consulta_saida;
        public DTO_Data Consulta_Saida
        {
            get
            {
                if (consulta_saida == null)
                {
                    consulta_saida = new DTO_Data();
                    return consulta_saida;
                }
                else
                    return consulta_saida;
            }
            set
            {
                consulta_saida = new DTO_Data();
                consulta_saida = value;
            }
        }
        #endregion
    }
}
