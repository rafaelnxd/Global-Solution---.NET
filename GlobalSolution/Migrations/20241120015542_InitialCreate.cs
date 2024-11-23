using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalSolution.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USUARIO_TD",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    TIPO_CONTA = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    DATA_REGISTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO_TD", x => x.ID_USUARIO);
                });

            migrationBuilder.CreateTable(
                name: "ALERTAS_NOTIFICACOES",
                columns: table => new
                {
                    ID_ALERTA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TIPO_ALERTA = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    MENSAGEM = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    DATA_HORA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALERTAS_NOTIFICACOES", x => x.ID_ALERTA);
                    table.ForeignKey(
                        name: "FK_ALERTAS_NOTIFICACOES_USUARIO_TD_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "USUARIO_TD",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DISPOSITIVOS",
                columns: table => new
                {
                    ID_DISPOSITIVO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME_DISPOSITIVO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    TIPO_DISPOSITIVO = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    LOCALIZACAO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    ID_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DISPOSITIVOS", x => x.ID_DISPOSITIVO);
                    table.ForeignKey(
                        name: "FK_DISPOSITIVOS_USUARIO_TD_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "USUARIO_TD",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RELATORIOS",
                columns: table => new
                {
                    ID_RELATORIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TIPO_RELATORIO = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    DATA_GERACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    RESUMO_CONSUMO = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RELATORIOS", x => x.ID_RELATORIO);
                    table.ForeignKey(
                        name: "FK_RELATORIOS_USUARIO_TD_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "USUARIO_TD",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CONFIGURACOES_AUTOMACAO",
                columns: table => new
                {
                    ID_CONFIGURACAO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_DISPOSITIVO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CONDICAO_ATIVACAO = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    ACAO = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONFIGURACOES_AUTOMACAO", x => x.ID_CONFIGURACAO);
                    table.ForeignKey(
                        name: "FK_CONFIGURACOES_AUTOMACAO_DISPOSITIVOS_ID_DISPOSITIVO",
                        column: x => x.ID_DISPOSITIVO,
                        principalTable: "DISPOSITIVOS",
                        principalColumn: "ID_DISPOSITIVO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CONFIGURACOES_AUTOMACAO_USUARIO_TD_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "USUARIO_TD",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CONSUMO_ENERGIA",
                columns: table => new
                {
                    ID_CONSUMO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_DISPOSITIVO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DATA_HORA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CONSUMO_ENERGIA_KWH = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    STATUS = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONSUMO_ENERGIA", x => x.ID_CONSUMO);
                    table.ForeignKey(
                        name: "FK_CONSUMO_ENERGIA_DISPOSITIVOS_ID_DISPOSITIVO",
                        column: x => x.ID_DISPOSITIVO,
                        principalTable: "DISPOSITIVOS",
                        principalColumn: "ID_DISPOSITIVO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALERTAS_NOTIFICACOES_ID_USUARIO",
                table: "ALERTAS_NOTIFICACOES",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_CONFIGURACOES_AUTOMACAO_ID_DISPOSITIVO",
                table: "CONFIGURACOES_AUTOMACAO",
                column: "ID_DISPOSITIVO");

            migrationBuilder.CreateIndex(
                name: "IX_CONFIGURACOES_AUTOMACAO_ID_USUARIO",
                table: "CONFIGURACOES_AUTOMACAO",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_CONSUMO_ENERGIA_ID_DISPOSITIVO",
                table: "CONSUMO_ENERGIA",
                column: "ID_DISPOSITIVO");

            migrationBuilder.CreateIndex(
                name: "IX_DISPOSITIVOS_ID_USUARIO",
                table: "DISPOSITIVOS",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_RELATORIOS_ID_USUARIO",
                table: "RELATORIOS",
                column: "ID_USUARIO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ALERTAS_NOTIFICACOES");

            migrationBuilder.DropTable(
                name: "CONFIGURACOES_AUTOMACAO");

            migrationBuilder.DropTable(
                name: "CONSUMO_ENERGIA");

            migrationBuilder.DropTable(
                name: "RELATORIOS");

            migrationBuilder.DropTable(
                name: "DISPOSITIVOS");

            migrationBuilder.DropTable(
                name: "USUARIO_TD");
        }
    }
}
