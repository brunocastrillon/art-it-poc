using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD.Infra.Data.Migrations
{
    public partial class migrationinicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    CodigoCliente = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RazaoSocial = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    NomeFantasia = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    TipoPessoa = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    Documento = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    Endereco = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    Complemento = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    Bairro = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    Cidade = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    CEP = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    UF = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    DataInsercao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UsuarioInsercao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.CodigoCliente);
                });

            migrationBuilder.CreateTable(
                name: "TiposTelefones",
                columns: table => new
                {
                    CodigoTipoTelefone = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DescricaoTipoTelefone = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    DataInsercao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UsuarioInsercao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposTelefones", x => x.CodigoTipoTelefone);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    CodigoCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    NumeroTelefone = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    CodigoTipoTelefone = table.Column<int>(type: "INTEGER", nullable: false),
                    Operadora = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataInsercao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UsuarioInsercao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => new { x.CodigoCliente, x.NumeroTelefone });
                    table.ForeignKey(
                        name: "FK_Telefones_Clientes_CodigoCliente",
                        column: x => x.CodigoCliente,
                        principalTable: "Clientes",
                        principalColumn: "CodigoCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Telefones_TiposTelefones_CodigoTipoTelefone",
                        column: x => x.CodigoTipoTelefone,
                        principalTable: "TiposTelefones",
                        principalColumn: "CodigoTipoTelefone",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_CodigoTipoTelefone",
                table: "Telefones",
                column: "CodigoTipoTelefone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "TiposTelefones");
        }
    }
}
