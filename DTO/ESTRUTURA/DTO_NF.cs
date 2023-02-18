using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.UTIL;

namespace Sistema.DTO
{
    public class DTO_NF
    {
        public int ID { get; set; }
        public int ID_Empresa { get; set; }
        public int Serie { get; set; }
        public int Modelo { get; set; }
        public bool FiltraEmpresa { get; set; }
        public int ID_NFe { get; set; }
        public int ID_Venda { get; set; }
        public int ID_OS { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime DataContigencia { get; set; }
        public int TipoDocumento { get; set; }
        public int FinalidadeEmissao { get; set; }
        public int FormaEmissao { get; set; }
        public int FormaPagto { get; set; }
        public int TipoImpressao { get; set; }
        public int TipoFrete { get; set; }

        /// <summary>
        /// <para>1 - ASSINADA</para>
        /// <para>2 - AUTORIZADA</para>
        /// <para>3 - CANCELADA</para>
        /// <para>4 - DENEGADA</para>
        /// <para>5 - EM DIGITAÇÃO</para>
        /// <para>6 - VALIDADA</para>
        /// <para>7 - EM PROCESSAMENTO</para>
        /// <para>8 - CF-e AUTORIZADO</para>
        /// <para>9 - INUTILIZADA</para>
        /// </summary>
        public int Situacao { get; set; }

        public string DescricaoSituacao { get; set; }
        public int TipoPessoa { get; set; }
        public int ID_Pessoa { get; set; }
        public int Dig_Verificador { get; set; }
        public int IE_Substituicao { get; set; }
        public int DestinoOperacao { get; set; }

        /// <summary>
        /// <para>0 - NÃO CONSUMIDOR FINAL</para>
        /// <para>1 - CONSUMIDOR FINAL</para>
        /// </summary>
        public int ConsumidorFinal { get; set; }

        private string cnpj_cpf_destinatario { get; set; }
        public string CNPJ_CPF_Destinatario
        {
            get
            {
                if (cnpj_cpf_destinatario == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(cnpj_cpf_destinatario);
            }

            set { cnpj_cpf_destinatario = value; }
        }

        public int PresencaConsumidor { get; set; }

        /// <summary>
        /// <para>0 - FINALIZADO</para>
        /// <para>1 - ERRO</para>
        /// <para>2 - ENVIO CFe</para>
        /// <para>3 - CANCELAMENTO CFe</para>
        /// <para>4 - PROCESSAMENTO</para>
        /// </summary>
        public int Status_CFe { get; set; }
        public string Retorno_CFe { get; set; }

        public double ValorBC { get; set; }
        public double ValorICMS { get; set; }
        public double ValorICMSDesonerado { get; set; }
        public double ValorBCST { get; set; }
        public double ValorST { get; set; }
        public double ValorProduto { get; set; }
        public double ValorFrete { get; set; }
        public double ValorSeguro { get; set; }
        public double ValorDesconto { get; set; }
        public double ValorImportacao { get; set; }
        public double ValorIPI { get; set; }
        public double ValorPIS { get; set; }
        public double ValorCOFINS { get; set; }
        public double ValorOutro { get; set; }
        public double ValorTotal { get; set; }

        public double Trib_Federal { get; set; }
        public double Trib_Estadual { get; set; }
        public double Trib_Municipal { get; set; }

        /// <summary>
        /// <para>1 - RETIRADA</para>
        /// <para>2 - ENTREGA</para>
        /// </summary>
        public int Tipo_Ent_Ret { get; set; }
        public int ID_NF_Volume { get; set; }
        public int ID_NF_Item { get; set; }
        public int ID_NF_Importacao { get; set; }

        private string naturezaoperacao { get; set; }
        public string NaturezaOperacao
        {
            get
            {
                if (naturezaoperacao == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(naturezaoperacao);
            }

            set { naturezaoperacao = value; }
        }

        private string chave { get; set; }
        public string Chave
        {
            get
            {
                if (chave == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(chave);
            }

            set { chave = value; }
        }

        public string QRCode { get; set; }

        public int Controle_CF { get; set; }

        private string justificativa { get; set; }
        public string Justificativa
        {
            get
            {
                if (justificativa == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(justificativa);
            }

            set { justificativa = value; }
        }

        private string informacaoadicional { get; set; }
        public string InformacaoAdicional
        {
            get
            {
                if (informacaoadicional == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(informacaoadicional);
            }

            set { informacaoadicional = value; }
        }

        private string informacaofisco { get; set; }
        public string InformacaoFisco
        {
            get
            {
                if (informacaofisco == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(informacaofisco);
            }

            set { informacaofisco = value; }
        }

        private string numeracaoinut { get; set; }
        public string NumeracaoInut
        {
            get
            {
                if (numeracaoinut == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(numeracaoinut);
            }

            set { numeracaoinut = value; }
        }

        private string motivo { get; set; }
        public string Motivo
        {
            get
            {
                if (motivo == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(motivo);
            }

            set { motivo = value; }
        }

        public int Stat { get; set; }

        public List<DTO_NF_Autorizacao_XML> Autorizacao_XML { get; set; }
        public List<DTO_NF_Itens> Itens { get; set; }
        public List<DTO_NF_Referenciada> Referenciada { get; set; }
        public List<DTO_NF_Ent_Ret> Ent_Ret { get; set; }
        public List<DTO_NF_Transporte> Transporte { get; set; }
        public List<DTO_NF_Volume> Volume { get; set; }
        public List<DTO_NF_Cobranca> Cobranca { get; set; }
        public List<DTO_NF_Duplicata> Duplicata { get; set; }

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

        public int Tipo_NF { get; set; }

        public int ID_Protocolo { get; set; }
        public string Protocolo { get; set; }
        public DateTime Data_Protocolo { get; set; }
        public string Evento_Protocolo { get; set; }
        public int Seq_Evento { get; set; }

        public bool FiltraEvento { get; set; }

        /// <summary>
        /// <para>1 - ENTREGA DE LOTE</para>
        /// <para>2 - AUTORIZAÇÃO DE USO</para>
        /// <para>3 - CANCELAMENTO</para>
        /// <para>4 - CARTA DE CORREÇÃO</para>
        /// </summary>
        public int Tipo_Evento { get; set; }
        #endregion
    }

    public class DTO_NF_Referenciada
    {
        public int ID { get; set; }
        public int ID_NFe { get; set; }

        /// <summary>
        /// <para>1 - NFe</para>
        /// <para>2 - NF-A1</para>
        /// <para>3 - NF-A1 Produtor</para>
        /// <para>4 - CTE</para>
        /// <para>5 - ECF</para>
        /// </summary>
        public int Tipo { get; set; }
        public DateTime DataEmissao { get; set; }
        public string Mod_CupomFiscal { get; set; }

        private string chave_nfe { get; set; }
        public string Chave_NFe
        {
            get
            {
                if (chave_nfe == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(chave_nfe);
            }

            set { chave_nfe = value; }
        }

        private string cnpj_cpf { get; set; }
        public string CNPJ_CPF
        {
            get
            {
                if (cnpj_cpf == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(cnpj_cpf);
            }

            set { cnpj_cpf = value; }
        }

        private string modelo { get; set; }
        public string Modelo
        {
            get
            {
                if (modelo == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(modelo);
            }

            set { modelo = value; }
        }

        private string serie { get; set; }
        public string Serie
        {
            get
            {
                if (serie == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(serie);
            }

            set { serie = value; }
        }

        private string numero_nf { get; set; }
        public string Numero_NF
        {
            get
            {
                if (numero_nf == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(numero_nf);
            }

            set { numero_nf = value; }
        }

        private string ie { get; set; }
        public string IE
        {
            get
            {
                if (ie == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(ie);
            }

            set { ie = value; }
        }

        private string cte { get; set; }
        public string CTE
        {
            get
            {
                if (cte == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(cte);
            }

            set { cte = value; }
        }

        private string ecf { get; set; }
        public string ECF
        {
            get
            {
                if (ecf == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(ecf);
            }

            set { ecf = value; }
        }

        private string uf { get; set; }
        public string UF
        {
            get
            {
                if (uf == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(uf);
            }

            set { uf = value; }
        }

        private string numero_contador { get; set; }
        public string Numero_Contador
        {
            get
            {
                if (numero_contador == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(numero_contador);
            }

            set { numero_contador = value; }
        }
    }

    public class DTO_NF_Ent_Ret
    {
        public int ID { get; set; }
        public int ID_NFe { get; set; }
        public int Tipo { get; set; }
        public int ID_UF { get; set; }
        public int ID_Municipio { get; set; }

        private string cnpj_cpf { get; set; }
        public string CNPJ_CPF
        {
            get
            {
                if (cnpj_cpf == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(cnpj_cpf);
            }

            set { cnpj_cpf = value; }
        }

        private string logradouro { get; set; }
        public string Logradouro
        {
            get
            {
                if (logradouro == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(logradouro);
            }

            set { logradouro = value; }
        }

        private string numero { get; set; }
        public string Numero
        {
            get
            {
                if (numero == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(numero);
            }

            set { numero = value; }
        }

        private string complemento { get; set; }
        public string Complemento
        {
            get
            {
                if (complemento == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(complemento);
            }

            set { complemento = value; }
        }

        private string bairro { get; set; }
        public string Bairro
        {
            get
            {
                if (bairro == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(bairro);
            }

            set { bairro = value; }
        }
    }

    public class DTO_NF_Importacao
    {
        public int ID { get; set; }
        public int ID_NFe { get; set; }
        public int UF { get; set; }
        public DateTime Data_Desen { get; set; }
        public DateTime Data_Registro { get; set; }

        private string documento { get; set; }
        public string Documento
        {
            get
            {
                if (documento == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(documento);
            }

            set { documento = value; }
        }

        private string local { get; set; }
        public string Local
        {
            get
            {
                if (local == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(local);
            }

            set { local = value; }
        }

        private string codigo { get; set; }
        public string Codigo
        {
            get
            {
                if (codigo == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(codigo);
            }

            set { codigo = value; }
        }

        public List<DTO_NF_Adicao> Adicao { get; set; }
    }

    public class DTO_NF_Adicao
    {
        public int ID { get; set; }
        public int Numero { get; set; }
        public int Seq { get; set; }

        private string codigo { get; set; }
        public string Codigo
        {
            get
            {
                if (codigo == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(codigo);
            }

            set { codigo = value; }
        }

        public double Desconto { get; set; }
    }

    public class DTO_NF_Itens
    {
        public int ID { get; set; }
        public int ID_NFe { get; set; }
        public int ID_Produto { get; set; }
        public int ID_Grade { get; set; }
        public int ID_Tabela { get; set; }
        public double Quantidade { get; set; }
        public double ValorUnitario { get; set; }
        public double ValorTotal { get; set; }
        public double Acrescimo { get; set; }
        public double Desconto { get; set; }
        public int TipoVendaProduto { get; set; }
        public double Frete { get; set; }
        public double Seguro { get; set; }

        public string NCM { get; set; }

        public string Descricao { get; set; }

        public string CFOP { get; set; }

        private string informacaoadicional { get; set; }
        public string InformacaoAdicional
        {
            get
            {
                if (informacaoadicional == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(informacaoadicional);
            }

            set { informacaoadicional = value; }
        }

        #region IPI
        public int Quantidade_Selo { get; set; }
        public string ClasseEnquadramento { get; set; }
        public string CNPJProdutor { get; set; }

        private string codigo_selo { get; set; }
        public string Codigo_Selo
        {
            get
            {
                if (codigo_selo == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(codigo_selo);
            }

            set { codigo_selo = value; }
        }

        private string ex_tipi { get; set; }
        public string EX_TIPI
        {
            get
            {
                if (ex_tipi == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(ex_tipi);
            }

            set { ex_tipi = value; }
        }

        public string CSTIPI { get; set; }
        public double AliquotaIPI { get; set; }
        public double ValorIPI { get; set; }

        public double IPIDevolvido { get; set; }
        public double Per_IPIDevolvido { get; set; }
        #endregion

        #region ICMS
        private string cst { get; set; }
        public string CST
        {
            get
            {
                if (cst == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(cst);
            }

            set { cst = value; }
        }

        public int Origem { get; set; }
        public int ModalidadeBC { get; set; }
        public int ModalidadeBCST { get; set; }

        public double AliquotaICMS { get; set; }
        public double AliquotaICMSST { get; set; }
        public double PercentualReducao { get; set; }
        public double PercentualReducaoST { get; set; }
        public double MargemVLAdicionado { get; set; }
        public double ValorICMS { get; set; }
        public double ValorICMSST { get; set; }
        public double ValorICMSSTRet { get; set; }
        public double ValorBC { get; set; }
        public double ValorBCST { get; set; }
        public double ValorBCSTRet { get; set; }
        public double ValorICMSOperacao { get; set; }
        public double PercentualDiferimento { get; set; }
        public double ValorICMSDeferido { get; set; }
        public double ValorICMSDesonerado { get; set; }
        public int MotivoDesonerado { get; set; }
        #endregion

        #region SIMPLES NACIONAL
        private string csosn { get; set; }
        public string CSOSN
        {
            get
            {
                if (csosn == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(csosn);
            }

            set { csosn = value; }
        }

        public double AliquotaCredito { get; set; }
        public double ValorCredito { get; set; }
        #endregion

        #region II
        public double ValorBCII { get; set; }
        public double ValorDesII { get; set; }
        public double ValorII { get; set; }
        public double ValorIOF { get; set; }
        #endregion

        #region PIS
        public string CSTPIS { get; set; }
        public double AliquotaPIS { get; set; }
        public double ValorAliquotaPIS { get; set; }
        public double ValorPIS { get; set; }
        #endregion

        #region COFINS
        public string CSTCOFINS { get; set; }
        public double AliquotaCOFINS { get; set; }
        public double ValorAliquotaCOFINS { get; set; }
        public double ValorCOFINS { get; set; }
        #endregion

        public List<DTO_NF_Importacao> Importacao { get; set; }
    }

    public class DTO_NF_Transporte
    {
        public int ID { get; set; }
        public int ID_NFe { get; set; }
        public int ID_Pessoa { get; set; }

        private string ie { get; set; }
        public string IE
        {
            get
            {
                if (ie == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(ie);
            }

            set { ie = value; }
        }

        private string cnpj_cpf { get; set; }
        public string CNPJ_CPF
        {
            get
            {
                if (cnpj_cpf == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(cnpj_cpf);
            }

            set { cnpj_cpf = value; }
        }

        private string nome { get; set; }
        public string Nome
        {
            get
            {
                if (nome == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(nome);
            }

            set { nome = value; }
        }

        private string endereco { get; set; }
        public string Endereco
        {
            get
            {
                if (endereco == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(endereco);
            }

            set { endereco = value; }
        }

        private string municipio { get; set; }
        public string Municipio
        {
            get
            {
                if (municipio == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(municipio);
            }

            set { municipio = value; }
        }

        private string uf { get; set; }
        public string UF
        {
            get
            {
                if (uf == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(uf);
            }

            set { uf = value; }
        }

        private string ufplaca { get; set; }
        public string UFPlaca
        {
            get
            {
                if (ufplaca == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(ufplaca);
            }

            set { ufplaca = value; }
        }

        private string placa { get; set; }
        public string Placa
        {
            get
            {
                if (placa == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(placa);
            }

            set { placa = value; }
        }

        public List<DTO_NF_Volume> Volume { get; set; }
    }

    public class DTO_NF_Volume
    {
        public int ID { get; set; }
        public double Quantidade { get; set; }

        private string especie { get; set; }
        public string Especie
        {
            get
            {
                if (especie == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(especie);
            }

            set { especie = value; }
        }

        private string marca { get; set; }
        public string Marca
        {
            get
            {
                if (marca == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(marca);
            }

            set { marca = value; }
        }

        private string numeracao { get; set; }
        public string Numeracao
        {
            get
            {
                if (numeracao == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(numeracao);
            }

            set { numeracao = value; }
        }

        public double PesoL { get; set; }
        public double PesoB { get; set; }

        public List<DTO_NF_Lacre> Lacre { get; set; }
    }

    public class DTO_NF_Lacre
    {
        public int ID { get; set; }
        private string numero { get; set; }
        public string Numero
        {
            get
            {
                if (numero == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(numero);
            }

            set { numero = value; }
        }
    }

    public class DTO_NF_Cobranca
    {
        public int ID { get; set; }
        public int ID_NFe { get; set; }

        private string numerofatura { get; set; }
        public string NumeroFatura
        {
            get
            {
                if (numerofatura == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(numerofatura);
            }

            set { numerofatura = value; }
        }

        public double Valor { get; set; }
        public double Desconto { get; set; }
        public double ValorFinal { get; set; }
    }

    public class DTO_NF_Duplicata
    {
        public int ID { get; set; }
        public int ID_NFe { get; set; }

        private string numeroduplicata { get; set; }
        public string NumeroDuplicata
        {
            get
            {
                if (numeroduplicata == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(numeroduplicata);
            }

            set { numeroduplicata = value; }
        }

        public DateTime Vencimento { get; set; }
        public double Valor { get; set; }
    }

    public class DTO_NF_Autorizacao_XML
    {
        public int ID { get; set; }
        public int ID_NF { get; set; }

        private string cnpj_cpf { get; set; }
        public string CNPJ_CPF
        {
            get
            {
                if (cnpj_cpf == null)
                    return string.Empty;
                else
                    return util_dados.RemoveAspa(cnpj_cpf);
            }

            set { cnpj_cpf = value; }
        }
    }
}
