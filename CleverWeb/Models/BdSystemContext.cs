using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CleverWeb.Models;

public partial class BdSystemContext : DbContext
{
    public BdSystemContext()
    {
    }

    public BdSystemContext(DbContextOptions<BdSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Banco> Bancos { get; set; }

    public virtual DbSet<Boleto> Boletos { get; set; }

    public virtual DbSet<BoletoControle> BoletoControles { get; set; }

    public virtual DbSet<BoletoRemessa> BoletoRemessas { get; set; }

    public virtual DbSet<BoletoRemessaControle> BoletoRemessaControles { get; set; }

    public virtual DbSet<Cartao> Cartaos { get; set; }

    public virtual DbSet<CartaoControle> CartaoControles { get; set; }

    public virtual DbSet<Cedente> Cedentes { get; set; }

    public virtual DbSet<Cest> Cests { get; set; }

    public virtual DbSet<Cfop> Cfops { get; set; }

    public virtual DbSet<Cheque> Cheques { get; set; }

    public virtual DbSet<Comodato> Comodatos { get; set; }

    public virtual DbSet<ComodatoItem> ComodatoItems { get; set; }

    public virtual DbSet<ControleDoc> ControleDocs { get; set; }

    public virtual DbSet<ControleDocTipo> ControleDocTipos { get; set; }

    public virtual DbSet<Cpagar> Cpagars { get; set; }

    public virtual DbSet<Creceber> Crecebers { get; set; }

    public virtual DbSet<Email> Emails { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<FichaProducao> FichaProducaos { get; set; }

    public virtual DbSet<FluxoCaixa> FluxoCaixas { get; set; }

    public virtual DbSet<FluxoCaixaControle> FluxoCaixaControles { get; set; }

    public virtual DbSet<FolhaPagto> FolhaPagtos { get; set; }

    public virtual DbSet<FolhaPagtoEvento> FolhaPagtoEventos { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<GrupoNivel> GrupoNivels { get; set; }

    public virtual DbSet<Imagem> Imagems { get; set; }

    public virtual DbSet<Imovel> Imovels { get; set; }

    public virtual DbSet<ImovelContrato> ImovelContratos { get; set; }

    public virtual DbSet<ImovelCusto> ImovelCustos { get; set; }

    public virtual DbSet<ImovelImagem> ImovelImagems { get; set; }

    public virtual DbSet<ImovelProprietario> ImovelProprietarios { get; set; }

    public virtual DbSet<ImovelVistorium> ImovelVistoria { get; set; }

    public virtual DbSet<Imposto> Impostos { get; set; }

    public virtual DbSet<ImpostoTributacao> ImpostoTributacaos { get; set; }

    public virtual DbSet<ImpostoUf> ImpostoUfs { get; set; }

    public virtual DbSet<Locacao> Locacaos { get; set; }

    public virtual DbSet<LocacaoFiador> LocacaoFiadors { get; set; }

    public virtual DbSet<LocacaoLocatario> LocacaoLocatarios { get; set; }

    public virtual DbSet<LogAcesso> LogAcessos { get; set; }

    public virtual DbSet<Mobile> Mobiles { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Ncm> Ncms { get; set; }

    public virtual DbSet<NfTipoEmissao> NfTipoEmissaos { get; set; }

    public virtual DbSet<NotaFiscal> NotaFiscals { get; set; }

    public virtual DbSet<NotaFiscalAdicao> NotaFiscalAdicaos { get; set; }

    public virtual DbSet<NotaFiscalAutXml> NotaFiscalAutXmls { get; set; }

    public virtual DbSet<NotaFiscalCobranca> NotaFiscalCobrancas { get; set; }

    public virtual DbSet<NotaFiscalDuplicatum> NotaFiscalDuplicata { get; set; }

    public virtual DbSet<NotaFiscalEntRet> NotaFiscalEntRets { get; set; }

    public virtual DbSet<NotaFiscalEvento> NotaFiscalEventos { get; set; }

    public virtual DbSet<NotaFiscalImportacao> NotaFiscalImportacaos { get; set; }

    public virtual DbSet<NotaFiscalInutilizacao> NotaFiscalInutilizacaos { get; set; }

    public virtual DbSet<NotaFiscalItem> NotaFiscalItems { get; set; }

    public virtual DbSet<NotaFiscalLacre> NotaFiscalLacres { get; set; }

    public virtual DbSet<NotaFiscalReferenciadum> NotaFiscalReferenciada { get; set; }

    public virtual DbSet<NotaFiscalTransporte> NotaFiscalTransportes { get; set; }

    public virtual DbSet<NotaFiscalVolume> NotaFiscalVolumes { get; set; }

    public virtual DbSet<Orcamento> Orcamentos { get; set; }

    public virtual DbSet<OrcamentoItem> OrcamentoItems { get; set; }

    public virtual DbSet<OrdemServico> OrdemServicos { get; set; }

    public virtual DbSet<OrdemServicoItem> OrdemServicoItems { get; set; }

    public virtual DbSet<Pagamento> Pagamentos { get; set; }

    public virtual DbSet<PagamentoParc> PagamentoParcs { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<ParametroMobile> ParametroMobiles { get; set; }

    public virtual DbSet<ParametroSistema> ParametroSistemas { get; set; }

    public virtual DbSet<ParametroUsuario> ParametroUsuarios { get; set; }

    public virtual DbSet<PermissaoMobile> PermissaoMobiles { get; set; }

    public virtual DbSet<PermissaoSistema> PermissaoSistemas { get; set; }

    public virtual DbSet<Pessoa> Pessoas { get; set; }

    public virtual DbSet<PessoaCliente> PessoaClientes { get; set; }

    public virtual DbSet<PessoaEmail> PessoaEmails { get; set; }

    public virtual DbSet<PessoaEmpresa> PessoaEmpresas { get; set; }

    public virtual DbSet<PessoaEmpresaResponsavel> PessoaEmpresaResponsavels { get; set; }

    public virtual DbSet<PessoaEndereco> PessoaEnderecos { get; set; }

    public virtual DbSet<PessoaFiador> PessoaFiadors { get; set; }

    public virtual DbSet<PessoaFornecedor> PessoaFornecedors { get; set; }

    public virtual DbSet<PessoaFuncionario> PessoaFuncionarios { get; set; }

    public virtual DbSet<PessoaImagem> PessoaImagems { get; set; }

    public virtual DbSet<PessoaLocatario> PessoaLocatarios { get; set; }

    public virtual DbSet<PessoaProprietario> PessoaProprietarios { get; set; }

    public virtual DbSet<PessoaResponsavel> PessoaResponsavels { get; set; }

    public virtual DbSet<PessoaTelefone> PessoaTelefones { get; set; }

    public virtual DbSet<PessoaTransportadora> PessoaTransportadoras { get; set; }

    public virtual DbSet<PlanoContum> PlanoConta { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<ProdutoComissao> ProdutoComissaos { get; set; }

    public virtual DbSet<ProdutoDesconto> ProdutoDescontos { get; set; }

    public virtual DbSet<ProdutoDescontoPessoa> ProdutoDescontoPessoas { get; set; }

    public virtual DbSet<ProdutoEntradaItem> ProdutoEntradaItems { get; set; }

    public virtual DbSet<ProdutoEntradum> ProdutoEntrada { get; set; }

    public virtual DbSet<ProdutoEstoque> ProdutoEstoques { get; set; }

    public virtual DbSet<ProdutoEstrutura> ProdutoEstruturas { get; set; }

    public virtual DbSet<ProdutoFornecedor> ProdutoFornecedors { get; set; }

    public virtual DbSet<ProdutoMovimento> ProdutoMovimentos { get; set; }

    public virtual DbSet<ProdutoParametro> ProdutoParametros { get; set; }

    public virtual DbSet<ProdutoServico> ProdutoServicos { get; set; }

    public virtual DbSet<ProdutoValor> ProdutoValors { get; set; }

    public virtual DbSet<TabelaValor> TabelaValors { get; set; }

    public virtual DbSet<Uf> Ufs { get; set; }

    public virtual DbSet<UfAliquotaIcm> UfAliquotaIcms { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<VChequeHistorico> VChequeHistoricos { get; set; }

    public virtual DbSet<VCpagar> VCpagars { get; set; }

    public virtual DbSet<VCreceber> VCrecebers { get; set; }

    public virtual DbSet<VFichaProducao> VFichaProducaos { get; set; }

    public virtual DbSet<VFinanceiroMobile> VFinanceiroMobiles { get; set; }

    public virtual DbSet<VHistoricoVendaItem> VHistoricoVendaItems { get; set; }

    public virtual DbSet<VHistoricoVendum> VHistoricoVenda { get; set; }

    public virtual DbSet<VOrcamento> VOrcamentos { get; set; }

    public virtual DbSet<VOrcamentoItem> VOrcamentoItems { get; set; }

    public virtual DbSet<VOrdemServico> VOrdemServicos { get; set; }

    public virtual DbSet<VOrdemServicoItem> VOrdemServicoItems { get; set; }

    public virtual DbSet<VOrdemServicoItemImposto> VOrdemServicoItemImpostos { get; set; }

    public virtual DbSet<VOrdemServicoItemImpostoCf> VOrdemServicoItemImpostoCfs { get; set; }

    public virtual DbSet<VOrdemServicoResumoPagto> VOrdemServicoResumoPagtos { get; set; }

    public virtual DbSet<VPessoaMobile> VPessoaMobiles { get; set; }

    public virtual DbSet<VPlanejamento> VPlanejamentos { get; set; }

    public virtual DbSet<VPlanoContum> VPlanoConta { get; set; }

    public virtual DbSet<VProdutoEntradum> VProdutoEntrada { get; set; }

    public virtual DbSet<VProdutoImposto> VProdutoImpostos { get; set; }

    public virtual DbSet<VProdutoMovimento> VProdutoMovimentos { get; set; }

    public virtual DbSet<VProdutoServico> VProdutoServicos { get; set; }

    public virtual DbSet<VProdutoVenda> VProdutoVenda { get; set; }

    public virtual DbSet<VResumoLocacao> VResumoLocacaos { get; set; }

    public virtual DbSet<VUsuarioMobile> VUsuarioMobiles { get; set; }

    public virtual DbSet<VVendaItem> VVendaItems { get; set; }

    public virtual DbSet<VVendaItemImposto> VVendaItemImpostos { get; set; }

    public virtual DbSet<VVendaItemImpostoCf> VVendaItemImpostoCfs { get; set; }

    public virtual DbSet<VVendaMobile> VVendaMobiles { get; set; }

    public virtual DbSet<VVendaPessoaInativo> VVendaPessoaInativos { get; set; }

    public virtual DbSet<VVendaResumoPagto> VVendaResumoPagtos { get; set; }

    public virtual DbSet<VVendum> VVenda { get; set; }

    public virtual DbSet<VendaExterno> VendaExternos { get; set; }

    public virtual DbSet<VendaExternoItem> VendaExternoItems { get; set; }

    public virtual DbSet<VendaItem> VendaItems { get; set; }

    public virtual DbSet<VendaItemMobile> VendaItemMobiles { get; set; }

    public virtual DbSet<VendaMobile> VendaMobiles { get; set; }

    public virtual DbSet<VendaSequencium> VendaSequencia { get; set; }

    public virtual DbSet<Vendum> Venda { get; set; }

    public virtual DbSet<Versao> Versaos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=BOOK\\SQLEXPRESS01;Database=BD_System;Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Banco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Banco__3214EC272EA5EC27");

            entity.ToTable("Banco");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Agencia).HasMaxLength(6);
            entity.Property(e => e.Conta).HasMaxLength(14);
            entity.Property(e => e.Descricao).HasMaxLength(100);
            entity.Property(e => e.IdBanco).HasColumnName("ID_Banco");
            entity.Property(e => e.IdCaixa).HasColumnName("ID_Caixa");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.Limite).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Boleto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Boleto__3214EC2755BFB948");

            entity.ToTable("Boleto");

            entity.HasIndex(e => e.IdPessoa, "I_ID_Pessoa");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Acrescimo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CodigoBarra).HasColumnType("image");
            entity.Property(e => e.DataBaixa).HasColumnType("datetime");
            entity.Property(e => e.Desconto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Documento).HasMaxLength(20);
            entity.Property(e => e.Emissao).HasColumnType("datetime");
            entity.Property(e => e.IdCedente).HasColumnName("ID_Cedente");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.NossoNumero).HasMaxLength(13);
            entity.Property(e => e.TipoRemessa).HasColumnName("Tipo_Remessa");
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Vencimento).HasColumnType("datetime");
        });

        modelBuilder.Entity<BoletoControle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BoletoCo__3214EC2750FB042B");

            entity.ToTable("BoletoControle");

            entity.HasIndex(e => e.IdBoleto, "I_ID_Boleto");

            entity.HasIndex(e => e.IdConta, "I_ID_Conta");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdBoleto).HasColumnName("ID_Boleto");
            entity.Property(e => e.IdConta).HasColumnName("ID_Conta");
        });

        modelBuilder.Entity<BoletoRemessa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Boleto_R__3214EC275DEAEAF5");

            entity.ToTable("Boleto_Remessa");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Arquivo).HasMaxLength(20);
            entity.Property(e => e.Emissao).HasColumnType("datetime");
        });

        modelBuilder.Entity<BoletoRemessaControle>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Boleto_RemessaControle");

            entity.Property(e => e.IdBoleto).HasColumnName("ID_Boleto");
            entity.Property(e => e.IdRemessa).HasColumnName("ID_Remessa");
        });

        modelBuilder.Entity<Cartao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cartao__3214EC27695C9DA1");

            entity.ToTable("Cartao");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DataBaixa)
                .HasColumnType("datetime")
                .HasColumnName("Data_Baixa");
            entity.Property(e => e.Emissao).HasColumnType("datetime");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdPagamento).HasColumnName("ID_Pagamento");
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Vencimento).HasColumnType("datetime");
        });

        modelBuilder.Entity<CartaoControle>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Cartao_Controle");

            entity.Property(e => e.IdCartao).HasColumnName("ID_Cartao");
            entity.Property(e => e.IdCreceber).HasColumnName("ID_CReceber");
        });

        modelBuilder.Entity<Cedente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cedente__3214EC274959E263");

            entity.ToTable("Cedente");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AlteraData).HasColumnName("Altera_Data");
            entity.Property(e => e.CnpjCpfCedente)
                .HasMaxLength(18)
                .HasColumnName("CNPJ_CPF_Cedente");
            entity.Property(e => e.CodCedente)
                .HasMaxLength(10)
                .HasColumnName("Cod_Cedente");
            entity.Property(e => e.CodProtesto).HasColumnName("Cod_Protesto");
            entity.Property(e => e.Descricao).HasMaxLength(60);
            entity.Property(e => e.IdBanco).HasColumnName("ID_Banco");
            entity.Property(e => e.IdConta).HasColumnName("ID_Conta");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.Instrucao1)
                .HasMaxLength(100)
                .HasColumnName("Instrucao_1");
            entity.Property(e => e.Instrucao2)
                .HasMaxLength(100)
                .HasColumnName("instrucao_2");
            entity.Property(e => e.Juros).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Multa).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RazaoCedente)
                .HasMaxLength(60)
                .HasColumnName("Razao_Cedente");
            entity.Property(e => e.Tarifa).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.TipoCobranca).HasColumnName("Tipo_Cobranca");
            entity.Property(e => e.TipoDocCedente).HasColumnName("Tipo_Doc_Cedente");
            entity.Property(e => e.TipoEmissao).HasColumnName("Tipo_Emissao");
        });

        modelBuilder.Entity<Cest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CEST__3214EC277993056A");

            entity.ToTable("CEST");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cest1)
                .HasMaxLength(10)
                .HasColumnName("CEST");
            entity.Property(e => e.Descricao).HasMaxLength(200);
            entity.Property(e => e.Ncm)
                .HasMaxLength(10)
                .HasColumnName("NCM");
        });

        modelBuilder.Entity<Cfop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CFOP__3214EC2700DF2177");

            entity.ToTable("CFOP");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Ajuda).HasColumnType("ntext");
            entity.Property(e => e.Cfop1)
                .HasMaxLength(4)
                .HasColumnName("CFOP");
            entity.Property(e => e.Descricao).HasColumnType("ntext");
        });

        modelBuilder.Entity<Cheque>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Controle__3214EC2758D1301D");

            entity.ToTable("Cheque");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Agencia).HasMaxLength(6);
            entity.Property(e => e.Banco)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.Cheque1)
                .HasMaxLength(10)
                .HasColumnName("Cheque");
            entity.Property(e => e.CnpjCpf)
                .HasMaxLength(18)
                .HasColumnName("CNPJ_CPF");
            entity.Property(e => e.Conta).HasMaxLength(15);
            entity.Property(e => e.Documento).HasMaxLength(2000);
            entity.Property(e => e.Emissao).HasColumnType("datetime");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.Informacao).HasMaxLength(200);
            entity.Property(e => e.Titular).HasMaxLength(200);
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Vencimento).HasColumnType("datetime");
        });

        modelBuilder.Entity<Comodato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comodato__3214EC272334397B");

            entity.ToTable("Comodato");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Data).HasColumnType("datetime");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
        });

        modelBuilder.Entity<ComodatoItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comodato__3214EC272704CA5F");

            entity.ToTable("ComodatoItem");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descricao).HasMaxLength(200);
            entity.Property(e => e.IdComodato).HasColumnName("ID_Comodato");
            entity.Property(e => e.Marca).HasMaxLength(100);
            entity.Property(e => e.Quantidade).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<ControleDoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cont_Con__3214EC271F2E9E6D");

            entity.ToTable("ControleDoc");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DataEntrada).HasColumnType("datetime");
            entity.Property(e => e.IdDocumento).HasColumnName("ID_Documento");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.Periodo).HasColumnType("datetime");
        });

        modelBuilder.Entity<ControleDocTipo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cont_Doc__3214EC271B5E0D89");

            entity.ToTable("ControleDoc_Tipo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descricao).HasMaxLength(100);
            entity.Property(e => e.IdTipo).HasColumnName("ID_Tipo");
        });

        modelBuilder.Entity<Cpagar>(entity =>
        {
            entity.ToTable("CPagar");

            entity.HasIndex(e => e.IdPessoa, "I_ID_Pessoa");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Acrescimo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DataBaixa).HasColumnType("datetime");
            entity.Property(e => e.Desconto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descricao).HasMaxLength(200);
            entity.Property(e => e.Documento)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Emissao).HasColumnType("datetime");
            entity.Property(e => e.GrupoConta).HasMaxLength(20);
            entity.Property(e => e.IdConta).HasColumnName("ID_Conta");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdPagamento).HasColumnName("ID_Pagamento");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.InformacaoBaixa).HasMaxLength(100);
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Vencimento).HasColumnType("datetime");
        });

        modelBuilder.Entity<Creceber>(entity =>
        {
            entity.ToTable("CReceber");

            entity.HasIndex(e => e.IdVenda, "I_ID_Pedido");

            entity.HasIndex(e => e.IdPessoa, "I_ID_Pessoa");

            entity.HasIndex(e => e.IdPrevisaoPagto, "I_ID_PrevisaoPagto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Acrescimo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DataBaixa).HasColumnType("datetime");
            entity.Property(e => e.Desconto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descricao).HasMaxLength(200);
            entity.Property(e => e.Documento)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Emissao).HasColumnType("datetime");
            entity.Property(e => e.GrupoConta).HasMaxLength(20);
            entity.Property(e => e.IdConta).HasColumnName("ID_Conta");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdOs).HasColumnName("ID_OS");
            entity.Property(e => e.IdPagamento).HasColumnName("ID_Pagamento");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.IdPrevisaoPagto).HasColumnName("ID_PrevisaoPagto");
            entity.Property(e => e.IdVenda).HasColumnName("ID_Venda");
            entity.Property(e => e.InformacaoBaixa).HasMaxLength(100);
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Vencimento).HasColumnType("datetime");
        });

        modelBuilder.Entity<Email>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Email__3214EC276991A7CB");

            entity.ToTable("Email");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Anexo).HasColumnType("text");
            entity.Property(e => e.Assunto).HasMaxLength(60);
            entity.Property(e => e.Cc)
                .HasMaxLength(500)
                .HasColumnName("CC");
            entity.Property(e => e.Cco)
                .HasMaxLength(500)
                .HasColumnName("CCO");
            entity.Property(e => e.Conteudo).HasColumnType("text");
            entity.Property(e => e.Data).HasColumnType("date");
            entity.Property(e => e.Para).HasMaxLength(500);
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Eventos__3214EC275C6CB6D7");

            entity.ToTable("Evento");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descricao).HasMaxLength(60);
            entity.Property(e => e.Referencia).HasMaxLength(200);
        });

        modelBuilder.Entity<FichaProducao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FichaPro__3214EC272665ABE1");

            entity.ToTable("FichaProducao");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Abd)
                .HasMaxLength(100)
                .HasColumnName("ABD");
            entity.Property(e => e.Abt)
                .HasMaxLength(100)
                .HasColumnName("ABT");
            entity.Property(e => e.AnoModelo).HasMaxLength(60);
            entity.Property(e => e.CorCouro).HasMaxLength(100);
            entity.Property(e => e.Costura).HasMaxLength(100);
            entity.Property(e => e.Entrada).HasColumnType("datetime");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdItemVenda).HasColumnName("ID_Item_Venda");
            entity.Property(e => e.IdVenda).HasColumnName("ID_Venda");
            entity.Property(e => e.LateraisPorta).HasColumnName("Laterais_Porta");
            entity.Property(e => e.Observacao).HasMaxLength(500);
            entity.Property(e => e.Saida).HasColumnType("datetime");
            entity.Property(e => e.TipoAcento).HasMaxLength(100);
            entity.Property(e => e.TipoEncosto).HasMaxLength(100);
            entity.Property(e => e.Transportadora).HasMaxLength(200);
        });

        modelBuilder.Entity<FluxoCaixa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_LivroCaixa");

            entity.ToTable("FluxoCaixa");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Credito).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Debito).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Documento).HasMaxLength(2000);
            entity.Property(e => e.Emissao).HasColumnType("datetime");
            entity.Property(e => e.GrupoConta).HasMaxLength(20);
            entity.Property(e => e.IdCheque).HasColumnName("ID_Cheque");
            entity.Property(e => e.IdConta).HasColumnName("ID_Conta");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdPagamento).HasColumnName("ID_Pagamento");
            entity.Property(e => e.Informacao).HasMaxLength(2000);
        });

        modelBuilder.Entity<FluxoCaixaControle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FluxoCai__3214EC274589517F");

            entity.ToTable("FluxoCaixa_Controle");

            entity.HasIndex(e => e.IdCpagar, "I_ID_CPagar");

            entity.HasIndex(e => e.IdCreceber, "I_ID_CReceber");

            entity.HasIndex(e => e.IdFluxoCaixa, "I_ID_FluxoCaixa");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdCpagar).HasColumnName("ID_CPagar");
            entity.Property(e => e.IdCreceber).HasColumnName("ID_CReceber");
            entity.Property(e => e.IdFluxoCaixa).HasColumnName("ID_FluxoCaixa");
        });

        modelBuilder.Entity<FolhaPagto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FolhaPag__3214EC27603D47BB");

            entity.ToTable("FolhaPagto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.Periodo).HasColumnType("datetime");
            entity.Property(e => e.Vencimento).HasColumnType("datetime");
        });

        modelBuilder.Entity<FolhaPagtoEvento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Folha_Ev__3214EC27640DD89F");

            entity.ToTable("FolhaPagto_Evento");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdEvento).HasColumnName("ID_Evento");
            entity.Property(e => e.IdFolhaPagto).HasColumnName("ID_FolhaPagto");
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.FolhaPagtoEventos)
                .HasForeignKey(d => d.IdEvento)
                .HasConstraintName("FK__Folha_Eve__ID_Ev__66EA454A");

            entity.HasOne(d => d.IdFolhaPagtoNavigation).WithMany(p => p.FolhaPagtoEventos)
                .HasForeignKey(d => d.IdFolhaPagto)
                .HasConstraintName("FK__Folha_Eve__ID_Fo__65F62111");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Grade__3214EC27634EBE90");

            entity.ToTable("Grade");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descricao).HasMaxLength(100);
            entity.Property(e => e.IdGrupo).HasColumnName("ID_Grupo");
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_GrupoSimples");

            entity.ToTable("Grupo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descricao).HasMaxLength(60);
        });

        modelBuilder.Entity<GrupoNivel>(entity =>
        {
            entity.ToTable("GrupoNivel");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Codigo).HasMaxLength(20);
            entity.Property(e => e.CodigoDescritivo).HasMaxLength(20);
            entity.Property(e => e.CodigoPai).HasMaxLength(20);
            entity.Property(e => e.Descricao).HasMaxLength(60);
        });

        modelBuilder.Entity<Imagem>(entity =>
        {
            entity.ToTable("Imagem");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.Imagem1)
                .HasColumnType("image")
                .HasColumnName("Imagem");
        });

        modelBuilder.Entity<Imovel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Imovel__3214EC273F9B6DFF");

            entity.ToTable("Imovel");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Area).HasColumnType("decimal(13, 2)");
            entity.Property(e => e.Bairro).HasMaxLength(60);
            entity.Property(e => e.Cep)
                .HasMaxLength(9)
                .HasColumnName("CEP");
            entity.Property(e => e.Ci)
                .HasMaxLength(18)
                .HasColumnName("CI");
            entity.Property(e => e.ComissaoPorc)
                .HasColumnType("decimal(13, 2)")
                .HasColumnName("Comissao_Porc");
            entity.Property(e => e.ComissaoValor)
                .HasColumnType("decimal(13, 2)")
                .HasColumnName("Comissao_Valor");
            entity.Property(e => e.Complemento).HasMaxLength(60);
            entity.Property(e => e.Descricao).HasMaxLength(200);
            entity.Property(e => e.IdMunicipio).HasColumnName("ID_Municipio");
            entity.Property(e => e.IdTipo).HasColumnName("ID_Tipo");
            entity.Property(e => e.Logradouro).HasMaxLength(60);
            entity.Property(e => e.Matricula).HasMaxLength(10);
            entity.Property(e => e.Numero).HasMaxLength(60);
            entity.Property(e => e.Rgi)
                .HasMaxLength(10)
                .HasColumnName("RGI");
            entity.Property(e => e.TipoImovel).HasColumnName("Tipo_Imovel");
            entity.Property(e => e.Uc)
                .HasMaxLength(10)
                .HasColumnName("UC");
            entity.Property(e => e.Valor).HasColumnType("decimal(13, 2)");
        });

        modelBuilder.Entity<ImovelContrato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Imovel_C__3214EC275E1FF51F");

            entity.ToTable("Imovel_Contrato");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DescricaoTest1)
                .HasMaxLength(60)
                .HasColumnName("Descricao_Test1");
            entity.Property(e => e.DescricaoTest2)
                .HasMaxLength(60)
                .HasColumnName("Descricao_Test2");
            entity.Property(e => e.DocTest1)
                .HasMaxLength(18)
                .HasColumnName("Doc_Test1");
            entity.Property(e => e.DocTest2)
                .HasMaxLength(18)
                .HasColumnName("Doc_Test2");
            entity.Property(e => e.Emissao).HasColumnType("date");
            entity.Property(e => e.IdProprietario).HasColumnName("ID_Proprietario");
        });

        modelBuilder.Entity<ImovelCusto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Imovel_C__3214EC274B0D20AB");

            entity.ToTable("Imovel_Custo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdImovel).HasColumnName("ID_Imovel");
            entity.Property(e => e.IdTipo).HasColumnName("ID_Tipo");
            entity.Property(e => e.Valor).HasColumnType("decimal(13, 2)");
        });

        modelBuilder.Entity<ImovelImagem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Imovel_I__3214EC27473C8FC7");

            entity.ToTable("Imovel_Imagem");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdImovel).HasColumnName("ID_Imovel");
            entity.Property(e => e.Imagem).HasColumnType("image");
            entity.Property(e => e.Informacao).HasMaxLength(60);
        });

        modelBuilder.Entity<ImovelProprietario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Imovel_P__3214EC27436BFEE3");

            entity.ToTable("Imovel_Proprietario");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdImovel).HasColumnName("ID_Imovel");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
        });

        modelBuilder.Entity<ImovelVistorium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Imovel_V__3214EC274EDDB18F");

            entity.ToTable("Imovel_Vistoria");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descricao).HasMaxLength(2000);
            entity.Property(e => e.IdImovel).HasColumnName("ID_Imovel");
            entity.Property(e => e.Local).HasMaxLength(60);
        });

        modelBuilder.Entity<Imposto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Imposto__3214EC27269AB60B");

            entity.ToTable("Imposto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descricao).HasMaxLength(60);
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
        });

        modelBuilder.Entity<ImpostoTributacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Imposto___3214EC272A6B46EF");

            entity.ToTable("Imposto_Tributacao");

            entity.HasIndex(e => e.IdImposto, "I_ID_Imposto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AliquotaCofins)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaCOFINS");
            entity.Property(e => e.AliquotaCofinsst)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaCOFINSST");
            entity.Property(e => e.AliquotaIcms)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaICMS");
            entity.Property(e => e.AliquotaIcmsst)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaICMSST");
            entity.Property(e => e.AliquotaIpi)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaIPI");
            entity.Property(e => e.AliquotaPis)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaPIS");
            entity.Property(e => e.AliquotaPisst)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaPISST");
            entity.Property(e => e.Cfop)
                .HasMaxLength(4)
                .HasColumnName("CFOP");
            entity.Property(e => e.CodEnquadramento)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("Cod_Enquadramento");
            entity.Property(e => e.Cst).HasColumnName("CST");
            entity.Property(e => e.Cstcofins).HasColumnName("CSTCOFINS");
            entity.Property(e => e.Cstipi).HasColumnName("CSTIPI");
            entity.Property(e => e.Cstpis).HasColumnName("CSTPIS");
            entity.Property(e => e.IdImposto).HasColumnName("ID_Imposto");
            entity.Property(e => e.MargemVadicionado)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("MargemVAdicionado");
            entity.Property(e => e.ModalidadeBc).HasColumnName("ModalidadeBC");
            entity.Property(e => e.ModalidadeBcst).HasColumnName("ModalidadeBCST");
            entity.Property(e => e.PDif)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("pDif");
            entity.Property(e => e.PercentualReducao).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PercentualReducaoSt)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PercentualReducaoST");
            entity.Property(e => e.TipoNf).HasColumnName("Tipo_NF");
            entity.Property(e => e.VIcmsdeson)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("vICMSDeson");
            entity.Property(e => e.VIcmsdif)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("vICMSDif");
            entity.Property(e => e.VIcmsop)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("vICMSOp");
        });

        modelBuilder.Entity<ImpostoUf>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Imposto_UF");

            entity.HasIndex(e => e.IdTributacao, "I_ID_Tributacao");

            entity.HasIndex(e => e.IdUf, "I_ID_UF");

            entity.Property(e => e.IdTributacao).HasColumnName("ID_Tributacao");
            entity.Property(e => e.IdUf).HasColumnName("ID_UF");
        });

        modelBuilder.Entity<Locacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Locacao__3214EC2752AE4273");

            entity.ToTable("Locacao");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Data).HasColumnType("date");
            entity.Property(e => e.DescricaoTest1)
                .HasMaxLength(60)
                .HasColumnName("Descricao_Test1");
            entity.Property(e => e.DescricaoTest2)
                .HasMaxLength(60)
                .HasColumnName("Descricao_Test2");
            entity.Property(e => e.DocTest1)
                .HasMaxLength(18)
                .HasColumnName("Doc_Test1");
            entity.Property(e => e.DocTest2)
                .HasMaxLength(18)
                .HasColumnName("Doc_Test2");
            entity.Property(e => e.IdImovel).HasColumnName("ID_Imovel");
            entity.Property(e => e.Inicio).HasColumnType("date");
            entity.Property(e => e.Observacao).HasMaxLength(200);
            entity.Property(e => e.Termino).HasColumnType("date");
            entity.Property(e => e.Uc)
                .HasMaxLength(10)
                .HasColumnName("UC");
            entity.Property(e => e.Valor).HasColumnType("decimal(13, 2)");
        });

        modelBuilder.Entity<LocacaoFiador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Locacao___3214EC275A4F643B");

            entity.ToTable("Locacao_Fiador");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdFiador).HasColumnName("ID_Fiador");
            entity.Property(e => e.IdLocacao).HasColumnName("ID_Locacao");
        });

        modelBuilder.Entity<LocacaoLocatario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Locacao___3214EC27567ED357");

            entity.ToTable("Locacao_Locatario");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdLocacao).HasColumnName("ID_Locacao");
            entity.Property(e => e.IdLocatario).HasColumnName("ID_Locatario");
        });

        modelBuilder.Entity<LogAcesso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Log_Aces__3214EC2722FF2F51");

            entity.ToTable("Log_Acesso");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Data).HasColumnType("datetime");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.Terminal).HasMaxLength(200);
        });

        modelBuilder.Entity<Mobile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Mobile__3214EC277E8CC4B1");

            entity.ToTable("Mobile");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Equipamento).HasMaxLength(100);
            entity.Property(e => e.Imei)
                .HasMaxLength(20)
                .HasColumnName("IMEI");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descricao).HasMaxLength(60);
            entity.Property(e => e.IdMunicipio).HasColumnName("ID_Municipio");
            entity.Property(e => e.IdPais).HasColumnName("ID_Pais");
            entity.Property(e => e.IdUf).HasColumnName("ID_UF");
        });

        modelBuilder.Entity<Ncm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NCM__3214EC270FB750B3");

            entity.ToTable("NCM");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AliqEstadual).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.AliqImpFederal).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.AliqNacFederal).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.Descricao).HasMaxLength(200);
            entity.Property(e => e.Ex).HasColumnName("EX");
            entity.Property(e => e.Ncm1).HasColumnName("NCM");
        });

        modelBuilder.Entity<NfTipoEmissao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NF_TipoE__3214EC276D9742D9");

            entity.ToTable("NF_TipoEmissao");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descricao)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
        });

        modelBuilder.Entity<NotaFiscal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NotaFisc__3214EC2740F9A68C");

            entity.ToTable("NotaFiscal");

            entity.HasIndex(e => e.IdVenda, "I_ID_Pedido");

            entity.HasIndex(e => e.IdPessoa, "I_ID_Pessoa");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Chave)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CnpjCpfDestinatario)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("CNPJ_CPF_Destinatario");
            entity.Property(e => e.ControleCf).HasColumnName("Controle_CF");
            entity.Property(e => e.DataContigencia).HasColumnType("datetime");
            entity.Property(e => e.DataEmissao).HasColumnType("datetime");
            entity.Property(e => e.DataSaida).HasColumnType("datetime");
            entity.Property(e => e.DigVerificador).HasColumnName("Dig_Verificador");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdNfe).HasColumnName("ID_NFe");
            entity.Property(e => e.IdOs).HasColumnName("ID_OS");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.IdVenda).HasColumnName("ID_Venda");
            entity.Property(e => e.IeSubstituicao)
                .HasMaxLength(15)
                .HasColumnName("IE_Substituicao");
            entity.Property(e => e.InformacaoAdicional).HasMaxLength(500);
            entity.Property(e => e.InformacaoFisco).HasMaxLength(2000);
            entity.Property(e => e.Justificativa).HasMaxLength(256);
            entity.Property(e => e.NaturezaOperacao).HasMaxLength(60);
            entity.Property(e => e.QrcodeCfe)
                .HasColumnType("text")
                .HasColumnName("QRCode_CFe");
            entity.Property(e => e.RetornoCfe)
                .HasMaxLength(200)
                .HasColumnName("Retorno_CFe");
            entity.Property(e => e.StatusCfe).HasColumnName("Status_CFe");
            entity.Property(e => e.TipoFrete1).HasColumnName("Tipo_Frete");
            entity.Property(e => e.TipoNf).HasColumnName("Tipo_NF");
            entity.Property(e => e.TribEstadual)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Trib_Estadual");
            entity.Property(e => e.TribFederal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Trib_Federal");
            entity.Property(e => e.TribMunicipal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Trib_Municipal");
            entity.Property(e => e.ValorBc)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("ValorBC");
            entity.Property(e => e.ValorBcst)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("ValorBCST");
            entity.Property(e => e.ValorCofins)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("ValorCOFINS");
            entity.Property(e => e.ValorDesconto).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.ValorFrete).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.ValorIcms)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("ValorICMS");
            entity.Property(e => e.ValorIcmsdesonerado)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("ValorICMSDesonerado");
            entity.Property(e => e.ValorImportacao).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.ValorIpi)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("ValorIPI");
            entity.Property(e => e.ValorOutro).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.ValorPis)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("ValorPIS");
            entity.Property(e => e.ValorProduto).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.ValorSeguro).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.ValorSt)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("ValorST");
            entity.Property(e => e.ValorTotal).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<NotaFiscalAdicao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NotaFisc__3214EC27084B3915");

            entity.ToTable("NotaFiscal_Adicao");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Codigo).HasMaxLength(60);
            entity.Property(e => e.Desconto).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.IdImportacao).HasColumnName("ID_Importacao");
            entity.Property(e => e.Numero).HasMaxLength(3);
        });

        modelBuilder.Entity<NotaFiscalAutXml>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NotaFisc__3214EC272F2FFC0C");

            entity.ToTable("NotaFiscal_AutXML");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CnpjCpf)
                .HasMaxLength(18)
                .HasColumnName("CNPJ_CPF");
            entity.Property(e => e.IdNf).HasColumnName("ID_NF");
        });

        modelBuilder.Entity<NotaFiscalCobranca>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NotaFisc__3214EC277CD98669");

            entity.ToTable("NotaFiscal_Cobranca");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Desconto).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.IdNf).HasColumnName("ID_NF");
            entity.Property(e => e.NumeroFatura).HasMaxLength(60);
            entity.Property(e => e.Valor).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.ValorFinal).HasColumnType("decimal(15, 2)");
        });

        modelBuilder.Entity<NotaFiscalDuplicatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NotaFisc__3214EC2700AA174D");

            entity.ToTable("NotaFiscal_Duplicata");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdNf).HasColumnName("ID_NF");
            entity.Property(e => e.NumeroDuplicata).HasMaxLength(60);
            entity.Property(e => e.Valor).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.Vencimento).HasColumnType("datetime");
        });

        modelBuilder.Entity<NotaFiscalEntRet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NotaFisc__3214EC270FEC5ADD");

            entity.ToTable("NotaFiscal_Ent_Ret");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Bairro).HasMaxLength(60);
            entity.Property(e => e.CnpjCpf)
                .HasMaxLength(18)
                .HasColumnName("CNPJ_CPF");
            entity.Property(e => e.Complemento).HasMaxLength(60);
            entity.Property(e => e.IdMunicipio).HasColumnName("ID_Municipio");
            entity.Property(e => e.IdNf).HasColumnName("ID_NF");
            entity.Property(e => e.Logradouro).HasMaxLength(60);
            entity.Property(e => e.Numero).HasMaxLength(60);
        });

        modelBuilder.Entity<NotaFiscalEvento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NotaFisc__3214EC2726CFC035");

            entity.ToTable("NotaFiscal_Evento");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Data).HasColumnType("datetime");
            entity.Property(e => e.Evento).HasMaxLength(200);
            entity.Property(e => e.IdNf).HasColumnName("ID_NF");
            entity.Property(e => e.Motivo).HasMaxLength(1000);
            entity.Property(e => e.Protocolo).HasMaxLength(20);
            entity.Property(e => e.TipoEvento).HasColumnName("Tipo_Evento");
        });

        modelBuilder.Entity<NotaFiscalImportacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NotaFisc__3214EC27047AA831");

            entity.ToTable("NotaFiscal_Importacao");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Codigo).HasMaxLength(60);
            entity.Property(e => e.DataDesen)
                .HasColumnType("datetime")
                .HasColumnName("Data_Desen");
            entity.Property(e => e.DataRegistro)
                .HasColumnType("datetime")
                .HasColumnName("Data_Registro");
            entity.Property(e => e.Documento).HasMaxLength(10);
            entity.Property(e => e.IdNfItem).HasColumnName("ID_NF_Item");
            entity.Property(e => e.Local).HasMaxLength(60);
            entity.Property(e => e.Uf)
                .HasMaxLength(2)
                .HasColumnName("UF");
        });

        modelBuilder.Entity<NotaFiscalInutilizacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NotaFisc__3214EC2770FDBF69");

            entity.ToTable("NotaFiscal_Inutilizacao");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.Justificativa).HasMaxLength(255);
            entity.Property(e => e.Numeracao).HasMaxLength(60);
            entity.Property(e => e.Protocolo).HasMaxLength(200);
        });

        modelBuilder.Entity<NotaFiscalItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NotaFisc__3214EC277D0E9093");

            entity.ToTable("NotaFiscal_Item");

            entity.HasIndex(e => e.IdProduto, "I_ID_Produto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Acrescimo).HasColumnType("decimal(12, 4)");
            entity.Property(e => e.AliquotaCofins)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("AliquotaCOFINS");
            entity.Property(e => e.AliquotaCredito).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.AliquotaIcms)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaICMS");
            entity.Property(e => e.AliquotaIcmsst)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaICMSST");
            entity.Property(e => e.AliquotaIpi)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("AliquotaIPI");
            entity.Property(e => e.AliquotaPis)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("AliquotaPIS");
            entity.Property(e => e.Cfop)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("CFOP");
            entity.Property(e => e.ClasseEnquadramento)
                .HasMaxLength(5)
                .IsFixedLength();
            entity.Property(e => e.Cnpjprodutor)
                .HasMaxLength(18)
                .HasColumnName("CNPJProdutor");
            entity.Property(e => e.CodigoSelo)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("Codigo_Selo");
            entity.Property(e => e.Csosn)
                .HasMaxLength(3)
                .HasColumnName("CSOSN");
            entity.Property(e => e.Cst).HasColumnName("CST");
            entity.Property(e => e.Cstcofins)
                .HasMaxLength(2)
                .HasColumnName("CSTCOFINS");
            entity.Property(e => e.Cstipi)
                .HasMaxLength(2)
                .HasColumnName("CSTIPI");
            entity.Property(e => e.Cstpis)
                .HasMaxLength(2)
                .HasColumnName("CSTPIS");
            entity.Property(e => e.Desconto).HasColumnType("decimal(12, 4)");
            entity.Property(e => e.ExTipi).HasColumnName("EX_TIPI");
            entity.Property(e => e.Frete).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.IdGrade).HasColumnName("ID_Grade");
            entity.Property(e => e.IdNf).HasColumnName("ID_NF");
            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
            entity.Property(e => e.IdTabela).HasColumnName("ID_Tabela");
            entity.Property(e => e.InformacaoAdicional).HasMaxLength(100);
            entity.Property(e => e.Ipidevolvido)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("IPIDevolvido");
            entity.Property(e => e.MargemVladicionado)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("MargemVLAdicionado");
            entity.Property(e => e.ModalidadeBc).HasColumnName("ModalidadeBC");
            entity.Property(e => e.ModalidadeBcst).HasColumnName("ModalidadeBCST");
            entity.Property(e => e.PerIpidevolvido)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("Per_IPIDevolvido");
            entity.Property(e => e.PercentualDiferimento).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.PercentualReducao).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PercentualReducaoSt)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PercentualReducaoST");
            entity.Property(e => e.Quantidade).HasColumnType("decimal(12, 4)");
            entity.Property(e => e.QuantidadeSelo)
                .HasMaxLength(11)
                .HasColumnName("Quantidade_Selo");
            entity.Property(e => e.Seguro).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.ValorAliquotaCofins)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("ValorAliquotaCOFINS");
            entity.Property(e => e.ValorAliquotaPis)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("ValorAliquotaPIS");
            entity.Property(e => e.ValorBc)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("ValorBC");
            entity.Property(e => e.ValorBcii)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("ValorBCII");
            entity.Property(e => e.ValorBcst)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("ValorBCST");
            entity.Property(e => e.ValorBcstret)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("ValorBCSTRet");
            entity.Property(e => e.ValorCofins)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("ValorCOFINS");
            entity.Property(e => e.ValorCredito).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.ValorDesIi)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("ValorDesII");
            entity.Property(e => e.ValorIcms)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("ValorICMS");
            entity.Property(e => e.ValorIcmsdeferido)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("ValorICMSDeferido");
            entity.Property(e => e.ValorIcmsdesonerado)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("ValorICMSDesonerado");
            entity.Property(e => e.ValorIcmsoperacao)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("ValorICMSOperacao");
            entity.Property(e => e.ValorIcmsst)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("ValorICMSST");
            entity.Property(e => e.ValorIcmsstret)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("ValorICMSSTRet");
            entity.Property(e => e.ValorIi)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("ValorII");
            entity.Property(e => e.ValorIof)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("ValorIOF");
            entity.Property(e => e.ValorIpi)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("ValorIPI");
            entity.Property(e => e.ValorPis)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("ValorPIS");
            entity.Property(e => e.ValorTotal).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.ValorUnitario).HasColumnType("decimal(12, 4)");
        });

        modelBuilder.Entity<NotaFiscalLacre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NotaFisc__3214EC27753864A1");

            entity.ToTable("NotaFiscal_Lacre");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdNfVolume).HasColumnName("ID_NF_Volume");
            entity.Property(e => e.Numero).HasMaxLength(60);
        });

        modelBuilder.Entity<NotaFiscalReferenciadum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NotaFisc__3214EC2713BCEBC1");

            entity.ToTable("NotaFiscal_Referenciada");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ChaveNfe)
                .HasMaxLength(44)
                .HasColumnName("Chave_NFe");
            entity.Property(e => e.CnpjCpf)
                .HasMaxLength(18)
                .HasColumnName("CNPJ_CPF");
            entity.Property(e => e.Cte)
                .HasMaxLength(44)
                .HasColumnName("CTE");
            entity.Property(e => e.DataEmissao).HasColumnType("datetime");
            entity.Property(e => e.Ecf)
                .HasMaxLength(3)
                .HasColumnName("ECF");
            entity.Property(e => e.IdNf).HasColumnName("ID_NF");
            entity.Property(e => e.Ie)
                .HasMaxLength(15)
                .HasColumnName("IE");
            entity.Property(e => e.ModCupomFiscal)
                .HasMaxLength(2)
                .HasColumnName("Mod_CupomFiscal");
            entity.Property(e => e.Modelo).HasMaxLength(2);
            entity.Property(e => e.NumeroContador)
                .HasMaxLength(6)
                .HasColumnName("Numero_Contador");
            entity.Property(e => e.NumeroNf)
                .HasMaxLength(9)
                .HasColumnName("Numero_NF");
            entity.Property(e => e.Serie).HasMaxLength(3);
            entity.Property(e => e.Uf)
                .HasMaxLength(2)
                .HasColumnName("UF");
        });

        modelBuilder.Entity<NotaFiscalTransporte>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NotaFisc__3214EC277908F585");

            entity.ToTable("NotaFiscal_Transporte");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CnpjCpf)
                .HasMaxLength(18)
                .HasColumnName("CNPJ_CPF");
            entity.Property(e => e.Endereco).HasMaxLength(60);
            entity.Property(e => e.IdNf).HasColumnName("ID_NF");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.Ie)
                .HasMaxLength(15)
                .HasColumnName("IE");
            entity.Property(e => e.Municipio).HasMaxLength(60);
            entity.Property(e => e.Nome).HasMaxLength(60);
            entity.Property(e => e.Placa).HasMaxLength(8);
            entity.Property(e => e.Uf)
                .HasMaxLength(2)
                .HasColumnName("UF");
            entity.Property(e => e.Ufplaca)
                .HasMaxLength(2)
                .HasColumnName("UFPlaca");
        });

        modelBuilder.Entity<NotaFiscalVolume>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NotaFisc__3214EC277167D3BD");

            entity.ToTable("NotaFiscal_Volume");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Especie).HasMaxLength(60);
            entity.Property(e => e.IdNf).HasColumnName("ID_NF");
            entity.Property(e => e.Marca).HasMaxLength(60);
            entity.Property(e => e.Numeracao).HasMaxLength(60);
            entity.Property(e => e.PesoB).HasColumnType("decimal(15, 3)");
            entity.Property(e => e.PesoL).HasColumnType("decimal(15, 3)");
        });

        modelBuilder.Entity<Orcamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_OrcamentoVenda_1");

            entity.ToTable("Orcamento");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Data).HasColumnType("datetime");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.IdUsuarioComissao1).HasColumnName("ID_UsuarioComissao1");
            entity.Property(e => e.IdUsuarioComissao2).HasColumnName("ID_UsuarioComissao2");
            entity.Property(e => e.IdUsuarioComissao3).HasColumnName("ID_UsuarioComissao3");
            entity.Property(e => e.Informacao).HasMaxLength(200);
        });

        modelBuilder.Entity<OrcamentoItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ItemOrcamentoVenda");

            entity.ToTable("Orcamento_Item");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdGrade).HasColumnName("ID_Grade");
            entity.Property(e => e.IdOrcamento).HasColumnName("ID_Orcamento");
            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
            entity.Property(e => e.IdTabela).HasColumnName("ID_Tabela");
            entity.Property(e => e.Informacao).HasMaxLength(100);
            entity.Property(e => e.Quantidade).HasColumnType("decimal(9, 3)");
            entity.Property(e => e.ValorCusto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorMinimo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorProduto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorVenda).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<OrdemServico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ordem_Se__3214EC273E723F9C");

            entity.ToTable("Ordem_Servico");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CpfCnpj)
                .HasMaxLength(18)
                .HasColumnName("CPF_CNPJ");
            entity.Property(e => e.DataAbertura)
                .HasColumnType("datetime")
                .HasColumnName("Data_Abertura");
            entity.Property(e => e.DataAprovacao)
                .HasColumnType("datetime")
                .HasColumnName("Data_Aprovacao");
            entity.Property(e => e.DataEntrega)
                .HasColumnType("datetime")
                .HasColumnName("Data_Entrega");
            entity.Property(e => e.DataMontagem)
                .HasColumnType("datetime")
                .HasColumnName("Data_Montagem");
            entity.Property(e => e.DataOrcamento)
                .HasColumnType("datetime")
                .HasColumnName("Data_Orcamento");
            entity.Property(e => e.DataPronta)
                .HasColumnType("datetime")
                .HasColumnName("Data_Pronta");
            entity.Property(e => e.IdCfe).HasColumnName("ID_CFe");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdNfe).HasColumnName("ID_NFe");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.IdUsuarioComissao1).HasColumnName("ID_UsuarioComissao1");
            entity.Property(e => e.IdUsuarioComissao2).HasColumnName("ID_UsuarioComissao2");
            entity.Property(e => e.InfoEquip1)
                .HasMaxLength(60)
                .HasColumnName("Info_Equip_1");
            entity.Property(e => e.InfoEquip2)
                .HasMaxLength(60)
                .HasColumnName("Info_Equip_2");
            entity.Property(e => e.InfoEquip3)
                .HasMaxLength(60)
                .HasColumnName("Info_Equip_3");
            entity.Property(e => e.Nfe).HasColumnName("NFe");
            entity.Property(e => e.ObsEquip1)
                .HasMaxLength(200)
                .HasColumnName("Obs_Equip_1");
            entity.Property(e => e.ObsEquip2)
                .HasMaxLength(200)
                .HasColumnName("Obs_Equip_2");
            entity.Property(e => e.Observacao).HasMaxLength(1000);
            entity.Property(e => e.Reclamacao).HasMaxLength(1000);
            entity.Property(e => e.StatusOs).HasColumnName("Status_OS");
            entity.Property(e => e.TipoEquipamento).HasColumnName("Tipo_Equipamento");
        });

        modelBuilder.Entity<OrdemServicoItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ordem_Se__3214EC274242D080");

            entity.ToTable("Ordem_Servico_Item");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdGrade).HasColumnName("ID_Grade");
            entity.Property(e => e.IdOs).HasColumnName("ID_OS");
            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
            entity.Property(e => e.IdTabela).HasColumnName("ID_Tabela");
            entity.Property(e => e.Informacao).HasMaxLength(1000);
            entity.Property(e => e.Quantidade).HasColumnType("decimal(9, 3)");
            entity.Property(e => e.QuantidadeEntregue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Quantidade_Entregue");
            entity.Property(e => e.ValorCusto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorProduto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorVenda).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Pagamento>(entity =>
        {
            entity.ToTable("Pagamento");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descricao).HasMaxLength(60);
            entity.Property(e => e.DiaLancamento).HasColumnName("Dia_Lancamento");
            entity.Property(e => e.Pagamento1).HasColumnName("Pagamento");
            entity.Property(e => e.PorcCusto)
                .HasColumnType("decimal(6, 3)")
                .HasColumnName("Porc_Custo");
            entity.Property(e => e.QtParcela).HasColumnName("Qt_Parcela");
            entity.Property(e => e.VlrCusto)
                .HasColumnType("decimal(6, 3)")
                .HasColumnName("Vlr_Custo");
        });

        modelBuilder.Entity<PagamentoParc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pagament__3214EC272E70E1FD");

            entity.ToTable("Pagamento_Parc");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdPagamento).HasColumnName("ID_Pagamento");
            entity.Property(e => e.Parcelamento).HasMaxLength(100);
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descricao).HasMaxLength(60);
            entity.Property(e => e.IdPais).HasColumnName("ID_Pais");
        });

        modelBuilder.Entity<ParametroMobile>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa);

            entity.ToTable("ParametroMobile");

            entity.Property(e => e.IdEmpresa)
                .ValueGeneratedNever()
                .HasColumnName("ID_Empresa");
        });

        modelBuilder.Entity<ParametroSistema>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa).HasName("PK__Parametr__F4BB60390BE6BFCF");

            entity.ToTable("Parametro_Sistema");

            entity.Property(e => e.IdEmpresa)
                .ValueGeneratedNever()
                .HasColumnName("ID_Empresa");
            entity.Property(e => e.AgruparProduto).HasColumnName("Agrupar_Produto");
            entity.Property(e => e.AliquotaCreditoIcms)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaCreditoICMS");
            entity.Property(e => e.AlteraValorPdv).HasColumnName("Altera_ValorPDV");
            entity.Property(e => e.AmbienteNfe).HasColumnName("AmbienteNFe");
            entity.Property(e => e.AssinaturaSat)
                .HasMaxLength(344)
                .HasColumnName("AssinaturaSAT");
            entity.Property(e => e.BloquearEstoqueNegativo).HasColumnName("Bloquear_EstoqueNegativo");
            entity.Property(e => e.CadastroPessoaPadrao).HasColumnName("Cadastro_PessoaPadrao");
            entity.Property(e => e.CaminhoNfe)
                .HasMaxLength(200)
                .HasColumnName("Caminho_NFe");
            entity.Property(e => e.CertificadoNfe)
                .HasMaxLength(200)
                .HasColumnName("Certificado_NFe");
            entity.Property(e => e.CfeA4).HasColumnName("CFe_A4");
            entity.Property(e => e.CfeCartao).HasColumnName("CFe_Cartao");
            entity.Property(e => e.CfePdvCartao).HasColumnName("CFe_PDV_Cartao");
            entity.Property(e => e.ClienteDescricao1).HasMaxLength(60);
            entity.Property(e => e.ClienteDescricao2).HasMaxLength(60);
            entity.Property(e => e.ClienteDescricao3).HasMaxLength(60);
            entity.Property(e => e.ConsultaGrade).HasColumnName("Consulta_Grade");
            entity.Property(e => e.ConsultaRapidaProduto).HasColumnName("Consulta_RapidaProduto");
            entity.Property(e => e.De).HasMaxLength(60);
            entity.Property(e => e.DecimalProdutoQuantidade).HasColumnName("Decimal_Produto_Quantidade");
            entity.Property(e => e.DecimalProdutoValor).HasColumnName("Decimal_Produto_Valor");
            entity.Property(e => e.DescontoPadrao).HasColumnName("Desconto_Padrao");
            entity.Property(e => e.DescricaoComissao)
                .HasMaxLength(60)
                .HasColumnName("Descricao_Comissao");
            entity.Property(e => e.DescricaoInfo1)
                .HasMaxLength(60)
                .HasColumnName("Descricao_Info1");
            entity.Property(e => e.DescricaoInfo2)
                .HasMaxLength(60)
                .HasColumnName("Descricao_Info2");
            entity.Property(e => e.DescricaoInfo3)
                .HasMaxLength(60)
                .HasColumnName("Descricao_Info3");
            entity.Property(e => e.DescricaoObs1)
                .HasMaxLength(60)
                .HasColumnName("Descricao_Obs1");
            entity.Property(e => e.DescricaoObs2)
                .HasMaxLength(60)
                .HasColumnName("Descricao_Obs2");
            entity.Property(e => e.Email).HasMaxLength(60);
            entity.Property(e => e.EmpresaDescricao1).HasMaxLength(60);
            entity.Property(e => e.EmpresaDescricao2).HasMaxLength(60);
            entity.Property(e => e.EmpresaDescricao3).HasMaxLength(60);
            entity.Property(e => e.EnderecoPadrao).HasColumnName("Endereco_Padrao");
            entity.Property(e => e.ExibeDesconto).HasColumnName("Exibe_Desconto");
            entity.Property(e => e.ExibeDuplicarProduto).HasColumnName("Exibe_DuplicarProduto");
            entity.Property(e => e.ExibeInfoProduto).HasColumnName("Exibe_InfoProduto");
            entity.Property(e => e.ExibeMsgCreditoIcms).HasColumnName("Exibe_msgCreditoICMS");
            entity.Property(e => e.ExibeNfeVenda).HasColumnName("Exibe_NFeVenda");
            entity.Property(e => e.ExibeReferenciaNfe).HasColumnName("Exibe_ReferenciaNFe");
            entity.Property(e => e.FornecedorDescricao1).HasMaxLength(60);
            entity.Property(e => e.FornecedorDescricao2).HasMaxLength(60);
            entity.Property(e => e.FornecedorDescricao3).HasMaxLength(60);
            entity.Property(e => e.FuncionarioDescricao1).HasMaxLength(60);
            entity.Property(e => e.FuncionarioDescricao2).HasMaxLength(60);
            entity.Property(e => e.FuncionarioDescricao3).HasMaxLength(60);
            entity.Property(e => e.IdCaixaPrincipal).HasColumnName("ID_Caixa_Principal");
            entity.Property(e => e.IdConsumidorFinal).HasColumnName("ID_ConsumidorFinal");
            entity.Property(e => e.IdContaCobrancaBancaria).HasColumnName("ID_Conta_CobrancaBancaria");
            entity.Property(e => e.IdContaDevolucaoCheque).HasColumnName("ID_ContaDevolucaoCheque");
            entity.Property(e => e.IdContaDevolucaoVenda).HasColumnName("ID_ContaDevolucaoVenda");
            entity.Property(e => e.IdContaFaturaCompra).HasColumnName("ID_ContaFaturaCompra");
            entity.Property(e => e.IdContaFaturaOs).HasColumnName("ID_ContaFaturaOS");
            entity.Property(e => e.IdContaFaturaVenda).HasColumnName("ID_ContaFaturaVenda");
            entity.Property(e => e.IdContaPagtoDiverso).HasColumnName("ID_Conta_PagtoDiverso");
            entity.Property(e => e.IdContaRectoDiverso).HasColumnName("ID_Conta_RectoDiverso");
            entity.Property(e => e.IdContaTransValor).HasColumnName("ID_ContaTransValor");
            entity.Property(e => e.IdPagtoBoleto).HasColumnName("ID_PagtoBoleto");
            entity.Property(e => e.IdTabelaVenda).HasColumnName("ID_TabelaVenda");
            entity.Property(e => e.ImprimeOsEquip).HasColumnName("Imprime_OS_Equip");
            entity.Property(e => e.InfoProduto1)
                .HasMaxLength(60)
                .HasColumnName("Info_Produto1");
            entity.Property(e => e.InfoProduto2)
                .HasMaxLength(60)
                .HasColumnName("Info_Produto2");
            entity.Property(e => e.JurosMes)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("Juros_Mes");
            entity.Property(e => e.LimiteDesconto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Limite_Desconto");
            entity.Property(e => e.ModeloMatricial).HasColumnName("Modelo_Matricial");
            entity.Property(e => e.MonitorCfe).HasColumnName("Monitor_CFe");
            entity.Property(e => e.MsgEstoqueNegativo).HasColumnName("Msg_EstoqueNegativo");
            entity.Property(e => e.Multa).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.MultiploUsuarioPdv).HasColumnName("MultiploUsuarioPDV");
            entity.Property(e => e.OrcaValorTotal).HasColumnName("Orca_ValorTotal");
            entity.Property(e => e.ProdutoMarca).HasColumnName("Produto_Marca");
            entity.Property(e => e.ProdutoPrecoVenda).HasColumnName("Produto_PrecoVenda");
            entity.Property(e => e.QtDiasPesquisa).HasColumnName("Qt_Dias_Pesquisa");
            entity.Property(e => e.SenhaAtivacaoSat)
                .HasMaxLength(32)
                .HasColumnName("SenhaAtivacaoSAT");
            entity.Property(e => e.SomenteMaiusculo).HasColumnName("Somente_Maiusculo");
            entity.Property(e => e.TelefonePadrao).HasColumnName("Telefone_Padrao");
            entity.Property(e => e.TipoEquipamentoSat).HasColumnName("TipoEquipamentoSAT");
            entity.Property(e => e.TipoNfeVenda).HasColumnName("Tipo_NFe_Venda");
            entity.Property(e => e.TipoSaidaFixo).HasColumnName("TipoSaida_Fixo");
            entity.Property(e => e.TransportadoraDescricao1).HasMaxLength(60);
            entity.Property(e => e.TransportadoraDescricao2).HasMaxLength(60);
            entity.Property(e => e.TransportadoraDescricao3).HasMaxLength(60);
            entity.Property(e => e.UltimoValor).HasColumnName("Ultimo_Valor");
            entity.Property(e => e.VendaImpressaoDireta).HasColumnName("Venda_ImpressaoDireta");
            entity.Property(e => e.VendaMatricial).HasColumnName("Venda_Matricial");
        });

        modelBuilder.Entity<ParametroUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario___3214EC271FEDB87C");

            entity.ToTable("Parametro_Usuario");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.LiberaDesconto).HasColumnName("Libera_Desconto");
            entity.Property(e => e.PermiteAterarFaturado).HasColumnName("Permite_AterarFaturado");
            entity.Property(e => e.PermiteFaturar).HasColumnName("Permite_Faturar");
            entity.Property(e => e.VendaFixaLogado).HasColumnName("Venda_Fixa_logado");
            entity.Property(e => e.VendaRestrita).HasColumnName("Venda_Restrita");
            entity.Property(e => e.VisualizaResumoVenda).HasColumnName("Visualiza_ResumoVenda");
        });

        modelBuilder.Entity<PermissaoMobile>(entity =>
        {
            entity.HasKey(e => new { e.IdUsuario, e.Menu });

            entity.ToTable("PermissaoMobile");

            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.Menu).HasMaxLength(50);
        });

        modelBuilder.Entity<PermissaoSistema>(entity =>
        {
            entity.HasKey(e => new { e.IdUsuario, e.Menu });

            entity.ToTable("PermissaoSistema");

            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.Menu).HasMaxLength(50);
        });

        modelBuilder.Entity<Pessoa>(entity =>
        {
            entity.ToTable("Pessoa");

            entity.HasIndex(e => e.IdPessoa, "I_ID_Pessoa");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cadastro).HasColumnType("datetime");
            entity.Property(e => e.Cei)
                .HasMaxLength(15)
                .HasColumnName("CEI");
            entity.Property(e => e.Cnae)
                .HasMaxLength(7)
                .IsFixedLength()
                .HasColumnName("CNAE");
            entity.Property(e => e.CnpjCpf)
                .HasMaxLength(18)
                .HasColumnName("CNPJ_CPF");
            entity.Property(e => e.Conjuge).HasMaxLength(60);
            entity.Property(e => e.Contato).HasMaxLength(60);
            entity.Property(e => e.CpfConjuge)
                .HasMaxLength(18)
                .HasColumnName("CPF_Conjuge");
            entity.Property(e => e.DescontoVenda)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Desconto_Venda");
            entity.Property(e => e.Descricao1).HasMaxLength(60);
            entity.Property(e => e.Descricao2).HasMaxLength(60);
            entity.Property(e => e.Descricao3).HasMaxLength(60);
            entity.Property(e => e.DiaFaturamento1)
                .HasMaxLength(10)
                .HasColumnName("Dia_Faturamento");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdGrupo).HasColumnName("ID_Grupo");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.IeRg)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("IE_RG");
            entity.Property(e => e.Im)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("IM");
            entity.Property(e => e.Informacao).HasMaxLength(200);
            entity.Property(e => e.InformacaoVenda)
                .HasMaxLength(60)
                .HasColumnName("Informacao_Venda");
            entity.Property(e => e.Limite).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.NascimentoFundacao)
                .HasColumnType("datetime")
                .HasColumnName("Nascimento_Fundacao");
            entity.Property(e => e.NomeFantasia).HasMaxLength(60);
            entity.Property(e => e.NomeRazao)
                .HasMaxLength(60)
                .HasColumnName("Nome_Razao");
            entity.Property(e => e.ProfissaoConjuge)
                .HasMaxLength(60)
                .HasColumnName("Profissao_Conjuge");
            entity.Property(e => e.RamoProfissao)
                .HasMaxLength(60)
                .HasColumnName("Ramo_Profissao");
            entity.Property(e => e.RgConjuge)
                .HasMaxLength(18)
                .HasColumnName("RG_Conjuge");
            entity.Property(e => e.SituacaoOld).HasColumnName("Situacao_old");
            entity.Property(e => e.ValorMensalidade).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<PessoaCliente>(entity =>
        {
            entity.ToTable("PessoaCliente");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.Referencia).HasMaxLength(200);
        });

        modelBuilder.Entity<PessoaEmail>(entity =>
        {
            entity.HasKey(e => e.IdEmail);

            entity.ToTable("PessoaEmail");

            entity.HasIndex(e => e.IdPessoa, "I_ID_Pessoa");

            entity.Property(e => e.IdEmail).HasColumnName("ID_Email");
            entity.Property(e => e.Email).HasMaxLength(60);
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.InformacaoEmail).HasMaxLength(60);
        });

        modelBuilder.Entity<PessoaEmpresa>(entity =>
        {
            entity.ToTable("PessoaEmpresa");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Referencia).HasMaxLength(200);
        });

        modelBuilder.Entity<PessoaEmpresaResponsavel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pessoa_E__3214EC2769C6B1F5");

            entity.ToTable("Pessoa_EmpresaResponsavel");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.IdPessoaResponsavel).HasColumnName("ID_PessoaResponsavel");
        });

        modelBuilder.Entity<PessoaEndereco>(entity =>
        {
            entity.HasKey(e => e.IdEndereco);

            entity.ToTable("PessoaEndereco");

            entity.HasIndex(e => e.IdPessoa, "I_ID_Pessoa");

            entity.Property(e => e.IdEndereco).HasColumnName("ID_Endereco");
            entity.Property(e => e.Bairro).HasMaxLength(60);
            entity.Property(e => e.Cep)
                .HasMaxLength(9)
                .IsFixedLength()
                .HasColumnName("CEP");
            entity.Property(e => e.Complemento).HasMaxLength(60);
            entity.Property(e => e.IdMunicipio).HasColumnName("ID_Municipio");
            entity.Property(e => e.IdPais).HasColumnName("ID_Pais");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.Logradouro).HasMaxLength(60);
            entity.Property(e => e.NumeroEndereco).HasMaxLength(60);
        });

        modelBuilder.Entity<PessoaFiador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PessoaFi__3214EC273BCADD1B");

            entity.ToTable("PessoaFiador");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.Referencia).HasMaxLength(200);
        });

        modelBuilder.Entity<PessoaFornecedor>(entity =>
        {
            entity.ToTable("PessoaFornecedor");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Referencia).HasMaxLength(200);
        });

        modelBuilder.Entity<PessoaFuncionario>(entity =>
        {
            entity.ToTable("PessoaFuncionario");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CarteiraProfissional).HasMaxLength(14);
            entity.Property(e => e.Pis)
                .HasMaxLength(15)
                .HasColumnName("PIS");
            entity.Property(e => e.Referencia).HasMaxLength(200);
            entity.Property(e => e.Salario).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<PessoaImagem>(entity =>
        {
            entity.ToTable("PessoaImagem");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.Imagem).HasColumnType("image");
        });

        modelBuilder.Entity<PessoaLocatario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PessoaLo__3214EC2737FA4C37");

            entity.ToTable("PessoaLocatario");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.Referencia).HasMaxLength(200);
        });

        modelBuilder.Entity<PessoaProprietario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PessoaPr__3214EC273429BB53");

            entity.ToTable("PessoaProprietario");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.Referencia).HasMaxLength(200);
        });

        modelBuilder.Entity<PessoaResponsavel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PessoaRe__3214EC2732767D0B");

            entity.ToTable("PessoaResponsavel");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Referencia).HasMaxLength(200);
        });

        modelBuilder.Entity<PessoaTelefone>(entity =>
        {
            entity.HasKey(e => e.IdTelefone);

            entity.ToTable("PessoaTelefone");

            entity.HasIndex(e => e.IdPessoa, "I_ID_Pessoa");

            entity.Property(e => e.IdTelefone).HasColumnName("ID_Telefone");
            entity.Property(e => e.Ddd)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("DDD");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.InformacaoTelefone)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.NumeroTelefone).HasMaxLength(13);
        });

        modelBuilder.Entity<PessoaTransportadora>(entity =>
        {
            entity.ToTable("PessoaTransportadora");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Referencia).HasMaxLength(200);
        });

        modelBuilder.Entity<PlanoContum>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Codigo).HasMaxLength(20);
            entity.Property(e => e.CodigoDescritivo).HasMaxLength(20);
            entity.Property(e => e.CodigoPai).HasMaxLength(20);
            entity.Property(e => e.Descricao).HasMaxLength(60);
            entity.Property(e => e.Referencial).HasMaxLength(20);
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Produto");

            entity.Property(e => e.Barra).HasMaxLength(14);
            entity.Property(e => e.Barratributavel).HasMaxLength(14);
            entity.Property(e => e.ClasseEnquadramento).HasMaxLength(5);
            entity.Property(e => e.Cnpjprodutor)
                .HasMaxLength(18)
                .HasColumnName("CNPJProdutor");
            entity.Property(e => e.CodAnp).HasColumnName("Cod_ANP");
            entity.Property(e => e.CodGrupo)
                .HasMaxLength(20)
                .HasColumnName("Cod_Grupo");
            entity.Property(e => e.ControleEstoque).HasColumnName("Controle_Estoque");
            entity.Property(e => e.CustoFinal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descricao).HasMaxLength(60);
            entity.Property(e => e.DescricaoGrupo).HasMaxLength(60);
            entity.Property(e => e.DescricaoImposto).HasMaxLength(60);
            entity.Property(e => e.DescricaoUnidade).HasMaxLength(60);
            entity.Property(e => e.ExTipi).HasColumnName("EX_TIPI");
            entity.Property(e => e.Fabricante).HasMaxLength(60);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdGrupo).HasColumnName("ID_Grupo");
            entity.Property(e => e.IdImposto).HasColumnName("ID_Imposto");
            entity.Property(e => e.Imagem).HasColumnType("image");
            entity.Property(e => e.Informacao).HasMaxLength(200);
            entity.Property(e => e.Ncm)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("NCM");
            entity.Property(e => e.OutrosCustos).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PesoB).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.PesoL).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.Referencia).HasMaxLength(60);
            entity.Property(e => e.ValorCompra).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorIpi)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("ValorIPI");
        });

        modelBuilder.Entity<ProdutoComissao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProdutoC__3214EC27671F4F74");

            entity.ToTable("Produto_Comissao");

            entity.HasIndex(e => e.IdProduto, "I_ID_Produto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Comissao).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
            entity.Property(e => e.IdTipoComissao).HasColumnName("ID_TipoComissao");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
        });

        modelBuilder.Entity<ProdutoDesconto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Produto___3214EC27190BB0C3");

            entity.ToTable("Produto_Desconto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Desconto).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
            entity.Property(e => e.QuantidadeMaxima)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("Quantidade_Maxima");
            entity.Property(e => e.QuantidadeMinima)
                .HasColumnType("decimal(9, 2)")
                .HasColumnName("Quantidade_Minima");
        });

        modelBuilder.Entity<ProdutoDescontoPessoa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Produto___3214EC2720ACD28B");

            entity.ToTable("Produto_Desconto_Pessoa");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Desconto).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
        });

        modelBuilder.Entity<ProdutoEntradaItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ItemOrdemCompra");

            entity.ToTable("Produto_Entrada_Item");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdGrade).HasColumnName("ID_Grade");
            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
            entity.Property(e => e.IdProdutoEntrada).HasColumnName("ID_Produto_Entrada");
            entity.Property(e => e.Margem).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.NfeCodigoProduto)
                .HasMaxLength(60)
                .HasColumnName("NFe_CodigoProduto");
            entity.Property(e => e.NfeDescricao)
                .HasMaxLength(200)
                .HasColumnName("NFe_Descricao");
            entity.Property(e => e.OutrosCustos).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Quantidade).HasColumnType("decimal(9, 3)");
            entity.Property(e => e.ValorAntigo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorCompra).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorIpi)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("ValorIPI");
            entity.Property(e => e.ValorSt)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("ValorST");
            entity.Property(e => e.ValorVenda).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<ProdutoEntradum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_OrdemCompra");

            entity.ToTable("Produto_Entrada");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Data).HasColumnType("datetime");
            entity.Property(e => e.Documento).HasMaxLength(100);
            entity.Property(e => e.Entrega).HasColumnType("datetime");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdPagamento).HasColumnName("ID_Pagamento");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.Informacao).HasMaxLength(200);
            entity.Property(e => e.TipoEntrada).HasColumnName("Tipo_Entrada");
        });

        modelBuilder.Entity<ProdutoEstoque>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProdutoE__3214EC2772910220");

            entity.ToTable("Produto_Estoque");

            entity.HasIndex(e => e.IdProduto, "I_ID_Produto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EstoqueAtual).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.EstoqueIdeal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.EstoqueMinimo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdGrade).HasColumnName("ID_Grade");
            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
            entity.Property(e => e.Localizacao).HasMaxLength(60);
        });

        modelBuilder.Entity<ProdutoEstrutura>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Produto_Estrutura");

            entity.HasIndex(e => e.IdGradeEstrutura, "I_ID_Grade_Estrutura");

            entity.HasIndex(e => e.IdProduto, "I_ID_Produto");

            entity.HasIndex(e => e.IdProdutoEstrutura, "I_ID_Produto_Estrutura");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.IdGradeEstrutura).HasColumnName("ID_Grade_Estrutura");
            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
            entity.Property(e => e.IdProdutoEstrutura).HasColumnName("ID_Produto_Estrutura");
            entity.Property(e => e.Quantidade).HasColumnType("decimal(10, 3)");
        });

        modelBuilder.Entity<ProdutoFornecedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ProdutoFornecedor");

            entity.ToTable("Produto_Fornecedor");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CodigoProduto)
                .HasMaxLength(60)
                .HasColumnName("Codigo_Produto");
            entity.Property(e => e.IdFornecedor).HasColumnName("ID_Fornecedor");
            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
        });

        modelBuilder.Entity<ProdutoMovimento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Produto___3214EC2774CE504D");

            entity.ToTable("Produto_Movimento");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Data).HasColumnType("datetime");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
            entity.Property(e => e.Informacao).HasMaxLength(200);
            entity.Property(e => e.Quantidade).HasColumnType("decimal(10, 3)");
        });

        modelBuilder.Entity<ProdutoParametro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProdutoI__3214EC273DE82FB7");

            entity.ToTable("Produto_Parametro");

            entity.HasIndex(e => e.IdImposto, "I_ID_Imposto");

            entity.HasIndex(e => e.IdProduto, "I_ID_Produto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdImposto).HasColumnName("ID_Imposto");
            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
        });

        modelBuilder.Entity<ProdutoServico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Produto");

            entity.ToTable("Produto_Servico");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Abc)
                .HasMaxLength(1)
                .HasColumnName("ABC");
            entity.Property(e => e.Barra).HasMaxLength(14);
            entity.Property(e => e.Barratributavel).HasMaxLength(14);
            entity.Property(e => e.ClasseEnquadramento).HasMaxLength(5);
            entity.Property(e => e.Cnpjprodutor)
                .HasMaxLength(18)
                .HasColumnName("CNPJProdutor");
            entity.Property(e => e.CodAnp).HasColumnName("Cod_ANP");
            entity.Property(e => e.ControleEstoque).HasColumnName("Controle_Estoque");
            entity.Property(e => e.CustoFinal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descricao).HasMaxLength(60);
            entity.Property(e => e.ExTipi).HasColumnName("EX_TIPI");
            entity.Property(e => e.Fabricante).HasMaxLength(60);
            entity.Property(e => e.GrupoNivel).HasMaxLength(20);
            entity.Property(e => e.IdCest).HasColumnName("ID_CEST");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdGrupo).HasColumnName("ID_Grupo");
            entity.Property(e => e.Imagem).HasColumnType("image");
            entity.Property(e => e.InfoAdicional1).HasMaxLength(60);
            entity.Property(e => e.InfoAdicional2).HasMaxLength(60);
            entity.Property(e => e.Informacao).HasMaxLength(200);
            entity.Property(e => e.Ncm)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("NCM");
            entity.Property(e => e.OutrosCustos).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PesoB).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.PesoL).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.Referencia).HasMaxLength(60);
            entity.Property(e => e.ValorCompra).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorIpi)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("ValorIPI");
            entity.Property(e => e.ValorSt)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("ValorST");
        });

        modelBuilder.Entity<ProdutoValor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ProdutoValor");

            entity.ToTable("Produto_Valor");

            entity.HasIndex(e => e.IdProduto, "I_ID_Produto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
            entity.Property(e => e.IdTabela).HasColumnName("ID_Tabela");
            entity.Property(e => e.MargemVenda).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UltimoReajuste).HasColumnType("datetime");
            entity.Property(e => e.ValorVenda).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<TabelaValor>(entity =>
        {
            entity.ToTable("TabelaValor");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CustoOperacional).HasColumnType("decimal(6, 3)");
            entity.Property(e => e.Descricao).HasMaxLength(60);
            entity.Property(e => e.Margem).HasColumnType("decimal(6, 3)");
        });

        modelBuilder.Entity<Uf>(entity =>
        {
            entity.ToTable("UF");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AliquotaFcp)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Aliquota_FCP");
            entity.Property(e => e.AliquotaInterna)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Aliquota_Interna");
            entity.Property(e => e.Descricao).HasMaxLength(60);
            entity.Property(e => e.IdPais).HasColumnName("ID_Pais");
            entity.Property(e => e.IdUf).HasColumnName("ID_UF");
            entity.Property(e => e.Sigla)
                .HasMaxLength(2)
                .IsFixedLength();
        });

        modelBuilder.Entity<UfAliquotaIcm>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UF_AliquotaICMS");

            entity.Property(e => e.Aliquota).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.IdUfDestino).HasColumnName("ID_UF_Destino");
            entity.Property(e => e.IdUfOrigem).HasColumnName("ID_UF_Origem");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("Usuario");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descricao).HasMaxLength(60);
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.SenhaMobile).HasMaxLength(20);
            entity.Property(e => e.SenhaSistema).HasMaxLength(20);
        });

        modelBuilder.Entity<VChequeHistorico>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Cheque_Historico");

            entity.Property(e => e.Credito).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.CreditoFluxo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DataBaixa).HasColumnType("datetime");
            entity.Property(e => e.Debito).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.DebitoFluxo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descricao).HasMaxLength(200);
            entity.Property(e => e.DescricaoCaixa).HasMaxLength(60);
            entity.Property(e => e.DescricaoConta).HasMaxLength(60);
            entity.Property(e => e.DescricaoContaFluxo).HasMaxLength(60);
            entity.Property(e => e.DescricaoPessoa).HasMaxLength(60);
            entity.Property(e => e.Documento).HasMaxLength(20);
            entity.Property(e => e.Emissao).HasColumnType("datetime");
            entity.Property(e => e.IdCaixa).HasColumnName("ID_Caixa");
            entity.Property(e => e.IdCheque).HasColumnName("ID_Cheque");
            entity.Property(e => e.IdCpagar).HasColumnName("ID_CPagar");
            entity.Property(e => e.IdCreceber).HasColumnName("ID_CReceber");
            entity.Property(e => e.IdFluxoCaixa).HasColumnName("ID_FluxoCaixa");
            entity.Property(e => e.IdPagamento).HasColumnName("ID_Pagamento");
            entity.Property(e => e.Total).HasColumnType("decimal(12, 2)");
        });

        modelBuilder.Entity<VCpagar>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CPagar");

            entity.Property(e => e.Acrescimo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Conta).HasMaxLength(20);
            entity.Property(e => e.Conta1).HasMaxLength(20);
            entity.Property(e => e.Conta2).HasMaxLength(20);
            entity.Property(e => e.Conta3).HasMaxLength(20);
            entity.Property(e => e.DataBaixa).HasColumnType("datetime");
            entity.Property(e => e.Desconto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descricao).HasMaxLength(200);
            entity.Property(e => e.DescricaoConta).HasMaxLength(60);
            entity.Property(e => e.DescricaoConta1).HasMaxLength(60);
            entity.Property(e => e.DescricaoConta2).HasMaxLength(60);
            entity.Property(e => e.DescricaoConta3).HasMaxLength(60);
            entity.Property(e => e.DescricaoPessoa).HasMaxLength(60);
            entity.Property(e => e.DescricaoSituacao)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.Documento)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Emissao).HasColumnType("datetime");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdConta).HasColumnName("ID_Conta");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.ResumoParcela)
                .HasMaxLength(33)
                .IsUnicode(false);
            entity.Property(e => e.Total).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Vencimento).HasColumnType("datetime");
        });

        modelBuilder.Entity<VCreceber>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CReceber");

            entity.Property(e => e.Acrescimo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Conta).HasMaxLength(20);
            entity.Property(e => e.Conta1).HasMaxLength(20);
            entity.Property(e => e.Conta2).HasMaxLength(20);
            entity.Property(e => e.Conta3).HasMaxLength(20);
            entity.Property(e => e.DataBaixa).HasColumnType("datetime");
            entity.Property(e => e.Desconto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descricao).HasMaxLength(200);
            entity.Property(e => e.DescricaoBoleto)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DescricaoConta).HasMaxLength(60);
            entity.Property(e => e.DescricaoConta1).HasMaxLength(60);
            entity.Property(e => e.DescricaoConta2).HasMaxLength(60);
            entity.Property(e => e.DescricaoConta3).HasMaxLength(60);
            entity.Property(e => e.DescricaoPessoa).HasMaxLength(60);
            entity.Property(e => e.DescricaoSituacao)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.Documento)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Emissao).HasColumnType("datetime");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdConta).HasColumnName("ID_Conta");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdOs).HasColumnName("ID_OS");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.IdPrevisaoPagto).HasColumnName("ID_PrevisaoPagto");
            entity.Property(e => e.IdVenda).HasColumnName("ID_Venda");
            entity.Property(e => e.PrevisaoPagto).HasMaxLength(60);
            entity.Property(e => e.ResumoParcela)
                .HasMaxLength(33)
                .IsUnicode(false);
            entity.Property(e => e.Total).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Vencimento).HasColumnType("datetime");
        });

        modelBuilder.Entity<VFichaProducao>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_FichaProducao");

            entity.Property(e => e.Abd)
                .HasMaxLength(100)
                .HasColumnName("ABD");
            entity.Property(e => e.Abt)
                .HasMaxLength(100)
                .HasColumnName("ABT");
            entity.Property(e => e.AnoModelo).HasMaxLength(60);
            entity.Property(e => e.CorCouro).HasMaxLength(100);
            entity.Property(e => e.Costura).HasMaxLength(100);
            entity.Property(e => e.DataVenda).HasColumnType("datetime");
            entity.Property(e => e.DescricaoLogomarca)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.DescricaoPessoa).HasMaxLength(60);
            entity.Property(e => e.DescricaoProduto).HasMaxLength(163);
            entity.Property(e => e.DescricaoProdutoInfo).HasMaxLength(264);
            entity.Property(e => e.DescricaoSituacao)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DescricaoUsuarioComissao1).HasMaxLength(60);
            entity.Property(e => e.Entrada).HasColumnType("datetime");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdItemVenda).HasColumnName("ID_Item_Venda");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.IdVenda).HasColumnName("ID_Venda");
            entity.Property(e => e.InfoAdicional1).HasMaxLength(60);
            entity.Property(e => e.LateraisPorta).HasColumnName("Laterais_Porta");
            entity.Property(e => e.Observacao).HasMaxLength(500);
            entity.Property(e => e.Saida).HasColumnType("datetime");
            entity.Property(e => e.TipoAcento).HasMaxLength(100);
            entity.Property(e => e.TipoEncosto).HasMaxLength(100);
            entity.Property(e => e.Transportadora).HasMaxLength(200);
        });

        modelBuilder.Entity<VFinanceiroMobile>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Financeiro_Mobile");

            entity.Property(e => e.Descricao).HasMaxLength(200);
            entity.Property(e => e.Emissao).HasColumnType("datetime");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.ResumoParcela)
                .HasMaxLength(33)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Vencimento).HasColumnType("datetime");
        });

        modelBuilder.Entity<VHistoricoVendaItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_HistoricoVenda_Item");

            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.IdVenda).HasColumnName("ID_Venda");
            entity.Property(e => e.Informacao).HasMaxLength(100);
            entity.Property(e => e.Quantidade).HasColumnType("decimal(9, 3)");
        });

        modelBuilder.Entity<VHistoricoVendum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_HistoricoVenda");

            entity.Property(e => e.Comprador).HasMaxLength(200);
            entity.Property(e => e.Data)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdParcelamento).HasColumnName("ID_Parcelamento");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.IdTabela).HasColumnName("ID_Tabela");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.Informacao)
                .HasMaxLength(1000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VOrcamento>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Orcamento");

            entity.Property(e => e.Complemento).HasMaxLength(60);
            entity.Property(e => e.CustoTotal).HasColumnType("decimal(38, 5)");
            entity.Property(e => e.Data).HasColumnType("datetime");
            entity.Property(e => e.Descricao).HasMaxLength(60);
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdOrcamento).HasColumnName("ID_Orcamento");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.IdUf).HasColumnName("ID_UF");
            entity.Property(e => e.IdUsuarioComissao1).HasColumnName("ID_UsuarioComissao1");
            entity.Property(e => e.IdUsuarioComissao2).HasColumnName("ID_UsuarioComissao2");
            entity.Property(e => e.IdUsuarioComissao3).HasColumnName("ID_UsuarioComissao3");
            entity.Property(e => e.Informacao).HasMaxLength(200);
            entity.Property(e => e.Municipio).HasMaxLength(63);
            entity.Property(e => e.ValorTotal).HasColumnType("decimal(38, 5)");
        });

        modelBuilder.Entity<VOrcamentoItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Orcamento_Item");

            entity.Property(e => e.Acrescimo).HasColumnType("decimal(11, 2)");
            entity.Property(e => e.Desconto).HasColumnType("decimal(11, 2)");
            entity.Property(e => e.DescricaoProduto).HasMaxLength(163);
            entity.Property(e => e.DescricaoSaida).HasMaxLength(60);
            entity.Property(e => e.IdGrade).HasColumnName("ID_Grade");
            entity.Property(e => e.IdOrcamento).HasColumnName("ID_Orcamento");
            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
            entity.Property(e => e.IdTabela).HasColumnName("ID_Tabela");
            entity.Property(e => e.Iditem).HasColumnName("IDItem");
            entity.Property(e => e.InfoAdicional1).HasMaxLength(60);
            entity.Property(e => e.InfoAdicional2).HasMaxLength(60);
            entity.Property(e => e.Informacao).HasMaxLength(100);
            entity.Property(e => e.Marca).HasMaxLength(60);
            entity.Property(e => e.Quantidade).HasColumnType("decimal(9, 3)");
            entity.Property(e => e.Referencia).HasMaxLength(60);
            entity.Property(e => e.ValorCusto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorProduto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorTotal).HasColumnType("decimal(20, 5)");
            entity.Property(e => e.ValorVenda).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<VOrdemServico>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Ordem_Servico");

            entity.Property(e => e.Complemento).HasMaxLength(60);
            entity.Property(e => e.CpfCnpj)
                .HasMaxLength(18)
                .HasColumnName("CPF_CNPJ");
            entity.Property(e => e.CustoTotal).HasColumnType("decimal(38, 5)");
            entity.Property(e => e.DataAbertura)
                .HasColumnType("datetime")
                .HasColumnName("Data_Abertura");
            entity.Property(e => e.DataAprovacao)
                .HasColumnType("datetime")
                .HasColumnName("Data_Aprovacao");
            entity.Property(e => e.DataEntrega)
                .HasColumnType("datetime")
                .HasColumnName("Data_Entrega");
            entity.Property(e => e.DataMontagem)
                .HasColumnType("datetime")
                .HasColumnName("Data_Montagem");
            entity.Property(e => e.DataOrcamento)
                .HasColumnType("datetime")
                .HasColumnName("Data_Orcamento");
            entity.Property(e => e.DataPronta)
                .HasColumnType("datetime")
                .HasColumnName("Data_Pronta");
            entity.Property(e => e.Descricao).HasMaxLength(60);
            entity.Property(e => e.DescricaoAtendimento).HasMaxLength(60);
            entity.Property(e => e.DescricaoEquipamento).HasMaxLength(60);
            entity.Property(e => e.DescricaoMarca).HasMaxLength(60);
            entity.Property(e => e.DescricaoStatus)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.IdCfe).HasColumnName("ID_CFe");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdNfe).HasColumnName("ID_NFe");
            entity.Property(e => e.IdOs).HasColumnName("ID_OS");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.IdUf).HasColumnName("ID_UF");
            entity.Property(e => e.IdUsuarioComissao1).HasColumnName("ID_UsuarioComissao1");
            entity.Property(e => e.IdUsuarioComissao2).HasColumnName("ID_UsuarioComissao2");
            entity.Property(e => e.InfoEquip1)
                .HasMaxLength(60)
                .HasColumnName("Info_Equip_1");
            entity.Property(e => e.InfoEquip2)
                .HasMaxLength(60)
                .HasColumnName("Info_Equip_2");
            entity.Property(e => e.InfoEquip3)
                .HasMaxLength(60)
                .HasColumnName("Info_Equip_3");
            entity.Property(e => e.InformacaoCompleta).HasMaxLength(186);
            entity.Property(e => e.Municipio).HasMaxLength(63);
            entity.Property(e => e.Nfe).HasColumnName("NFe");
            entity.Property(e => e.ObsEquip1)
                .HasMaxLength(200)
                .HasColumnName("Obs_Equip_1");
            entity.Property(e => e.ObsEquip2)
                .HasMaxLength(200)
                .HasColumnName("Obs_Equip_2");
            entity.Property(e => e.Observacao).HasMaxLength(1000);
            entity.Property(e => e.Reclamacao).HasMaxLength(1000);
            entity.Property(e => e.StatusOs).HasColumnName("Status_OS");
            entity.Property(e => e.TipoEquipamento).HasColumnName("Tipo_Equipamento");
            entity.Property(e => e.ValorTotal).HasColumnType("decimal(38, 5)");
        });

        modelBuilder.Entity<VOrdemServicoItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Ordem_Servico_Item");

            entity.Property(e => e.Acrescimo).HasColumnType("decimal(11, 2)");
            entity.Property(e => e.ControleEstoque).HasColumnName("Controle_Estoque");
            entity.Property(e => e.Desconto).HasColumnType("decimal(11, 2)");
            entity.Property(e => e.DescricaoProduto).HasMaxLength(163);
            entity.Property(e => e.DescricaoSaida)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.IdGrade).HasColumnName("ID_Grade");
            entity.Property(e => e.IdOs).HasColumnName("ID_OS");
            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
            entity.Property(e => e.IdTabela).HasColumnName("ID_Tabela");
            entity.Property(e => e.Iditem).HasColumnName("IDItem");
            entity.Property(e => e.Informacao).HasMaxLength(100);
            entity.Property(e => e.Marca).HasMaxLength(60);
            entity.Property(e => e.Quantidade).HasColumnType("decimal(9, 3)");
            entity.Property(e => e.QuantidadeEntregue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Quantidade_Entregue");
            entity.Property(e => e.Referencia).HasMaxLength(60);
            entity.Property(e => e.ValorCusto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorProduto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorTotal).HasColumnType("decimal(20, 5)");
            entity.Property(e => e.ValorVenda).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<VOrdemServicoItemImposto>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Ordem_Servico_Item_Imposto");

            entity.Property(e => e.Acrescimo).HasColumnType("decimal(11, 2)");
            entity.Property(e => e.AliquotaCofins)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaCOFINS");
            entity.Property(e => e.AliquotaCofinsst)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaCOFINSST");
            entity.Property(e => e.AliquotaIcms)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaICMS");
            entity.Property(e => e.AliquotaIcmsst)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaICMSST");
            entity.Property(e => e.AliquotaIpi)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaIPI");
            entity.Property(e => e.AliquotaPis)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaPIS");
            entity.Property(e => e.AliquotaPisst)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaPISST");
            entity.Property(e => e.Cfop)
                .HasMaxLength(4)
                .HasColumnName("CFOP");
            entity.Property(e => e.ClasseEnquadramento).HasMaxLength(5);
            entity.Property(e => e.Cnpjprodutor)
                .HasMaxLength(18)
                .HasColumnName("CNPJProdutor");
            entity.Property(e => e.CodEnquadramento)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("Cod_Enquadramento");
            entity.Property(e => e.Cst).HasColumnName("CST");
            entity.Property(e => e.Cstcofins).HasColumnName("CSTCOFINS");
            entity.Property(e => e.Cstipi).HasColumnName("CSTIPI");
            entity.Property(e => e.Cstpis).HasColumnName("CSTPIS");
            entity.Property(e => e.Desconto).HasColumnType("decimal(11, 2)");
            entity.Property(e => e.DescricaoProduto).HasMaxLength(163);
            entity.Property(e => e.ExTipi).HasColumnName("EX_TIPI");
            entity.Property(e => e.IdCest).HasColumnName("ID_CEST");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdGrade).HasColumnName("ID_Grade");
            entity.Property(e => e.IdImposto).HasColumnName("ID_Imposto");
            entity.Property(e => e.IdOs).HasColumnName("ID_OS");
            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
            entity.Property(e => e.IdTabela).HasColumnName("ID_Tabela");
            entity.Property(e => e.Informacao).HasMaxLength(100);
            entity.Property(e => e.MargemVadicionado)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("MargemVAdicionado");
            entity.Property(e => e.ModalidadeBc).HasColumnName("ModalidadeBC");
            entity.Property(e => e.ModalidadeBcst).HasColumnName("ModalidadeBCST");
            entity.Property(e => e.Ncm)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("NCM");
            entity.Property(e => e.PercentualReducao).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PercentualReducaoSt)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PercentualReducaoST");
            entity.Property(e => e.Quantidade).HasColumnType("decimal(9, 3)");
            entity.Property(e => e.TipoNf).HasColumnName("Tipo_NF");
            entity.Property(e => e.ValorCusto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorProduto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorTotal).HasColumnType("decimal(20, 5)");
            entity.Property(e => e.ValorVenda).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<VOrdemServicoItemImpostoCf>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Ordem_Servico_Item_Imposto_CF");

            entity.Property(e => e.Acrescimo).HasColumnType("decimal(11, 2)");
            entity.Property(e => e.AliquotaCofins)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaCOFINS");
            entity.Property(e => e.AliquotaCofinsst)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaCOFINSST");
            entity.Property(e => e.AliquotaIcms)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaICMS");
            entity.Property(e => e.AliquotaIcmsst)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaICMSST");
            entity.Property(e => e.AliquotaIpi)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaIPI");
            entity.Property(e => e.AliquotaPis)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaPIS");
            entity.Property(e => e.AliquotaPisst)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaPISST");
            entity.Property(e => e.Cfop)
                .HasMaxLength(4)
                .HasColumnName("CFOP");
            entity.Property(e => e.ClasseEnquadramento).HasMaxLength(5);
            entity.Property(e => e.Cnpjprodutor)
                .HasMaxLength(18)
                .HasColumnName("CNPJProdutor");
            entity.Property(e => e.CodEnquadramento)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("Cod_Enquadramento");
            entity.Property(e => e.Cst).HasColumnName("CST");
            entity.Property(e => e.Cstcofins).HasColumnName("CSTCOFINS");
            entity.Property(e => e.Cstipi).HasColumnName("CSTIPI");
            entity.Property(e => e.Cstpis).HasColumnName("CSTPIS");
            entity.Property(e => e.Desconto).HasColumnType("decimal(11, 2)");
            entity.Property(e => e.DescricaoProduto).HasMaxLength(163);
            entity.Property(e => e.ExTipi).HasColumnName("EX_TIPI");
            entity.Property(e => e.IdCest).HasColumnName("ID_CEST");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdGrade).HasColumnName("ID_Grade");
            entity.Property(e => e.IdImposto).HasColumnName("ID_Imposto");
            entity.Property(e => e.IdOs).HasColumnName("ID_OS");
            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
            entity.Property(e => e.IdTabela).HasColumnName("ID_Tabela");
            entity.Property(e => e.Informacao).HasMaxLength(100);
            entity.Property(e => e.MargemVadicionado)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("MargemVAdicionado");
            entity.Property(e => e.ModalidadeBc).HasColumnName("ModalidadeBC");
            entity.Property(e => e.ModalidadeBcst).HasColumnName("ModalidadeBCST");
            entity.Property(e => e.Ncm)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("NCM");
            entity.Property(e => e.PercentualReducao).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PercentualReducaoSt)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PercentualReducaoST");
            entity.Property(e => e.Quantidade).HasColumnType("decimal(9, 3)");
            entity.Property(e => e.TipoNf).HasColumnName("Tipo_NF");
            entity.Property(e => e.ValorCusto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorProduto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorTotal).HasColumnType("decimal(20, 5)");
            entity.Property(e => e.ValorVenda).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<VOrdemServicoResumoPagto>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Ordem_Servico_ResumoPagto");

            entity.Property(e => e.Credito).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Data).HasColumnType("datetime");
            entity.Property(e => e.Descricao).HasMaxLength(60);
            entity.Property(e => e.IdOs).HasColumnName("ID_OS");
            entity.Property(e => e.ValorPago).HasColumnType("decimal(12, 2)");
        });

        modelBuilder.Entity<VPessoaMobile>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_PessoaMobile");

            entity.Property(e => e.Bairro).HasMaxLength(60);
            entity.Property(e => e.Cei)
                .HasMaxLength(15)
                .HasColumnName("CEI");
            entity.Property(e => e.Cep)
                .HasMaxLength(9)
                .IsFixedLength()
                .HasColumnName("CEP");
            entity.Property(e => e.CnpjCpf)
                .HasMaxLength(18)
                .HasColumnName("CNPJ_CPF");
            entity.Property(e => e.Complemento).HasMaxLength(60);
            entity.Property(e => e.Conjuge).HasMaxLength(60);
            entity.Property(e => e.CpfConjuge)
                .HasMaxLength(18)
                .HasColumnName("CPF_Conjuge");
            entity.Property(e => e.Ddd)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("DDD");
            entity.Property(e => e.Descricao1).HasMaxLength(60);
            entity.Property(e => e.Descricao2).HasMaxLength(60);
            entity.Property(e => e.Descricao3).HasMaxLength(60);
            entity.Property(e => e.DescricaoGrupo).HasMaxLength(60);
            entity.Property(e => e.Email).HasMaxLength(60);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdMunicipio).HasColumnName("ID_Municipio");
            entity.Property(e => e.IdPais).HasColumnName("ID_Pais");
            entity.Property(e => e.IdUf).HasColumnName("ID_UF");
            entity.Property(e => e.IdVendedor).HasColumnName("ID_Vendedor");
            entity.Property(e => e.IeRg)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("IE_RG");
            entity.Property(e => e.Informacao).HasMaxLength(200);
            entity.Property(e => e.Logradouro).HasMaxLength(60);
            entity.Property(e => e.Municipio).HasMaxLength(60);
            entity.Property(e => e.NomeFantasia).HasMaxLength(60);
            entity.Property(e => e.NomeRazao)
                .HasMaxLength(60)
                .HasColumnName("Nome_Razao");
            entity.Property(e => e.NumeroEndereco).HasMaxLength(60);
            entity.Property(e => e.NumeroTelefone).HasMaxLength(13);
            entity.Property(e => e.Pais).HasMaxLength(60);
            entity.Property(e => e.ProfissaoConjuge)
                .HasMaxLength(60)
                .HasColumnName("Profissao_Conjuge");
            entity.Property(e => e.RgConjuge)
                .HasMaxLength(18)
                .HasColumnName("RG_Conjuge");
            entity.Property(e => e.Uf)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("UF");
        });

        modelBuilder.Entity<VPlanejamento>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Planejamento");

            entity.Property(e => e.Conta).HasMaxLength(20);
            entity.Property(e => e.Credito).HasColumnType("numeric(12, 2)");
            entity.Property(e => e.Debito).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.DescricaoConta).HasMaxLength(60);
            entity.Property(e => e.DescricaoPessoa).HasMaxLength(2000);
            entity.Property(e => e.Documento).HasMaxLength(2000);
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.ResumoParcela)
                .HasMaxLength(33)
                .IsUnicode(false);
            entity.Property(e => e.Saldo).HasColumnType("numeric(1, 1)");
            entity.Property(e => e.Tipo)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.Vencimento).HasColumnType("datetime");
        });

        modelBuilder.Entity<VPlanoContum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_PlanoConta");

            entity.Property(e => e.Codigo).HasMaxLength(20);
            entity.Property(e => e.Codigo1).HasMaxLength(20);
            entity.Property(e => e.Codigo2).HasMaxLength(20);
            entity.Property(e => e.Codigo3).HasMaxLength(20);
            entity.Property(e => e.CodigoDescritivo).HasMaxLength(20);
            entity.Property(e => e.CodigoDescritivo1).HasMaxLength(20);
            entity.Property(e => e.CodigoDescritivo2).HasMaxLength(20);
            entity.Property(e => e.CodigoDescritivo3).HasMaxLength(20);
            entity.Property(e => e.CodigoPai).HasMaxLength(20);
            entity.Property(e => e.CodigoPai1).HasMaxLength(20);
            entity.Property(e => e.CodigoPai2).HasMaxLength(20);
            entity.Property(e => e.CodigoPai3).HasMaxLength(20);
            entity.Property(e => e.Descricao).HasMaxLength(60);
            entity.Property(e => e.Descricao1).HasMaxLength(60);
            entity.Property(e => e.Descricao2).HasMaxLength(60);
            entity.Property(e => e.Descricao3).HasMaxLength(60);
            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<VProdutoEntradum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Produto_Entrada");

            entity.Property(e => e.Complemento).HasMaxLength(60);
            entity.Property(e => e.CustoTotal).HasColumnType("decimal(38, 5)");
            entity.Property(e => e.Data).HasColumnType("datetime");
            entity.Property(e => e.Descricao).HasMaxLength(60);
            entity.Property(e => e.DescricaoTipoEntrada)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasColumnName("Descricao_Tipo_Entrada");
            entity.Property(e => e.Documento).HasMaxLength(20);
            entity.Property(e => e.Entrega).HasColumnType("datetime");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdEntrada).HasColumnName("ID_Entrada");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.IdUf).HasColumnName("ID_UF");
            entity.Property(e => e.Informacao).HasMaxLength(200);
            entity.Property(e => e.Municipio).HasMaxLength(63);
            entity.Property(e => e.TipoEntrada).HasColumnName("Tipo_Entrada");
        });

        modelBuilder.Entity<VProdutoImposto>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Produto_Imposto");

            entity.Property(e => e.AliquotaCofins)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaCOFINS");
            entity.Property(e => e.AliquotaCofinsst)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaCOFINSST");
            entity.Property(e => e.AliquotaIcms)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaICMS");
            entity.Property(e => e.AliquotaIcmsst)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaICMSST");
            entity.Property(e => e.AliquotaIpi)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaIPI");
            entity.Property(e => e.AliquotaPis)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaPIS");
            entity.Property(e => e.AliquotaPisst)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaPISST");
            entity.Property(e => e.Barra).HasMaxLength(14);
            entity.Property(e => e.BarraTributavel).HasMaxLength(14);
            entity.Property(e => e.Cfop)
                .HasMaxLength(4)
                .HasColumnName("CFOP");
            entity.Property(e => e.ClasseEnquadramento).HasMaxLength(5);
            entity.Property(e => e.Cnpjprodutor)
                .HasMaxLength(18)
                .HasColumnName("CNPJProdutor");
            entity.Property(e => e.CodAnp).HasColumnName("Cod_ANP");
            entity.Property(e => e.CodEnquadramento)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("Cod_Enquadramento");
            entity.Property(e => e.Cst).HasColumnName("CST");
            entity.Property(e => e.Cstcofins).HasColumnName("CSTCOFINS");
            entity.Property(e => e.Cstipi).HasColumnName("CSTIPI");
            entity.Property(e => e.Cstpis).HasColumnName("CSTPIS");
            entity.Property(e => e.CustoFinal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descricao).HasMaxLength(60);
            entity.Property(e => e.ExTipi).HasColumnName("EX_TIPI");
            entity.Property(e => e.Fabricante).HasMaxLength(60);
            entity.Property(e => e.IdCest).HasColumnName("ID_CEST");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdGrupo).HasColumnName("ID_Grupo");
            entity.Property(e => e.IdImposto).HasColumnName("ID_Imposto");
            entity.Property(e => e.IdImpostoProduto).HasColumnName("ID_Imposto_Produto");
            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
            entity.Property(e => e.IdTabela).HasColumnName("ID_Tabela");
            entity.Property(e => e.IdUf).HasColumnName("ID_UF");
            entity.Property(e => e.Informacao).HasMaxLength(200);
            entity.Property(e => e.MargemVadicionado)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("MargemVAdicionado");
            entity.Property(e => e.MargemVenda).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ModalidadeBc).HasColumnName("ModalidadeBC");
            entity.Property(e => e.ModalidadeBcst).HasColumnName("ModalidadeBCST");
            entity.Property(e => e.Ncm)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("NCM");
            entity.Property(e => e.OutrosCustos).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PercentualReducao).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PercentualReducaoSt)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PercentualReducaoST");
            entity.Property(e => e.Referencia).HasMaxLength(60);
            entity.Property(e => e.TipoNf).HasColumnName("Tipo_NF");
            entity.Property(e => e.UltimoReajuste).HasColumnType("datetime");
            entity.Property(e => e.ValorCompra).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorIpi)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("ValorIPI");
            entity.Property(e => e.ValorSt)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("ValorST");
            entity.Property(e => e.ValorVenda).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<VProdutoMovimento>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Produto_Movimento");

            entity.Property(e => e.Barra).HasMaxLength(14);
            entity.Property(e => e.Compra).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.Data).HasColumnType("datetime");
            entity.Property(e => e.Descricao).HasMaxLength(60);
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
            entity.Property(e => e.Pessoa).HasMaxLength(60);
            entity.Property(e => e.Referencia).HasMaxLength(60);
            entity.Property(e => e.Tipo)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.UltimoLancamento).HasMaxLength(200);
            entity.Property(e => e.Venda).HasColumnType("decimal(11, 3)");
        });

        modelBuilder.Entity<VProdutoServico>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Produto_Servico");

            entity.Property(e => e.Abc)
                .HasMaxLength(1)
                .HasColumnName("ABC");
            entity.Property(e => e.Barra).HasMaxLength(14);
            entity.Property(e => e.Barratributavel).HasMaxLength(14);
            entity.Property(e => e.ClasseEnquadramento).HasMaxLength(5);
            entity.Property(e => e.Cnpjprodutor)
                .HasMaxLength(18)
                .HasColumnName("CNPJProdutor");
            entity.Property(e => e.CodAnp).HasColumnName("Cod_ANP");
            entity.Property(e => e.CodGrupo)
                .HasMaxLength(20)
                .HasColumnName("Cod_Grupo");
            entity.Property(e => e.ControleEstoque).HasColumnName("Controle_Estoque");
            entity.Property(e => e.CustoFinal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descricao).HasMaxLength(60);
            entity.Property(e => e.DescricaoGrupo).HasMaxLength(60);
            entity.Property(e => e.DescricaoImposto).HasMaxLength(60);
            entity.Property(e => e.DescricaoUnidade).HasMaxLength(60);
            entity.Property(e => e.ExTipi).HasColumnName("EX_TIPI");
            entity.Property(e => e.Fabricante).HasMaxLength(60);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdCest).HasColumnName("ID_CEST");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdGrupo).HasColumnName("ID_Grupo");
            entity.Property(e => e.IdImposto).HasColumnName("ID_Imposto");
            entity.Property(e => e.Imagem).HasColumnType("image");
            entity.Property(e => e.InfoAdicional1).HasMaxLength(60);
            entity.Property(e => e.InfoAdicional2).HasMaxLength(60);
            entity.Property(e => e.Informacao).HasMaxLength(200);
            entity.Property(e => e.Ncm)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("NCM");
            entity.Property(e => e.OutrosCustos).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PesoB).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.PesoL).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.Referencia).HasMaxLength(60);
            entity.Property(e => e.ValorCompra).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorIpi)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("ValorIPI");
            entity.Property(e => e.ValorSt)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("ValorST");
        });

        modelBuilder.Entity<VProdutoVenda>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Produto_Venda");

            entity.Property(e => e.Barra).HasMaxLength(14);
            entity.Property(e => e.BarraEtiqueta)
                .HasMaxLength(8000)
                .IsUnicode(false)
                .HasColumnName("Barra_Etiqueta");
            entity.Property(e => e.BarraTributavel).HasMaxLength(14);
            entity.Property(e => e.CodGrupo)
                .HasMaxLength(20)
                .HasColumnName("Cod_Grupo");
            entity.Property(e => e.CustoFinal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descricao).HasMaxLength(60);
            entity.Property(e => e.DescricaoCompleta).HasMaxLength(163);
            entity.Property(e => e.DescricaoGrade).HasMaxLength(100);
            entity.Property(e => e.DescricaoGrupo).HasMaxLength(60);
            entity.Property(e => e.EstoqueAtual).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.EstoqueIdeal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.EstoqueMinimo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Fabricante).HasMaxLength(60);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdGrade).HasColumnName("ID_Grade");
            entity.Property(e => e.IdGrupo).HasColumnName("ID_Grupo");
            entity.Property(e => e.IdGrupoGrade).HasColumnName("ID_GrupoGrade");
            entity.Property(e => e.IdTabela).HasColumnName("ID_Tabela");
            entity.Property(e => e.Imagem).HasColumnType("image");
            entity.Property(e => e.InfoAdicional1).HasMaxLength(60);
            entity.Property(e => e.InfoAdicional2).HasMaxLength(60);
            entity.Property(e => e.Informacao).HasMaxLength(200);
            entity.Property(e => e.Localizacao).HasMaxLength(60);
            entity.Property(e => e.MargemVenda).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Ncm)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("NCM");
            entity.Property(e => e.OutrosCustos).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Referencia).HasMaxLength(60);
            entity.Property(e => e.UltimoReajuste).HasColumnType("datetime");
            entity.Property(e => e.Unidade).HasMaxLength(60);
            entity.Property(e => e.ValorCompra).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorIpi)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("ValorIPI");
            entity.Property(e => e.ValorSt)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("ValorST");
            entity.Property(e => e.ValorVenda).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<VResumoLocacao>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_ResumoLocacao");

            entity.Property(e => e.Area).HasColumnType("decimal(13, 2)");
            entity.Property(e => e.Bairro).HasMaxLength(60);
            entity.Property(e => e.Cadastro).HasColumnType("datetime");
            entity.Property(e => e.Cei)
                .HasMaxLength(15)
                .HasColumnName("CEI");
            entity.Property(e => e.Cep)
                .HasMaxLength(9)
                .HasColumnName("CEP");
            entity.Property(e => e.Cnae)
                .HasMaxLength(7)
                .IsFixedLength()
                .HasColumnName("CNAE");
            entity.Property(e => e.CnpjCpf)
                .HasMaxLength(18)
                .HasColumnName("CNPJ_CPF");
            entity.Property(e => e.ComissaoPorc)
                .HasColumnType("decimal(13, 2)")
                .HasColumnName("Comissao_Porc");
            entity.Property(e => e.ComissaoValor)
                .HasColumnType("decimal(13, 2)")
                .HasColumnName("Comissao_Valor");
            entity.Property(e => e.Complemento).HasMaxLength(60);
            entity.Property(e => e.Conjuge).HasMaxLength(60);
            entity.Property(e => e.Contato).HasMaxLength(60);
            entity.Property(e => e.CpfConjuge)
                .HasMaxLength(18)
                .HasColumnName("CPF_Conjuge");
            entity.Property(e => e.Data).HasColumnType("date");
            entity.Property(e => e.Descricao).HasMaxLength(200);
            entity.Property(e => e.Descricao1).HasMaxLength(60);
            entity.Property(e => e.Descricao2).HasMaxLength(60);
            entity.Property(e => e.Descricao3).HasMaxLength(60);
            entity.Property(e => e.DescricaoTest1)
                .HasMaxLength(60)
                .HasColumnName("Descricao_Test1");
            entity.Property(e => e.DescricaoTest2)
                .HasMaxLength(60)
                .HasColumnName("Descricao_Test2");
            entity.Property(e => e.DocTest1)
                .HasMaxLength(18)
                .HasColumnName("Doc_Test1");
            entity.Property(e => e.DocTest2)
                .HasMaxLength(18)
                .HasColumnName("Doc_Test2");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdGrupo).HasColumnName("ID_Grupo");
            entity.Property(e => e.IdImovel).HasColumnName("ID_Imovel");
            entity.Property(e => e.IdLocacao).HasColumnName("ID_Locacao");
            entity.Property(e => e.IdLocatario).HasColumnName("ID_Locatario");
            entity.Property(e => e.IdMunicipio).HasColumnName("ID_Municipio");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.IdTipo).HasColumnName("ID_Tipo");
            entity.Property(e => e.IeRg)
                .HasMaxLength(15)
                .HasColumnName("IE_RG");
            entity.Property(e => e.Im)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("IM");
            entity.Property(e => e.Informacao).HasMaxLength(200);
            entity.Property(e => e.Inicio).HasColumnType("date");
            entity.Property(e => e.Limite).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Logradouro).HasMaxLength(60);
            entity.Property(e => e.NascimentoFundacao)
                .HasColumnType("datetime")
                .HasColumnName("Nascimento_Fundacao");
            entity.Property(e => e.NomeFantasia).HasMaxLength(60);
            entity.Property(e => e.NomeRazao)
                .HasMaxLength(60)
                .HasColumnName("Nome_Razao");
            entity.Property(e => e.Numero).HasMaxLength(60);
            entity.Property(e => e.Observacao).HasMaxLength(200);
            entity.Property(e => e.ProfissaoConjuge)
                .HasMaxLength(60)
                .HasColumnName("Profissao_Conjuge");
            entity.Property(e => e.RamoProfissao)
                .HasMaxLength(60)
                .HasColumnName("Ramo_Profissao");
            entity.Property(e => e.RgConjuge)
                .HasMaxLength(18)
                .HasColumnName("RG_Conjuge");
            entity.Property(e => e.Rgi)
                .HasMaxLength(10)
                .HasColumnName("RGI");
            entity.Property(e => e.Termino).HasColumnType("date");
            entity.Property(e => e.TipoImovel).HasColumnName("Tipo_Imovel");
            entity.Property(e => e.Uc)
                .HasMaxLength(10)
                .HasColumnName("UC");
            entity.Property(e => e.Valor).HasColumnType("decimal(13, 2)");
            entity.Property(e => e.ValorImovel).HasColumnType("decimal(13, 2)");
        });

        modelBuilder.Entity<VUsuarioMobile>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_UsuarioMobile");

            entity.Property(e => e.Descricao).HasMaxLength(60);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Senha).HasMaxLength(20);
        });

        modelBuilder.Entity<VVendaItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Venda_Item");

            entity.Property(e => e.Acrescimo).HasColumnType("decimal(11, 2)");
            entity.Property(e => e.Barra).HasMaxLength(14);
            entity.Property(e => e.ControleEstoque).HasColumnName("Controle_Estoque");
            entity.Property(e => e.Desconto).HasColumnType("decimal(11, 2)");
            entity.Property(e => e.DescricaoProduto).HasMaxLength(163);
            entity.Property(e => e.DescricaoSaida)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.IdGrade).HasColumnName("ID_Grade");
            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
            entity.Property(e => e.IdTabela).HasColumnName("ID_Tabela");
            entity.Property(e => e.IdVenda).HasColumnName("ID_Venda");
            entity.Property(e => e.Iditem).HasColumnName("IDItem");
            entity.Property(e => e.InfoAdicional1).HasMaxLength(60);
            entity.Property(e => e.InfoAdicional2).HasMaxLength(60);
            entity.Property(e => e.Informacao).HasMaxLength(100);
            entity.Property(e => e.Marca).HasMaxLength(60);
            entity.Property(e => e.Quantidade).HasColumnType("decimal(9, 3)");
            entity.Property(e => e.QuantidadeConferido)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Quantidade_Conferido");
            entity.Property(e => e.QuantidadeEntregue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Quantidade_Entregue");
            entity.Property(e => e.Referencia).HasMaxLength(60);
            entity.Property(e => e.ValorCusto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorProduto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorTotal).HasColumnType("decimal(20, 5)");
            entity.Property(e => e.ValorVenda).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<VVendaItemImposto>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Venda_Item_Imposto");

            entity.Property(e => e.Acrescimo).HasColumnType("decimal(11, 2)");
            entity.Property(e => e.AliquotaCofins)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaCOFINS");
            entity.Property(e => e.AliquotaCofinsst)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaCOFINSST");
            entity.Property(e => e.AliquotaIcms)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaICMS");
            entity.Property(e => e.AliquotaIcmsst)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaICMSST");
            entity.Property(e => e.AliquotaIpi)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaIPI");
            entity.Property(e => e.AliquotaPis)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaPIS");
            entity.Property(e => e.AliquotaPisst)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaPISST");
            entity.Property(e => e.Cfop)
                .HasMaxLength(4)
                .HasColumnName("CFOP");
            entity.Property(e => e.ClasseEnquadramento).HasMaxLength(5);
            entity.Property(e => e.Cnpjprodutor)
                .HasMaxLength(18)
                .HasColumnName("CNPJProdutor");
            entity.Property(e => e.CodAnp).HasColumnName("Cod_ANP");
            entity.Property(e => e.CodEnquadramento)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("Cod_Enquadramento");
            entity.Property(e => e.Cst).HasColumnName("CST");
            entity.Property(e => e.Cstcofins).HasColumnName("CSTCOFINS");
            entity.Property(e => e.Cstipi).HasColumnName("CSTIPI");
            entity.Property(e => e.Cstpis).HasColumnName("CSTPIS");
            entity.Property(e => e.Desconto).HasColumnType("decimal(11, 2)");
            entity.Property(e => e.DescricaoProduto).HasMaxLength(163);
            entity.Property(e => e.ExTipi).HasColumnName("EX_TIPI");
            entity.Property(e => e.IdCest).HasColumnName("ID_CEST");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdGrade).HasColumnName("ID_Grade");
            entity.Property(e => e.IdImposto).HasColumnName("ID_Imposto");
            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
            entity.Property(e => e.IdTabela).HasColumnName("ID_Tabela");
            entity.Property(e => e.IdVenda).HasColumnName("ID_Venda");
            entity.Property(e => e.Informacao).HasMaxLength(100);
            entity.Property(e => e.MargemVadicionado)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("MargemVAdicionado");
            entity.Property(e => e.ModalidadeBc).HasColumnName("ModalidadeBC");
            entity.Property(e => e.ModalidadeBcst).HasColumnName("ModalidadeBCST");
            entity.Property(e => e.Ncm)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("NCM");
            entity.Property(e => e.PercentualReducao).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PercentualReducaoSt)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PercentualReducaoST");
            entity.Property(e => e.Quantidade).HasColumnType("decimal(9, 3)");
            entity.Property(e => e.TipoNf).HasColumnName("Tipo_NF");
            entity.Property(e => e.ValorCusto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorProduto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorTotal).HasColumnType("decimal(20, 5)");
            entity.Property(e => e.ValorVenda).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<VVendaItemImpostoCf>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Venda_Item_Imposto_CF");

            entity.Property(e => e.Acrescimo).HasColumnType("decimal(11, 2)");
            entity.Property(e => e.AliquotaCofins)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaCOFINS");
            entity.Property(e => e.AliquotaCofinsst)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaCOFINSST");
            entity.Property(e => e.AliquotaIcms)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaICMS");
            entity.Property(e => e.AliquotaIcmsst)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaICMSST");
            entity.Property(e => e.AliquotaIpi)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaIPI");
            entity.Property(e => e.AliquotaPis)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaPIS");
            entity.Property(e => e.AliquotaPisst)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("AliquotaPISST");
            entity.Property(e => e.Cfop)
                .HasMaxLength(4)
                .HasColumnName("CFOP");
            entity.Property(e => e.ClasseEnquadramento).HasMaxLength(5);
            entity.Property(e => e.Cnpjprodutor)
                .HasMaxLength(18)
                .HasColumnName("CNPJProdutor");
            entity.Property(e => e.CodEnquadramento)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("Cod_Enquadramento");
            entity.Property(e => e.Cst).HasColumnName("CST");
            entity.Property(e => e.Cstcofins).HasColumnName("CSTCOFINS");
            entity.Property(e => e.Cstipi).HasColumnName("CSTIPI");
            entity.Property(e => e.Cstpis).HasColumnName("CSTPIS");
            entity.Property(e => e.Desconto).HasColumnType("decimal(11, 2)");
            entity.Property(e => e.DescricaoProduto).HasMaxLength(163);
            entity.Property(e => e.ExTipi).HasColumnName("EX_TIPI");
            entity.Property(e => e.IdCest).HasColumnName("ID_CEST");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdGrade).HasColumnName("ID_Grade");
            entity.Property(e => e.IdImposto).HasColumnName("ID_Imposto");
            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
            entity.Property(e => e.IdTabela).HasColumnName("ID_Tabela");
            entity.Property(e => e.IdVenda).HasColumnName("ID_Venda");
            entity.Property(e => e.Informacao).HasMaxLength(100);
            entity.Property(e => e.MargemVadicionado)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("MargemVAdicionado");
            entity.Property(e => e.ModalidadeBc).HasColumnName("ModalidadeBC");
            entity.Property(e => e.ModalidadeBcst).HasColumnName("ModalidadeBCST");
            entity.Property(e => e.PercentualReducao).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PercentualReducaoSt)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PercentualReducaoST");
            entity.Property(e => e.Quantidade).HasColumnType("decimal(9, 3)");
            entity.Property(e => e.TipoNf).HasColumnName("Tipo_NF");
            entity.Property(e => e.ValorCusto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorProduto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorTotal).HasColumnType("decimal(20, 5)");
            entity.Property(e => e.ValorVenda).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<VVendaMobile>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Venda_Mobile");

            entity.Property(e => e.Comprador).HasMaxLength(200);
            entity.Property(e => e.Data).HasMaxLength(10);
            entity.Property(e => e.Desconto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descricao).HasMaxLength(60);
            entity.Property(e => e.Equipamento).HasMaxLength(100);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdPagamento).HasColumnName("ID_Pagamento");
            entity.Property(e => e.IdParcelamento).HasColumnName("ID_Parcelamento");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.IdTabela).HasColumnName("ID_Tabela");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.IdVenda).HasColumnName("ID_Venda");
            entity.Property(e => e.Imei)
                .HasMaxLength(20)
                .HasColumnName("IMEI");
            entity.Property(e => e.Informacao)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Pagamento).HasMaxLength(60);
            entity.Property(e => e.Parcelamento).HasMaxLength(100);
            entity.Property(e => e.Usuario).HasMaxLength(60);
        });

        modelBuilder.Entity<VVendaPessoaInativo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Venda_PessoaInativo");

            entity.Property(e => e.Contato).HasMaxLength(60);
            entity.Property(e => e.Data).HasColumnType("datetime");
            entity.Property(e => e.DataFatura).HasColumnType("datetime");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.IdUsuarioComissao1).HasColumnName("ID_UsuarioComissao1");
            entity.Property(e => e.IdVenda).HasColumnName("ID_Venda");
            entity.Property(e => e.Informacao).HasMaxLength(200);
            entity.Property(e => e.Nfe).HasColumnName("NFe");
            entity.Property(e => e.NomeFantasia).HasMaxLength(60);
            entity.Property(e => e.NomeRazao)
                .HasMaxLength(60)
                .HasColumnName("Nome_Razao");
            entity.Property(e => e.TempoCompra)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VVendaResumoPagto>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Venda_ResumoPagto");

            entity.Property(e => e.Credito).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Data).HasColumnType("datetime");
            entity.Property(e => e.Descricao).HasMaxLength(60);
            entity.Property(e => e.IdVenda).HasColumnName("ID_Venda");
            entity.Property(e => e.ValorPago).HasColumnType("decimal(12, 2)");
        });

        modelBuilder.Entity<VVendum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_Venda");

            entity.Property(e => e.Complemento).HasMaxLength(60);
            entity.Property(e => e.Comprador).HasMaxLength(200);
            entity.Property(e => e.CpfCnpj)
                .HasMaxLength(18)
                .HasColumnName("CPF_CNPJ");
            entity.Property(e => e.CustoTotal).HasColumnType("decimal(38, 5)");
            entity.Property(e => e.Data).HasColumnType("datetime");
            entity.Property(e => e.DataFatura).HasColumnType("datetime");
            entity.Property(e => e.Descricao).HasMaxLength(60);
            entity.Property(e => e.Entrega).HasColumnType("datetime");
            entity.Property(e => e.IdCfe).HasColumnName("ID_CFe");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdNfe).HasColumnName("ID_NFe");
            entity.Property(e => e.IdPagamento).HasColumnName("ID_Pagamento");
            entity.Property(e => e.IdParcelamento).HasColumnName("ID_Parcelamento");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.IdUf).HasColumnName("ID_UF");
            entity.Property(e => e.IdUsuarioComissao1).HasColumnName("ID_UsuarioComissao1");
            entity.Property(e => e.IdUsuarioComissao2).HasColumnName("ID_UsuarioComissao2");
            entity.Property(e => e.IdUsuarioConferencia).HasColumnName("ID_Usuario_Conferencia");
            entity.Property(e => e.IdVenda).HasColumnName("ID_Venda");
            entity.Property(e => e.Informacao)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Municipio).HasMaxLength(63);
            entity.Property(e => e.Nfe).HasColumnName("NFe");
            entity.Property(e => e.PrevisaoPagto).HasMaxLength(162);
            entity.Property(e => e.SituacaoEntrega).HasColumnName("Situacao_Entrega");
            entity.Property(e => e.UsuarioConferencia)
                .HasMaxLength(60)
                .HasColumnName("Usuario_Conferencia");
            entity.Property(e => e.ValorTotal).HasColumnType("decimal(38, 5)");
        });

        modelBuilder.Entity<VendaExterno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Venda_Ex__3214EC270BB1B5A5");

            entity.ToTable("Venda_Externo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Data).HasColumnType("datetime");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.Informacao).HasMaxLength(500);
        });

        modelBuilder.Entity<VendaExternoItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Venda_Ex__3214EC270F824689");

            entity.ToTable("Venda_Externo_Item");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
            entity.Property(e => e.IdVendaExterna).HasColumnName("ID_Venda_Externa");
            entity.Property(e => e.Informacao).HasMaxLength(500);

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.VendaExternoItems)
                .HasForeignKey(d => d.IdProduto)
                .HasConstraintName("FK__Venda_Ext__ID_Pr__125EB334");

            entity.HasOne(d => d.IdVendaExternaNavigation).WithMany(p => p.VendaExternoItems)
                .HasForeignKey(d => d.IdVendaExterna)
                .HasConstraintName("FK__Venda_Ext__ID_Ve__116A8EFB");
        });

        modelBuilder.Entity<VendaItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ItemPedidoVenda");

            entity.ToTable("Venda_Item");

            entity.HasIndex(e => e.IdVenda, "I_ID_Pedido");

            entity.HasIndex(e => e.IdProduto, "I_ID_Produto");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdGrade).HasColumnName("ID_Grade");
            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
            entity.Property(e => e.IdTabela).HasColumnName("ID_Tabela");
            entity.Property(e => e.IdVenda).HasColumnName("ID_Venda");
            entity.Property(e => e.Informacao).HasMaxLength(100);
            entity.Property(e => e.Quantidade).HasColumnType("decimal(9, 3)");
            entity.Property(e => e.QuantidadeConferido)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Quantidade_Conferido");
            entity.Property(e => e.QuantidadeEntregue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Quantidade_Entregue");
            entity.Property(e => e.ValorCusto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorProduto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ValorVenda).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<VendaItemMobile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Venda_It__3214EC2779C80F94");

            entity.ToTable("Venda_Item_Mobile");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdProduto).HasColumnName("ID_Produto");
            entity.Property(e => e.IdVenda).HasColumnName("ID_Venda");
            entity.Property(e => e.Imei)
                .HasMaxLength(30)
                .HasColumnName("IMEI");
            entity.Property(e => e.Informacao).HasMaxLength(200);
            entity.Property(e => e.Quantidade).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<VendaMobile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Venda_Mo__3214EC2775F77EB0");

            entity.ToTable("Venda_Mobile");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Comprador).HasMaxLength(200);
            entity.Property(e => e.Data).HasMaxLength(10);
            entity.Property(e => e.Desconto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.IdParcelamento).HasColumnName("ID_Parcelamento");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.IdTabela).HasColumnName("ID_Tabela");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.IdVenda).HasColumnName("ID_Venda");
            entity.Property(e => e.Imei)
                .HasMaxLength(30)
                .HasColumnName("IMEI");
            entity.Property(e => e.Informacao)
                .HasMaxLength(1000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VendaSequencium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Venda_Se__3214EC2738D2CF00");

            entity.ToTable("Venda_Sequencia");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Seq).HasColumnName("SEQ");
        });

        modelBuilder.Entity<Vendum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PedidoVenda");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Comprador).HasMaxLength(200);
            entity.Property(e => e.CpfCnpj)
                .HasMaxLength(18)
                .HasColumnName("CPF_CNPJ");
            entity.Property(e => e.Data).HasColumnType("datetime");
            entity.Property(e => e.DataFatura).HasColumnType("datetime");
            entity.Property(e => e.Entrega).HasColumnType("datetime");
            entity.Property(e => e.IdCfe).HasColumnName("ID_CFe");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_Empresa");
            entity.Property(e => e.IdNfe).HasColumnName("ID_NFe");
            entity.Property(e => e.IdPagamento).HasColumnName("ID_Pagamento");
            entity.Property(e => e.IdParcelamento).HasColumnName("ID_Parcelamento");
            entity.Property(e => e.IdPessoa).HasColumnName("ID_Pessoa");
            entity.Property(e => e.IdUsuarioComissao1).HasColumnName("ID_UsuarioComissao1");
            entity.Property(e => e.IdUsuarioComissao2).HasColumnName("ID_UsuarioComissao2");
            entity.Property(e => e.IdUsuarioConferencia).HasColumnName("ID_Usuario_Conferencia");
            entity.Property(e => e.Informacao)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Nfe).HasColumnName("NFe");
            entity.Property(e => e.Seqvenda)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SEQVENDA");
            entity.Property(e => e.SituacaoConferencia).HasColumnName("Situacao_Conferencia");
            entity.Property(e => e.SituacaoEntrega).HasColumnName("Situacao_Entrega");
        });

        modelBuilder.Entity<Versao>(entity =>
        {
            entity.ToTable("Versao");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Bd).HasColumnName("BD");
            entity.Property(e => e.Chave).HasMaxLength(200);
            entity.Property(e => e.Versao1).HasColumnName("Versao");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
