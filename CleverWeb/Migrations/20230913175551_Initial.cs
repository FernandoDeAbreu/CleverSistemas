using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleverWeb.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banco",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Empresa = table.Column<int>(type: "int", nullable: false),
                    ID_Banco = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Agencia = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Conta = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    ID_Caixa = table.Column<int>(type: "int", nullable: false),
                    Limite = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Banco__3214EC272EA5EC27", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Boleto",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NossoNumero = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    TipoPessoa = table.Column<int>(type: "int", nullable: true),
                    ID_Pessoa = table.Column<int>(type: "int", nullable: true),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    ID_Cedente = table.Column<int>(type: "int", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Acrescimo = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Desconto = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Emissao = table.Column<DateTime>(type: "datetime", nullable: true),
                    Vencimento = table.Column<DateTime>(type: "datetime", nullable: true),
                    Documento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CodigoBarra = table.Column<byte[]>(type: "image", nullable: true),
                    Liquidado = table.Column<bool>(type: "bit", nullable: true),
                    DataBaixa = table.Column<DateTime>(type: "datetime", nullable: true),
                    Remessa = table.Column<bool>(type: "bit", nullable: true),
                    Cancelado = table.Column<bool>(type: "bit", nullable: true),
                    Tipo_Remessa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Boleto__3214EC2755BFB948", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Boleto_Remessa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emissao = table.Column<DateTime>(type: "datetime", nullable: true),
                    Arquivo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Boleto_R__3214EC275DEAEAF5", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Boleto_RemessaControle",
                columns: table => new
                {
                    ID_Remessa = table.Column<int>(type: "int", nullable: true),
                    ID_Boleto = table.Column<int>(type: "int", nullable: true),
                    Movimento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "BoletoControle",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Boleto = table.Column<int>(type: "int", nullable: true),
                    ID_Conta = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BoletoCo__3214EC2750FB042B", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cartao",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    ID_Pagamento = table.Column<int>(type: "int", nullable: true),
                    Emissao = table.Column<DateTime>(type: "datetime", nullable: true),
                    Vencimento = table.Column<DateTime>(type: "datetime", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    QuantidadeParcela = table.Column<int>(type: "int", nullable: true),
                    Parcela = table.Column<int>(type: "int", nullable: true),
                    Baixado = table.Column<bool>(type: "bit", nullable: true),
                    Data_Baixa = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cartao__3214EC27695C9DA1", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cartao_Controle",
                columns: table => new
                {
                    ID_Cartao = table.Column<int>(type: "int", nullable: true),
                    ID_CReceber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Cedente",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Cod_Cedente = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Carteira = table.Column<int>(type: "int", nullable: true),
                    Juros = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    DiasJuros = table.Column<int>(type: "int", nullable: true),
                    Multa = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    DiasMulta = table.Column<int>(type: "int", nullable: true),
                    Instrucao_1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ID_Banco = table.Column<int>(type: "int", nullable: true),
                    ID_Conta = table.Column<int>(type: "int", nullable: true),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    Tipo_Doc_Cedente = table.Column<int>(type: "int", nullable: true),
                    CNPJ_CPF_Cedente = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    Razao_Cedente = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    UtilizaTarifa = table.Column<bool>(type: "bit", nullable: true),
                    Tarifa = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    instrucao_2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DiaProtesto = table.Column<int>(type: "int", nullable: true),
                    Aceite = table.Column<bool>(type: "bit", nullable: true),
                    Tipo_Emissao = table.Column<int>(type: "int", nullable: true),
                    Cod_Protesto = table.Column<int>(type: "int", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    Tipo_Cobranca = table.Column<int>(type: "int", nullable: true),
                    Altera_Data = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cedente__3214EC274959E263", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CEST",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NCM = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CEST = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CEST__3214EC277993056A", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CFOP",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CFOP = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Descricao = table.Column<string>(type: "ntext", nullable: true),
                    Ajuda = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CFOP__3214EC2700DF2177", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cheque",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: true),
                    TipoPessoa = table.Column<int>(type: "int", nullable: true),
                    ID_Pessoa = table.Column<int>(type: "int", nullable: true),
                    Documento = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Emissao = table.Column<DateTime>(type: "datetime", nullable: true),
                    Vencimento = table.Column<DateTime>(type: "datetime", nullable: true),
                    Banco = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: true),
                    Agencia = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Conta = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Cheque = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Situacao = table.Column<int>(type: "int", nullable: true),
                    Informacao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Titular = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CNPJ_CPF = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Controle__3214EC2758D1301D", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Comodato",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    TipoPessoa = table.Column<int>(type: "int", nullable: true),
                    ID_Pessoa = table.Column<int>(type: "int", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime", nullable: true),
                    Situacao = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comodato__3214EC272334397B", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ComodatoItem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Comodato = table.Column<int>(type: "int", nullable: true),
                    Quantidade = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comodato__3214EC272704CA5F", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ControleDoc",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Documento = table.Column<int>(type: "int", nullable: true),
                    TipoPessoa = table.Column<int>(type: "int", nullable: true),
                    ID_Pessoa = table.Column<int>(type: "int", nullable: true),
                    Periodo = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataEntrada = table.Column<DateTime>(type: "datetime", nullable: true),
                    Entregue = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cont_Con__3214EC271F2E9E6D", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ControleDoc_Tipo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Tipo = table.Column<int>(type: "int", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cont_Doc__3214EC271B5E0D89", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CPagar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    ID_Conta = table.Column<int>(type: "int", nullable: true),
                    GrupoConta = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Situacao = table.Column<int>(type: "int", nullable: true),
                    Documento = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Emissao = table.Column<DateTime>(type: "datetime", nullable: true),
                    Vencimento = table.Column<DateTime>(type: "datetime", nullable: true),
                    TipoPessoa = table.Column<int>(type: "int", nullable: true),
                    ID_Pessoa = table.Column<int>(type: "int", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Parcelado = table.Column<bool>(type: "bit", nullable: true),
                    QuantidadeParcela = table.Column<int>(type: "int", nullable: true),
                    Parcela = table.Column<int>(type: "int", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DataBaixa = table.Column<DateTime>(type: "datetime", nullable: true),
                    Desconto = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Acrescimo = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Caixa = table.Column<int>(type: "int", nullable: true),
                    ID_Pagamento = table.Column<int>(type: "int", nullable: true),
                    InformacaoBaixa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Controle = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPagar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CReceber",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    ID_Conta = table.Column<int>(type: "int", nullable: true),
                    GrupoConta = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Situacao = table.Column<int>(type: "int", nullable: true),
                    Documento = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Emissao = table.Column<DateTime>(type: "datetime", nullable: true),
                    Vencimento = table.Column<DateTime>(type: "datetime", nullable: true),
                    TipoPessoa = table.Column<int>(type: "int", nullable: true),
                    ID_Pessoa = table.Column<int>(type: "int", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Parcelado = table.Column<bool>(type: "bit", nullable: true),
                    QuantidadeParcela = table.Column<int>(type: "int", nullable: true),
                    Parcela = table.Column<int>(type: "int", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DataBaixa = table.Column<DateTime>(type: "datetime", nullable: true),
                    Desconto = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Acrescimo = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Caixa = table.Column<int>(type: "int", nullable: true),
                    ID_Pagamento = table.Column<int>(type: "int", nullable: true),
                    InformacaoBaixa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Controle = table.Column<int>(type: "int", nullable: true),
                    Boleto = table.Column<bool>(type: "bit", nullable: true),
                    ID_Venda = table.Column<int>(type: "int", nullable: true),
                    ID_PrevisaoPagto = table.Column<int>(type: "int", nullable: true),
                    ID_OS = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CReceber", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "date", nullable: true),
                    Para = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CC = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CCO = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Assunto = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Conteudo = table.Column<string>(type: "text", nullable: true),
                    Anexo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Email__3214EC276991A7CB", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Referencia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Vencimento = table.Column<bool>(type: "bit", nullable: true),
                    Desconto = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Eventos__3214EC275C6CB6D7", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FichaProducao",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    ID_Venda = table.Column<int>(type: "int", nullable: true),
                    Situacao = table.Column<int>(type: "int", nullable: true),
                    Entrada = table.Column<DateTime>(type: "datetime", nullable: true),
                    Saida = table.Column<DateTime>(type: "datetime", nullable: true),
                    Transportadora = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ID_Item_Venda = table.Column<int>(type: "int", nullable: true),
                    AnoModelo = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    CorCouro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Costura = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Logomarca = table.Column<int>(type: "int", nullable: true),
                    Laterais_Porta = table.Column<int>(type: "int", nullable: true),
                    ApoioCabeca = table.Column<int>(type: "int", nullable: true),
                    TipoAcento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ABD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ABT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TipoEncosto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FichaPro__3214EC272665ABE1", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FluxoCaixa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    Emissao = table.Column<DateTime>(type: "datetime", nullable: true),
                    Caixa = table.Column<int>(type: "int", nullable: true),
                    Documento = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ID_Conta = table.Column<int>(type: "int", nullable: true),
                    GrupoConta = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Credito = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Debito = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Informacao = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Conciliado = table.Column<bool>(type: "bit", nullable: true),
                    ID_Cheque = table.Column<int>(type: "int", nullable: true),
                    ID_Pagamento = table.Column<int>(type: "int", nullable: true),
                    Planejamento = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroCaixa", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FluxoCaixa_Controle",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_FluxoCaixa = table.Column<int>(type: "int", nullable: true),
                    ID_CPagar = table.Column<int>(type: "int", nullable: true),
                    ID_CReceber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FluxoCai__3214EC274589517F", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FolhaPagto",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Pessoa = table.Column<int>(type: "int", nullable: true),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    Periodo = table.Column<DateTime>(type: "datetime", nullable: true),
                    Vencimento = table.Column<DateTime>(type: "datetime", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FolhaPag__3214EC27603D47BB", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Grupo = table.Column<int>(type: "int", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Grade__3214EC27634EBE90", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Grupo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<int>(type: "int", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Exibir = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoSimples", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GrupoNivel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nivel = table.Column<int>(type: "int", nullable: true),
                    CodigoPai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CodigoDescritivo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoNivel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Imagem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: true),
                    Imagem = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagem", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Imovel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ID_Tipo = table.Column<int>(type: "int", nullable: true),
                    Tipo_Imovel = table.Column<int>(type: "int", nullable: true),
                    Area = table.Column<decimal>(type: "decimal(13,2)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(13,2)", nullable: true),
                    Comissao_Porc = table.Column<decimal>(type: "decimal(13,2)", nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    CEP = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    ID_Municipio = table.Column<int>(type: "int", nullable: true),
                    RGI = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UC = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Comissao_Valor = table.Column<decimal>(type: "decimal(13,2)", nullable: true),
                    CI = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    Matricula = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Imovel__3214EC273F9B6DFF", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Imovel_Contrato",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Proprietario = table.Column<int>(type: "int", nullable: true),
                    Emissao = table.Column<DateTime>(type: "date", nullable: true),
                    Descricao_Test1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Descricao_Test2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Doc_Test1 = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    Doc_Test2 = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Imovel_C__3214EC275E1FF51F", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Imovel_Custo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Imovel = table.Column<int>(type: "int", nullable: true),
                    ID_Tipo = table.Column<int>(type: "int", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(13,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Imovel_C__3214EC274B0D20AB", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Imovel_Imagem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Imovel = table.Column<int>(type: "int", nullable: true),
                    Informacao = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Imagem = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Imovel_I__3214EC27473C8FC7", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Imovel_Proprietario",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Imovel = table.Column<int>(type: "int", nullable: true),
                    TipoPessoa = table.Column<int>(type: "int", nullable: true),
                    ID_Pessoa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Imovel_P__3214EC27436BFEE3", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Imovel_Vistoria",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Imovel = table.Column<int>(type: "int", nullable: true),
                    Local = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Imovel_V__3214EC274EDDB18F", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Imposto",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Imposto__3214EC27269AB60B", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Imposto_Tributacao",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Imposto = table.Column<int>(type: "int", nullable: true),
                    Tipo_NF = table.Column<int>(type: "int", nullable: true),
                    CFOP = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    CST = table.Column<int>(type: "int", nullable: true),
                    Origem = table.Column<int>(type: "int", nullable: true),
                    ModalidadeBC = table.Column<int>(type: "int", nullable: true),
                    AliquotaICMS = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    PercentualReducao = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ModalidadeBCST = table.Column<int>(type: "int", nullable: true),
                    AliquotaICMSST = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    PercentualReducaoST = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    MargemVAdicionado = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    vICMSDeson = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    vICMSOp = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    pDif = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    vICMSDif = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    CSTPIS = table.Column<int>(type: "int", nullable: true),
                    AliquotaPIS = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    AliquotaPISST = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    CSTCOFINS = table.Column<int>(type: "int", nullable: true),
                    AliquotaCOFINS = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    AliquotaCOFINSST = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    CSTIPI = table.Column<int>(type: "int", nullable: true),
                    AliquotaIPI = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Cod_Enquadramento = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Imposto___3214EC272A6B46EF", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Imposto_UF",
                columns: table => new
                {
                    ID_Tributacao = table.Column<int>(type: "int", nullable: true),
                    ID_UF = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Locacao",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Imovel = table.Column<int>(type: "int", nullable: true),
                    Data = table.Column<DateTime>(type: "date", nullable: true),
                    Inicio = table.Column<DateTime>(type: "date", nullable: true),
                    Termino = table.Column<DateTime>(type: "date", nullable: true),
                    DiaVencimento = table.Column<int>(type: "int", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(13,2)", nullable: true),
                    Descricao_Test1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Descricao_Test2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Doc_Test1 = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    Doc_Test2 = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UC = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Locacao__3214EC2752AE4273", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Locacao_Fiador",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Locacao = table.Column<int>(type: "int", nullable: true),
                    ID_Fiador = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Locacao___3214EC275A4F643B", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Locacao_Locatario",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Locacao = table.Column<int>(type: "int", nullable: true),
                    ID_Locatario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Locacao___3214EC27567ED357", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Log_Acesso",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Usuario = table.Column<int>(type: "int", nullable: true),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime", nullable: true),
                    Terminal = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Log_Aces__3214EC2722FF2F51", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Mobile",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IMEI = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Equipamento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Mobile__3214EC277E8CC4B1", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Pais = table.Column<int>(type: "int", nullable: true),
                    ID_UF = table.Column<int>(type: "int", nullable: true),
                    ID_Municipio = table.Column<int>(type: "int", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NCM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NCM = table.Column<int>(type: "int", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AliqNacFederal = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    AliqImpFederal = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    EX = table.Column<int>(type: "int", nullable: true),
                    AliqEstadual = table.Column<decimal>(type: "decimal(4,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NCM__3214EC270FB750B3", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NF_TipoEmissao",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    Serie = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NF_TipoE__3214EC276D9742D9", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NaturezaOperacao = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    DataEmissao = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataSaida = table.Column<DateTime>(type: "datetime", nullable: true),
                    TipoDocumento = table.Column<int>(type: "int", nullable: true),
                    FinalidadeEmissao = table.Column<int>(type: "int", nullable: true),
                    FormaEmissao = table.Column<int>(type: "int", nullable: true),
                    FormaPagto = table.Column<int>(type: "int", nullable: true),
                    ValorTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ID_NFe = table.Column<int>(type: "int", nullable: true),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    InformacaoAdicional = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Situacao = table.Column<int>(type: "int", nullable: true),
                    TipoPessoa = table.Column<int>(type: "int", nullable: true),
                    ID_Pessoa = table.Column<int>(type: "int", nullable: true),
                    ID_Venda = table.Column<int>(type: "int", nullable: true),
                    TipoFrete = table.Column<int>(type: "int", nullable: true),
                    TipoImpressao = table.Column<int>(type: "int", nullable: true),
                    Dig_Verificador = table.Column<int>(type: "int", nullable: true),
                    DataContigencia = table.Column<DateTime>(type: "datetime", nullable: true),
                    Justificativa = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IE_Substituicao = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ValorBC = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorICMS = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorBCST = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorST = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorProduto = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorFrete = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorSeguro = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorDesconto = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorImportacao = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorIPI = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorPIS = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorCOFINS = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorOutro = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    InformacaoFisco = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Tipo_Frete = table.Column<int>(type: "int", nullable: true),
                    Tipo_NF = table.Column<int>(type: "int", nullable: true),
                    Serie = table.Column<int>(type: "int", nullable: true),
                    ValorICMSDesonerado = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ConsumidorFinal = table.Column<bool>(type: "bit", nullable: true),
                    PresencaConsumidor = table.Column<int>(type: "int", nullable: true),
                    Modelo = table.Column<int>(type: "int", nullable: true),
                    CNPJ_CPF_Destinatario = table.Column<string>(type: "varchar(18)", unicode: false, maxLength: 18, nullable: true),
                    Chave = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    QRCode_CFe = table.Column<string>(type: "text", nullable: true),
                    Trib_Federal = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Trib_Estadual = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Trib_Municipal = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Controle_CF = table.Column<int>(type: "int", nullable: true),
                    ID_OS = table.Column<int>(type: "int", nullable: true),
                    Status_CFe = table.Column<int>(type: "int", nullable: true),
                    Retorno_CFe = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NotaFisc__3214EC2740F9A68C", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscal_Adicao",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Importacao = table.Column<int>(type: "int", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Seq = table.Column<int>(type: "int", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Desconto = table.Column<decimal>(type: "decimal(15,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NotaFisc__3214EC27084B3915", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscal_AutXML",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_NF = table.Column<int>(type: "int", nullable: true),
                    CNPJ_CPF = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NotaFisc__3214EC272F2FFC0C", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscal_Cobranca",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_NF = table.Column<int>(type: "int", nullable: true),
                    NumeroFatura = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    Desconto = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorFinal = table.Column<decimal>(type: "decimal(15,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NotaFisc__3214EC277CD98669", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscal_Duplicata",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_NF = table.Column<int>(type: "int", nullable: true),
                    NumeroDuplicata = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Vencimento = table.Column<DateTime>(type: "datetime", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(15,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NotaFisc__3214EC2700AA174D", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscal_Ent_Ret",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<int>(type: "int", nullable: true),
                    ID_NF = table.Column<int>(type: "int", nullable: true),
                    CNPJ_CPF = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    ID_Municipio = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NotaFisc__3214EC270FEC5ADD", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscal_Evento",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_NF = table.Column<int>(type: "int", nullable: true),
                    Protocolo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Data = table.Column<DateTime>(type: "datetime", nullable: true),
                    Evento = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Seq = table.Column<int>(type: "int", nullable: true),
                    Tipo_Evento = table.Column<int>(type: "int", nullable: true),
                    Motivo = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Stat = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NotaFisc__3214EC2726CFC035", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscal_Importacao",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_NF_Item = table.Column<int>(type: "int", nullable: true),
                    Documento = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Data_Registro = table.Column<DateTime>(type: "datetime", nullable: true),
                    Local = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    UF = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Data_Desen = table.Column<DateTime>(type: "datetime", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NotaFisc__3214EC27047AA831", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscal_Inutilizacao",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    Serie = table.Column<int>(type: "int", nullable: true),
                    Numeracao = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Justificativa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Protocolo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NotaFisc__3214EC2770FDBF69", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscal_Item",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_NF = table.Column<int>(type: "int", nullable: true),
                    ID_Produto = table.Column<int>(type: "int", nullable: true),
                    Quantidade = table.Column<decimal>(type: "decimal(12,4)", nullable: true),
                    ID_Tabela = table.Column<int>(type: "int", nullable: true),
                    ValorUnitario = table.Column<decimal>(type: "decimal(12,4)", nullable: true),
                    ValorTotal = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    Acrescimo = table.Column<decimal>(type: "decimal(12,4)", nullable: true),
                    Desconto = table.Column<decimal>(type: "decimal(12,4)", nullable: true),
                    InformacaoAdicional = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TipoVendaProduto = table.Column<int>(type: "int", nullable: true),
                    ID_Grade = table.Column<int>(type: "int", nullable: true),
                    EX_TIPI = table.Column<int>(type: "int", nullable: true),
                    Quantidade_Selo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    ClasseEnquadramento = table.Column<string>(type: "nchar(5)", fixedLength: true, maxLength: 5, nullable: true),
                    CNPJProdutor = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    Codigo_Selo = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: true),
                    CST = table.Column<int>(type: "int", nullable: true),
                    Origem = table.Column<int>(type: "int", nullable: true),
                    ModalidadeBC = table.Column<int>(type: "int", nullable: true),
                    AliquotaICMS = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    PercentualReducao = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ModalidadeBCST = table.Column<int>(type: "int", nullable: true),
                    AliquotaICMSST = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    PercentualReducaoST = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    MargemVLAdicionado = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    CFOP = table.Column<string>(type: "nchar(4)", fixedLength: true, maxLength: 4, nullable: true),
                    Frete = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    Seguro = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorBC = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorICMS = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorBCST = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorICMSST = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorBCSTRet = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorICMSSTRet = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    CSOSN = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    AliquotaCredito = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorCredito = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    CSTIPI = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    AliquotaIPI = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    ValorIPI = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorBCII = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorDesII = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorII = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorIOF = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    CSTPIS = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    AliquotaPIS = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    ValorPIS = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorAliquotaPIS = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    CSTCOFINS = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    AliquotaCOFINS = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    ValorCOFINS = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorAliquotaCOFINS = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorICMSOperacao = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    PercentualDiferimento = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorICMSDeferido = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ValorICMSDesonerado = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    MotivoDesonerado = table.Column<int>(type: "int", nullable: true),
                    IPIDevolvido = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    Per_IPIDevolvido = table.Column<decimal>(type: "decimal(15,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NotaFisc__3214EC277D0E9093", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscal_Lacre",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_NF_Volume = table.Column<int>(type: "int", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NotaFisc__3214EC27753864A1", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscal_Referenciada",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<int>(type: "int", nullable: true),
                    ID_NF = table.Column<int>(type: "int", nullable: true),
                    Chave_NFe = table.Column<string>(type: "nvarchar(44)", maxLength: 44, nullable: true),
                    UF = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    DataEmissao = table.Column<DateTime>(type: "datetime", nullable: true),
                    CNPJ_CPF = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Serie = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Numero_NF = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    IE = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CTE = table.Column<string>(type: "nvarchar(44)", maxLength: 44, nullable: true),
                    Mod_CupomFiscal = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    ECF = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Numero_Contador = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NotaFisc__3214EC2713BCEBC1", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscal_Transporte",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_NF = table.Column<int>(type: "int", nullable: true),
                    CNPJ_CPF = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    IE = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Municipio = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    UF = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    ID_Pessoa = table.Column<int>(type: "int", nullable: true),
                    UFPlaca = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Placa = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NotaFisc__3214EC277908F585", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscal_Volume",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_NF = table.Column<int>(type: "int", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: true),
                    Especie = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Numeracao = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    PesoL = table.Column<decimal>(type: "decimal(15,3)", nullable: true),
                    PesoB = table.Column<decimal>(type: "decimal(15,3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NotaFisc__3214EC277167D3BD", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orcamento",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    TipoPessoa = table.Column<int>(type: "int", nullable: true),
                    ID_Pessoa = table.Column<int>(type: "int", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime", nullable: true),
                    Informacao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ID_UsuarioComissao1 = table.Column<int>(type: "int", nullable: true),
                    ID_UsuarioComissao2 = table.Column<int>(type: "int", nullable: true),
                    ID_UsuarioComissao3 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrcamentoVenda_1", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orcamento_Item",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Orcamento = table.Column<int>(type: "int", nullable: true),
                    ID_Produto = table.Column<int>(type: "int", nullable: true),
                    Quantidade = table.Column<decimal>(type: "decimal(9,3)", nullable: true),
                    ID_Tabela = table.Column<int>(type: "int", nullable: true),
                    ValorMinimo = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ValorProduto = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ValorVenda = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Informacao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TipoSaida = table.Column<int>(type: "int", nullable: true),
                    ID_Grade = table.Column<int>(type: "int", nullable: true),
                    ValorCusto = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOrcamentoVenda", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ordem_Servico",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    TipoPessoa = table.Column<int>(type: "int", nullable: true),
                    ID_Pessoa = table.Column<int>(type: "int", nullable: true),
                    Data_Abertura = table.Column<DateTime>(type: "datetime", nullable: true),
                    Data_Orcamento = table.Column<DateTime>(type: "datetime", nullable: true),
                    Data_Aprovacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    Data_Montagem = table.Column<DateTime>(type: "datetime", nullable: true),
                    Data_Pronta = table.Column<DateTime>(type: "datetime", nullable: true),
                    Data_Entrega = table.Column<DateTime>(type: "datetime", nullable: true),
                    Garantia = table.Column<bool>(type: "bit", nullable: true),
                    Reclamacao = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    TipoAtendimento = table.Column<int>(type: "int", nullable: true),
                    Tipo_Equipamento = table.Column<int>(type: "int", nullable: true),
                    Marca = table.Column<int>(type: "int", nullable: true),
                    Info_Equip_1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Info_Equip_2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Info_Equip_3 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Obs_Equip_1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Obs_Equip_2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Status_OS = table.Column<int>(type: "int", nullable: true),
                    ID_UsuarioComissao1 = table.Column<int>(type: "int", nullable: true),
                    ID_UsuarioComissao2 = table.Column<int>(type: "int", nullable: true),
                    Faturado = table.Column<bool>(type: "bit", nullable: true),
                    NFe = table.Column<bool>(type: "bit", nullable: true),
                    Cancelado = table.Column<bool>(type: "bit", nullable: true),
                    CPF_CNPJ = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    ID_NFe = table.Column<int>(type: "int", nullable: true),
                    ID_CFe = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ordem_Se__3214EC273E723F9C", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ordem_Servico_Item",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_OS = table.Column<int>(type: "int", nullable: true),
                    ID_Produto = table.Column<int>(type: "int", nullable: true),
                    Quantidade = table.Column<decimal>(type: "decimal(9,3)", nullable: true),
                    ID_Tabela = table.Column<int>(type: "int", nullable: true),
                    ValorProduto = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ValorVenda = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Informacao = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    TipoSaida = table.Column<int>(type: "int", nullable: true),
                    ID_Grade = table.Column<int>(type: "int", nullable: true),
                    ValorCusto = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Quantidade_Entregue = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ordem_Se__3214EC274242D080", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Porc_Custo = table.Column<decimal>(type: "decimal(6,3)", nullable: true),
                    Vlr_Custo = table.Column<decimal>(type: "decimal(6,3)", nullable: true),
                    Qt_Parcela = table.Column<int>(type: "int", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: true),
                    Recebimento = table.Column<bool>(type: "bit", nullable: true),
                    Pagamento = table.Column<bool>(type: "bit", nullable: true),
                    Dia_Lancamento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento_Parc",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Pagamento = table.Column<int>(type: "int", nullable: true),
                    Parcelamento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Personalizado = table.Column<bool>(type: "bit", nullable: true),
                    Periodo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pagament__3214EC272E70E1FD", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Pais = table.Column<int>(type: "int", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Parametro_Sistema",
                columns: table => new
                {
                    ID_Empresa = table.Column<int>(type: "int", nullable: false),
                    Juros_Mes = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    Multa = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    DiasBloqueioVenda = table.Column<int>(type: "int", nullable: true),
                    HistoricoVenda = table.Column<int>(type: "int", nullable: true),
                    ID_ContaTransValor = table.Column<int>(type: "int", nullable: true),
                    ID_ContaDevolucaoCheque = table.Column<int>(type: "int", nullable: true),
                    AmbienteNFe = table.Column<int>(type: "int", nullable: true),
                    RegimeTributario = table.Column<int>(type: "int", nullable: true),
                    Exibe_msgCreditoICMS = table.Column<bool>(type: "bit", nullable: true),
                    AliquotaCreditoICMS = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Caminho_NFe = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Exibe_Desconto = table.Column<bool>(type: "bit", nullable: true),
                    Exibe_InfoProduto = table.Column<bool>(type: "bit", nullable: true),
                    Certificado_NFe = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Tipo_NFe_Venda = table.Column<int>(type: "int", nullable: true),
                    ID_ConsumidorFinal = table.Column<int>(type: "int", nullable: true),
                    ID_TabelaVenda = table.Column<int>(type: "int", nullable: true),
                    TipoEquipamentoSAT = table.Column<int>(type: "int", nullable: true),
                    SenhaAtivacaoSAT = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    AssinaturaSAT = table.Column<string>(type: "nvarchar(344)", maxLength: 344, nullable: true),
                    Consulta_Grade = table.Column<int>(type: "int", nullable: true),
                    TipoImpressoraTermica = table.Column<int>(type: "int", nullable: true),
                    Descricao_Info1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Descricao_Info2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Descricao_Info3 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Descricao_Obs1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Descricao_Obs2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    ID_ContaFaturaVenda = table.Column<int>(type: "int", nullable: true),
                    ID_ContaFaturaOS = table.Column<int>(type: "int", nullable: true),
                    ID_ContaFaturaCompra = table.Column<int>(type: "int", nullable: true),
                    Imprime_OS_Equip = table.Column<bool>(type: "bit", nullable: true),
                    Ultimo_Valor = table.Column<bool>(type: "bit", nullable: true),
                    Permitir2Vias = table.Column<bool>(type: "bit", nullable: true),
                    Agrupar_Produto = table.Column<bool>(type: "bit", nullable: true),
                    Descricao_Comissao = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Limite_Desconto = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Produto_Marca = table.Column<bool>(type: "bit", nullable: true),
                    Bloquear_EstoqueNegativo = table.Column<bool>(type: "bit", nullable: true),
                    Msg_EstoqueNegativo = table.Column<bool>(type: "bit", nullable: true),
                    Orca_ValorTotal = table.Column<bool>(type: "bit", nullable: true),
                    Consulta_RapidaProduto = table.Column<bool>(type: "bit", nullable: true),
                    MultiploUsuarioPDV = table.Column<bool>(type: "bit", nullable: true),
                    CFe_A4 = table.Column<bool>(type: "bit", nullable: true),
                    Monitor_CFe = table.Column<bool>(type: "bit", nullable: true),
                    NaoAlterarVendaFaturada = table.Column<bool>(type: "bit", nullable: true),
                    PagamentoTrocoDevolucao = table.Column<int>(type: "int", nullable: true),
                    ID_ContaDevolucaoVenda = table.Column<int>(type: "int", nullable: true),
                    ID_Caixa_Principal = table.Column<int>(type: "int", nullable: true),
                    ID_Conta_PagtoDiverso = table.Column<int>(type: "int", nullable: true),
                    ID_Conta_RectoDiverso = table.Column<int>(type: "int", nullable: true),
                    ID_Conta_CobrancaBancaria = table.Column<int>(type: "int", nullable: true),
                    ID_PagtoBoleto = table.Column<int>(type: "int", nullable: true),
                    De = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    ClienteDescricao1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    ClienteDescricao2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    ClienteDescricao3 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    EmpresaDescricao1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    EmpresaDescricao2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    EmpresaDescricao3 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    FornecedorDescricao1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    FornecedorDescricao2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    FornecedorDescricao3 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    FuncionarioDescricao1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    FuncionarioDescricao2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    FuncionarioDescricao3 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    TransportadoraDescricao1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    TransportadoraDescricao2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    TransportadoraDescricao3 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Info_Produto1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Info_Produto2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Venda_Matricial = table.Column<bool>(type: "bit", nullable: true),
                    Modelo_Matricial = table.Column<int>(type: "int", nullable: true),
                    Exibe_DuplicarProduto = table.Column<bool>(type: "bit", nullable: true),
                    Desconto_Padrao = table.Column<int>(type: "int", nullable: true),
                    Exibe_NFeVenda = table.Column<bool>(type: "bit", nullable: true),
                    Exibe_ReferenciaNFe = table.Column<bool>(type: "bit", nullable: true),
                    CFe_Cartao = table.Column<bool>(type: "bit", nullable: true),
                    Venda_ImpressaoDireta = table.Column<bool>(type: "bit", nullable: true),
                    CFe_PDV_Cartao = table.Column<bool>(type: "bit", nullable: true),
                    TipoSaida_Fixo = table.Column<bool>(type: "bit", nullable: true),
                    Produto_PrecoVenda = table.Column<int>(type: "int", nullable: true),
                    Somente_Maiusculo = table.Column<bool>(type: "bit", nullable: true),
                    Qt_Dias_Pesquisa = table.Column<int>(type: "int", nullable: true),
                    Cadastro_PessoaPadrao = table.Column<int>(type: "int", nullable: true),
                    Altera_ValorPDV = table.Column<bool>(type: "bit", nullable: true),
                    Endereco_Padrao = table.Column<int>(type: "int", nullable: true),
                    Telefone_Padrao = table.Column<int>(type: "int", nullable: true),
                    EntradaProduto = table.Column<int>(type: "int", nullable: true),
                    Decimal_Produto_Valor = table.Column<int>(type: "int", nullable: true),
                    Decimal_Produto_Quantidade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Parametr__F4BB60390BE6BFCF", x => x.ID_Empresa);
                });

            migrationBuilder.CreateTable(
                name: "Parametro_Usuario",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Usuario = table.Column<int>(type: "int", nullable: true),
                    Comissao = table.Column<bool>(type: "bit", nullable: true),
                    Venda_Restrita = table.Column<bool>(type: "bit", nullable: true),
                    Libera_Desconto = table.Column<bool>(type: "bit", nullable: true),
                    Venda_Fixa_logado = table.Column<bool>(type: "bit", nullable: true),
                    Permite_Faturar = table.Column<bool>(type: "bit", nullable: true),
                    Permite_AterarFaturado = table.Column<bool>(type: "bit", nullable: true),
                    Visualiza_ResumoVenda = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario___3214EC271FEDB87C", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ParametroMobile",
                columns: table => new
                {
                    ID_Empresa = table.Column<int>(type: "int", nullable: false),
                    Situacao = table.Column<int>(type: "int", nullable: true),
                    TipoVendaProduto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametroMobile", x => x.ID_Empresa);
                });

            migrationBuilder.CreateTable(
                name: "PermissaoMobile",
                columns: table => new
                {
                    ID_Usuario = table.Column<int>(type: "int", nullable: false),
                    Menu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissaoMobile", x => new { x.ID_Usuario, x.Menu });
                });

            migrationBuilder.CreateTable(
                name: "PermissaoSistema",
                columns: table => new
                {
                    ID_Usuario = table.Column<int>(type: "int", nullable: false),
                    Menu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissaoSistema", x => new { x.ID_Usuario, x.Menu });
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MultiEmpresa = table.Column<bool>(type: "bit", nullable: true),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    TipoPessoa = table.Column<int>(type: "int", nullable: true),
                    ID_Pessoa = table.Column<int>(type: "int", nullable: true),
                    TipoDocumento = table.Column<int>(type: "int", nullable: true),
                    CNPJ_CPF = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    Nome_Razao = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    NomeFantasia = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Contato = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    IE_RG = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    IM = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    CNAE = table.Column<string>(type: "nchar(7)", fixedLength: true, maxLength: 7, nullable: true),
                    Cadastro = table.Column<DateTime>(type: "datetime", nullable: true),
                    Informacao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ID_Grupo = table.Column<int>(type: "int", nullable: true),
                    Nascimento_Fundacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ramo_Profissao = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Descricao1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Descricao2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Descricao3 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Limite = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    DiaFaturamento = table.Column<int>(type: "int", nullable: true),
                    Situacao_old = table.Column<int>(type: "int", nullable: true),
                    CEI = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ValorMensalidade = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Responsavel = table.Column<int>(type: "int", nullable: true),
                    Conjuge = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    CPF_Conjuge = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    Profissao_Conjuge = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    RG_Conjuge = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    Situacao = table.Column<bool>(type: "bit", nullable: true),
                    Desconto_Venda = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Informacao_Venda = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Dia_Faturamento = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa_EmpresaResponsavel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Pessoa = table.Column<int>(type: "int", nullable: true),
                    TipoPessoaResponsavel = table.Column<int>(type: "int", nullable: true),
                    ID_PessoaResponsavel = table.Column<int>(type: "int", nullable: true),
                    TipoPessoa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pessoa_E__3214EC2769C6B1F5", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PessoaCliente",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Usuario = table.Column<int>(type: "int", nullable: true),
                    Referencia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaCliente", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PessoaEmail",
                columns: table => new
                {
                    ID_Email = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoPessoa = table.Column<int>(type: "int", nullable: true),
                    ID_Pessoa = table.Column<int>(type: "int", nullable: true),
                    PrincipalEmail = table.Column<bool>(type: "bit", nullable: true),
                    TipoEmail = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    InformacaoEmail = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaEmail", x => x.ID_Email);
                });

            migrationBuilder.CreateTable(
                name: "PessoaEmpresa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Referencia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaEmpresa", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PessoaEndereco",
                columns: table => new
                {
                    ID_Endereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoPessoa = table.Column<int>(type: "int", nullable: true),
                    ID_Pessoa = table.Column<int>(type: "int", nullable: true),
                    PrincipalEndereco = table.Column<bool>(type: "bit", nullable: true),
                    TipoEndereco = table.Column<int>(type: "int", nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    NumeroEndereco = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    ID_Municipio = table.Column<int>(type: "int", nullable: true),
                    CEP = table.Column<string>(type: "nchar(9)", fixedLength: true, maxLength: 9, nullable: true),
                    ID_Pais = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaEndereco", x => x.ID_Endereco);
                });

            migrationBuilder.CreateTable(
                name: "PessoaFiador",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Usuario = table.Column<int>(type: "int", nullable: true),
                    Referencia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PessoaFi__3214EC273BCADD1B", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PessoaFornecedor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Referencia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaFornecedor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PessoaFuncionario",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salario = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    CarteiraProfissional = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    PIS = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Referencia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaFuncionario", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PessoaImagem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<int>(type: "int", nullable: true),
                    TipoPessoa = table.Column<int>(type: "int", nullable: true),
                    ID_Pessoa = table.Column<int>(type: "int", nullable: true),
                    Imagem = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaImagem", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PessoaLocatario",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Usuario = table.Column<int>(type: "int", nullable: true),
                    Referencia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PessoaLo__3214EC2737FA4C37", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PessoaProprietario",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Usuario = table.Column<int>(type: "int", nullable: true),
                    Referencia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PessoaPr__3214EC273429BB53", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PessoaResponsavel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Referencia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PessoaRe__3214EC2732767D0B", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PessoaTelefone",
                columns: table => new
                {
                    ID_Telefone = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoPessoa = table.Column<int>(type: "int", nullable: true),
                    ID_Pessoa = table.Column<int>(type: "int", nullable: true),
                    PrincipalTelefone = table.Column<bool>(type: "bit", nullable: true),
                    TipoTelefone = table.Column<int>(type: "int", nullable: true),
                    DDD = table.Column<string>(type: "nchar(2)", fixedLength: true, maxLength: 2, nullable: true),
                    NumeroTelefone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    InformacaoTelefone = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaTelefone", x => x.ID_Telefone);
                });

            migrationBuilder.CreateTable(
                name: "PessoaTransportadora",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Referencia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaTransportadora", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlanoConta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nivel = table.Column<int>(type: "int", nullable: true),
                    CodigoPai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CodigoDescritivo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Redutor = table.Column<bool>(type: "bit", nullable: true),
                    Referencial = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Planejamento = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoConta", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Produto_Comissao",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Produto = table.Column<int>(type: "int", nullable: true),
                    ID_Usuario = table.Column<int>(type: "int", nullable: true),
                    ID_TipoComissao = table.Column<int>(type: "int", nullable: true),
                    Comissao = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProdutoC__3214EC27671F4F74", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Produto_Desconto",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    ID_Produto = table.Column<int>(type: "int", nullable: true),
                    Quantidade_Minima = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    Quantidade_Maxima = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    Desconto = table.Column<decimal>(type: "decimal(9,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Produto___3214EC27190BB0C3", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Produto_Desconto_Pessoa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    ID_Produto = table.Column<int>(type: "int", nullable: true),
                    TipoPessoa = table.Column<int>(type: "int", nullable: true),
                    ID_Pessoa = table.Column<int>(type: "int", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: true),
                    Desconto = table.Column<decimal>(type: "decimal(9,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Produto___3214EC2720ACD28B", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Produto_Entrada",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    TipoPessoa = table.Column<int>(type: "int", nullable: true),
                    ID_Pessoa = table.Column<int>(type: "int", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime", nullable: true),
                    Entrega = table.Column<DateTime>(type: "datetime", nullable: true),
                    ID_Usuario = table.Column<int>(type: "int", nullable: true),
                    ID_Pagamento = table.Column<int>(type: "int", nullable: true),
                    Informacao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Situacao = table.Column<int>(type: "int", nullable: true),
                    TipoDocumento = table.Column<int>(type: "int", nullable: true),
                    Documento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Faturado = table.Column<bool>(type: "bit", nullable: true),
                    Tipo_Entrada = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemCompra", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Produto_Entrada_Item",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Produto_Entrada = table.Column<int>(type: "int", nullable: true),
                    ID_Produto = table.Column<int>(type: "int", nullable: true),
                    Quantidade = table.Column<decimal>(type: "decimal(9,3)", nullable: true),
                    ValorCompra = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    OutrosCustos = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ID_Grade = table.Column<int>(type: "int", nullable: true),
                    ValorIPI = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ValorST = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ValorVenda = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Margem = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ValorAntigo = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    NFe_Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NFe_CodigoProduto = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOrdemCompra", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Produto_Estoque",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Produto = table.Column<int>(type: "int", nullable: true),
                    ID_Grade = table.Column<int>(type: "int", nullable: true),
                    EstoqueAtual = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    EstoqueIdeal = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    EstoqueMinimo = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Localizacao = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProdutoE__3214EC2772910220", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Produto_Estrutura",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Produto = table.Column<int>(type: "int", nullable: true),
                    ID_Produto_Estrutura = table.Column<int>(type: "int", nullable: true),
                    ID_Grade_Estrutura = table.Column<int>(type: "int", nullable: true),
                    Quantidade = table.Column<decimal>(type: "decimal(10,3)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Produto_Fornecedor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Produto = table.Column<int>(type: "int", nullable: true),
                    ID_Fornecedor = table.Column<int>(type: "int", nullable: true),
                    Codigo_Produto = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoFornecedor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Produto_Movimento",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime", nullable: true),
                    ID_Produto = table.Column<int>(type: "int", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: true),
                    Quantidade = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    Informacao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Produto___3214EC2774CE504D", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Produto_Parametro",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Produto = table.Column<int>(type: "int", nullable: true),
                    ID_Imposto = table.Column<int>(type: "int", nullable: true),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProdutoI__3214EC273DE82FB7", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Produto_Servico",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MultiEmpresa = table.Column<bool>(type: "bit", nullable: true),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    GrupoNivel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Referencia = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Fabricante = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Informacao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Barra = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    Barratributavel = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    NCM = table.Column<string>(type: "nchar(8)", fixedLength: true, maxLength: 8, nullable: true),
                    ValorCompra = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    OutrosCustos = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    UnidadeTributavel = table.Column<int>(type: "int", nullable: true),
                    Validade = table.Column<int>(type: "int", nullable: true),
                    Garantia = table.Column<int>(type: "int", nullable: true),
                    Situacao = table.Column<bool>(type: "bit", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    EX_TIPI = table.Column<int>(type: "int", nullable: true),
                    ClasseEnquadramento = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CNPJProdutor = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    CustoFinal = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ID_Grupo = table.Column<int>(type: "int", nullable: true),
                    Imagem = table.Column<byte[]>(type: "image", nullable: true),
                    PesoB = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    PesoL = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    ValorIPI = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Controle_Estoque = table.Column<bool>(type: "bit", nullable: true),
                    ProdutoEspecifico = table.Column<bool>(type: "bit", nullable: true),
                    Cod_ANP = table.Column<int>(type: "int", nullable: true),
                    ValorST = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    InfoAdicional1 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    InfoAdicional2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    ABC = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    ID_CEST = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Produto_Valor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Produto = table.Column<int>(type: "int", nullable: true),
                    ID_Tabela = table.Column<int>(type: "int", nullable: true),
                    MargemVenda = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ValorVenda = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    UltimoReajuste = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoValor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoServicoViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    IdEmpresa = table.Column<int>(type: "int", nullable: true),
                    IdGrupo = table.Column<int>(type: "int", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fabricante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Informacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imagem = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Barra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarraTributavel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ncm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OutrosCustos = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorIpi = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorSt = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CustoFinal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnidadeTributavel = table.Column<int>(type: "int", nullable: true),
                    Validade = table.Column<int>(type: "int", nullable: true),
                    Garantia = table.Column<int>(type: "int", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: true),
                    InfoAdicional1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoAdicional2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTabela = table.Column<int>(type: "int", nullable: true),
                    MargemVenda = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorVenda = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UltimoReajuste = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BarraEtiqueta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdGrade = table.Column<int>(type: "int", nullable: true),
                    EstoqueMinimo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EstoqueIdeal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EstoqueAtual = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Localizacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescricaoGrade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdGrupoGrade = table.Column<int>(type: "int", nullable: true),
                    Unidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescricaoCompleta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescricaoGrupo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodGrupo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoServicoViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaValor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Margem = table.Column<decimal>(type: "decimal(6,3)", nullable: true),
                    CustoOperacional = table.Column<decimal>(type: "decimal(6,3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaValor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UF",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Pais = table.Column<int>(type: "int", nullable: true),
                    ID_UF = table.Column<int>(type: "int", nullable: true),
                    Sigla = table.Column<string>(type: "nchar(2)", fixedLength: true, maxLength: 2, nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Aliquota_Interna = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Aliquota_FCP = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UF", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UF_AliquotaICMS",
                columns: table => new
                {
                    ID_UF_Origem = table.Column<int>(type: "int", nullable: true),
                    ID_UF_Destino = table.Column<int>(type: "int", nullable: true),
                    Aliquota = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MultiEmpresa = table.Column<bool>(type: "bit", nullable: true),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    Cadastrado = table.Column<bool>(type: "bit", nullable: true),
                    TipoPessoa = table.Column<int>(type: "int", nullable: true),
                    ID_Pessoa = table.Column<int>(type: "int", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    UsuarioSistema = table.Column<bool>(type: "bit", nullable: true),
                    SenhaSistema = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UsuarioMobile = table.Column<bool>(type: "bit", nullable: true),
                    SenhaMobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Situacao = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    TipoPessoa = table.Column<int>(type: "int", nullable: true),
                    ID_Pessoa = table.Column<int>(type: "int", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime", nullable: true),
                    Entrega = table.Column<DateTime>(type: "datetime", nullable: true),
                    Informacao = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ID_UsuarioComissao1 = table.Column<int>(type: "int", nullable: true),
                    ID_UsuarioComissao2 = table.Column<int>(type: "int", nullable: true),
                    DataFatura = table.Column<DateTime>(type: "datetime", nullable: true),
                    Comprador = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Faturado = table.Column<bool>(type: "bit", nullable: true),
                    NFe = table.Column<bool>(type: "bit", nullable: true),
                    ID_Pagamento = table.Column<int>(type: "int", nullable: true),
                    ID_Parcelamento = table.Column<int>(type: "int", nullable: true),
                    Cancelado = table.Column<bool>(type: "bit", nullable: true),
                    Situacao_Entrega = table.Column<int>(type: "int", nullable: true),
                    Situacao_Conferencia = table.Column<int>(type: "int", nullable: true),
                    ID_Usuario_Conferencia = table.Column<int>(type: "int", nullable: true),
                    CPF_CNPJ = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    ID_NFe = table.Column<int>(type: "int", nullable: true),
                    ID_CFe = table.Column<int>(type: "int", nullable: true),
                    SEQVENDA = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoVenda", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Venda_Externo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Empresa = table.Column<int>(type: "int", nullable: true),
                    ID_Usuario = table.Column<int>(type: "int", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime", nullable: true),
                    Informacao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Venda_Ex__3214EC270BB1B5A5", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Venda_Item",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Venda = table.Column<int>(type: "int", nullable: true),
                    ID_Produto = table.Column<int>(type: "int", nullable: true),
                    Quantidade = table.Column<decimal>(type: "decimal(9,3)", nullable: true),
                    ID_Tabela = table.Column<int>(type: "int", nullable: true),
                    ValorProduto = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ValorVenda = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Informacao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TipoSaida = table.Column<int>(type: "int", nullable: true),
                    ID_Grade = table.Column<int>(type: "int", nullable: true),
                    ValorCusto = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Quantidade_Entregue = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Quantidade_Conferido = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPedidoVenda", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Venda_Mobile",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Venda = table.Column<int>(type: "int", nullable: true),
                    ID_Pessoa = table.Column<int>(type: "int", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ID_Tabela = table.Column<int>(type: "int", nullable: true),
                    ID_Parcelamento = table.Column<int>(type: "int", nullable: true),
                    Informacao = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Desconto = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Comprador = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ID_Usuario = table.Column<int>(type: "int", nullable: true),
                    IMEI = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Venda_Mo__3214EC2775F77EB0", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Venda_Sequencia",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SEQ = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Venda_Se__3214EC2738D2CF00", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Versao",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Versao = table.Column<int>(type: "int", nullable: true),
                    BD = table.Column<int>(type: "int", nullable: true),
                    Chave = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versao", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FolhaPagto_Evento",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_FolhaPagto = table.Column<int>(type: "int", nullable: true),
                    ID_Evento = table.Column<int>(type: "int", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Folha_Ev__3214EC27640DD89F", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Folha_Eve__ID_Ev__66EA454A",
                        column: x => x.ID_Evento,
                        principalTable: "Evento",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Folha_Eve__ID_Fo__65F62111",
                        column: x => x.ID_FolhaPagto,
                        principalTable: "FolhaPagto",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Venda_Externo_Item",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Venda_Externa = table.Column<int>(type: "int", nullable: true),
                    ID_Produto = table.Column<int>(type: "int", nullable: true),
                    Informacao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Venda_Ex__3214EC270F824689", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Venda_Ext__ID_Pr__125EB334",
                        column: x => x.ID_Produto,
                        principalTable: "Produto_Servico",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Venda_Ext__ID_Ve__116A8EFB",
                        column: x => x.ID_Venda_Externa,
                        principalTable: "Venda_Externo",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Venda_Item_Mobile",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Venda = table.Column<int>(type: "int", nullable: true),
                    ID_Produto = table.Column<int>(type: "int", nullable: true),
                    Quantidade = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Informacao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TipoSaida = table.Column<int>(type: "int", nullable: true),
                    IMEI = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VendaMobileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Venda_It__3214EC2779C80F94", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Venda_Item_Mobile_Venda_Mobile_VendaMobileId",
                        column: x => x.VendaMobileId,
                        principalTable: "Venda_Mobile",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Venda_Mob__ID_Ve__116A8EFB",
                        column: x => x.ID_Venda,
                        principalTable: "ProdutoServicoViewModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "I_ID_Pessoa",
                table: "Boleto",
                column: "ID_Pessoa");

            migrationBuilder.CreateIndex(
                name: "I_ID_Boleto",
                table: "BoletoControle",
                column: "ID_Boleto");

            migrationBuilder.CreateIndex(
                name: "I_ID_Conta",
                table: "BoletoControle",
                column: "ID_Conta");

            migrationBuilder.CreateIndex(
                name: "I_ID_Pessoa",
                table: "CPagar",
                column: "ID_Pessoa");

            migrationBuilder.CreateIndex(
                name: "I_ID_Pedido",
                table: "CReceber",
                column: "ID_Venda");

            migrationBuilder.CreateIndex(
                name: "I_ID_Pessoa",
                table: "CReceber",
                column: "ID_Pessoa");

            migrationBuilder.CreateIndex(
                name: "I_ID_PrevisaoPagto",
                table: "CReceber",
                column: "ID_PrevisaoPagto");

            migrationBuilder.CreateIndex(
                name: "I_ID_CPagar",
                table: "FluxoCaixa_Controle",
                column: "ID_CPagar");

            migrationBuilder.CreateIndex(
                name: "I_ID_CReceber",
                table: "FluxoCaixa_Controle",
                column: "ID_CReceber");

            migrationBuilder.CreateIndex(
                name: "I_ID_FluxoCaixa",
                table: "FluxoCaixa_Controle",
                column: "ID_FluxoCaixa");

            migrationBuilder.CreateIndex(
                name: "IX_FolhaPagto_Evento_ID_Evento",
                table: "FolhaPagto_Evento",
                column: "ID_Evento");

            migrationBuilder.CreateIndex(
                name: "IX_FolhaPagto_Evento_ID_FolhaPagto",
                table: "FolhaPagto_Evento",
                column: "ID_FolhaPagto");

            migrationBuilder.CreateIndex(
                name: "I_ID_Imposto",
                table: "Imposto_Tributacao",
                column: "ID_Imposto");

            migrationBuilder.CreateIndex(
                name: "I_ID_Tributacao",
                table: "Imposto_UF",
                column: "ID_Tributacao");

            migrationBuilder.CreateIndex(
                name: "I_ID_UF",
                table: "Imposto_UF",
                column: "ID_UF");

            migrationBuilder.CreateIndex(
                name: "I_ID_Pedido",
                table: "NotaFiscal",
                column: "ID_Venda");

            migrationBuilder.CreateIndex(
                name: "I_ID_Pessoa",
                table: "NotaFiscal",
                column: "ID_Pessoa");

            migrationBuilder.CreateIndex(
                name: "I_ID_Produto",
                table: "NotaFiscal_Item",
                column: "ID_Produto");

            migrationBuilder.CreateIndex(
                name: "I_ID_Pessoa",
                table: "Pessoa",
                column: "ID_Pessoa");

            migrationBuilder.CreateIndex(
                name: "I_ID_Pessoa",
                table: "PessoaEmail",
                column: "ID_Pessoa");

            migrationBuilder.CreateIndex(
                name: "I_ID_Pessoa",
                table: "PessoaEndereco",
                column: "ID_Pessoa");

            migrationBuilder.CreateIndex(
                name: "I_ID_Pessoa",
                table: "PessoaTelefone",
                column: "ID_Pessoa");

            migrationBuilder.CreateIndex(
                name: "I_ID_Produto",
                table: "Produto_Comissao",
                column: "ID_Produto");

            migrationBuilder.CreateIndex(
                name: "I_ID_Produto",
                table: "Produto_Estoque",
                column: "ID_Produto");

            migrationBuilder.CreateIndex(
                name: "I_ID_Grade_Estrutura",
                table: "Produto_Estrutura",
                column: "ID_Grade_Estrutura");

            migrationBuilder.CreateIndex(
                name: "I_ID_Produto",
                table: "Produto_Estrutura",
                column: "ID_Produto");

            migrationBuilder.CreateIndex(
                name: "I_ID_Produto_Estrutura",
                table: "Produto_Estrutura",
                column: "ID_Produto_Estrutura");

            migrationBuilder.CreateIndex(
                name: "I_ID_Imposto",
                table: "Produto_Parametro",
                column: "ID_Imposto");

            migrationBuilder.CreateIndex(
                name: "I_ID_Produto",
                table: "Produto_Parametro",
                column: "ID_Produto");

            migrationBuilder.CreateIndex(
                name: "I_ID_Produto",
                table: "Produto_Valor",
                column: "ID_Produto");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_Externo_Item_ID_Produto",
                table: "Venda_Externo_Item",
                column: "ID_Produto");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_Externo_Item_ID_Venda_Externa",
                table: "Venda_Externo_Item",
                column: "ID_Venda_Externa");

            migrationBuilder.CreateIndex(
                name: "I_ID_Pedido",
                table: "Venda_Item",
                column: "ID_Venda");

            migrationBuilder.CreateIndex(
                name: "I_ID_Produto",
                table: "Venda_Item",
                column: "ID_Produto");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_Item_Mobile_ID_Venda",
                table: "Venda_Item_Mobile",
                column: "ID_Venda");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_Item_Mobile_VendaMobileId",
                table: "Venda_Item_Mobile",
                column: "VendaMobileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banco");

            migrationBuilder.DropTable(
                name: "Boleto");

            migrationBuilder.DropTable(
                name: "Boleto_Remessa");

            migrationBuilder.DropTable(
                name: "Boleto_RemessaControle");

            migrationBuilder.DropTable(
                name: "BoletoControle");

            migrationBuilder.DropTable(
                name: "Cartao");

            migrationBuilder.DropTable(
                name: "Cartao_Controle");

            migrationBuilder.DropTable(
                name: "Cedente");

            migrationBuilder.DropTable(
                name: "CEST");

            migrationBuilder.DropTable(
                name: "CFOP");

            migrationBuilder.DropTable(
                name: "Cheque");

            migrationBuilder.DropTable(
                name: "Comodato");

            migrationBuilder.DropTable(
                name: "ComodatoItem");

            migrationBuilder.DropTable(
                name: "ControleDoc");

            migrationBuilder.DropTable(
                name: "ControleDoc_Tipo");

            migrationBuilder.DropTable(
                name: "CPagar");

            migrationBuilder.DropTable(
                name: "CReceber");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "FichaProducao");

            migrationBuilder.DropTable(
                name: "FluxoCaixa");

            migrationBuilder.DropTable(
                name: "FluxoCaixa_Controle");

            migrationBuilder.DropTable(
                name: "FolhaPagto_Evento");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "Grupo");

            migrationBuilder.DropTable(
                name: "GrupoNivel");

            migrationBuilder.DropTable(
                name: "Imagem");

            migrationBuilder.DropTable(
                name: "Imovel");

            migrationBuilder.DropTable(
                name: "Imovel_Contrato");

            migrationBuilder.DropTable(
                name: "Imovel_Custo");

            migrationBuilder.DropTable(
                name: "Imovel_Imagem");

            migrationBuilder.DropTable(
                name: "Imovel_Proprietario");

            migrationBuilder.DropTable(
                name: "Imovel_Vistoria");

            migrationBuilder.DropTable(
                name: "Imposto");

            migrationBuilder.DropTable(
                name: "Imposto_Tributacao");

            migrationBuilder.DropTable(
                name: "Imposto_UF");

            migrationBuilder.DropTable(
                name: "Locacao");

            migrationBuilder.DropTable(
                name: "Locacao_Fiador");

            migrationBuilder.DropTable(
                name: "Locacao_Locatario");

            migrationBuilder.DropTable(
                name: "Log_Acesso");

            migrationBuilder.DropTable(
                name: "Mobile");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "NCM");

            migrationBuilder.DropTable(
                name: "NF_TipoEmissao");

            migrationBuilder.DropTable(
                name: "NotaFiscal");

            migrationBuilder.DropTable(
                name: "NotaFiscal_Adicao");

            migrationBuilder.DropTable(
                name: "NotaFiscal_AutXML");

            migrationBuilder.DropTable(
                name: "NotaFiscal_Cobranca");

            migrationBuilder.DropTable(
                name: "NotaFiscal_Duplicata");

            migrationBuilder.DropTable(
                name: "NotaFiscal_Ent_Ret");

            migrationBuilder.DropTable(
                name: "NotaFiscal_Evento");

            migrationBuilder.DropTable(
                name: "NotaFiscal_Importacao");

            migrationBuilder.DropTable(
                name: "NotaFiscal_Inutilizacao");

            migrationBuilder.DropTable(
                name: "NotaFiscal_Item");

            migrationBuilder.DropTable(
                name: "NotaFiscal_Lacre");

            migrationBuilder.DropTable(
                name: "NotaFiscal_Referenciada");

            migrationBuilder.DropTable(
                name: "NotaFiscal_Transporte");

            migrationBuilder.DropTable(
                name: "NotaFiscal_Volume");

            migrationBuilder.DropTable(
                name: "Orcamento");

            migrationBuilder.DropTable(
                name: "Orcamento_Item");

            migrationBuilder.DropTable(
                name: "Ordem_Servico");

            migrationBuilder.DropTable(
                name: "Ordem_Servico_Item");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "Pagamento_Parc");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropTable(
                name: "Parametro_Sistema");

            migrationBuilder.DropTable(
                name: "Parametro_Usuario");

            migrationBuilder.DropTable(
                name: "ParametroMobile");

            migrationBuilder.DropTable(
                name: "PermissaoMobile");

            migrationBuilder.DropTable(
                name: "PermissaoSistema");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Pessoa_EmpresaResponsavel");

            migrationBuilder.DropTable(
                name: "PessoaCliente");

            migrationBuilder.DropTable(
                name: "PessoaEmail");

            migrationBuilder.DropTable(
                name: "PessoaEmpresa");

            migrationBuilder.DropTable(
                name: "PessoaEndereco");

            migrationBuilder.DropTable(
                name: "PessoaFiador");

            migrationBuilder.DropTable(
                name: "PessoaFornecedor");

            migrationBuilder.DropTable(
                name: "PessoaFuncionario");

            migrationBuilder.DropTable(
                name: "PessoaImagem");

            migrationBuilder.DropTable(
                name: "PessoaLocatario");

            migrationBuilder.DropTable(
                name: "PessoaProprietario");

            migrationBuilder.DropTable(
                name: "PessoaResponsavel");

            migrationBuilder.DropTable(
                name: "PessoaTelefone");

            migrationBuilder.DropTable(
                name: "PessoaTransportadora");

            migrationBuilder.DropTable(
                name: "PlanoConta");

            migrationBuilder.DropTable(
                name: "Produto_Comissao");

            migrationBuilder.DropTable(
                name: "Produto_Desconto");

            migrationBuilder.DropTable(
                name: "Produto_Desconto_Pessoa");

            migrationBuilder.DropTable(
                name: "Produto_Entrada");

            migrationBuilder.DropTable(
                name: "Produto_Entrada_Item");

            migrationBuilder.DropTable(
                name: "Produto_Estoque");

            migrationBuilder.DropTable(
                name: "Produto_Estrutura");

            migrationBuilder.DropTable(
                name: "Produto_Fornecedor");

            migrationBuilder.DropTable(
                name: "Produto_Movimento");

            migrationBuilder.DropTable(
                name: "Produto_Parametro");

            migrationBuilder.DropTable(
                name: "Produto_Valor");

            migrationBuilder.DropTable(
                name: "TabelaValor");

            migrationBuilder.DropTable(
                name: "UF");

            migrationBuilder.DropTable(
                name: "UF_AliquotaICMS");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropTable(
                name: "Venda_Externo_Item");

            migrationBuilder.DropTable(
                name: "Venda_Item");

            migrationBuilder.DropTable(
                name: "Venda_Item_Mobile");

            migrationBuilder.DropTable(
                name: "Venda_Sequencia");

            migrationBuilder.DropTable(
                name: "Versao");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "FolhaPagto");

            migrationBuilder.DropTable(
                name: "Produto_Servico");

            migrationBuilder.DropTable(
                name: "Venda_Externo");

            migrationBuilder.DropTable(
                name: "Venda_Mobile");

            migrationBuilder.DropTable(
                name: "ProdutoServicoViewModel");
        }
    }
}
