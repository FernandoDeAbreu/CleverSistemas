using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.UI
{
    public static class Info
    {
        #region MENSAGENS DIVERSAS
        public static string msg_Grava = "Dados salvos com sucesso!";
        public static string msg_Altera = "Dados alterados com sucesso!";
        public static string msg_GravaID = "Dados salvos com sucesso!\nCódigo: ";
        public static string msg_Exclui = "Dados excluídos com sucesso!";
        public static string msg_Erro = "Ocorreu um erro!\n";
        public static string msg_ConfirmaExclusao = "Confirma exclusão do registro?";
        public static string msg_Novo_Lancamento = "Atenção!\nOs dados não salvos serão perdidos!\nContinuar?";
        #endregion

        #region ABERTURA DE FORM
        #region PAIS, UF, MUNICÍPIO
        //1 - Pais
        //2 - UF
        //3 - Municipio
        #endregion

        #region GRUPO SIMPLES
        /*
        1 - Cliente
        2 - Transportadora
        3 - Fornecedor
        4 - Funcionario
        5 - Empresa
        6 - Endereço
        7 - Telefone
        8 - e-mail
        9 - Caixa
        10 - OSPrioridade
        11 - OSModalidade
        12 - OSAtendimento
        13 - OSFabricante
        14 - OSSituação
        15 - OSEquipamento
        16 - Unidade Tributável
        17 - Tipo de Usuário
        18 - Situação
        19 - Situação CPagar
        20 - Situação CReceber
        21 - Situação Pedidos/Orçamentos
        22 - Tipo Documento Ordem de Compra
        23 - Situação Ordem de Compra
        24 - Situação Pedidos Mobile
        25 - Situação Cheques
        26 - Tipo de Venda de Produtos
        27 - Grade
        28 - Comodato
        29 - Tipo Folha de Pagamento
        30 - Tipo Nota Fiscal
        31 - Tipo Documento Contábil
        
        */
        #endregion

        #region TIPO DE CPAGAR E CRECEBER
        /*
        1 - Lançamento
        2 - Baixar/Alterar
        */
        #endregion

        #region TIPO DE PESSOA
        /*
        1 - Cliente
        2 - Empresa    
        3 - Fornecedores
        4 - Funcionários
        5 - Transportadora
        6 - Responsável
        */
        #endregion

        #region CHEQUES
        /*
        1 - Emitidos
        2 - Recebidos
        */
        #endregion
        #endregion

        #region SITUAÇÃO NF-e
        /*
        1 - Assinada
        2 - Autorizada
        3 - Cancelada
        4 - Denegada
        5 - Em Digitação
        6 - Validada
        7 - Exportada .txt
        */
        #endregion

        #region EXEMPLOS DE ROTINAS
        #region CARREGAR FORM SEM BOTÕES
        /*
        tabctl.TabPages.Remove(TabPage2);
        bt_Imprimir.Visible = false;
        bt_Excluir.Visible = false;
        bt_Localizar.Visible = false;
        bt_Novo.Visible = false;
        bt_Salvar.Visible = false;
        tabctl.SelectedTab = TabPage1;
        combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        dg_Itens.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
        dg_Itens.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
        dg_Itens.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
        dg_Itens.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
        dg_Itens.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
        */
        #endregion

        #region Impressão de Relatórios com Visualização
        /*
            frm_Relatorio frm_rpt = new frm_Relatorio();
            string rpt_Nome = "rpt_Pedido.rdlc";
            string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
            frm_rpt.rpt_Viewer.LocalReport.ReportPath = Caminhorpt;

            BLL_Pessoa = new BLL_Pessoa();
            Pessoa = new DTO_Pessoa();
            Endereco = new DTO_Pessoa_Endereco();
            Telefone = new DTO_Pessoa_Telefone();
            Email = new DTO_Pessoa_Email();

            Pessoa.ID = Parametros.IDEmpresa;

            DTR_Empresa = BLL_Pessoa.Busca_Info_Relatorio(Pessoa);

            BLL_Pedido = new BLL_Pedido();
            Pedido = new DTO_Pedido();

            Pedido.ID = Rotinas.Verifica_int(txt_ID.Text);

            DTR_Pedido = BLL_Pedido.Busca_Relatorio(Pedido);
            DTR_ItemPedido = BLL_Pedido.Busca_Item(Pedido);

            Pessoa.TipoPessoa = Convert.ToInt32(cb_TipoPessoa.SelectedValue);
            Pessoa.ID = Convert.ToInt32(cb_ID_Pessoa.SelectedValue);
            DTR_Pessoa = BLL_Pessoa.Busca_Relatorio(Pessoa);

            Endereco.Principal = true;
            Pessoa.Endereco.Add(Endereco);
            DTR_Endereco = BLL_Pessoa.Busca_Endereco(Pessoa);

            Telefone.Principal = true;
            Pessoa.Telefone.Add(Telefone);
            DTR_Telefone = BLL_Pessoa.Busca_Telefone(Pessoa);

            Email.Principal = true;
            Pessoa.Email.Add(Email);
            DTR_Email = BLL_Pessoa.Busca_Email(Pessoa);

            ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
            ReportDataSource ds_Pedido = new ReportDataSource("ds_Venda_Pedido", DTR_Pedido);
            ReportDataSource ds_ItemPedido = new ReportDataSource("ds_Item_Pedido", DTR_ItemPedido);
            ReportDataSource ds_Pessoa = new ReportDataSource("ds_Pessoa_Pessoa", DTR_Pessoa);
            ReportDataSource ds_Endereco = new ReportDataSource("ds_Pessoa_Endereco", DTR_Endereco);
            ReportDataSource ds_Telefone = new ReportDataSource("ds_Pessoa_Telefone", DTR_Telefone);
            ReportDataSource ds_Email = new ReportDataSource("ds_Pessoa_Email", DTR_Email);

            ReportParameter p1 = new ReportParameter("FormaPagto", cb_ID_Pagamento.Text);
            ReportParameter p2 = new ReportParameter("TotalPedido", Rotinas.ConfigNumDecimal(txt_ValorPedido.Text, 3));
            ReportParameter p3 = new ReportParameter("Vendedor", cb_ID_UsuarioComissao1.Text);

            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Empresa);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Pedido);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_ItemPedido);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Pessoa);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Endereco);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Telefone);
            frm_rpt.rpt_Viewer.LocalReport.DataSources.Add(ds_Email);
            frm_rpt.rpt_Viewer.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3 });

            frm_rpt.rpt_Viewer.RefreshReport();
            frm_rpt.Show();
        */
        #endregion

        #region Impressão de relatórios sem Visualização
        /*
        LocalReport rpt = new LocalReport();

        string Caminhorpt = Parametro_Sistema.Caminho_Relatorio + rpt_Nome;
        rpt.ReportPath = Caminhorpt;

        negocioEmpresa = new negocio_Pessoa();
        DTR_Empresa = negocioEmpresa.Busca_Info_Relatorio(Parametros.IDEmpresa);

        if (negocioPessoa == null)
             negocioPessoa = new negocio_Pessoa();
        DTR_Pessoa = negocioPessoa.Busca_Relatorio_Pessoa(Convert.ToInt32(DRBoleto["TipoPessoa"]), Convert.ToInt32(DRBoleto["ID_Pessoa"]), 0, 0);

        ReportDataSource ds_Empresa = new ReportDataSource("ds_InfoEmitente", DTR_Empresa);
        ReportDataSource ds_Pessoa = new ReportDataSource("ds_InfoPessoa", DTR_Pessoa);
        ReportDataSource ds_Boleto = new ReportDataSource("ds_Cedente", DT);
        ReportDataSource ds_Barra = new ReportDataSource("ds_Barra", DTR_Imagem);

        ReportParameter p1 = new ReportParameter("Juros", Juros);
        ReportParameter p2 = new ReportParameter("Multa", Multa);
        ReportParameter p3 = new ReportParameter("LinhaDigitavel", LinhaDigitavel);

        rpt.DataSources.Add(ds_Empresa);
        rpt.DataSources.Add(ds_Pessoa);
        rpt.DataSources.Add(ds_Boleto);
        rpt.SetParameters(new ReportParameter[] { p1, p2, p3 });

        Imprimir imp = new Imprimir();

        imp.Export(rpt);
        imp.Print();
        */
        #endregion

        #region Mensagem com Resposta
        /*
        DialogResult msgbox = MessageBox.Show("Encerrar Módulo?", "Fechar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        if (msgbox == DialogResult.Yes)
         */
        #endregion

        #region Validação de Data
        /*
        DateTime.TryParseExact(mk_ .Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
        if (ValidaData == DateTime.MinValue)
        {
        MessageBox.Show("Data Inválida!", "Erro");
        mk_ .Text = Convert.ToString(DateTime.Now);
        mk_ .Focus();
        }
        DateTime.TryParseExact(Convert.ToString(DateTime.Now), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ValidaData);
        */
        #endregion

        #region Configura 1º e Ultimo dia do Mês
        /*
        DateTime Periodo = Convert.ToDateTime("01/" + DateTime.Now.ToString("MM/yyyy"));
        mk_DataInicial.Text = Convert.ToString(Periodo);
        mk_DataFinal.Text = Convert.ToString(Periodo.AddMonths(1).AddDays(-1));
        */
        #endregion

        #region Alternar cor de Linha
        /*
        =IIf((RowNumber(Nothing) mod 2 =0), "LightGrey", "White")
        */
        #endregion

        #region Usando SelectCase no SQL
        /*
        sql += "CASE PC.ID_TipoComissao ";
        sql += "WHEN 1 THEN 'Valor' ";
        sql += "WHEN 2 THEN 'Porcentagem' ";
        sql += "END AS TipoComissao, ";
        */
        #endregion

        #region ALTERAR DATAGRID FORM MODELO
        /*
        DG.Columns["Complemento"].DataPropertyName = "ValorTotal";
        DG.Columns["Complemento"].HeaderText = "Valor Total";
        DG.Columns["Complemento"].DefaultCellStyle.Format = "C2";
        DG.Columns["Complemento"].Width = 200;

        BASE INICIAL
        
        Codigo
        Descricao
        Complemento
         */
        #endregion

        #region Impressão Matricial
        /*
          negocioPessoa = new negocio_Pessoa();

                                    if (DT.Rows.Count > 0 && DT != null)
                                    {
                                        for (int i = 0; i <= DT.Rows.Count - 1; i++)
                                        {
                                            if (Convert.ToBoolean(dg_CReceber.Rows[i].Cells[0].Value) == true)
                                            {
                                                DR = DT.Rows[i];
                                                if (negocioPessoa == null)
                                                    negocioPessoa = new negocio_Pessoa();
                                                DTPessoa = negocioPessoa.Busca_Relatorio(Convert.ToInt32(DR["TipoPessoa"]), Convert.ToInt32(DR["ID_Pessoa"]));
                                                DRPessoa = DTPessoa.Rows[0];
                                                DTEndereco = negocioPessoa.Busca_Endereco(Convert.ToInt32(DR["TipoPessoa"]), Convert.ToInt32(DR["ID_Pessoa"]), true);
                                                DREndereco = DTEndereco.Rows[0];
                                                conteudo = "\t\t\t\t\t\t\t\t\t\t\t" + Rotinas.ConfigData(Convert.ToDateTime(DR["Vencimento"]), 2);
                                                conteudo += "\n\n\n\n\n\t\t\t\t\t\t\t\t\t\t\t\t" + Rotinas.ConfigNumDecimal(DR["Valor"], 2);
                                                conteudo += "\n\n" + Parametros.InstrucaoBoleto;

                                                conteudo += "\n\n\t" + DRPessoa["Descricao"] + " (" + DRPessoa["NomeFantasia"] + ")";
                                                conteudo += "\n\t" + DREndereco["Logradouro"] + ", " + DREndereco["NumeroEndereco"] + " - " + DREndereco["Bairro"];
                                                conteudo += "\n\tCEP: " + DREndereco["CEP"] + " - " + DREndereco["NomeMunicipio"] + "-" + DREndereco["Sigla"];

                                                conteudo += "\n\n\n\n\n\n\n\n";

                                                conteudo = Rotinas.ConfigCampoNFe(conteudo);

                                                System.IO.StreamWriter GeraTXT = null;
                                                GeraTXT = new System.IO.StreamWriter(Parametro_Empresa.Caminho_Sistema + "\\Boletos\\" + Convert.ToInt32(DR["ID"]) + ".txt");
                                                GeraTXT.Write(conteudo);
                                                GeraTXT.Close();

                                                System.IO.File.Copy((Parametro_Empresa.Caminho_Sistema + "\\Boletos\\" + Convert.ToInt32(DR["ID"]) + ".txt"), Parametros.CaminhoImpressora);

                                                System.IO.File.Delete(Parametro_Empresa.Caminho_Sistema + "\\Boletos\\" + Convert.ToInt32(DR["ID"]) + ".txt");
                                            }
                                        }
                  }*/
        /*
        Conteudo = "";
            for (int x = 0; x <= 63; x++)
            {
                Conteudo += x;
                for (int i = 0; i <= 9; i++)
                    Conteudo += "|" + i + "\t";
                            }
  */
        #endregion

        #region Campo Select DataGridView
        /*
        bool Seleciona = false;
        
         private void dg_CReceber_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ConfiguraCampoDGCReceber();

            if (e.ColumnIndex == 0)
            {
                Seleciona = !Seleciona;
                for (int i = 0; i <= dg_CReceber.Rows.Count - 1; i++)
                    dg_CReceber.Rows[i].Cells[0].Value = Seleciona;
            }
            txt_ValorBaixa.Focus();
        }
       
        private void dg_CReceber_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                try
                {
                    //Erase the cell
                    using (Brush backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                    {
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                    }


                    e.Graphics.DrawLine(Pens.DarkGray, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                    e.Graphics.DrawLine(Pens.DarkGray, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Right, e.CellBounds.Top);
                    e.Graphics.DrawLine(Pens.White, e.CellBounds.Left, e.CellBounds.Top + 1, e.CellBounds.Right, e.CellBounds.Top + 1);
                    e.Graphics.DrawLine(Pens.DarkGray, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                    e.Graphics.DrawLine(Pens.White, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Left, e.CellBounds.Bottom);

                    Image imgChecked = (Image)UI.Properties.Resources._checked;
                    Image imgUnchecked = (Image)UI.Properties.Resources._unchecked;

                    int X = e.CellBounds.Left + ((e.CellBounds.Width - imgChecked.Width) / 2) - 1;
                    int Y = e.CellBounds.Top + ((e.CellBounds.Height - imgChecked.Height) / 2) - 1;

                    if (Seleciona)
                        e.Graphics.DrawImage(imgChecked, X, Y);
                    else
                        e.Graphics.DrawImage(imgUnchecked, X, Y);

                    e.Handled = true;
                }
                catch
                {
                }
            }
        }
         */
        #endregion

        #region Criar VIEW SQL
        /*
        CREATE VIEW AS
        CONSULTA SQL
        */
        #endregion

        #region Modelo Carrega Item Form
        /*
         
        private void bt_Adiciona_Click(object sender, EventArgs e)
        {
          for (int i = 0; i <= dg_Lancamentos.Rows.Count - 1; i++)
                if (Convert.ToInt32(dg_Lancamentos.Rows[i].Cells["col_ID_Evento"].Value) == Convert.ToInt32(cb_ID_Evento.SelectedValue))
                {
                    DialogResult msgbox = MessageBox.Show("Já Existe um Evento.\nAlterar Valor do Evento?", "Eventos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msgbox == DialogResult.No)
                        return;
                    else
                    {
                        dg_Lancamentos.Rows[i].Cells["col_Vencimento"].Value = Vencimento;
                        dg_Lancamentos.Rows[i].Cells["col_Desconto"].Value = Desconto;
                        cb_ID_Evento.Focus();
                        return;
                    }
                }
            int aux = dg_Lancamentos.Rows.Count;

            dg_Lancamentos.Rows.Add();
            dg_Lancamentos.Rows[aux].Cells["col_ID"].Value = 0;
            dg_Lancamentos.Rows[aux].Cells["col_ID_Folha"].Value = Rotinas.Verifica_int(txt_ID.Text);
            dg_Lancamentos.Rows[aux].Cells["col_ID_Evento"].Value = Rotinas.Verifica_int(cb_ID_Evento.SelectedValue.ToString());
            dg_Lancamentos.Rows[aux].Cells["col_DescricaoEvento"].Value = cb_ID_Evento.Text;
            dg_Lancamentos.Rows[aux].Cells["col_Vencimento"].Value = Vencimento;
            dg_Lancamentos.Rows[aux].Cells["col_Desconto"].Value = Desconto;
        }
           
        private void bt_Exclui_Click(object sender, EventArgs e)
        {
            if (dg_Lancamentos.Rows.Count > 0)
            {
                DialogResult msgbox = MessageBox.Show("Confirma Exclusão de Registro?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msgbox == DialogResult.No)
                    return;

                if (Rotinas.Verifica_int(txt_ID.Text) > 0)
                {
                    DTO_Folha _Folha = new DTO_Folha();
                    DTO_Folha_Evento Item = new DTO_Folha_Evento();
                    List<DTO_Folha_Evento> Folha_Evento = new List<DTO_Folha_Evento>();
                    Item.ID = Convert.ToInt32(dg_Lancamentos.Rows[dg_Lancamentos.CurrentRow.Index].Cells["col_ID"].Value);
                    Folha_Evento.Add(Item);
                    _Folha.FolhaEvento = Folha_Evento;

                    BLL_FolhaPagamento obj = new BLL_FolhaPagamento();
                    string aux = obj.Exclui_Item(_Folha);
                    if (aux.IndexOf("Sucesso") != -1)
                    {
                        DTO_Folha Folha = new DTO_Folha();
                        Folha.ID = Rotinas.Verifica_int(txt_ID.Text);

                        DataTable DT = obj.Busca_Item(Folha);

                        if (DT.Rows.Count > 0)
                            CarregaItem(DT);
                        else
                            dg_Lancamentos.Rows.Clear();
         
                        return;
                    }
                }
                dg_Lancamentos.Rows.RemoveAt(dg_Lancamentos.CurrentRow.Index);
            }
        }
       
        private DTO_Folha CarregaItem()
        {
            DTO_Folha Folha = new DTO_Folha();
            DTO_Folha_Evento Item;
            List<DTO_Folha_Evento> Folha_Evento = new List<DTO_Folha_Evento>();
            for (int i = 0; i <= dg_Lancamentos.Rows.Count - 1; i++)
            {
                Item = new DTO_Folha_Evento();
                Item.ID = Convert.ToInt32(dg_Lancamentos.Rows[i].Cells["col_ID"].Value);
                Item.ID_Evento = Convert.ToInt32(dg_Lancamentos.Rows[i].Cells["col_ID_Evento"].Value);
                Item.ID_Folha = Convert.ToInt32(dg_Lancamentos.Rows[i].Cells["col_ID_Folha"].Value);

                if (Convert.ToInt32(dg_Lancamentos.Rows[i].Cells["col_Vencimento"].Value) == 0)
                    Item.Valor = Convert.ToDouble(dg_Lancamentos.Rows[i].Cells["col_Desconto"].Value);
                else
                    Item.Valor = Convert.ToDouble(dg_Lancamentos.Rows[i].Cells["col_Vencimento"].Value);

                Folha_Evento.Add(Item);
            }
            Folha.FolhaEvento = Folha_Evento;
            return Folha;
        }

        private void CarregaItem(DataTable DT)
        {
            dg_Lancamentos.Rows.Clear();
            for (int i = 0; i <= DT.Rows.Count - 1; i++)
            {
                dg_Lancamentos.Rows.Add();
                dg_Lancamentos.Rows[i].Cells["col_ID"].Value = DT.Rows[i]["ID"];
                dg_Lancamentos.Rows[i].Cells["col_ID_Folha"].Value = DT.Rows[i]["ID_Folha"];
                dg_Lancamentos.Rows[i].Cells["col_ID_Evento"].Value = DT.Rows[i]["ID_Eventos"];
                dg_Lancamentos.Rows[i].Cells["col_DescricaoEvento"].Value = DT.Rows[i]["Descricao"];
                dg_Lancamentos.Rows[i].Cells["col_Vencimento"].Value = DT.Rows[i]["Vencimento"];
                dg_Lancamentos.Rows[i].Cells["col_Desconto"].Value = DT.Rows[i]["Desconto"];
            }
        }
       */
        #endregion

        #region TIPO DE PROPRIEDADES
        /*
        private string descricao;
        public string Descricao
        {
            get
            {
                if (descricao == null)
                    return string.Empty;
                else
                    return Rotina.RemoveAspa(descricao);
            }

            set { descricao = value; }
        }
        
        private DTO_Data consulta_vencimento;
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
        
        */
        #endregion

        #region CARREGA DATATABLE TIPO
        /*
        DataTable _DT = Parametros.Tipo_Pessoa();

        Rotinas.CarregaCombo(_DT, "Descricao", "ID", cb_TipoPessoa);
        cb_TipoPessoa.SelectedValue = 1;
         */
        #endregion
        #endregion

        #region MODELO DE ESTRUTURAS(string, e data)
        /*
        private string descricao;
        public string Descricao
        {
            get
            {
                if (descricao == null)
                    return string.Empty;
                else
                    return Rotina.RemoveAspa(descricao);
            }

            set { descricao = value; }
        }
        
        private DTO_Data consulta_vencimento;
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
        
        */
        #endregion

        #region Modelo DAL
        /*
        public int Grava()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();

            int ID = 0;
            try
            {
                //ABRE CONEXÃO COM BANCO DE DADOS E INICIA A TRANSAÇÃO
                conexao.Abre_Conexao();
                conexao.Begin_Conexao();

                query = "INSERT INTO ";
                query += "GrupoSimples ";
                query += "(Tipo, Descricao, Exibir) ";
                query += "VALUES ";
                query += "(@Tipo, @Descricao, @Exibir) ";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Tipo", Grupo_Simples.Tipo);
                cmd.Parameters.AddWithValue("@Descricao", Grupo_Simples.Descricao);
                cmd.Parameters.AddWithValue("@Exibir", Grupo_Simples.Exibir);

                ID = conexao.Executa_ComandoID(cmd);
         
                //CASO PRECISE UTILIZAR O CMD NOVAMENTE LIMPA SE OS PARAMETROS
                //COM A ROTINA ABAIXO
                cmd.Parameters.Clear();

                //SE NÃO OCORRER NENHUM ERRO, DA O COMANDO COMMIT
                conexao.Commit_Conexao();
         
                return ID;
            }
            catch (Exception ex)
            {
                //CASO ACONTEÇA ALGUM ERRO DA O COMANDO ROLLBACK
         
                conexao.RollBack_Conexao();

                cmd.Parameters.Clear();

                //SELECIONA A ID MAXIMA DE CADA TABELA UTILIZADA NA ROTINA
                //PARA VOLTAR O IDENTITY DE CADA TABELA
                  
                query = "SELECT MAX(ID) AS ID FROM GrupoSimples";
                int aux = Convert.ToInt32(conexao.Consulta(query).Rows[0]["ID"]);
                
                //COMANDO QUE VOLTA O IDENTITY DAS TABELAS QUE MUDARAM O IDENTITY
                query = " DBCC CHECKIDENT(GrupoSimples,RESEED, " + aux + ")";
                cmd.CommandText = query;
           
                conexao.Executa_Comando(cmd);
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public void Altera()
        {
            conexao = new Conexao();
            cmd = new SqlCommand();
            try
            {
                //ABRE CONEXÃO COM BANCO DE DADOS E INICIA A TRANSAÇÃO
                conexao.Abre_Conexao();
                conexao.Begin_Conexao();

                query = "UPDATE ";
                query += "GrupoSimples ";
                query += "SET ";
                query += "Descricao = @Descricao, ";
                query += "Exibir = @Exibir ";
                query += "WHERE ";
                query += "ID = @ID ";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@ID", Grupo_Simples.ID);
                cmd.Parameters.AddWithValue("@Descricao", Grupo_Simples.Descricao);
                cmd.Parameters.AddWithValue("@Exibir", Grupo_Simples.Exibir);

                conexao.Executa_Comando(cmd);
                 
                //CASO PRECISE UTILIZAR O CMD NOVAMENTE LIMPA SE OS PARAMETROS
                //COM A ROTINA ABAIXO
                cmd.Parameters.Clear();

                //SE NÃO OCORRER NENHUM ERRO, DA O COMANDO COMMIT
                conexao.Commit_Conexao();
         
            }
            catch (Exception ex)
            {
                //CASO ACONTEÇA ALGUM ERRO DA O COMANDO ROOBACK
                conexao.RollBack_Conexao();
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public DataTable Busca()
        {
            conexao = new Conexao();
            try
            {
                conexao.Abre_Conexao();

                query = "SELECT ";
                query += "ID, Tipo, Descricao, Exibir ";
                query += "FROM GrupoSimples ";
                query += "WHERE ";
                query += "NOT ID IS NULL ";

                if (Grupo_Simples.FiltraExibir == true)
                    query += "AND Exibir = '" + Grupo_Simples.Exibir + "' ";

                if (Grupo_Simples.ID > 0)
                    query += "AND ID = " + Grupo_Simples.ID + " ";

                if (Grupo_Simples.Tipo > 0)
                    query += "AND Tipo = " + Grupo_Simples.Tipo + " ";

                if (Grupo_Simples.Descricao != null)
                    query += "AND Descricao LIKE '" + Grupo_Simples.Descricao + "%' ";

                query += "ORDER BY Descricao ";

                return conexao.Consulta(query);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                conexao.Fecha_Conexao();
            }
        }

        public void Exclui()
        {
            cmd = new SqlCommand();
            conexao = new Conexao();
            msg = "";
            try
            {
                //ABRE A CONEXÃO E INICIA A TRANSIÇÃO
                conexao.Abre_Conexao();
                
                //VERIFICA SE EXISTE ALGUMA INFORMAÇÃO EM OUTRAS TABELAS
                #region Consulta Módulos
                query = "SELECT ";
                query += "ID ";
                query += "FROM ";
                query += "ControleCheque ";
                query += "WHERE ";
                query += "Tipo = " + Grupo_Simples.ID + " ";
                query += "OR Situacao = " + Grupo_Simples.ID;

                if (conexao.Consulta(query).Rows.Count > 0)
                    msg += "Controle de Cheques.\n";
                #endregion

                if (msg != "")
                    throw new Exception("Não foi possível excluir grupo, pois existe lançamentos nos seguintes módulos:\n" + msg);

                //INICIA A TRANSIÇÃO DEPOIS DAS CONSULTAS
                conexao.Begin_Conexao();
                query = "DELETE FROM ";
                query += "GrupoSimples ";
                query += "WHERE ";
                query += "ID = @ID ";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@ID", Grupo_Simples.ID);
                conexao.Executa_Comando(cmd);
         
                conexao.Commit_Conexao();
            }
            catch (Exception ex)
            {
                if (cmd.Transaction != null)
                    conexao.RollBack_Conexao();
         * 
                throw new Exception(ex.Message);
            }
        }
        */
        #endregion

        #region Modelo BLL
        /*
        public int Grava(DTO_Grupo_Simples _Grupo_Simples)
        {
            //FAZ AS VALIDAÇÕES DAS INFORMAÇÕES
            if (_Grupo_Simples.Descricao == string.Empty)
                throw new Exception(Info.CampoInvalido + "Descrição");

            DAL_Grupo_Simples obj = new DAL_Grupo_Simples(_Grupo_Simples);
            return obj.Grava();
        }

        public void Altera(DTO_Grupo_Simples _Grupo_Simples)
        {
            //FAZ AS VALIDAÇÕES DAS INFORMAÇÕES
            if (_Grupo_Simples.Descricao == string.Empty)
                throw new Exception(Info.CampoInvalido + "Descrição");

            DAL_Grupo_Simples obj = new DAL_Grupo_Simples(_Grupo_Simples);
            obj.Altera();
        }

        public DataTable Busca(DTO_Grupo_Simples _Grupo_Simples)
        {
            DAL_Grupo_Simples obj = new DAL_Grupo_Simples(_Grupo_Simples);
            return obj.Busca();
        }

        public void Exclui(DTO_Grupo_Simples _Grupo_Simples)
        {
            //FAZ AS VALIDAÇÕES DAS INFORMAÇÕES
            if (_Grupo_Simples.ID == 0)
                throw new Exception(Info.ErroExclusaoNull);

            DAL_Grupo_Simples obj = new DAL_Grupo_Simples(_Grupo_Simples);
            obj.Exclui();
        }
        */
        #endregion

        #region ROTINAS PARA USAR NO PUBLIC OVERRIDE SALVAR()
        /*
        try
            {
                if (Grupo_Simples.ID == 0)
                {
                    txt_ID.Text = BLL_Grupo_Simples.Grava(Grupo_Simples).ToString();
                    MessageBox.Show(Info.msg_Grava, "Cadastro de grupos");
                }
                else
                {
                    BLL_Grupo_Simples.Altera(Grupo_Simples);
                    MessageBox.Show(Info.msg_Altera, "Cadastro de grupos");
                }
                ResultadoSalvar = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Info.msg_Erro_Grava + ex.Message, "Cadastro de grupos");
            }
        */
        #endregion

        #region ROTINAS ANTIGAS
        //Mensagens de Retorno
        public static string ErroConfigSistema = "Erro ao Configurar Sistema!";
        public static string ErroParametro = "Erro ao Carregar Parâmetros!";
        public static string ErroRegisto = "Erro ao Carregar Registro!";
        public static string ErroPermissao = "Erro ao Gravar Permissão!";
        public static string ErroData = "Data Inválida!,\nVerifique e tente Novamente!";
        #endregion
    }
}
