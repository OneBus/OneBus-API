using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTypeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Empresa_EmpresaId",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "Usuario",
                newName: "TipoUsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_EmpresaId",
                table: "Usuario",
                newName: "IX_Usuario_TipoUsuarioId");

            migrationBuilder.CreateTable(
                name: "Funcionalidade",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<byte>(type: "tinyint", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionalidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoUsuario_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuarioFuncionalidade",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoUsuarioId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    FuncionalidadeId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    TemPermissao = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuarioFuncionalidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoUsuarioFuncionalidade_Funcionalidade_FuncionalidadeId",
                        column: x => x.FuncionalidadeId,
                        principalTable: "Funcionalidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TipoUsuarioFuncionalidade_TipoUsuario_TipoUsuarioId",
                        column: x => x.TipoUsuarioId,
                        principalTable: "TipoUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionalidade_Codigo",
                table: "Funcionalidade",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionalidade_Descricao",
                table: "Funcionalidade",
                column: "Descricao");

            migrationBuilder.CreateIndex(
                name: "IX_TipoUsuario_EmpresaId",
                table: "TipoUsuario",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoUsuarioFuncionalidade_FuncionalidadeId",
                table: "TipoUsuarioFuncionalidade",
                column: "FuncionalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoUsuarioFuncionalidade_TipoUsuarioId",
                table: "TipoUsuarioFuncionalidade",
                column: "TipoUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_TipoUsuario_TipoUsuarioId",
                table: "Usuario",
                column: "TipoUsuarioId",
                principalTable: "TipoUsuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_TipoUsuario_TipoUsuarioId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "TipoUsuarioFuncionalidade");

            migrationBuilder.DropTable(
                name: "Funcionalidade");

            migrationBuilder.DropTable(
                name: "TipoUsuario");

            migrationBuilder.RenameColumn(
                name: "TipoUsuarioId",
                table: "Usuario",
                newName: "EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_TipoUsuarioId",
                table: "Usuario",
                newName: "IX_Usuario_EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Empresa_EmpresaId",
                table: "Usuario",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
