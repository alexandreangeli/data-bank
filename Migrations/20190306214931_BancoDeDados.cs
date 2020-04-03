using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Databank.Migrations
{
    public partial class BancoDeDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Codigo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Sigla = table.Column<string>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PessoaFisica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    CPF = table.Column<string>(nullable: false),
                    RG = table.Column<string>(nullable: false),
                    OrgaoExpedidor = table.Column<string>(nullable: false),
                    DataNascimento = table.Column<string>(maxLength: 10, nullable: false),
                    Genero = table.Column<string>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Rua = table.Column<string>(nullable: false),
                    NumeroEndereco = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(nullable: false),
                    Complemento = table.Column<string>(nullable: true),
                    Observacao = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: false),
                    Cidade = table.Column<string>(nullable: false),
                    UF = table.Column<string>(nullable: false),
                    Pais = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaFisica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PessoaJuridica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    CNPJ = table.Column<string>(nullable: false),
                    NumeroMunicipal = table.Column<string>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Rua = table.Column<string>(nullable: false),
                    NumeroEndereco = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(nullable: false),
                    Complemento = table.Column<string>(nullable: true),
                    Observacao = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: false),
                    Cidade = table.Column<string>(nullable: false),
                    UF = table.Column<string>(nullable: false),
                    Pais = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaJuridica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agencia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PessoaJuridicaForeignKey = table.Column<int>(nullable: false),
                    BancoId = table.Column<int>(nullable: false),
                    Codigo = table.Column<int>(nullable: false),
                    DigitoVerificador = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agencia_Banco_BancoId",
                        column: x => x.BancoId,
                        principalTable: "Banco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agencia_PessoaJuridica_PessoaJuridicaForeignKey",
                        column: x => x.PessoaJuridicaForeignKey,
                        principalTable: "PessoaJuridica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Filial",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmpresaId = table.Column<int>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    NumeroRegistroNaJuntaComercial = table.Column<long>(nullable: false),
                    PessoaJuridicaForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filial_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Filial_PessoaJuridica_PessoaJuridicaForeignKey",
                        column: x => x.PessoaJuridicaForeignKey,
                        principalTable: "PessoaJuridica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContaCorrente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BancoId = table.Column<int>(nullable: true),
                    AgenciaId = table.Column<int>(nullable: false),
                    FilialId = table.Column<int>(nullable: true),
                    DataDeAbertura = table.Column<DateTime>(nullable: false),
                    DataDeEncerramento = table.Column<DateTime>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    NumeroDaConta = table.Column<long>(nullable: false),
                    DigitoVerificadorCC = table.Column<string>(maxLength: 2, nullable: false),
                    Saldo = table.Column<double>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaCorrente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContaCorrente_Agencia_AgenciaId",
                        column: x => x.AgenciaId,
                        principalTable: "Agencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContaCorrente_Banco_BancoId",
                        column: x => x.BancoId,
                        principalTable: "Banco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContaCorrente_Filial_FilialId",
                        column: x => x.FilialId,
                        principalTable: "Filial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmpresaId = table.Column<int>(nullable: true),
                    FilialId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Celular = table.Column<long>(nullable: false),
                    Senha = table.Column<string>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    PessoaFisicaForeignKey = table.Column<int>(nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Usuario_Filial_FilialId",
                        column: x => x.FilialId,
                        principalTable: "Filial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_PessoaFisica_PessoaFisicaForeignKey",
                        column: x => x.PessoaFisicaForeignKey,
                        principalTable: "PessoaFisica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovimentoBancario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContaCorrenteId = table.Column<int>(nullable: false),
                    Usuario = table.Column<string>(nullable: true),
                    Valor = table.Column<double>(nullable: false),
                    Tipo = table.Column<string>(nullable: false),
                    Cheque = table.Column<bool>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    TransferenciaGetId = table.Column<int>(nullable: true),
                    TransferenciaSendId = table.Column<int>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentoBancario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimentoBancario_ContaCorrente_ContaCorrenteId",
                        column: x => x.ContaCorrenteId,
                        principalTable: "ContaCorrente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovimentoBancario_ContaCorrente_TransferenciaGetId",
                        column: x => x.TransferenciaGetId,
                        principalTable: "ContaCorrente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimentoBancario_ContaCorrente_TransferenciaSendId",
                        column: x => x.TransferenciaSendId,
                        principalTable: "ContaCorrente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostoDeCaixa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FilialId = table.Column<int>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false),
                    ContaCorrenteId = table.Column<int>(nullable: true),
                    CodigoDoPosto = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostoDeCaixa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostoDeCaixa_ContaCorrente_ContaCorrenteId",
                        column: x => x.ContaCorrenteId,
                        principalTable: "ContaCorrente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostoDeCaixa_Filial_FilialId",
                        column: x => x.FilialId,
                        principalTable: "Filial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostoDeCaixa_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agencia_BancoId",
                table: "Agencia",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_Agencia_PessoaJuridicaForeignKey",
                table: "Agencia",
                column: "PessoaJuridicaForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContaCorrente_AgenciaId",
                table: "ContaCorrente",
                column: "AgenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_ContaCorrente_BancoId",
                table: "ContaCorrente",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_ContaCorrente_FilialId",
                table: "ContaCorrente",
                column: "FilialId");

            migrationBuilder.CreateIndex(
                name: "IX_Filial_EmpresaId",
                table: "Filial",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Filial_PessoaJuridicaForeignKey",
                table: "Filial",
                column: "PessoaJuridicaForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovimentoBancario_ContaCorrenteId",
                table: "MovimentoBancario",
                column: "ContaCorrenteId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentoBancario_TransferenciaGetId",
                table: "MovimentoBancario",
                column: "TransferenciaGetId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentoBancario_TransferenciaSendId",
                table: "MovimentoBancario",
                column: "TransferenciaSendId");

            migrationBuilder.CreateIndex(
                name: "IX_PostoDeCaixa_ContaCorrenteId",
                table: "PostoDeCaixa",
                column: "ContaCorrenteId");

            migrationBuilder.CreateIndex(
                name: "IX_PostoDeCaixa_FilialId",
                table: "PostoDeCaixa",
                column: "FilialId");

            migrationBuilder.CreateIndex(
                name: "IX_PostoDeCaixa_UsuarioId",
                table: "PostoDeCaixa",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EmpresaId",
                table: "Usuario",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_FilialId",
                table: "Usuario",
                column: "FilialId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PessoaFisicaForeignKey",
                table: "Usuario",
                column: "PessoaFisicaForeignKey",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimentoBancario");

            migrationBuilder.DropTable(
                name: "PostoDeCaixa");

            migrationBuilder.DropTable(
                name: "ContaCorrente");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Agencia");

            migrationBuilder.DropTable(
                name: "Filial");

            migrationBuilder.DropTable(
                name: "PessoaFisica");

            migrationBuilder.DropTable(
                name: "Banco");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "PessoaJuridica");
        }
    }
}
