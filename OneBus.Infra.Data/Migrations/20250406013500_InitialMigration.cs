using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Cep = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Municipio = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    Numero = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Complemento = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<byte>(type: "tinyint", nullable: false),
                    Prefixo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    NumeroPortas = table.Column<byte>(type: "tinyint", nullable: false),
                    NumeroAssentos = table.Column<byte>(type: "tinyint", nullable: false),
                    TemAcessibilidade = table.Column<bool>(type: "bit", nullable: false),
                    TipoCombustivel = table.Column<byte>(type: "tinyint", nullable: false),
                    Marca = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Modelo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Placa = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Cor = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    NumeroCarroceria = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    NumeroChassi = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    NumeroMotor = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    NumeroEixos = table.Column<byte>(type: "tinyint", nullable: false),
                    IpvaVencimento = table.Column<DateOnly>(type: "date", nullable: false),
                    LicenciamentoVencimento = table.Column<DateOnly>(type: "date", nullable: false),
                    Renavam = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    TipoTransmissao = table.Column<byte>(type: "tinyint", nullable: false),
                    DataAquisicao = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Foto = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnderecoId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    Cnpj = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Foto = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresa_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnderecoId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    Rg = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Cpf = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    TipoSanguineo = table.Column<byte>(type: "tinyint", nullable: true),
                    Codigo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Cargo = table.Column<byte>(type: "tinyint", nullable: false),
                    Email = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    DataContratacao = table.Column<DateOnly>(type: "date", nullable: false),
                    NumeroCnh = table.Column<string>(type: "varchar(900)", unicode: false, nullable: true),
                    CategoriaCnh = table.Column<byte>(type: "tinyint", nullable: true),
                    ValidadeCnh = table.Column<DateOnly>(type: "date", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Foto = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionario_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Manutencao",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VeiculoId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Setor = table.Column<byte>(type: "tinyint", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    DataInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    DataFim = table.Column<DateOnly>(type: "date", nullable: false),
                    VistoriaVencimento = table.Column<DateOnly>(type: "date", nullable: false),
                    Custo = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manutencao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manutencao_Veiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Onibus",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VeiculoId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Servico = table.Column<byte>(type: "tinyint", nullable: false),
                    MarcaChassi = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ModeloChassi = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    AnoChassi = table.Column<int>(type: "int", nullable: false),
                    TemPisoBaixo = table.Column<bool>(type: "bit", nullable: false),
                    TemPortasEsquerda = table.Column<bool>(type: "bit", nullable: false),
                    SeguroVencimento = table.Column<DateOnly>(type: "date", nullable: false),
                    DetetizacaoVencimento = table.Column<DateOnly>(type: "date", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onibus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Onibus_Veiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Garagem",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    EnderecoId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Foto = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Garagem_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Garagem_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Linha",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Nome = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    Tipo = table.Column<byte>(type: "tinyint", nullable: false),
                    TempoViagem = table.Column<TimeOnly>(type: "time", nullable: false),
                    Quilometragem = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: false),
                    NumeroMinimoOnibus = table.Column<byte>(type: "tinyint", nullable: false),
                    NumeroMaximoOnibus = table.Column<byte>(type: "tinyint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Linha_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Senha = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Sal = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Foto = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FuncionarioHorario",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    HoraInicio = table.Column<TimeOnly>(type: "time", nullable: false),
                    HoraFim = table.Column<TimeOnly>(type: "time", nullable: false),
                    Dia = table.Column<byte>(type: "tinyint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioHorario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuncionarioHorario_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OnibusAuditoria",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    OnibusId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Data = table.Column<DateOnly>(type: "date", nullable: false),
                    TotalPassageiros = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    TotalPassageirosDia = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    TotalQuilometragem = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: false),
                    TotalQuilometragemDia = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnibusAuditoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnibusAuditoria_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnibusAuditoria_Onibus_OnibusId",
                        column: x => x.OnibusId,
                        principalTable: "Onibus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FuncionarioGaragem",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    GaragemId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioGaragem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuncionarioGaragem_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FuncionarioGaragem_Garagem_GaragemId",
                        column: x => x.GaragemId,
                        principalTable: "Garagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VeiculoGaragem",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VeiculoId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    GaragemId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeiculoGaragem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VeiculoGaragem_Garagem_GaragemId",
                        column: x => x.GaragemId,
                        principalTable: "Garagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VeiculoGaragem_Veiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LinhaEndereco",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinhaId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    EnderecoId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    SentidoLinha = table.Column<byte>(type: "tinyint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinhaEndereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinhaEndereco_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LinhaEndereco_Linha_LinhaId",
                        column: x => x.LinhaId,
                        principalTable: "Linha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LinhaHorario",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinhaId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    HoraInicio = table.Column<TimeOnly>(type: "time", nullable: false),
                    HoraFim = table.Column<TimeOnly>(type: "time", nullable: false),
                    Dia = table.Column<byte>(type: "tinyint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinhaHorario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinhaHorario_Linha_LinhaId",
                        column: x => x.LinhaId,
                        principalTable: "Linha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LinhaTarifa",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinhaId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: false),
                    NumeroBilhetes = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinhaTarifa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinhaTarifa_Linha_LinhaId",
                        column: x => x.LinhaId,
                        principalTable: "Linha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VeiculoOperacao",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioHorarioId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    VeiculoId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Data = table.Column<DateOnly>(type: "date", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeiculoOperacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VeiculoOperacao_FuncionarioHorario_FuncionarioHorarioId",
                        column: x => x.FuncionarioHorarioId,
                        principalTable: "FuncionarioHorario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VeiculoOperacao_Veiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parada",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinhaEnderecoId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    PontoInicial = table.Column<bool>(type: "bit", nullable: false),
                    PontoFinal = table.Column<bool>(type: "bit", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parada_LinhaEndereco_LinhaEnderecoId",
                        column: x => x.LinhaEnderecoId,
                        principalTable: "LinhaEndereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OnibusOperacao",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinhaHorarioId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    FuncionarioHorarioId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    OnibusId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Data = table.Column<DateOnly>(type: "date", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnibusOperacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnibusOperacao_FuncionarioHorario_FuncionarioHorarioId",
                        column: x => x.FuncionarioHorarioId,
                        principalTable: "FuncionarioHorario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnibusOperacao_LinhaHorario_LinhaHorarioId",
                        column: x => x.LinhaHorarioId,
                        principalTable: "LinhaHorario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnibusOperacao_Onibus_OnibusId",
                        column: x => x.OnibusId,
                        principalTable: "Onibus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LinhaTarifaAuditoria",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    LinhaTarifaId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    NumeroRestanteBilhetes = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateOnly>(type: "date", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinhaTarifaAuditoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinhaTarifaAuditoria_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LinhaTarifaAuditoria_LinhaTarifa_LinhaTarifaId",
                        column: x => x.LinhaTarifaId,
                        principalTable: "LinhaTarifa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParadaHorario",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParadaId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Horario = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Dia = table.Column<byte>(type: "tinyint", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParadaHorario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParadaHorario_Parada_ParadaId",
                        column: x => x.ParadaId,
                        principalTable: "Parada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_Cnpj",
                table: "Empresa",
                column: "Cnpj");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_Email",
                table: "Empresa",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_EnderecoId",
                table: "Empresa",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_Cep",
                table: "Endereco",
                column: "Cep");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_Codigo",
                table: "Funcionario",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_Cpf",
                table: "Funcionario",
                column: "Cpf");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_EnderecoId",
                table: "Funcionario",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_NumeroCnh",
                table: "Funcionario",
                column: "NumeroCnh");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioGaragem_FuncionarioId",
                table: "FuncionarioGaragem",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioGaragem_GaragemId",
                table: "FuncionarioGaragem",
                column: "GaragemId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioHorario_FuncionarioId",
                table: "FuncionarioHorario",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Garagem_EmpresaId",
                table: "Garagem",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Garagem_EnderecoId",
                table: "Garagem",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Linha_EmpresaId",
                table: "Linha",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_LinhaEndereco_EnderecoId",
                table: "LinhaEndereco",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_LinhaEndereco_LinhaId",
                table: "LinhaEndereco",
                column: "LinhaId");

            migrationBuilder.CreateIndex(
                name: "IX_LinhaHorario_LinhaId",
                table: "LinhaHorario",
                column: "LinhaId");

            migrationBuilder.CreateIndex(
                name: "IX_LinhaTarifa_LinhaId",
                table: "LinhaTarifa",
                column: "LinhaId");

            migrationBuilder.CreateIndex(
                name: "IX_LinhaTarifaAuditoria_FuncionarioId",
                table: "LinhaTarifaAuditoria",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_LinhaTarifaAuditoria_LinhaTarifaId",
                table: "LinhaTarifaAuditoria",
                column: "LinhaTarifaId");

            migrationBuilder.CreateIndex(
                name: "IX_Manutencao_VeiculoId",
                table: "Manutencao",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Onibus_VeiculoId",
                table: "Onibus",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_OnibusAuditoria_FuncionarioId",
                table: "OnibusAuditoria",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_OnibusAuditoria_OnibusId",
                table: "OnibusAuditoria",
                column: "OnibusId");

            migrationBuilder.CreateIndex(
                name: "IX_OnibusOperacao_FuncionarioHorarioId",
                table: "OnibusOperacao",
                column: "FuncionarioHorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_OnibusOperacao_LinhaHorarioId",
                table: "OnibusOperacao",
                column: "LinhaHorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_OnibusOperacao_OnibusId",
                table: "OnibusOperacao",
                column: "OnibusId");

            migrationBuilder.CreateIndex(
                name: "IX_Parada_LinhaEnderecoId",
                table: "Parada",
                column: "LinhaEnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_ParadaHorario_ParadaId",
                table: "ParadaHorario",
                column: "ParadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EmpresaId",
                table: "Usuario",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_Placa",
                table: "Veiculo",
                column: "Placa");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_Prefixo",
                table: "Veiculo",
                column: "Prefixo");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_Renavam",
                table: "Veiculo",
                column: "Renavam");

            migrationBuilder.CreateIndex(
                name: "IX_VeiculoGaragem_GaragemId",
                table: "VeiculoGaragem",
                column: "GaragemId");

            migrationBuilder.CreateIndex(
                name: "IX_VeiculoGaragem_VeiculoId",
                table: "VeiculoGaragem",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_VeiculoOperacao_FuncionarioHorarioId",
                table: "VeiculoOperacao",
                column: "FuncionarioHorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_VeiculoOperacao_VeiculoId",
                table: "VeiculoOperacao",
                column: "VeiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuncionarioGaragem");

            migrationBuilder.DropTable(
                name: "LinhaTarifaAuditoria");

            migrationBuilder.DropTable(
                name: "Manutencao");

            migrationBuilder.DropTable(
                name: "OnibusAuditoria");

            migrationBuilder.DropTable(
                name: "OnibusOperacao");

            migrationBuilder.DropTable(
                name: "ParadaHorario");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "VeiculoGaragem");

            migrationBuilder.DropTable(
                name: "VeiculoOperacao");

            migrationBuilder.DropTable(
                name: "LinhaTarifa");

            migrationBuilder.DropTable(
                name: "LinhaHorario");

            migrationBuilder.DropTable(
                name: "Onibus");

            migrationBuilder.DropTable(
                name: "Parada");

            migrationBuilder.DropTable(
                name: "Garagem");

            migrationBuilder.DropTable(
                name: "FuncionarioHorario");

            migrationBuilder.DropTable(
                name: "Veiculo");

            migrationBuilder.DropTable(
                name: "LinhaEndereco");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Linha");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
