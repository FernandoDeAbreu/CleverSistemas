using Microsoft.Reporting.WinForms;
using Sistema.BLL;
using Sistema.DTO;
using Sistema.UTIL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace Sistema.UI.UI_FORMS
{
    public partial class UI_PDV_II : Form
    {
        private SqlConnection sqlConn = new SqlConnection("Data Source=" + SQL.Servidor + ";Initial Catalog=" + SQL.Banco + ";Persist Security Info=True;User ID=sa;Password=" + SQL.Senha);
        private string codProd;
        private string idPessoa = "1";
        private decimal subtotal = 0;
        private string idUltimaVenda;
        public string pagamentoEfetuado;
        public string Moeda;
        private string descricaoGrupo;
        private int contadorDeVendas = 0;
        private bool exibirPromocao = false;
        private int id_Tabela = 1;

        public UI_PDV_II()
        {
            InitializeComponent();
        }

        #region VARIAVEIS DE CLASSE

        private BLL_Produto BLL_Produto;
        private BLL_Venda BLL_Venda;
        private BLL_Pessoa BLL_Pessoa;
        private BLL_Parametro BLL_Parametro;
        private BLL_Usuario BLL_Usuario;
        private BLL_Imagem BLL_Imagem;

        #endregion VARIAVEIS DE CLASSE

        #region ESTRUTURA

        private DTO_Produto Produto;
        private DTO_Produto_Item Produto_Item;
        private DTO_Pessoa Pessoa;
        private DTO_Venda Venda;
        private DTO_Produto_Estoque Produto_Estoque;
        private DTO_Pessoa_Endereco Endereco;
        private DTO_Pessoa_Telefone Telefone;
        private DTO_Pessoa_Email Email;
        private DTO_Parametro Parametro;
        private DTO_Usuario Usuario;
        private DTO_Imagem Imagem;

        #endregion ESTRUTURA

        #region TIMER

        private void DataHora_Tick(object sender, EventArgs e)
        {
            //lb_Data.Text = DateTime.Now.ToShortDateString();
            //lb_Horario.Text = DateTime.Now.ToLongTimeString();
        }

        #endregion TIMER

        public class Panel : System.Windows.Forms.Panel
        {
            public int BorderRadius { get; private set; }

            protected override void OnPaint(PaintEventArgs e)
            {
                Color bc = Color.Black;
                Color bg = Color.Black;
                Color fc = Color.White;
                BorderRadius = 20;
                StringFormat formatter = new StringFormat();

                base.OnPaint(e);
                formatter.LineAlignment = StringAlignment.Center;
                formatter.Alignment = StringAlignment.Center;
                //  RectangleF rectangle = new RectangleF(0,0, e.ClipRectangle.Width, e.ClipRectangle.Height);

                //e.Graphics.FillRectangle(new SolidBrush(bg), e.ClipRectangle);
                // ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, bc, ButtonBorderStyle.None);
                //  e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(fc), rectangle, formatter);

                // BorderRadius é uma variável do tipo inteiro que define a quantidade que a borda deve ser arredondada.
                if (BorderRadius > 0)
                {
                    GraphicsPath gp = UTIL.Transform.BorderRadius(ClientRectangle, BorderRadius, true, true);
                    this.Region = new System.Drawing.Region(gp);
                }
            }
        }

        private void carregarGrid()
        {
            this.flowLayoutPanel1.Controls.Clear();
            if (descricaoGrupo == null)
                descricaoGrupo = "is not null";

            var sql1 = "SELECT * FROM V_Produto_Venda where DescricaoGrupo " + descricaoGrupo + " order by ID_Tabela desc,  ID";
            var sql2 = "SELECT * FROM V_Produto_Venda where DescricaoGrupo " + descricaoGrupo + " and ID_Tabela = 1";

            if (!exibirPromocao)
                sql1 = sql2;

            SqlCommand cmd = new SqlCommand(sql1, sqlConn);

            sqlConn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                //string myFile = dr["IMAGEM"].ToString();
                //Image newImage = Image.FromFile(myFile);
                //b.BackgroundImage = newImage;

                Panel panelProduto = new Panel();
                Label lblPrecoProd = new Label();
                Label lblDescrProduto = new Label();
                PictureBox pictureBoxProduto = new PictureBox();

                // panelProduto
                //
                panelProduto.Controls.Add(lblPrecoProd);
                panelProduto.Controls.Add(lblDescrProduto);
                panelProduto.Controls.Add(pictureBoxProduto);
                panelProduto.Location = new System.Drawing.Point(3, 3);
                panelProduto.Name = dr["ID"].ToString();
                panelProduto.Size = new System.Drawing.Size(186, 84);
                panelProduto.TabIndex = 0;
                panelProduto.BackColor = System.Drawing.Color.White;
                if (exibirPromocao && dr["ID_Tabela"].ToString() != "1")
                    panelProduto.BackColor = Color.Red;

                //
                // pictureBoxProduto
                //
                pictureBoxProduto.Location = new System.Drawing.Point(3, 3);
                pictureBoxProduto.Name = dr["ID"].ToString();
                pictureBoxProduto.Size = new System.Drawing.Size(66, 78);
                pictureBoxProduto.TabIndex = 0;
                pictureBoxProduto.TabStop = false;
                pictureBoxProduto.Enabled = false;
                pictureBoxProduto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

                try
                {
                    byte[] bits = (byte[])(dr["IMAGEM"]);
                    MemoryStream memorybits = new MemoryStream(bits);
                    Bitmap ImagemConvertida = new Bitmap(memorybits);
                    pictureBoxProduto.Image = ImagemConvertida;
                }
                catch (Exception)
                {
                    pictureBoxProduto.BackgroundImage = null;
                }

                //
                // lblDescrProduto
                //
                lblDescrProduto.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
                lblDescrProduto.Location = new System.Drawing.Point(75, 3);
                lblDescrProduto.Name = "lblDescrProduto";
                lblDescrProduto.Size = new System.Drawing.Size(108, 61);
                lblDescrProduto.TabIndex = 1;
                lblDescrProduto.Text = dr["DESCRICAO"].ToString();
                lblDescrProduto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                lblDescrProduto.Enabled = false;
                //
                // lblPrecoProd
                //
                lblPrecoProd.AutoSize = true;
                lblPrecoProd.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
                lblPrecoProd.Location = new System.Drawing.Point(141, 62);
                lblPrecoProd.Name = "lblPrecoProd";
                lblPrecoProd.Size = new System.Drawing.Size(42, 19);
                lblPrecoProd.TabIndex = 2;
                lblPrecoProd.Text = dr["ValorVenda"].ToString();
                lblPrecoProd.Enabled = false;
                lblPrecoProd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                //

                panelProduto.Click += new EventHandler(b_Click);

                this.flowLayoutPanel1.Controls.Add(panelProduto);
            }

            sqlConn.Close();
        }

        private void pesquisarGrupoNivel()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM GRUPONIVEL G WHERE G.Nivel > 1", sqlConn);

                sqlConn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                int o = dg_GrupoNivel.Rows.Count;

                while (dr.Read())
                {
                    dg_GrupoNivel.Rows.Add();
                    dg_GrupoNivel.Rows[o].Cells["col_ID"].Value = dr["ID"].ToString();
                    dg_GrupoNivel.Rows[o].Cells["col_Codigo"].Value = dr["Codigo"].ToString();
                    dg_GrupoNivel.Rows[o].Cells["col_Descricao"].Value = dr["Descricao"].ToString();

                    o++;
                }

                sqlConn.Close();

                descricaoGrupo = dg_GrupoNivel.CurrentRow.Cells[2].Value.ToString();
                label2.Text = descricaoGrupo;
                if (descricaoGrupo != null)
                {
                    descricaoGrupo = " = '" + descricaoGrupo + "'";
                }
                else
                {
                    descricaoGrupo = "is not null";
                }
            }
            catch (Exception)
            {
                carregarGrid();
            }

            carregarGrid();
        }

        private void pesquisarProduto()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM V_Produto_Venda where ID_Tabela = " + id_Tabela + " and id = " + codProd, sqlConn);

            sqlConn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            int o = dg_Itens.Rows.Count;

            while (dr.Read())
            {
                dg_Itens.Rows.Add();
                dg_Itens.Rows[o].Cells["col_Item"].Value = o + 1;
                dg_Itens.Rows[o].Cells["col_ID_Produto"].Value = dr["ID"].ToString();
                dg_Itens.Rows[o].Cells["col_Descricao_Produto"].Value = dr["Descricao"].ToString();
                dg_Itens.Rows[o].Cells["col_InfoAdicional1"].Value = dr["InfoAdicional1"].ToString();
                dg_Itens.Rows[o].Cells["col_Quantidade"].Value = "1";
                dg_Itens.Rows[o].Cells["col_Valor"].Value = dr["ValorVenda"].ToString();
                dg_Itens.Rows[o].Cells["col_ValorTotal"].Value = dr["ValorVenda"].ToString();
                dg_Itens.Rows[o].Cells["Col_ValorCusto"].Value = dr["CustoFinal"].ToString();

                o++;
            }

            sqlConn.Close();
        }

        private void Carrega_Parametro()
        {
            BLL_Parametro = new BLL_Parametro();
            Parametro = new DTO_Parametro();

            Parametro.Tipo = 2;
            Parametro.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable _DT = new DataTable();
            _DT = BLL_Parametro.Busca(Parametro);

            if (_DT.Rows.Count > 0)
            {
                Parametro_Venda.ID_TabelaVendaPadrao = Convert.ToInt32(_DT.Rows[0]["ID_TabelaVenda"]);
                Parametro_Venda.ID_ConsumidorFinal = Convert.ToInt32(_DT.Rows[0]["ID_ConsumidorFinal"]);
                Parametro_Venda.Ultimo_Valor = Convert.ToBoolean(_DT.Rows[0]["Ultimo_Valor"]);
                Parametro_Venda.Permitir2Vias = Convert.ToBoolean(_DT.Rows[0]["Permitir2Vias"]);
                Parametro_Venda.Agrupar_Produto = Convert.ToBoolean(_DT.Rows[0]["Agrupar_Produto"]);
                Parametro_Venda.Descricao_Comissao = _DT.Rows[0]["Descricao_Comissao"].ToString();
                Parametro_Venda.Limite_Desconto = Convert.ToDouble(_DT.Rows[0]["Limite_Desconto"]);
                Parametro_Venda.Produto_Marca = Convert.ToBoolean(_DT.Rows[0]["Produto_Marca"]);
                Parametro_Venda.Bloquear_EstoqueNegativo = Convert.ToBoolean(_DT.Rows[0]["Bloquear_EstoqueNegativo"]);
                Parametro_Venda.msg_EstoqueNegativo = Convert.ToBoolean(_DT.Rows[0]["msg_EstoqueNegativo"]);
                Parametro_Venda.Orca_ValorTotal = Convert.ToBoolean(_DT.Rows[0]["Orca_ValorTotal"]);
                Parametro_Venda.MultiploUsuarioPDV = Convert.ToBoolean(_DT.Rows[0]["MultiploUsuarioPDV"]);
                Parametro_Venda.Consulta_RapidaProduto = Convert.ToBoolean(_DT.Rows[0]["Consulta_RapidaProduto"]);
            }
        }

        private void totalizador()
        {
            subtotal = 0;
            lblTotal.Text = "0,00";
            for (int i = 0; i < dg_Itens.Rows.Count; i++)
            {
                subtotal = subtotal + Convert.ToDecimal(dg_Itens.Rows[i].Cells["col_Valor"].Value);
                lblTotal.Text = Convert.ToString(subtotal);
            }
        }

        private void Limpa_Campos()
        {
            codProd = null;
            subtotal = 0;
            idUltimaVenda = null;
            lblTotal.Text = "0,00";
            dg_Itens.Rows.Clear();
            pagamentoEfetuado = null;
        }

        private void Inicia_Form()
        {
            this.Text = "PONTO DE VENDA";

            DataHora.Enabled = true;
            DataHora.Start();

            Carrega_Parametro();

            Limpa_Campos();
            pesquisarGrupoNivel();
            retornarSeqVenda();
            // carregarGrid();
        }

        private void Imprime(int ID_Venda)
        {
            if (ID_Venda == 0)
            {
                MessageBox.Show(util_msg.msg_NenhumRegistro, this.Text);
                return;
            }

            LocalReport rpt = new LocalReport();

            string rpt_Nome = string.Empty;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();
            Endereco = new DTO_Pessoa_Endereco();
            Telefone = new DTO_Pessoa_Telefone();
            Email = new DTO_Pessoa_Email();

            Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

            DataTable DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            BLL_Venda = new BLL_Venda();
            Venda = new DTO_Venda();

            Venda.ID = ID_Venda;

            DataTable DTR_Venda = BLL_Venda.Busca_Relatorio(Venda);
            DataTable DTR_ItemPedido = BLL_Venda.Busca_Item(Venda);
            DataTable DTR_Financeiro = BLL_Venda.Busca_Financeiro(Venda);

            string Financeiro = string.Empty;
            string TipoPagto = string.Empty;

            if (DTR_Financeiro.Rows.Count > 0)
            {
                for (int i = 0; i <= DTR_Financeiro.Rows.Count - 1; i++)
                {
                    if (TipoPagto != DTR_Financeiro.Rows[i]["PrevisaoPagto"].ToString())
                    {
                        TipoPagto = DTR_Financeiro.Rows[i]["PrevisaoPagto"].ToString();

                        Financeiro += DTR_Financeiro.Rows[i]["PrevisaoPagto"] + "(" + util_dados.Config_Data(DateTime.Parse(DTR_Financeiro.Rows[i]["Vencimento"].ToString()), 3)
                                          + " - R$ " + util_dados.ConfigNumDecimal(DTR_Financeiro.Rows[i]["Valor"], 2) + ")";
                    }
                    else
                        Financeiro += "(" + util_dados.Config_Data(DateTime.Parse(DTR_Financeiro.Rows[i]["Vencimento"].ToString()), 3)
                                    + " - R$ " + util_dados.ConfigNumDecimal(DTR_Financeiro.Rows[i]["Valor"], 2) + ")";
                }
            }
            else
                Financeiro = string.Empty;

            if (DTR_ItemPedido.Rows.Count <= 11 &&
                Parametro_Venda.Permitir2Vias == true &&
                Parametro_Venda.TipoImpressoraTermica == 0)
            {
                rpt_Nome = "rpt_Venda2.rdlc";
                for (int i = DTR_ItemPedido.Rows.Count; i <= 11; i++)
                {
                    DTR_ItemPedido.Rows.Add();
                    DTR_ItemPedido.Rows[i]["DescricaoProduto"] = "";
                    DTR_ItemPedido.Rows[i]["ValorVenda"] = 0;
                    DTR_ItemPedido.Rows[i]["Quantidade"] = 0;
                    DTR_ItemPedido.Rows[i]["Desconto"] = 0;
                    DTR_ItemPedido.Rows[i]["Acrescimo"] = 0;
                    DTR_ItemPedido.AcceptChanges();
                }
            }
            else
                rpt_Nome = "rpt_Venda.rdlc";

            if (Parametro_Venda.TipoImpressoraTermica == 1)
                rpt_Nome = "rpt_Venda_Termica.rdlc";

            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            rpt.ReportPath = Caminhorpt;

            Pessoa.TipoPessoa = 1;
            Pessoa.ID = Convert.ToInt32(idPessoa);
            DataTable DTR_Pessoa = BLL_Pessoa.Busca_Relatorio(Pessoa);

            Endereco.Principal = true;
            Pessoa.Endereco.Add(Endereco);
            DataTable DTR_Endereco = BLL_Pessoa.Busca_Endereco(Pessoa);

            Telefone.Principal = true;
            Pessoa.Telefone.Add(Telefone);
            DataTable DTR_Telefone = BLL_Pessoa.Busca_Telefone(Pessoa);

            Email.Principal = true;
            Pessoa.Email.Add(Email);
            DataTable DTR_Email = BLL_Pessoa.Busca_Email(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
            ReportDataSource ds_Pedido = new ReportDataSource("ds_Venda_Pedido", DTR_Venda);
            ReportDataSource ds_ItemPedido = new ReportDataSource("ds_Item_Pedido", DTR_ItemPedido);
            ReportDataSource ds_Pessoa = new ReportDataSource("ds_Pessoa_Pessoa", DTR_Pessoa);
            ReportDataSource ds_Endereco = new ReportDataSource("ds_Pessoa_Endereco", DTR_Endereco);
            ReportDataSource ds_Telefone = new ReportDataSource("ds_Pessoa_Telefone", DTR_Telefone);
            ReportDataSource ds_Email = new ReportDataSource("ds_Pessoa_Email", DTR_Email);

            ReportParameter p1 = new ReportParameter("FormaPagto", Financeiro);
            ReportParameter p2 = new ReportParameter("TotalPedido", util_dados.ConfigNumDecimal(lblTotal.Text, 3));
            ReportParameter p3 = new ReportParameter("Vendedor", Convert.ToString(contadorDeVendas));

            rpt.DataSources.Add(ds_Empresa);
            rpt.DataSources.Add(ds_Pedido);
            rpt.DataSources.Add(ds_ItemPedido);
            rpt.DataSources.Add(ds_Pessoa);
            rpt.DataSources.Add(ds_Endereco);
            rpt.DataSources.Add(ds_Telefone);
            rpt.DataSources.Add(ds_Email);

            rpt.SetParameters(new ReportParameter[] { p1, p2, p3 });
            rpt.Refresh();
            string Impressora = string.Empty;
            PrintDialog EscolheImpressora = new PrintDialog();
            //if (EscolheImpressora.ShowDialog() == DialogResult.OK)
            //{
            PrintDocument documento = new PrintDocument();
            documento.PrinterSettings.PrinterName = EscolheImpressora.PrinterSettings.PrinterName;
            documento.PrinterSettings.Copies = 2;
            util_Impressao imp = util_Impressao.Novo(rpt);

            if (Parametro_Venda.TipoImpressoraTermica == 1)
                imp.Imprimir(documento, Tipo_Impressao.Termica);
            else
                imp.Imprimir(documento, Tipo_Impressao.Retrato);
            imp = null;
            //}
        }

        private void ResumoVenda()
        {
            try
            {
                UI_Visualiza_Relatorio rpt = new UI_Visualiza_Relatorio();

                string rpt_Nome = "rpt_Venda_ResumoSimples.rdlc";

                if (Parametro_Venda.TipoImpressoraTermica == 1)
                {
                    DialogResult msgbox = MessageBox.Show(util_msg.msg_ConfirmaImpressaoA4, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                        rpt_Nome = "rpt_Venda_ResumoSimples_Termica.rdlc";
                }

                string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
                rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

                BLL_Pessoa = new BLL_Pessoa();
                Pessoa = new DTO_Pessoa();

                Pessoa.ID = Parametro_Empresa.ID_Empresa_Ativa;

                DataTable _DT_Empresa = new DataTable();
                _DT_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

                BLL_Venda = new BLL_Venda();
                Venda = new DTO_Venda();

                Venda.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;

                /* if (Convert.ToInt32(cb_Situacao.SelectedValue) > 0)
                 {
                     if (Convert.ToInt32(cb_Situacao.SelectedValue) == 3)
                     {
                         Venda.Pesquisa_Cancelado = true;
                         Venda.Cancelado = true;
                     }
                     else
                     {
                         Venda.Pesquisa_Faturado = true;
                         if (Convert.ToInt32(cb_Situacao.SelectedValue) == 1)
                             Venda.Faturado = true;
                         else
                             Venda.Faturado = false;
                     }
                 }*/

                /*if (Convert.ToInt32(cb_NFe.SelectedValue) > 0)
                {
                    Venda.Pesquisa_EmitidoNFe = true;
                    if (Convert.ToInt32(cb_NFe.SelectedValue) == 1)
                        Venda.NFe = true;
                    else
                        Venda.NFe = false;
                }
                */

                /*switch (cb_Periodo.Text)
                {
                    case "EMISSÃO":
                        Venda.Consulta_Emissao.Filtra = true;
                        Venda.Consulta_Emissao.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                        Venda.Consulta_Emissao.Final = Convert.ToDateTime(mk_DataFinal.Text);
                        break;

                    case "FATURAMENTO":
                        Venda.Consulta_Fatura.Filtra = true;
                        Venda.Consulta_Fatura.Inicial = Convert.ToDateTime(mk_DataInicial.Text);
                        Venda.Consulta_Fatura.Final = Convert.ToDateTime(mk_DataFinal.Text);
                        break;
                }*/

                Venda.Consulta_Fatura.Filtra = true;
                Venda.Consulta_Fatura.Inicial = DateTime.Now;
                Venda.Consulta_Fatura.Final = DateTime.Now;

                ReportDataSource ds_Empresa;
                ReportDataSource ds_TotalVenda;

                ReportParameter p1;
                ReportParameter p2;
                ReportParameter p3;

                DataTable _DT_Venda = new DataTable();

                _DT_Venda = BLL_Venda.Busca_TotalVenda(Venda);
                int aux_cont = 0;
                int aux_ID = 0;
                for (int i = 0; i <= _DT_Venda.Rows.Count - 1; i++)
                {
                    int aux = int.Parse(_DT_Venda.Rows[i]["ID_Venda"].ToString());

                    if (aux == aux_ID)
                    {
                        if (aux_cont > 0)
                        {
                            _DT_Venda.Rows[i]["ID_Venda"] = DBNull.Value;
                            _DT_Venda.Rows[i]["Data"] = DBNull.Value;
                            _DT_Venda.Rows[i]["Descricao"] = DBNull.Value;
                            _DT_Venda.Rows[i]["DescricaoUsuarioComissao1"] = DBNull.Value;
                            _DT_Venda.Rows[i]["DescricaoUsuarioComissao2"] = DBNull.Value;
                            _DT_Venda.Rows[i]["ValorTotal"] = DBNull.Value;
                            _DT_Venda.Rows[i]["CustoTotal"] = DBNull.Value;
                            _DT_Venda.Rows[i]["Faturado"] = DBNull.Value;
                        }
                        else
                            aux_cont = aux_cont + 1;
                    }
                    else
                    {
                        aux_ID = int.Parse(_DT_Venda.Rows[i]["ID_Venda"].ToString());
                        aux_cont = aux_cont + 1;
                    }
                }

                ds_Empresa = new ReportDataSource("Emitente", _DT_Empresa);
                ds_TotalVenda = new ReportDataSource("ResumoVenda", _DT_Venda);

                p1 = new ReportParameter("Periodo", DateTime.Now.ToShortDateString() + " À " + DateTime.Now.ToShortDateString());
                p2 = new ReportParameter("Comissao1", Parametro_Venda.Descricao_Comissao);
                p3 = new ReportParameter("Comissao2", Parametro_Venda.Descricao_Comissao);

                rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
                rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_TotalVenda);

                rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3 });

                rpt.rpt_Viewer.RefreshReport();

                rpt.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void UI_PDV_II_Load(object sender, EventArgs e)
        {
            Inicia_Form();
            try
            {
                #region LOGO RELATÓRIO

                BLL_Imagem = new BLL_Imagem();
                Imagem = new DTO_Imagem();
                Imagem.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Imagem.Tipo = 1;

                DataTable _DT = new DataTable();

                _DT = BLL_Imagem.Busca(Imagem);
                byte[] bits = (byte[])(_DT.Rows[0][0]);

                MemoryStream memorybits = new MemoryStream(bits);
                Bitmap ImagemConvertida = new Bitmap(memorybits);

                #endregion LOGO RELATÓRIO

                #region LOGO EMPRESA

                Imagem = new DTO_Imagem();
                Imagem.ID_Empresa = Parametro_Empresa.ID_Empresa_Ativa;
                Imagem.Tipo = 2;

                _DT = new DataTable();

                _DT = BLL_Imagem.Busca(Imagem);

                bits = (byte[])(_DT.Rows[0][0]);
                memorybits = new MemoryStream(bits);
                ImagemConvertida = new Bitmap(memorybits);
                pBox_Imagen_Principal.Image = ImagemConvertida;

                #endregion LOGO EMPRESA
            }
            catch (Exception ex)
            {
                MessageBox.Show(util_msg.msg_Erro + ex.Message, this.Text);
            }
        }

        private void b_Click(object sender, EventArgs e)
        {
            id_Tabela = 1;

            Panel b = sender as Panel;
            codProd = b.Name;

            if (b.BackColor != Color.White)
                id_Tabela = 2;

            pesquisarProduto();
            totalizador();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dg_Itens.Rows.Clear();
            totalizador();
        }

        private void btnRemoverItem_Click(object sender, EventArgs e)
        {
            if (dg_Itens.RowCount == 0)
            {
                return;
            }
            try
            {
                dg_Itens.Rows.RemoveAt(Convert.ToInt32(dg_Itens.CurrentRow.Cells["Col_Item"].Value.ToString()) - 1);
                for (int i = 0; i < dg_Itens.Rows.Count; i++)
                {
                    dg_Itens.Rows[i].Cells["Col_Item"].Value = i + 1;
                }
            }
            catch (Exception)
            {
            }
            totalizador();
        }

        private void retornaUltimaVenda()
        {
            SqlCommand cmd = new SqlCommand("SELECT MAX(ID) FROM VENDA", sqlConn);

            sqlConn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                idUltimaVenda = dr[0].ToString();
            }

            sqlConn.Close();
        }

        private void gravarSeqVenda()
        {
            //definição do comando sql
            string sql = "INSERT INTO VENDA_SEQUENCIA (SEQ, ID_Usuario_Sistema) VALUES (@SEQ, @ID_Usuario_Sistema)";

            SqlCommand comando = new SqlCommand(sql, sqlConn);
            comando.Parameters.Add(new SqlParameter("ID_Usuario_Sistema", Parametro_Usuario.ID_Usuario_Ativo));
            comando.Parameters.Add(new SqlParameter("SEQ", contadorDeVendas + 1));
            sqlConn.Open();
            comando.ExecuteNonQuery();
            sqlConn.Close();
        }

        private void zerarSeqVenda()
        {
            //definição do comando sql
            string sql = "INSERT INTO VENDA_SEQUENCIA (SEQ, ID_Usuario_Sistema) VALUES (@SEQ, @ID_Usuario_Sistema)";

            SqlCommand comando = new SqlCommand(sql, sqlConn);
            comando.Parameters.Add(new SqlParameter("ID_Usuario_Sistema", Parametro_Usuario.ID_Usuario_Ativo));
            comando.Parameters.Add(new SqlParameter("SEQ", "0"));
            sqlConn.Open();
            comando.ExecuteNonQuery();
            sqlConn.Close();
        }

        private void retornarSeqVenda()
        {
            SqlCommand cmd = new SqlCommand($"SELECT TOP 1 * FROM Venda_Sequencia WHERE  ID_Usuario_Sistema = {Parametro_Usuario.ID_Usuario_Ativo}  ORDER BY ID DESC ", sqlConn);

            sqlConn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                contadorDeVendas = Convert.ToInt32(dr[1].ToString());
                label1.Text = "Venda Balcão Nº " + (contadorDeVendas + 1);
            }

            sqlConn.Close();
        }

        private void gravarVenda()
        {
            //definição do comando sql
            string sql = " INSERT INTO VENDA     ( ID_EMPRESA             " +
                                                " ,TIPOPESSOA             " +
                                                " ,ID_Pessoa              " +
                                                " ,Data                   " +
                                                " ,Entrega                " +
                                                " ,Informacao             " +
                                                " ,ID_UsuarioComissao1    " +
                                                " ,ID_UsuarioComissao2    " +
                                                " ,DataFatura             " +
                                                " ,Comprador              " +
                                                " ,Faturado               " +
                                                " ,NFe                    " +
                                                " ,ID_Pagamento           " +
                                                " ,ID_Parcelamento        " +
                                                " ,Cancelado              " +
                                                " ,Situacao_Entrega       " +
                                                " ,Situacao_Conferencia   " +
                                                " ,ID_Usuario_Conferencia " +
                                                " ,CPF_CNPJ               " +
                                                " ,ID_NFe                 " +
                                                " ,ID_CFe                 " +
                                                " ,ID_Usuario_Sistema     " +
                                                " ,SEQVENDA )               " +
                                                " VALUES (                " +
                                                "  @ID_EMPRESA             " +
                                                " ,@TIPOPESSOA             " +
                                                " ,@ID_Pessoa              " +
                                                " ,@Data                   " +
                                                " ,@Entrega                " +
                                                " ,@Informacao             " +
                                                " ,@ID_UsuarioComissao1    " +
                                                " ,@ID_UsuarioComissao2    " +
                                                " ,@DataFatura             " +
                                                " ,@Comprador              " +
                                                " ,@Faturado               " +
                                                " ,@NFe                    " +
                                                " ,@ID_Pagamento           " +
                                                " ,@ID_Parcelamento        " +
                                                " ,@Cancelado              " +
                                                " ,@Situacao_Entrega       " +
                                                " ,@Situacao_Conferencia   " +
                                                " ,@ID_Usuario_Conferencia " +
                                                " ,@CPF_CNPJ               " +
                                                " ,@ID_NFe                 " +
                                                " ,@ID_CFe                 " +
                                                " ,@ID_Usuario_Sistema     " +
                                                " ,@SEQVENDA  )            ";

            SqlCommand comando = new SqlCommand(sql, sqlConn);
            comando.Parameters.Add(new SqlParameter("ID_EMPRESA", "1"));
            comando.Parameters.Add(new SqlParameter("TIPOPESSOA", "1"));
            comando.Parameters.Add(new SqlParameter("ID_Pessoa", idPessoa));
            comando.Parameters.Add(new SqlParameter("Data", DateTime.Now.ToShortDateString()));
            comando.Parameters.Add(new SqlParameter("Entrega", DateTime.Now.ToShortDateString()));
            comando.Parameters.Add(new SqlParameter("Informacao", "PDV Gourmet"));
            comando.Parameters.Add(new SqlParameter("ID_UsuarioComissao1", Parametro_Usuario.ID_Usuario_Ativo));
            comando.Parameters.Add(new SqlParameter("ID_UsuarioComissao2", "0"));
            comando.Parameters.Add(new SqlParameter("DataFatura", DateTime.Now.ToShortDateString()));
            comando.Parameters.Add(new SqlParameter("Comprador", ""));
            comando.Parameters.Add(new SqlParameter("Faturado", "1"));
            comando.Parameters.Add(new SqlParameter("NFe", "0"));
            comando.Parameters.Add(new SqlParameter("ID_Pagamento", "0"));
            comando.Parameters.Add(new SqlParameter("ID_Parcelamento", "0"));
            comando.Parameters.Add(new SqlParameter("Cancelado", "0"));
            comando.Parameters.Add(new SqlParameter("Situacao_Entrega", "0"));
            comando.Parameters.Add(new SqlParameter("Situacao_Conferencia", "0"));
            comando.Parameters.Add(new SqlParameter("ID_Usuario_Conferencia", ""));
            comando.Parameters.Add(new SqlParameter("CPF_CNPJ", ""));
            comando.Parameters.Add(new SqlParameter("ID_NFe", ""));
            comando.Parameters.Add(new SqlParameter("ID_CFe", ""));
            comando.Parameters.Add(new SqlParameter("ID_Usuario_Sistema", Parametro_Usuario.ID_Usuario_Ativo));
            comando.Parameters.Add(new SqlParameter("SEQVENDA", contadorDeVendas));

            sqlConn.Open();
            comando.ExecuteNonQuery();
            sqlConn.Close();
        }

        private void gravarVenda_Item()
        {
            for (int i = 0; i < dg_Itens.RowCount; i++)
            {
                string sql = " INSERT INTO Venda_Item (       " +
                                   "  ID_Produto            " +
                                   " ,ID_Venda              " +
                                   " ,Quantidade            " +
                                   " ,ID_Tabela             " +
                                   " ,ValorProduto          " +
                                   " ,Informacao            " +
                                   " ,ValorVenda            " +
                                   " ,TipoSaida             " +
                                   " ,ID_Grade              " +
                                   " ,ValorCusto            " +
                                   " ,Quantidade_Entregue   " +
                                   " ,Quantidade_Conferido )  " +
                                   " VALUES (               " +
                                   "  @ID_Produto            " +
                                   " ,@ID_Venda              " +
                                   " ,@Quantidade            " +
                                   " ,@ID_Tabela             " +
                                   " ,@ValorProduto          " +
                                   " ,@Informacao            " +
                                   " ,@ValorVenda            " +
                                   " ,@TipoSaida             " +
                                   " ,@ID_Grade              " +
                                   " ,@ValorCusto            " +
                                   " ,@Quantidade_Entregue   " +
                                   " ,@Quantidade_Conferido )";

                SqlCommand comando = new SqlCommand(sql, sqlConn);
                comando.Parameters.Add(new SqlParameter("ID_Produto", Convert.ToInt32(dg_Itens.Rows[i].Cells["col_ID_Produto"].Value)));
                comando.Parameters.Add(new SqlParameter("ID_Venda", idUltimaVenda));
                comando.Parameters.Add(new SqlParameter("Quantidade", Convert.ToInt32(dg_Itens.Rows[i].Cells["col_Quantidade"].Value)));
                comando.Parameters.Add(new SqlParameter("ID_Tabela", Convert.ToInt32("1")));
                comando.Parameters.Add(new SqlParameter("ValorProduto", Convert.ToDecimal(dg_Itens.Rows[i].Cells["col_Valor"].Value)));
                comando.Parameters.Add(new SqlParameter("Informacao", dg_Itens.Rows[i].Cells["col_InfoAdicional1"].Value));
                comando.Parameters.Add(new SqlParameter("ValorVenda", Convert.ToDecimal(dg_Itens.Rows[i].Cells["col_Valor"].Value)));
                comando.Parameters.Add(new SqlParameter("TipoSaida", Convert.ToInt32("0")));
                comando.Parameters.Add(new SqlParameter("ID_Grade", Convert.ToInt32("1")));
                comando.Parameters.Add(new SqlParameter("ValorCusto", Convert.ToDecimal(dg_Itens.Rows[i].Cells["Col_ValorCusto"].Value)));
                comando.Parameters.Add(new SqlParameter("Quantidade_Entregue", Convert.ToInt32(dg_Itens.Rows[i].Cells["col_Quantidade"].Value)));
                comando.Parameters.Add(new SqlParameter("Quantidade_Conferido", Convert.ToInt32("0")));

                sqlConn.Open();
                comando.ExecuteNonQuery();
                sqlConn.Close();
                //definição do comando sql
            }
        }

        private void gravarCReceber()
        {
            //definição do comando sql
            string sql = " INSERT INTO CReceber (" +
                                   "  Descricao         " +
                                   " ,ID_Venda          " +
                                   " ,ID_EMPRESA        " +
                                   " ,ID_Conta          " +
                                   " ,GrupoConta        " +
                                   " ,Situacao          " +
                                   " ,Documento         " +
                                   " ,Emissao           " +
                                   " ,Vencimento        " +
                                   " ,TIPOPESSOA        " +
                                   " ,ID_Pessoa         " +
                                   " ,Valor             " +
                                   " ,Parcelado         " +
                                   " ,QuantidadeParcela " +
                                   " ,Parcela           " +
                                   " ,DataBaixa         " +
                                   " ,Desconto          " +
                                   " ,Acrescimo         " +
                                   " ,Caixa             " +
                                   " ,ID_Pagamento      " +
                                   " ,InformacaoBaixa   " +
                                   " ,Controle          " +
                                   " ,Boleto            " +
                                   " ,ID_PrevisaoPagto  " +
                                   " ,ID_OS )           " +
                                   "VALUES (            " +
                                    " @Descricao        " +
                                   " ,@ID_Venda          " +
                                   " ,@ID_EMPRESA        " +
                                   " ,@ID_Conta          " +
                                   " ,@GrupoConta        " +
                                   " ,@Situacao          " +
                                   " ,@Documento         " +
                                   " ,@Emissao           " +
                                   " ,@Vencimento        " +
                                   " ,@TIPOPESSOA        " +
                                   " ,@ID_Pessoa         " +
                                   " ,@Valor             " +
                                   " ,@Parcelado         " +
                                   " ,@QuantidadeParcela " +
                                   " ,@Parcela           " +
                                   " ,@DataBaixa         " +
                                   " ,@Desconto          " +
                                   " ,@Acrescimo         " +
                                   " ,@Caixa             " +
                                   " ,@ID_Pagamento      " +
                                   " ,@InformacaoBaixa   " +
                                   " ,@Controle          " +
                                   " ,@Boleto            " +
                                   " ,@ID_PrevisaoPagto  " +
                                   " ,@ID_OS     )        ";

            SqlCommand comando = new SqlCommand(sql, sqlConn);
            comando.Parameters.Add(new SqlParameter("Descricao", "PEDIDO Nº" + idUltimaVenda));
            comando.Parameters.Add(new SqlParameter("ID_Venda", idUltimaVenda));
            comando.Parameters.Add(new SqlParameter("ID_EMPRESA", "1"));
            comando.Parameters.Add(new SqlParameter("ID_Conta", "2"));
            comando.Parameters.Add(new SqlParameter("GrupoConta", ""));
            comando.Parameters.Add(new SqlParameter("Situacao ", "2"));
            comando.Parameters.Add(new SqlParameter("Documento", idUltimaVenda));
            comando.Parameters.Add(new SqlParameter("Emissao", DateTime.Now.ToShortDateString()));
            comando.Parameters.Add(new SqlParameter("Vencimento", DateTime.Now.ToShortDateString()));
            comando.Parameters.Add(new SqlParameter("TIPOPESSOA", "1"));
            comando.Parameters.Add(new SqlParameter("ID_Pessoa", idPessoa));
            comando.Parameters.Add(new SqlParameter("Valor ", Convert.ToDecimal(lblTotal.Text)));
            comando.Parameters.Add(new SqlParameter("Parcelado", "0"));
            comando.Parameters.Add(new SqlParameter("QuantidadeParcela", "1"));
            comando.Parameters.Add(new SqlParameter("Parcela", "1"));
            comando.Parameters.Add(new SqlParameter("DataBaixa", DateTime.Now.ToShortDateString()));
            comando.Parameters.Add(new SqlParameter("Desconto", Convert.ToDecimal("0,00")));
            comando.Parameters.Add(new SqlParameter("Acrescimo", Convert.ToDecimal("0,00")));
            comando.Parameters.Add(new SqlParameter("Caixa", ""));
            comando.Parameters.Add(new SqlParameter("ID_Pagamento", ""));
            comando.Parameters.Add(new SqlParameter("InformacaoBaixa", ""));
            comando.Parameters.Add(new SqlParameter("Controle", "0"));
            comando.Parameters.Add(new SqlParameter("Boleto", "0"));
            comando.Parameters.Add(new SqlParameter("ID_PrevisaoPagto", Moeda));
            comando.Parameters.Add(new SqlParameter("ID_OS", "0"));

            sqlConn.Open();
            comando.ExecuteNonQuery();
            sqlConn.Close();
        }

        private void btnPagamento_Click(object sender, EventArgs e)
        {
            if (lblTotal.Text != "0,00")
            {
                UI_PDV_II_FINALIZAR a = new UI_PDV_II_FINALIZAR(this);
                a.tboxValorTotal.Text = this.lblTotal.Text;
                a.ShowDialog();

                if (pagamentoEfetuado == "SIM")
                {
                    gravarSeqVenda();
                    retornarSeqVenda();
                    gravarVenda();
                    retornaUltimaVenda();

                    gravarVenda_Item();
                    gravarCReceber();
                    Imprime(Convert.ToInt32(idUltimaVenda));
                    Limpa_Campos();
                    retornarSeqVenda();
                }
            }
        }

        private void UI_PDV_II_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            string cellAtual = dg_GrupoNivel.CurrentRow.Cells[1].Value.ToString();
            int varlinha = 0;

            try
            {
                if (dg_GrupoNivel.CurrentRow.Cells[1].Value.ToString() == cellAtual)
                {
                    varlinha = dg_GrupoNivel.CurrentRow.Index;
                    varlinha += 1;
                    dg_GrupoNivel.CurrentCell = dg_GrupoNivel.Rows[varlinha].Cells[0];
                }
            }
            catch (Exception)
            {
                dg_GrupoNivel.CurrentCell = dg_GrupoNivel.Rows[0].Cells[0];
            }
            descricaoGrupo = dg_GrupoNivel.CurrentRow.Cells[2].Value.ToString();

            label2.Text = descricaoGrupo;

            descricaoGrupo = " = '" + descricaoGrupo + "'";
            carregarGrid();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            string cellAtual = dg_GrupoNivel.CurrentRow.Cells[1].Value.ToString();
            int varlinha = 0;

            try
            {
                if (dg_GrupoNivel.CurrentRow.Cells[1].Value.ToString() == cellAtual)
                {
                    varlinha = dg_GrupoNivel.CurrentRow.Index;
                    varlinha += -1;
                    dg_GrupoNivel.CurrentCell = dg_GrupoNivel.Rows[varlinha].Cells[0];
                }
            }
            catch (Exception)
            {
                dg_GrupoNivel.CurrentCell = dg_GrupoNivel.Rows[dg_GrupoNivel.RowCount - 1].Cells[0];
            }
            descricaoGrupo = dg_GrupoNivel.CurrentRow.Cells[2].Value.ToString();

            label2.Text = descricaoGrupo;

            descricaoGrupo = " = '" + descricaoGrupo + "'";
            carregarGrid();
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            label2.Text = "TODOS";

            descricaoGrupo = " <> '' ";
            carregarGrid();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Zerar Sequencia de vendas?", "Clever Sistemas", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                zerarSeqVenda();
                retornarSeqVenda();
            }
        }

        private void bntConfiguracao_Click(object sender, EventArgs e)
        {
            if (exibirPromocao)
            {
                exibirPromocao = false;
            }
            else
            {
                exibirPromocao = true;
            }
            carregarGrid();
        }
    }
}