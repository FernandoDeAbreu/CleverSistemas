using Sistema.DAL;
using Sistema.DTO;
using Sistema.UTIL;
using System;
using System.Data;

namespace Sistema.BLL
{
    public class BLL_Produto
    {
        public int Grava(DTO_Produto _Produto)
        {
            string msg = string.Empty;

            if (_Produto.Descricao == string.Empty)
                msg += "DESCRIÇÃO\n";

            if (_Produto.Valor == null ||
                _Produto.Valor.Count == 0)
                msg += "VALOR DE VENDA\n";

            if (_Produto.Tipo != "5" &&
                _Produto.Estrutura != null &&
                _Produto.Estrutura.Count > 0)
                msg += "TIPO DE PRODUTO INVÁLIDO PARA ESTRUTURA DE KIT\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Produto obj = new DAL_Produto(_Produto);
            return obj.Grava();
        }

        public void Grava_NovaEmpresa(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            obj.Grava_NovaEmpresa();
        }

        public void Grava_Estoque(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            obj.Grava_Estoque();
        }

        public void Grava_Imposto(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            obj.Grava_Imposto();
        }

        public void Grava_Desconto(DTO_Produto _Produto)
        {
            string msg = string.Empty;

            if (_Produto.ID == 0)
                msg += "PRODUTO\n";

            if (_Produto.Desconto == 0)
                msg += "DESCONTO\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Produto obj = new DAL_Produto(_Produto);
            obj.Grava_Desconto();
        }

        public void Grava_Desconto_Pessoa(DTO_Produto _Produto)
        {
            string msg = string.Empty;

            if (_Produto.Desconto_Pessoa.Count == 0)
                msg += "NENHUM PRODUTO DEFINIDO\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Produto obj = new DAL_Produto(_Produto);
            obj.Grava_Desconto_Pessoa();
        }

        public void Grava_MovimentoProduto(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            obj.Grava_MovimentoProduto();
        }

        public void Atualiza_Estoque(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            obj.Atualiza_Estoque();
        }

        public void Atualiza_Valor(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            obj.Atualiza_Valor();
        }

        public DataTable Busca(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            return obj.Busca();
        }

        public DataTable Busca_PDV(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            return obj.Busca_PDV();
        }

        public DataTable Busca_new(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            return obj.Busca_Venda();
        }

        public DataTable Busca_AlteraValor(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            return obj.Busca_AlteraValor();
        }

        public DataTable Busca_Valor(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            return obj.Busca_Valor();
        }

        public DataTable Busca_Valor_Imposto(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            return obj.Busca_Valor_Imposto();
        }

        public DataTable Busca_Etiqueta(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            return obj.Busca_Etiqueta();
        }

        public DataTable Busca_ResumoVenda(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            return obj.Busca_ResumoVenda();
        }

        public DataTable Busca_Rel_TabelaValor(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            return obj.Busca_Rel_TabelaValor();
        }

        public DataTable Busca_Imposto(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            return obj.Busca_Imposto();
        }

        public DataTable Busca_Fornecedor(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            return obj.Busca_Fornecedor();
        }

        public DataTable Busca_Produto_Fornecedor(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            return obj.Busca_Produto_Fornecedor();
        }

        public DataTable Busca_TabelaValor(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            return obj.Busca_TabelaValor();
        }

        public DataTable Busca_Comissao(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            return obj.Busca_Comissao();
        }

        public DataTable Busca_Estoque(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            return obj.Busca_Estoque();
        }

        public DataTable Busca_Estoque_Simples(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            return obj.Busca_Estoque_Simples();
        }

        public DataTable Busca_Estrutura(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            return obj.Busca_Estrutura();
        }

        public DataTable Busca_Imagem(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            return obj.Busca_Imagem();
        }

        public DataTable Busca_Rel_Estoque(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            return obj.Busca_Rel_Estoque();
        }

        public DataTable Busca_Rel_Estoque_Coletor(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            return obj.Busca_Rel_Estoque_Coletor();
        }

        public DataTable Busca_Estoque_Vlr(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            return obj.Busca_Estoque_Vlr();
        }

        public DataTable Busca_Estoque_Vlr_Data(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            return obj.Busca_Estoque_Vlr_Data();
        }

        public DataTable Busca_ProdutoMovimento(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            return obj.Busca_ProdutoMovimento();
        }

        public DataTable Busca_Desconto(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            return obj.Busca_Desconto();
        }

        public DataTable Busca_Desconto_Pessoa(DTO_Produto _Produto)
        {
            DAL_Produto obj = new DAL_Produto(_Produto);
            return obj.Busca_Desconto_Pessoa();
        }

        public void Exclui(DTO_Produto _Produto)
        {
            if (_Produto.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Produto obj = new DAL_Produto(_Produto);
            obj.Exclui();
        }

        public void Exclui_Fornecedor(DTO_Produto _Produto)
        {
            if (_Produto.Fornecedor[0].ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Produto obj = new DAL_Produto(_Produto);
            obj.Exclui_Fornecedor();
        }

        public void Exclui_Valor(DTO_Produto _Produto)
        {
            if (_Produto.Valor[0].ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Produto obj = new DAL_Produto(_Produto);
            obj.Exclui_Valor();
        }

        public void Exclui_Estoque(DTO_Produto _Produto)
        {
            if (_Produto.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Produto obj = new DAL_Produto(_Produto);
            obj.Exclui_Estoque();
        }

        public void Exclui_Estrutura(DTO_Produto _Produto)
        {
            if (_Produto.Estrutura[0].ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Produto obj = new DAL_Produto(_Produto);
            obj.Exclui_Estrutura();
        }

        public void Exclui_Imagem(DTO_Produto _Produto)
        {
            if (_Produto.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Produto obj = new DAL_Produto(_Produto);
            obj.Exclui_Imagem();
        }

        public void Exclui_Desconto(DTO_Produto _Produto)
        {
            if (_Produto.ID_Desconto == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Produto obj = new DAL_Produto(_Produto);
            obj.Exclui_Desconto();
        }

        public void Exclui_Desconto_Pessoa(DTO_Produto _Produto)
        {
            if (_Produto.TipoPessoa == 0 ||
                _Produto.ID_Pessoa == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Produto obj = new DAL_Produto(_Produto);
            obj.Exclui_Desconto_Pessoa();
        }
    }

    public class BLL_Produto_Entrada
    {
        public int Grava(DTO_Produto_Entrada _Produto_Entrada)
        {
            string msg = string.Empty;

            if (_Produto_Entrada.ID_Pessoa == 0)
                msg += "Pessoa/n";

            if (_Produto_Entrada.Entrada_XML_NFe == true)
                for (int i = 0; i <= _Produto_Entrada.Item.Count - 1; i++)
                    if (_Produto_Entrada.Item[i].ID_Produto == 0)
                        msg += _Produto_Entrada.Item[i].NFe_Descricao + " Não especificado!\n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Produto_Entrada obj = new DAL_Produto_Entrada(_Produto_Entrada);
            return obj.Grava();
        }

        public void Altera_Fatura(DTO_Produto_Entrada _Produto_Entrada)
        {
            string msg = string.Empty;

            if (_Produto_Entrada.ID == 0)
                msg += "Código";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);

            DAL_Produto_Entrada obj = new DAL_Produto_Entrada(_Produto_Entrada);
            obj.Altera_Fatura();
        }

        public void Grava_Item(DTO_Produto_Item _Produto_Item)
        {
            string msg = string.Empty;

            if (_Produto_Item.ID_Produto == 0)
                msg += "Produto/n";

            if (msg != string.Empty)
                throw new Exception(util_msg.msg_BLL_CampoIncorreto + msg);
        }

        public void Atualiza_ValorEstoque(DTO_Produto_Entrada _Produto_Entrada)
        {
            DAL_Produto_Entrada obj = new DAL_Produto_Entrada(_Produto_Entrada);
            obj.Atualiza_ValorEstoque();
        }

        public DataTable Busca(DTO_Produto_Entrada _Produto_Entrada)
        {
            DAL_Produto_Entrada obj = new DAL_Produto_Entrada(_Produto_Entrada);
            return obj.Busca();
        }

        public DataTable Busca_Relatorio(DTO_Produto_Entrada _Produto_Entrada)
        {
            DAL_Produto_Entrada obj = new DAL_Produto_Entrada(_Produto_Entrada);
            return obj.Busca_Relatorio();
        }

        public DataTable Busca_Item(DTO_Produto_Entrada _Produto_Entrada)
        {
            DAL_Produto_Entrada obj = new DAL_Produto_Entrada(_Produto_Entrada);
            return obj.Busca_Item();
        }

        public DataTable Busca_HistoricoEntrada(DTO_Produto_Entrada _Produto_Entrada)
        {
            DAL_Produto_Entrada obj = new DAL_Produto_Entrada(_Produto_Entrada);
            return obj.Busca_HistoricoEntrada();
        }

        public DataTable Busca_Item_Relatorio(DTO_Produto_Entrada _Produto_Entrada)
        {
            DAL_Produto_Entrada obj = new DAL_Produto_Entrada(_Produto_Entrada);
            return obj.Busca_Item_Relatorio();
        }

        public DataTable Busca_Produto_Entrada_Simplificado(DTO_Produto_Entrada _Produto_Entrada)
        {
            DAL_Produto_Entrada obj = new DAL_Produto_Entrada(_Produto_Entrada);
            return obj.Busca_Produto_Entrada_Simplificado();
        }

        public DataTable Busca_Produto_Entrada_Detalhado(DTO_Produto_Entrada _Produto_Entrada)
        {
            DAL_Produto_Entrada obj = new DAL_Produto_Entrada(_Produto_Entrada);
            return obj.Busca_Produto_Entrada_Detalhado();
        }

        public void Exclui(DTO_Produto_Entrada _Produto_Entrada)
        {
            if (_Produto_Entrada.ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Produto_Entrada obj = new DAL_Produto_Entrada(_Produto_Entrada);
            obj.Exclui();
        }

        public void Exclui_Item(DTO_Produto_Entrada _Produto_Entrada)
        {
            if (_Produto_Entrada.Item[0].ID == 0)
                throw new Exception(util_msg.msg_BLL_ErroExclui_Null);

            DAL_Produto_Entrada obj = new DAL_Produto_Entrada(_Produto_Entrada);
            obj.Exclui_Item();
        }

        public class BLL_Produto_Locacao
        {
            public int Grava(DTO_Locacao_Produto _Locacao_Produto)
            {
                DAL_Produto_Locacao obj = new DAL_Produto_Locacao(_Locacao_Produto);
                return obj.Grava_Locacao();
            }
        }
    }
}