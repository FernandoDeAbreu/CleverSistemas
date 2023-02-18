using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.UTIL
{
    public static class util_msg
    {
        public static string Sistema = "CLEVER GESTÃO EMPRESARIAL";

        //MENSAGENS DE RETORNO GRAVAÇÃO E CONSULTA
        public static string msg_Grava = "Dados salvos com sucesso!";
        public static string msg_Altera = "Dados alterados com sucesso!";
        public static string msg_GravaID = "Dados salvos com sucesso!\nCódigo: ";
        public static string msg_Exclui = "Dados excluídos com sucesso!";
        public static string msg_BLL_ErroExclui_Null = "Nenhum registro foi selecionado!";
        public static string msg_Baixa = "Baixa realizada com sucesso!";

        //MENSAGENS DE ERRO DIVERSOS
        public static string msg_Erro = "Ocorreu um erro!\n";
        public static string msg_Senha_Incorreta = "Senha incorreta, tente novamente!";
        public static string msg_Erro_Atualizacao = "Erro ao atualizar sistema!\nEntre em contato com suporte técnico!";
        public static string msg_Erro_AtualizacaoServidor = "Não foi possível conectar ao servidor de atualização!\nEntre em contato com suporte técnico!";
        public static string msg_Erro_Usuario_Senha_Nulo = "Usuário e/ou senha não informados!";
        public static string msg_Erro_Usuario_Senha_Invalido = "Usuário e/ou senha inválido!\nTente Novamente!";
        public static string msg_Erro_Alteracao = "Não foi possível alterar!";
        public static string msg_Erro_BD = "Não foi possivel conectar no banco de dados!\nVerifique a rede e tente novamente!";
        public static string msg_Erro_Suporte = "Ocorreu um erro, entre em contato com suporte técnico!";
        public static string msg_Exclui_Erro = "Não foi possível excluir grupo, pois existe lançamentos nos seguintes módulos:\n";
        public static string msg_BLL_CampoIncorreto = "Os seguintes campos estão incorretos:\n";
        public static string msg_ErroLancaPagamento = "Atenção, não foi realizado o pagamento.\nFechar sem realizar o pagamento?";
        public static string msg_ErroRegistroJaCancelado = "Registro já cancelado!";
        public static string msg_Erro_Param = "Ocorreu um erro ao carregar os Parâmetros:\n";
        public static string msg_DAL_Erro_Exclui = "Não foi possível excluir, existe registro nos seguintes módulos:\n";
        public static string msg_DAL_Erro_Grava = "Erro ao gravar registro!";
        public static string msg_SelecioneRegistroUnico = "Selecione somente um registro!";
        public static string msg_NenhumRegistroSelecionado = "Nenhum registro selecionado!";
        public static string msg_OpcaoInvalida = "Opção Inválida para lançamento!";
        public static string msg_SistemaBloqueado = "Sistema bloqueado!\nEntre em contato com suporte técnico!";
        public static string msg_ServidorOffLine = "Servidor sem acesso a internet!\nEntre em contato com suporte técnico!";
        public static string msg_TerminalNaoEmissorNFe = "Terminal não emissor de NF-e!";
        public static string msg_TerminalNaoEmissorCFe = "Terminal não emissor de CF-e SAT!";
        public static string msg_Conferencia_Qt_Maior = "A quantidade a ser conferida é maior que a quantidade vendida!\nVerifique novamente!";
        public static string msg_Conferencia_Produto_Null = "Não existe produto a ser conferido na Venda!\nVerifique novamente!";
        public static string msg_PessoaDiferente = "Ação permitida somente para a mesma pessoa!";
        public static string msg_InformacaoProdutoNull = "Informação sobre movimentação incorreta!\nVerifique e tente novamente!";
        public static string msg_TransferenciaCaixaErro = "Selecione Caixa/Bancos diferentes!";
        public static string msg_Devolucao_Qt_Maior = "A quantidade a ser devolvida é maior que a quantidade vendida!\nVerifique novamente!";
        public static string msg_Devolucao_Produto_Null = "Não existe produto a ser devolvido na Venda!\nVerifique novamente!";

        //MENSAGENS DE CONFIRMAÇÃO
        public static string msg_ConfirmaExclusao = "Confirma exclusão do registro?";
        public static string msg_ConfirmaDevolucao = "Confirma devolução de itens?";
        public static string msg_ConfirmaExclusaoVenda = "Confirma exclusão de Venda?\nATENÇÃO ESTA AÇÃO NÃO PODERÁ SER DESFEITA!";
        public static string msg_ConfirmaCancelamento = "Confirma cancelamento?";
        public static string msg_ConfirmaExclusaoItem = "Confirma exclusão do item?";
        public static string msg_Novo_Lancamento = "Atenção!\nOs dados não salvos serão perdidos!\nContinuar?";
        public static string msg_Confirma_Lancamento = "Confirma lançamento?";
        public static string msg_Confirma_EfetivaVenda = "Efetivar venda?";
        public static string msg_Confirma_Alteracao = "Confirma alteração?";
        public static string msg_Confirma_AlteracaoCritica = "Confirma alteração?\nATENÇÃO ESTA AÇÃO NÃO PODERÁ SER DESFEITA!";
        public static string msg_Confirma_AlteracaoEstoque = "Confirma alteração de estoque?\nATENÇÃO ESTA AÇÃO NÃO PODERÁ SER DESFEITA!";
        public static string msg_Confirma_RetiradaEstoque = "Confirma retirada de estoque?\nATENÇÃO ESTA AÇÃO NÃO PODERÁ SER DESFEITA!";
        public static string msg_Desconto_Itens = "ATENÇÃO!\nConfirma desconto de ## %?";
        public static string msg_ConfirmaBaixaBoleto = "Confirma baixa de boleto?";
        public static string msg_ConfirmaInfo = "Confirma Informações?";
        public static string msg_ConfirmaEnvioCartaCobranca = "Confirma envio de Carta de Cobrança?";
        public static string msg_ConfirmaExclusaoImagem = "Confirma exclusão da imagem?";
        public static string msg_ImprimeVenda = "Imprimir Venda?";
        public static string msg_EnviarNFeSefaz = "Transmitir NF-e?";
        public static string msg_FecharPDV = "Fechar PDV?";
        public static string msg_Encerrar_OS = "Confirma encerramento de ordem de serviço?";
        public static string msg_Encerrar_OS_ValorZero = "Ordem de serviço com valor zerado, encerrar mesmo assim?";
        public static string msg_Encerrar_Venda_ValorZero = "Venda com valor zerado, encerrar mesmo assim?";
        public static string msg_AlteraStatus = "Status alterado com sucesso!";
        public static string msg_ConfirmaDuplicar = "Confirma duplicação de item?";
        public static string msg_VisualizarArquivo = "Somente visualizar arquivo?";
        public static string msg_Encerrar_EntradaProduto = "Encerrar entrada de produto?";

        //MENSAGENS DIVERSAS
        public static string msg_registroUnico = "Selecione somente 1 registro!";
        public static string msg_Atualizacao = "ATUALIZAÇÃO PENDENTE!\nFECHE O SISTEMA E ABRA-O NOVAMENTE PARA ATUALIZAR!";
        public static string msg_RegistroNull = "Nenhum registro selecionado!";
        public static string msg_VendaConcluida = "Venda finalizada!";
        public static string msg_RegistroCancelado = "Registro cancelado com sucesso!";
        public static string msg_Altera_Financeiro = "**ALTERE FINANCEIRO MANUALMENTE!**";
        public static string msg_EntradaProdutConcluida = "Entrada de produto realizada com sucesso!";
        public static string msg_NenhumRegistro = "Nenhum registro encontrado!";
        public static string msg_NenhumEmpresa = "Nenhuma empresa cadastrada!";
        public static string msg_NenhumCedente = "Nenhum cedente selecionado!";
        public static string msg_NenhumEmpresaSelecionada = "Nenhuma empresa selecionada!";
        public static string msg_Produto_SemValor = "Não existe valor para esta tabela!";
        public static string msg_Produto_Cadastrado = "Produto já cadastrado!";
        public static string msg_Pessoa_Cadastrado = "Já existe um cadastro com este CNPJ/CPF!\nCadastrar mesmo assim?";
        public static string msg_Cadastro_Pessoa_FaltandoContato = "Não foi informado -~~-!\nCadastrar mesmo assim?";
        public static string msg_ParamNaoConfigurado = "Parâmetros não configurados!\n";
        public static string msg_ResumoContaBoleto = "Exibir resumo de contas?";
        public static string msg_BoletoGerado = "Boletos gerados com sucesso!";
        public static string msg_BoletoRetornoNaoConfig = "Não foi possível reconhecer o tipo de retorno!\n Verifique e tente novamente!\n\nCNAB240: SANTANDER, CAIXA\nCNAB400: SICOOB, BRADESCO";
        public static string msg_CReceber_Boleto = "Existem boletos gerados para esta conta, verifique e tente novamente!";
        public static string msg_PessoaNull = "Nenhuma pessoa selecionada!";
        public static string msg_FormAberto = "Já existe uma janela aberta, Deseja fechá-la e abrir novamente?\n\n**ATENÇÃO**: Os dados não salvos, serão perdidos!";
        public static string msg_ProcessoDemorado = "*ATENÇÃO*\nEste processo pode demorar alguns minutos!";
        public static string msg_EfetivaMobile = "Existe vendas externas para efetivar!";
        public static string msg_FornecedorProduto = "Fornecedor já incluído!";
        public static string msg_AlteraGrade = "ATENÇÃO\nAlterar o tipo de GRADE perderá as informações de estoque salvas!\n\nConfirma alteração?";
        public static string msg_ImagemGrande = "Imagem muito grande!\n\nTamanho da Imagem: ";
        public static string msg_EstoqueNaoCadastrado = "Tipo de estoque não cadastrado!";
        public static string msg_EstoqueInvalido = "Tipo de estoque inválido!";
        public static string msg_EstoqueEmpresaInvalido = "Estoque não configurado na empresa selecionada!";
        public static string msg_EstoqueNegativo = "Produto com estoque negativo!";
        public static string msg_GravaAliqNCM = "Confirma atualização de alíquotas?\nEste processo pode demorar alguns minutos!";
        public static string msg_ArquivoGerado = "Arquivo gerado com sucesso!";
        public static string msg_ConfirmaImpressaoA4 = "Imprimir em A4?";
        public static string msg_ConfirmaImpressao = "Confirma impressão?";
        public static string msg_ValorInvalido = "Valor inválido!";
        public static string msg_AlterarEvento = "Já existe um lançamento para este evento!\nAlterar valor do evento?";
        public static string msg_Empresa_Cadastrado = "Empresa já adicionada!";
        public static string msg_Quantidade_Item = "Quantidade de itens: ";
        public static string msg_Desconto_Total = "Total Desconto(R$) ";
        public static string msg_Desconto_AcimaLimite = "Desconto acima do limite!";
        public static string msg_BoletoRemessa = "Impossível alterar boleto, pois já foi gerado arquivo de remessa!";
        public static string msg_Faturamento_Personalizado = "Cliente com faturamento personalizado!\nPróxima data de fechamento: ";
        public static string msg_Fornecedor_NãoEncontrado = "Fornecedor não encontrado!\nCadastrar novo fornecedor?";
        public static string msg_ConfigEmail_Invalido = "Configuração de e-mail inválida!";
        public static string msg_ValorVenda_CustoFinal = "VALOR VENDA = (CUSTO FINAL + MARGEM DE VENDA)";
        public static string msg_ValorVenda_ValorCompra = "VALOR VENDA = (VALOR DE COMPRA + MARGEM) + IPI + ST + OUTROS CUSTOS";
        public static string msg_AtualizeValorVenda = "ATUALIZE MANUALMENTE OS VALORES VENDA!";
        public static string msg_TipodeProdutoInvalidoKit = "Tipo de produto inválido para estrutura de kit.";
        public static string msg_Quantidade_Invalida = "Quantidade inválida!";
        /// <summary>
        /// <para>Padrão da mensagem</para>
        /// <para>string.Format(util_msg.msg_CReceberEmAberto, Parametro_Financeiro.DiasBloqueioVenda)</para>
        /// </summary>
        public static string msg_CReceberEmAberto = "Consta no sistema registro financeiro em ABERTO a mais de {0} dias!";

        //MENSAGENS DE VALIDAÇÕES DE CAMPO
        public static string msg_CPFCNPJ_Invalido = "CPF/CNPJ Inválido!";
        public static string msg_CPFCNPJ_JaCadastrado = "Já existe um cadastro com este CPF/CNPJ!";
        public static string msg_Data_Inválida = "Data Incorreta!";
        public static string msg_FechaModulo = "Fechar módulo?";
        public static string msg_FechaSistema = "Encerrar sistema?";
        public static string msg_TrocadeUsuario = "Confirma troca de usuário?\n\nAviso as janelas abertas serão fechadas!";
        public static string msg_CEP_NaoEncontrado = "CEP não encontrado!";
        public static string msg_PagamentoIncompleto = "Pagamento incompleto, verifique os valores!";
        public static string msg_TrocoInvalido = "Valor de troco inválido!";
        public static string msg_TrocoInvalidoDinheiro = "ATENÇÃO\nValor em dinheiro não informado para troco!";

        //MENSAGENS, COMPLEMENTOS DE LANÇAMENTOS
        public static string msg_LancaVenda = "PEDIDO Nº ";
        public static string msg_LancaCompra = "COMPRA Nº ";
        public static string msg_LancaCheque = "CHEQUE Nº ";
        public static string msg_LancaOS = "OS Nº ";
        public static string msg_LancaBoleto = "BOLETO Nº ";
        public static string msg_LancaTarifaBoleto = "TARIFA LIQUIDAÇÃO DE BOLETO";
        public static string msg_TranfereCheque = "TRANSFERÊNCIA CHEQUE Nº ";
        public static string msg_ChequeDevolvido = "DEVOLUÇÃO DE CHEQUE Nº ";
        public static string msg_RelatorioEmail = "Gerado em " + util_dados.Config_Data(DateTime.Now, 3) + " às " + util_dados.Config_Data(DateTime.Now, 14);
        public static string msg_TransfereFluxoCaixaSaida = "TRANSFERÊNCIA DE VALOR PARA ";
        public static string msg_transrefeFluxoCaixaEntrada = "ENTRADA DE VALOR ";

        //CARTA DE COBRANÇA
        public static string msg_AssuntoCartaCobranca = "Informativo de cobrança";
        public static string msg_MsgCartaCobranca = "À" + Environment.NewLine + "Cliente: #pessoa#" + Environment.NewLine + Environment.NewLine + "Prezado(a) Cliente," + Environment.NewLine +
            "Até a presente data, nossos registros não acusam o recebimento do(s) pagamento(s) referente os lançamentos abaixo relacionados:" + Environment.NewLine +
            "#lancamento#" + Environment.NewLine +
            "TOTAL R$ #total#" + Environment.NewLine +
            "Valores referenciais, não estão inclusos multas e demais encargos." + Environment.NewLine +
            "Caso V. Sa. tenha efetuado a quitação do débito supra citado, solicitamos vossa especial colaboração no sentido de nos remeter cópia do respectivo recibo/boleto." + Environment.NewLine +
            "Caso contrário, para que possamos regularizar vossa pendência na listagem de clientes em atraso, solicitamos vosso comparecimento em nossa empresa ou mesmo contato telefônico, onde serão fornecidas informações adicionais." + Environment.NewLine + Environment.NewLine +
            "Atenciosamente";

        //NOTA FISCAL ELETRONICA
        public static string msg_EventoRegistrado = "Evento registrado com sucesso!";
        public static string msg_NFeAutorizada = "NF-e autorizada com sucesso!";
        public static string msg_CancelamentoRegistrado = "Cancelamento registrado com sucesso!";
        public static string msg_Cert_NaoEncontrado = "Nenhum certificado digital foi selecionado ou o certificado selecionado está com problemas!";
        public static string msg_Cert_Vencido = "Certificado Vencido!";
        public static string msg_NFe_ErroTag = "A tag de assinatura não existe no XML.";
        public static string msg_ChaveIncorreta = @"Chave da NF-e / CT-e incorreto!";
        public static string msg_Dados_NotaIncorreto = "Dados da Nota Fiscal incorretos!";
        public static string msg_Dados_CupomIncorreto = "Dados do Cupom Fiscal incorretos!";
        public static string msg_Natureza_Invalida = "Selecione uma Natureza de Emissão!";
        public static string msg_Erro_XML_NFe = "Foram encontrados os seguintes erros:\n";
        public static string msg_NFe_Assinar = "Ocorreu um erro ao Assinar XML:\n";
        public static string msg_DataEmissaoInvalida = "Data de emissão diferente da data de possível autorização!";
        public static string msg_NFe_erro_Processar = "Ocorreu um erro ao processar NFe:\n";
        public static string msg_NF_Erro_BuscarItem = "Ocorreu um erro ao buscar itens da venda!";
        public static string msg_Erro_AlteraNF = "Impossível alterar NF-e ";
        public static string msg_Erro_NumDuplicadoNF = "Já existe uma NF-e com esta Numeração!";
        public static string msg_qant_invalido = "Quantidade de caracteres inválidos!";
        public static string msg_Email_Invalido = "Email para emissão de NFe inválido!";
        public static string msg_Confirma_CC = "Confirma emissão de Carta de Correção eletrônica?\nESTE PROCESSO NÃO PODE SER DESFEITO!";
        public static string msg_Confirma_CANC = "Confirma cancelamento da Nota Fiscal Eletrônica?\nESTE PROCESSO NÃO PODE SER DESFEITO!";
        public static string msg_Confirma_INUT = "Confirma inutilização de numeração?\nESTE PROCESSO NÃO PODE SER DESFEITO!";
        public static string msg_NFe_SimplesNacional = "DOCUMENTO EMITIDO POR ME OU EPP OPTANTE PELO SIMPLES NACIONAL; NÃO GERA DIREITO A CRÉDITO FISCAL DE IPI;";
        public static string msg_CreditoICMS = "PERMITE O APROVEITAMENTO DO CREDITO DE ICMS NO VALOR DE R$ %CreditoICMS%; CORRESPONDENTE A ALIQUOTA DE %Aliquota%%, NOS TERMOS DO ART. 23 DA LC 123/2006";
        public static string msg_Difal_UF = "VALOES TOTAIS DE ICMS INTERESTADUAL: DIFAL DA UF DESTINO R$ #destino# + FCP R$ #fcp#; DIFAL DA UF ORIGEM R$ #origem#.";
        public static string msg_ConfirmaAlteracaoNatureza = "Confirma alteração de natureza?";

        public static string msg_Assunto_Email_NFe = "Nota Fiscal Eletrônica nº #num_nota#";
        public static string msg_Assunto_Email_Canc = "Cancelamento da NF-e nº #num_nota#";
        public static string msg_Assunto_Email_CCe = "Carta de Correção Eletrônica ref. NF-e nº #num_nota#";
        public static string msg_InutilizacaoSucesso = "Numeração inutilizada com sucesso!";

        public static string msg_Mensagem_Email_NFe = "Prezado cliente," + Environment.NewLine +
        "Você está recebendo a Nota Fiscal Eletrônica número #num_nota#, série #serie_nota# de #nome_emitente#, no valor de R$ #valor_nota#. Além disso, junto com a mercadoria seguirá o DANFE (Documento Auxiliar da Nota Fiscal Eletrônica), impresso em papel que acompanha o transporte das mesmas." + Environment.NewLine +
        "Anexo à este e-mail você está recebendo também o arquivo XML da Nota Fiscal Eletrônica. Este arquivo deve ser armazenado eletronicamente por sua empresa pelo prazo de 05 (cinco) anos, conforme previsto na legislação tributária (Art. 173 do Código Tributário Nacional e § 4º da Lei 5.172 de 25/10/1966)." + Environment.NewLine +
        "O DANFE em papel pode ser arquivado para apresentação ao fisco quando solicitado. Todavia, se sua empresa também for emitente de NF-e, o arquivamento eletrônico do XML de seus fornecedores é obrigatório, sendo passível de fiscalização." + Environment.NewLine +
        "Para se certificar que esta NF-e é válida, queira por favor consultar sua autenticidade no site nacional do projeto NF-e (www.nfe.fazenda.gov.br), utilizando a chave de acesso contida no DANFE." + Environment.NewLine +
        "Atenciosamente," + Environment.NewLine +
        "#nome_emitente#";

        public static string msg_Mensagem_Email_Canc = "Prezado Cliente:" + Environment.NewLine +
        "Comunicamos o cancelamento de Nota Fiscal Eletrônica, conforme segue:" + Environment.NewLine +
        "Chave de Acesso: #chave_acesso#" + Environment.NewLine +
        "Número: #num_nota#" + Environment.NewLine +
        "Série: #serie_nota#" + Environment.NewLine +
        "Emissão: #emissao_documento#" + Environment.NewLine +
        "Emitente: #nome_emitente#" + Environment.NewLine +
        "CNPJ: #cnpj_emitente#" + Environment.NewLine +
        "Justificativa: #justificativa#" + Environment.NewLine +
        "Protocolo de Cancelamento: #protocolo#" + Environment.NewLine +
        "Data/Hora do Recebimento: #data#" + Environment.NewLine +
        "Está em anexo o arquivo XML com as informações do cancelamento." + Environment.NewLine +
        "Em caso de dúvidas queira por favor entrar em contato." + Environment.NewLine +
        "Att," + Environment.NewLine +
        "#nome_emitente#";

        public static string msg_Mensagem_Email_CCe = "Prezado cliente," + Environment.NewLine +
        "Você está recebendo a Carta de Correção Eletrônica referente à NF-e nº #num_nota# de #nome_emitente#." + Environment.NewLine +
        "Anexo à este e-mail você está recebendo também o arquivo XML da Carta de Correção Eletrônica." + Environment.NewLine +
        "Atenciosamente," + Environment.NewLine +
        "#nome_emitente#";

        //CF-e SAT
        public static string msg_TipoSATinvalido = "Tipo de equipamento SAT não especificado!";
        public static string msg_FuncaoSATSucesso = "Comando executado com sucesso!\nRETORNO SAT: ";
        public static string msg_FuncaoSATErro = "Ocorreu um erro ao processar comando!\nRETORNO SAT: ";
        public static string msg_MensagemSEFAZ = "Mensagem retorno SEFAZ: ";
        public static string msg_Confirma_ConfigRede = "Confirma alteração de configuração de rede?\nObs. Esta operação não pode ser desfeita!";
        public static string msg_ExecutaFuncaoSAT = "Confirma execução de comando!";
        public static string msg_EmissaoSATSucesso = "CF-e SAT emitido com sucesso!";
        public static string msg_CancelamentoSATSucesso = "CF-e SAT cancelado com sucesso!";
        public static string msg_EmissaoSATErro = "Ocorreu um erro ao emitir CF-e!\nErro: ";
        public static string msg_EmissaoSATErroMonitor = "Provavelmente o Monitor CF-e SAT não está sendo executado,\nVerifique e tente novamente!";
    }
}
