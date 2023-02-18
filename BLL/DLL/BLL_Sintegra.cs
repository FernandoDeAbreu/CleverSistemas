using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Sistema.DTO;
using Sistema.UTIL;
using System.IO;

namespace Sistema.BLL
{
    public class BLL_Sintegra
    {

        List<string> texto = new List<string>();
        public void GerarSintegra(DateTime data_Ini, bool mostra_Inventario, string diretorio)
        {
            try
            {

                DateTime data_Fim = data_Ini.AddMonths(1).AddDays(-1);
                int id_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                
                List<int> Produto = new List<int>();

                string reg10 = string.Empty; // Empresa
                string reg11 = string.Empty; // Empresa Endereco
                string reg50 = string.Empty; // NF
                string reg53 = string.Empty; // NF item Sub.Trib.
                string reg54 = string.Empty; // NF item
                string reg70 = string.Empty; // Serv.Transporte - tomador ou prestador
                string reg75 = string.Empty; // Cad. Prod
                string reg90 = string.Empty; // Totais de registros

                int qtd_reg10 = 1;
                int qtd_reg11 = 1;
                int qtd_reg50 = 0;
                int qtd_reg53 = 0;
                int qtd_reg54 = 0;
                int qtd_reg70 = 0;
                int qtd_reg75 = 0;
                int qtd_reg90 = 1;

                DataTable _DT_Empresa = new DataTable();
                DataTable _DT_NF = new DataTable();
                DataTable _DT_NF_ST = new DataTable();
                DataTable _DT_NF_Item = new DataTable();


                DTO_NF NFe = new DTO_NF();
                DTO_Pessoa Pessoa = new DTO_Pessoa();

                BLL_NF BLL_NF = new BLL_NF();
                BLL_Pessoa BLL_Pessoa = new BLL_Pessoa();


                Pessoa.ID = id_Empresa;
                _DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);


                NFe.Consulta_Emissao.Filtra = true;
                NFe.ID_Empresa = id_Empresa;
                NFe.Modelo = 55;
                NFe.Consulta_Emissao.Inicial = data_Ini;
                NFe.Consulta_Emissao.Final = data_Fim;

                _DT_NF = BLL_NF.Busca_NF_Sintegra(NFe);
                _DT_NF_ST = BLL_NF.Busca_NF_Sintegra_ST(NFe);
                _DT_NF_Item = BLL_NF.Busca_NF_Sintegra_Item(NFe);


                if (_DT_Empresa.Rows.Count != 1)
                    throw new Exception("Erro ao Localizar Empresa!");

                if (string.IsNullOrEmpty(_DT_Empresa.Rows[0]["Contato"].ToString()))
                    throw new Exception("Contato Inválido no Cadastro de Empresa!");

                reg10 = "10";
                reg10 += util_dados.Config_Campo_String(14, 'E', '0', util_dados.Retorna_Numero(_DT_Empresa.Rows[0]["CNPJ_CPF"].ToString()));
                reg10 += util_dados.Config_Campo_String(14, 'D', ' ', util_dados.Retorna_Numero(_DT_Empresa.Rows[0]["IE_RG"].ToString()));
                reg10 += util_dados.Config_Campo_String(35, 'D', ' ', _DT_Empresa.Rows[0]["Nome_Razao"].ToString());
                reg10 += util_dados.Config_Campo_String(30, 'D', ' ', _DT_Empresa.Rows[0]["Municipio"].ToString());
                reg10 += _DT_Empresa.Rows[0]["UF"];
                reg10 += util_dados.Config_Campo_String(10, 'E', '0', _DT_Empresa.Rows[0]["DDD"] + util_dados.Retorna_Numero(_DT_Empresa.Rows[0]["NumeroTelefone"].ToString()));
                reg10 += util_dados.Config_Data(data_Ini, 21);
                reg10 += util_dados.Config_Data(data_Fim, 21);
                reg10 += "3";
                reg10 += "3";
                reg10 += "1";

                ValidaQtdCaracteres(reg10, "reg10");


                reg11 = "11";
                reg11 += util_dados.Config_Campo_String(34, 'D', ' ', _DT_Empresa.Rows[0]["Logradouro"].ToString());
                reg11 += util_dados.Config_Campo_String(5, 'E', '0', util_dados.Retorna_Numero(_DT_Empresa.Rows[0]["NumeroEndereco"].ToString()));
                reg11 += util_dados.Config_Campo_String(22, 'D', ' ', _DT_Empresa.Rows[0]["Complemento"].ToString());
                reg11 += util_dados.Config_Campo_String(15, 'D', ' ', _DT_Empresa.Rows[0]["Bairro"].ToString());
                reg11 += util_dados.Config_Campo_String(8, 'E', '0', util_dados.Retorna_Numero(_DT_Empresa.Rows[0]["CEP"].ToString()));
                reg11 += util_dados.Config_Campo_String(28, 'D', ' ', _DT_Empresa.Rows[0]["Contato"].ToString());
                reg11 += util_dados.Config_Campo_String(12, 'E', '0', _DT_Empresa.Rows[0]["DDD"] + util_dados.Retorna_Numero(_DT_Empresa.Rows[0]["NumeroTelefone"].ToString()));

                ValidaQtdCaracteres(reg11, "reg11");



                for (int i = 0; i <= _DT_NF.Rows.Count - 1; i++)
                {

                    reg50 = "50";

                    if (!_DT_NF.Rows[i]["Situacao"].Equals("S")) //S= Cancelada
                    {
                        reg50 += util_dados.Config_Campo_String(14, 'E', '0', util_dados.Retorna_Numero(_DT_NF.Rows[i]["CNPJ_CPF"].ToString()));

                        if (util_dados.Retorna_Numero(_DT_NF.Rows[i]["CNPJ_CPF"].ToString()).Length == 11)
                            reg50 += util_dados.Config_Campo_String(14, 'D', ' ', "ISENTO");
                        else
                            reg50 += util_dados.Config_Campo_String(14, 'D', ' ', util_dados.Retorna_Numero(_DT_NF.Rows[i]["IE_RG"].ToString()));

                        reg50 += util_dados.Config_Data(Convert.ToDateTime(_DT_NF.Rows[i]["DataEmissao"]), 21);
                        reg50 += _DT_NF.Rows[i]["UF"];
                        reg50 += util_dados.Config_Campo_String(2, 'E', '0', _DT_NF.Rows[i]["Modelo"].ToString());
                        reg50 += util_dados.Config_Campo_String(3, 'D', ' ', _DT_NF.Rows[i]["Serie"].ToString());
                        reg50 += util_dados.Config_Campo_String(6, 'E', '0', _DT_NF.Rows[i]["ID_NFe"].ToString());
                        reg50 += util_dados.Config_Campo_String(4, 'E', '0', _DT_NF.Rows[i]["CFOP"].ToString());
                        reg50 += _DT_NF.Rows[i]["Emitente"];
                        reg50 += util_dados.Config_Campo_String(13, 'E', '0', util_dados.ConfigNumDecimal(_DT_NF.Rows[i]["ValorTotal"].ToString(), 32));
                        reg50 += util_dados.Config_Campo_String(13, 'E', '0', util_dados.ConfigNumDecimal(_DT_NF.Rows[i]["ValorBC"].ToString(), 32));
                        reg50 += util_dados.Config_Campo_String(13, 'E', '0', util_dados.ConfigNumDecimal(_DT_NF.Rows[i]["ValorICMS"].ToString(), 32));
                        reg50 += util_dados.Config_Campo_String(13, 'E', '0', util_dados.ConfigNumDecimal(_DT_NF.Rows[i]["Isento"].ToString(), 32));
                        reg50 += util_dados.Config_Campo_String(13, 'E', '0', util_dados.ConfigNumDecimal(_DT_NF.Rows[i]["Outras"].ToString(), 32));
                        reg50 += util_dados.Config_Campo_String(4, 'D', '0', util_dados.ConfigNumDecimal(_DT_NF.Rows[i]["AliquotaICMS"].ToString(), 32));
                        reg50 += _DT_NF.Rows[i]["Situacao"];

                    }
                    else
                    {
                        reg50 += util_dados.Config_Campo_String(14, 'E', '0', "0");
                        reg50 += util_dados.Config_Campo_String(14, 'E', ' ', " ");
                        reg50 += util_dados.Config_Campo_String(8, 'E', '0', "0");
                        reg50 += "  ";
                        reg50 += util_dados.Config_Campo_String(2, 'E', '0', _DT_NF.Rows[i]["Modelo"].ToString());
                        reg50 += util_dados.Config_Campo_String(3, 'D', ' ', _DT_NF.Rows[i]["Serie"].ToString());
                        reg50 += util_dados.Config_Campo_String(6, 'E', '0', _DT_NF.Rows[i]["ID_NFe"].ToString());
                        reg50 += util_dados.Config_Campo_String(4, 'E', '0', "0");
                        reg50 += " ";
                        reg50 += util_dados.Config_Campo_String(69, 'E', '0', "0");
                        reg50 += "S";
                    }


                    ValidaQtdCaracteres(reg50, "reg50");
                    qtd_reg50++;
                }



                for (int i = 0; i <= _DT_NF_ST.Rows.Count - 1; i++)
                {

                    reg53 = "53";

                    if (_DT_NF_ST.Rows[i]["Situacao"].Equals("N"))
                    {
                        reg53 += util_dados.Config_Campo_String(14, 'E', '0', util_dados.Retorna_Numero(_DT_NF_ST.Rows[i]["CNPJ_CPF"].ToString()));

                        if (util_dados.Retorna_Numero(_DT_NF_ST.Rows[i]["CNPJ_CPF"].ToString()).Length == 11)
                            reg53 += util_dados.Config_Campo_String(14, 'D', ' ', "ISENTO");
                        else
                            reg53 += util_dados.Config_Campo_String(14, 'D', ' ', util_dados.Retorna_Numero(_DT_NF_ST.Rows[i]["IE_RG"].ToString()));

                        reg53 += util_dados.Config_Data(Convert.ToDateTime(_DT_NF_ST.Rows[i]["DataEmissao"]), 21);
                        reg53 += _DT_NF_ST.Rows[i]["UF"];
                        reg53 += util_dados.Config_Campo_String(2, 'E', '0', _DT_NF_ST.Rows[i]["Modelo"].ToString());
                        reg53 += util_dados.Config_Campo_String(3, 'D', ' ', _DT_NF_ST.Rows[i]["Serie"].ToString());
                        reg53 += util_dados.Config_Campo_String(6, 'E', '0', _DT_NF_ST.Rows[i]["ID_NFe"].ToString());
                        reg53 += util_dados.Config_Campo_String(4, 'E', '0', _DT_NF_ST.Rows[i]["CFOP"].ToString());
                        reg53 += _DT_NF_ST.Rows[i]["Emitente"];
                        reg53 += util_dados.Config_Campo_String(13, 'E', '0', util_dados.ConfigNumDecimal(_DT_NF_ST.Rows[i]["ValorBCST"].ToString(), 32));
                        reg53 += util_dados.Config_Campo_String(13, 'E', '0', util_dados.ConfigNumDecimal(_DT_NF_ST.Rows[i]["ValorICMSST"].ToString(), 32));
                        reg53 += util_dados.Config_Campo_String(13, 'E', '0', util_dados.ConfigNumDecimal(_DT_NF_ST.Rows[i]["Outras"].ToString(), 32));
                        reg53 += _DT_NF_ST.Rows[i]["Situacao"];
                    }
                    else
                    {
                        reg53 += util_dados.Config_Campo_String(14, 'E', '0', "0");
                        reg53 += util_dados.Config_Campo_String(14, 'E', ' ', " ");
                        reg53 += util_dados.Config_Campo_String(8, 'E', '0', "0");
                        reg53 += "  ";
                        reg53 += util_dados.Config_Campo_String(2, 'E', '0', _DT_NF_ST.Rows[i]["Modelo"].ToString());
                        reg53 += util_dados.Config_Campo_String(3, 'D', ' ', _DT_NF_ST.Rows[i]["Serie"].ToString());
                        reg53 += util_dados.Config_Campo_String(6, 'E', '0', _DT_NF_ST.Rows[i]["ID_NFe"].ToString());
                        reg53 += util_dados.Config_Campo_String(4, 'E', '0', "0");
                        reg53 += " ";
                        reg53 += util_dados.Config_Campo_String(39, 'E', '0', "0");
                        reg53 += "S";
                    }

                    
                    reg53 += util_dados.Config_Campo_String(30, 'E', ' ', " ");


                    ValidaQtdCaracteres(reg53, "reg53");
                    qtd_reg53++;
                }



                for (int i = 0; i <= _DT_NF_Item.Rows.Count - 1; i++)
                {
                    if (Parametro_NFe_NFC_SAT.Regime_Tributario == 1)
                        _DT_NF_Item.Rows[i]["CST"] = _DT_NF_Item.Rows[i]["CSOSN"];

                    reg54 = "54";
                    reg54 += util_dados.Config_Campo_String(14, 'E', '0', util_dados.Retorna_Numero(_DT_NF_Item.Rows[i]["CNPJ_CPF"].ToString()));
                    reg54 += util_dados.Config_Campo_String(2, 'E', '0', _DT_NF_Item.Rows[i]["Modelo"].ToString());
                    reg54 += util_dados.Config_Campo_String(3, 'D', ' ', _DT_NF_Item.Rows[i]["Serie"].ToString());
                    reg54 += util_dados.Config_Campo_String(6, 'E', '0', _DT_NF_Item.Rows[i]["ID_NFe"].ToString());
                    reg54 += util_dados.Config_Campo_String(4, 'E', '0', _DT_NF_Item.Rows[i]["CFOP"].ToString());
                    reg54 += util_dados.Config_Campo_String(3, 'E', '0', _DT_NF_Item.Rows[i]["CST"].ToString());
                    reg54 += util_dados.Config_Campo_String(3, 'E', '0', _DT_NF_Item.Rows[i]["NumItem"].ToString());
                    reg54 += util_dados.Config_Campo_String(14, 'D', ' ', _DT_NF_Item.Rows[i]["ID_Produto"].ToString());
                    reg54 += util_dados.Config_Campo_String(11, 'E', '0', util_dados.ConfigNumDecimal(_DT_NF_Item.Rows[i]["Quantidade"].ToString(), 33));
                    reg54 += util_dados.Config_Campo_String(12, 'E', '0', util_dados.ConfigNumDecimal(_DT_NF_Item.Rows[i]["ValorBrunto"].ToString(), 32));
                    reg54 += util_dados.Config_Campo_String(12, 'E', '0', util_dados.ConfigNumDecimal(_DT_NF_Item.Rows[i]["Desconto"].ToString(), 32));
                    reg54 += util_dados.Config_Campo_String(12, 'E', '0', util_dados.ConfigNumDecimal(_DT_NF_Item.Rows[i]["ValorBC"].ToString(), 32));
                    reg54 += util_dados.Config_Campo_String(12, 'E', '0', util_dados.ConfigNumDecimal(_DT_NF_Item.Rows[i]["ValorBCST"].ToString(), 32));
                    reg54 += util_dados.Config_Campo_String(12, 'E', '0', util_dados.ConfigNumDecimal(_DT_NF_Item.Rows[i]["ValorIPI"].ToString(), 32));
                    reg54 += util_dados.Config_Campo_String(4, 'D', '0', util_dados.ConfigNumDecimal(_DT_NF_Item.Rows[i]["AliquotaICMS"].ToString(), 32));

                    ValidaQtdCaracteres(reg54, "reg54");
                    qtd_reg54++;

                }

                

                for (int i = 0; i <= _DT_NF_Item.Rows.Count - 1; i++)
                {

                    if (!Produto.Exists(x=> x.Equals(_DT_NF_Item.Rows[i]["ID_Produto"])))
                    {
                        Produto.Add(Convert.ToInt32(_DT_NF_Item.Rows[i]["ID_Produto"]));


                        if (Parametro_NFe_NFC_SAT.Regime_Tributario == 1)
                            _DT_NF_Item.Rows[i]["CST"] = _DT_NF_Item.Rows[i]["CSOSN"];
                        

                        reg75 = "75";
                        reg75 += util_dados.Config_Data(data_Ini, 21);
                        reg75 += util_dados.Config_Data(data_Fim, 21);
                        reg75 += util_dados.Config_Campo_String(14, 'D', ' ', _DT_NF_Item.Rows[i]["ID_Produto"].ToString());
                        reg75 += util_dados.Config_Campo_String(8, 'D', ' ', _DT_NF_Item.Rows[i]["NCM"].ToString());
                        reg75 += util_dados.Config_Campo_String(53, 'D', ' ', _DT_NF_Item.Rows[i]["DescricaoProduto"].ToString());
                        reg75 += util_dados.Config_Campo_String(6, 'D', ' ', _DT_NF_Item.Rows[i]["Unidade"].ToString());
                        reg75 += util_dados.Config_Campo_String(5, 'D', '0', util_dados.ConfigNumDecimal(_DT_NF_Item.Rows[i]["IPI"].ToString(), 32));
                        reg75 += util_dados.Config_Campo_String(4, 'D', '0', util_dados.ConfigNumDecimal(_DT_NF_Item.Rows[i]["AliquotaICMSProd"].ToString(), 32));
                        reg75 += util_dados.Config_Campo_String(5, 'E', '0', util_dados.ConfigNumDecimal(_DT_NF_Item.Rows[i]["ReducaoBC"].ToString(), 32));
                        reg75 += util_dados.Config_Campo_String(13, 'E', '0', util_dados.ConfigNumDecimal(_DT_NF_Item.Rows[i]["BCST"].ToString(), 32));

                        ValidaQtdCaracteres(reg75, "reg75");
                        qtd_reg75++;
                    }

                }

                reg90 = "90";      
                reg90 += util_dados.Config_Campo_String(14, 'E', '0', util_dados.Retorna_Numero(_DT_Empresa.Rows[0]["CNPJ_CPF"].ToString()));
                reg90 += util_dados.Config_Campo_String(14, 'D', ' ', util_dados.Retorna_Numero(_DT_Empresa.Rows[0]["IE_RG"].ToString()));
                reg90 += "50";
                reg90 += util_dados.Config_Campo_String(8, 'E', '0', qtd_reg50.ToString());
                if (qtd_reg53 > 0)
                {
                    reg90 += "53";
                    reg90 += util_dados.Config_Campo_String(8, 'E', '0', qtd_reg53.ToString());
                }
                reg90 += "54";
                reg90 += util_dados.Config_Campo_String(8, 'E', '0', qtd_reg54.ToString());
                if (qtd_reg70 > 0)
                {
                    reg90 += "70";
                    reg90 += util_dados.Config_Campo_String(8, 'E', '0', qtd_reg70.ToString());
                }
                reg90 += "75";
                reg90 += util_dados.Config_Campo_String(8, 'E', '0', qtd_reg75.ToString());
                reg90 += "99";
                reg90 += util_dados.Config_Campo_String(8, 'E', '0', (qtd_reg10+qtd_reg11 + qtd_reg50 + qtd_reg53 + qtd_reg54 + qtd_reg70 + qtd_reg75 + qtd_reg90).ToString());
                reg90 += util_dados.Config_Campo_String(126 - reg90.Length , 'E', ' ',"1");


                ValidaQtdCaracteres(reg90, "reg90");


                string Arquivo = diretorio + @"\";
                Arquivo += util_dados.Config_Campo_String(14, 'E', '0', util_dados.Retorna_Numero(_DT_Empresa.Rows[0]["CNPJ_CPF"].ToString())) + "_";
                Arquivo += util_dados.Config_Campo_String(14, 'D', '0', util_dados.Retorna_Numero(_DT_Empresa.Rows[0]["IE_RG"].ToString())) + "_";
                Arquivo += util_dados.Config_Data(data_Ini, 21) + "_" + util_dados.Config_Data(data_Fim, 21) + ".txt";

                //ANSI
                File.WriteAllLines(Arquivo, texto.ToArray(), Encoding.GetEncoding(1252));

                

                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message );
            }



        }

        private void ValidaQtdCaracteres(string campo, string nome_campo)
        {
            if (campo.Length != 126)
                throw new Exception("Quantidade caracteres Inválidas ("+ campo.Length +") em " + nome_campo);


            texto.Add(campo);

        }


    }
}
